using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VocabulatorLibrary;
using VocabulatorLibrary.Data;

namespace Vocabulator
{
    public partial class WindowForm : Form
    {
        public WindowForm(UserFacade userFacade, Action showMenu, string inputPath, string outputPath)
        {
            _userFacade = userFacade;
            _showMenu = showMenu;
            _outputPath = outputPath;
            _resultsWords = new List<Word>();
            _words = userFacade.GetDtoCollection(File.ReadLines(inputPath)).GetEnumerator();
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
            _userFacade.CreateResultFile(_resultsWords, _outputPath);
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

            if (_wordDto != null)
            {
                _wordDto.IsProcessed = true;
                _resultsWords.Add(new Word(
                    Word.Text,
                    PartOfSpeech.Text,
                    Transcription.Text,
                    Definition.Text,
                    Examples.SelectedItem?.ToString() ?? string.Empty));
            }

            _isAcceptButtonActive = true;
            Clear();
            SwapButton(true);
            _words.MoveNext();
            ChangeSelectedWord();
        }

        private void ChangeSelectedWord()
        {
            _words.MoveNext();

            if (_words.Current == null)
            {
                DefinitionsButton.Visible = false;
                NextButton.Visible = false;
                return;
            }

            var word = _words.Current;

            if (word.IsStatusSuccess)
            {
                _wordDto = word as WordDto;
                var definitions = _wordDto?.Results
                                      .Select(result => result.Definition).ToArray() ?? Array.Empty<object>();
                Definitions.Items.AddRange(definitions);
                Word.Text = _wordDto.Word;
            }
            else
            {
                _wordDto = null;
                Word.Text += ((ErrorDto) word).Message;
            }
        }

        private void LoadOtherFields(int index)
        {
            var result = _wordDto.Results.ToArray()[index];
            var examples = result.Examples?.ToArray() ?? Array.Empty<object>();

            PartOfSpeech.Text = result.PartOfSpeech;
            Transcription.Text = _wordDto.Pronunciation;
            Examples.Items.AddRange(examples);
        }

        private void Clear()
        {
            Definition.Text = string.Empty;
            Word.Text = string.Empty;
            Transcription.Text = string.Empty;
            PartOfSpeech.Text = string.Empty;
            Definitions.Items.Clear();
            Examples.Items.Clear();
        }

        private void WindowForm_Load(object sender, EventArgs e) => ChangeSelectedWord();


        private bool _isAcceptButtonActive = true;
        private WordDto _wordDto;
        private readonly UserFacade _userFacade;
        private readonly Action _showMenu;
        private readonly string _outputPath;
        private readonly IEnumerator<IDto> _words;
        private readonly List<Word> _resultsWords;
    }
}