using System;
using System.Linq;
using System.Windows.Forms;
using Vocabulator.Models;
using Vocabulator.Properties;

namespace Vocabulator
{
    public partial class WindowForm : Form
    {
        public WindowForm(UserFacade userFacade, Action showMenu)
        {
            _userFacade = userFacade;
            _showMenu = showMenu;
            InitializeComponent();
        }

        private void DefinitionsButton_Click(object sender, EventArgs e)
        {
            if (_isAcceptButtonActive)
            {
                if (Definitions.SelectedItem == null)
                    return;
                Definition.Text = Definitions.SelectedItem.ToString();
                LoadOtherFields(Definitions.SelectedIndex);
            }

            _isAcceptButtonActive = !_isAcceptButtonActive;
            SwapButton(_isAcceptButtonActive);
        }

        private void ToMenuButton_Click(object sender, EventArgs e)
        {
            _showMenu();
            Close();
        }

        private void SwapButton(bool isSwapToAccept)
        {
            Definitions.SelectionMode = isSwapToAccept ? SelectionMode.One : SelectionMode.None;
            DefinitionsButton.Text = isSwapToAccept ? "Accept" : "Back";
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (Examples.SelectedItem == null && Examples.Items.Count > 0)
                return;

            if(_wordModel != null) 
            {
                _wordModel.IsProcessed = true;
                _userFacade.SaveWord(new Word(
                    Word.Text,
                    PartOfSpeech.Text,
                    Transcription.Text,
                    Definition.Text,
                    Examples.SelectedItem?.ToString() ?? string.Empty));
            }
           
            _isAcceptButtonActive = true;
            Clear();
            SwapButton(true);
            ChangeSelectedWord();
        }

        private void ChangeSelectedWord()
        {
            var word = _userFacade.ReadNextWord();
            
            if (string.IsNullOrEmpty(word))
            {
                MessageBox.Show(
                    Resources.ReadingWordEndText, 
                    Resources.ReadingWordEndCaption, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Asterisk);
                _showMenu();
                Close();
                return;
            }

            Word.Text = word.ToValidFormat();
            NecessaryPartOfSpeech.Text = word.GetPartOfSpeech();

            var model = _userFacade.GetWordModel(Word.Text);
            if (model.IsStatusSuccess)
            {
                _wordModel = model as WordModel;
                var definitions = _wordModel?.Results
                                      .Select(result => result.Definition).ToArray() ?? Array.Empty<object>();
                Definitions.Items.AddRange(definitions);
            }
            else
            {
                _wordModel = null;
                Word.Text += @": " + ((ErrorModel)model).Message;
            }
        }

        private void LoadOtherFields(int index)
        {
            var result = _wordModel.Results.ToArray()[index];
            var examples = result.Examples?.ToArray() ?? Array.Empty<object>();

            PartOfSpeech.Text = result.PartOfSpeech;
            Transcription.Text = _wordModel.Pronunciation;
            Examples.Items.AddRange(examples);
        }

        private void Clear()
        {
            Definition.Text = string.Empty;
            Word.Text = string.Empty;
            Transcription.Text = string.Empty;
            PartOfSpeech.Text = string.Empty;
            NecessaryPartOfSpeech.Text = string.Empty;
            Definitions.Items.Clear();
            Examples.Items.Clear();
        }

        private void WindowForm_FormClosing(object sender, FormClosingEventArgs e) => _userFacade.Dispose();
        private void WindowForm_Load(object sender, EventArgs e) => ChangeSelectedWord();

        private bool _isAcceptButtonActive = true;
        private WordModel _wordModel;
        private readonly UserFacade _userFacade;
        private readonly Action _showMenu;
    }
}