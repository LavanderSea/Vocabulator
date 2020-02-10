using System;
using System.Windows.Forms;
using VocabulatorLibrary;
using VocabulatorLibrary.Dictionaries;

namespace Vocabulator
{
    public partial class StartWindowForm : Form
    {
        private string _inputPath;
        private string _outputPath;
        public StartWindowForm() => InitializeComponent();

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

        private void StartButton_Click(object sender, EventArgs e)
        {
            Hide();
            var userFacade = new UserFacade(new DictionaryClient(new ResponseParser()));
            var window = new WindowForm(userFacade, Show, _inputPath, _outputPath);
            window.Show();
        }
    }
}