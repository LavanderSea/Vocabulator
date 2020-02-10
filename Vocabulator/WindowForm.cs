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
        private readonly List<Word> _resultsWords;
        private readonly UserFacade _userFacade;
        private string _inputPath;
        private string _outputPath;
        private WordDto _wordDto;
        private IEnumerator<IDto> _words;

        public WindowForm(UserFacade userFacade)
        {
            _userFacade = userFacade;
            _resultsWords = new List<Word>();
            InitializeComponent();
        }

        private void ToMenuButton_Click(object sender, EventArgs e)
        {
            _userFacade.CreateResultFile(_resultsWords, _outputPath);
            wordPanel.Visible = false;
            startPanel.Visible = true;
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

            Clear();
            ChangeSelectedWord();
        }

        private void ChangeSelectedWord()
        {
            _words.MoveNext();

            if (_words.Current == null)
            {
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
            Examples.Items.Clear();
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

        private void InputFileSelectButton_Click(object sender, EventArgs e)
        {
            using (var dialog = openFileDialog)
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                _inputPath = dialog.FileName;
            }

            OutputFileSelectButton.Enabled = true;
        }

        private void OutputFileSelectButton_Click(object sender, EventArgs e)
        {
            using (var dialog = saveFileDialog)
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;
                _outputPath = dialog.FileName;
            }

            StartButton.Enabled = true;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            startPanel.Visible = false;
            wordPanel.Visible = true;

            _words = _userFacade.GetDtoCollection(File.ReadLines(_inputPath)).GetEnumerator();
            ChangeSelectedWord();
        }

        private void Definitions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Definitions.SelectedItem == null)
                return;

            Definition.Text = Definitions.SelectedItem.ToString();
            LoadOtherFields(Definitions.SelectedIndex);
        }
    }
}