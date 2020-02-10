using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Vocabulator.Properties;

namespace Vocabulator
{
    public partial class StartWindowForm : Form
    {
        public StartWindowForm() => InitializeComponent();

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
                var path = dialog.FileName;
                if (File.Exists(path))
                {
                    var result = MessageBox.Show(
                        Resources.WarningMessageText,
                        Resources.WarningTitle,
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.OK)
                        _outputPath = path;
                }
            }

            StartButton.Enabled = true;
        }

        private void ColorSelectButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new ColorDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                _selectedColor = dialog.Color;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Hide();
            var userFacade = UserFacade.Create(_inputPath, _outputPath, _selectedColor);
            var window = new WindowForm(userFacade, Show);
            window.Show();
        }

        private string _inputPath;
        private string _outputPath;
        private Color _selectedColor;
    }
}