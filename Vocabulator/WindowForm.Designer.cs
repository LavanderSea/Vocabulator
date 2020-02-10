namespace Vocabulator
{
    partial class WindowForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.wordPanel = new System.Windows.Forms.Panel();
            this.PartOfSpeech = new System.Windows.Forms.Label();
            this.Word = new System.Windows.Forms.Label();
            this.Transcription = new System.Windows.Forms.Label();
            this.DefinitionsTitle = new System.Windows.Forms.Label();
            this.ExamplesTitle = new System.Windows.Forms.Label();
            this.TranscriptionTitle = new System.Windows.Forms.Label();
            this.Definitions = new System.Windows.Forms.ListBox();
            this.Definition = new System.Windows.Forms.Label();
            this.ToMenuButton = new System.Windows.Forms.Button();
            this.Examples = new System.Windows.Forms.ListBox();
            this.PartOfSpeechTitle = new System.Windows.Forms.Label();
            this.NextButton = new System.Windows.Forms.Button();
            this.startPanel = new System.Windows.Forms.Panel();
            this.OutputFileSelectButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.InputFileSelectButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.wordPanel.SuspendLayout();
            this.startPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // wordPanel
            // 
            this.wordPanel.Controls.Add(this.PartOfSpeech);
            this.wordPanel.Controls.Add(this.Word);
            this.wordPanel.Controls.Add(this.Transcription);
            this.wordPanel.Controls.Add(this.DefinitionsTitle);
            this.wordPanel.Controls.Add(this.ExamplesTitle);
            this.wordPanel.Controls.Add(this.TranscriptionTitle);
            this.wordPanel.Controls.Add(this.Definitions);
            this.wordPanel.Controls.Add(this.Definition);
            this.wordPanel.Controls.Add(this.ToMenuButton);
            this.wordPanel.Controls.Add(this.Examples);
            this.wordPanel.Controls.Add(this.PartOfSpeechTitle);
            this.wordPanel.Controls.Add(this.NextButton);
            this.wordPanel.Location = new System.Drawing.Point(12, 12);
            this.wordPanel.Name = "wordPanel";
            this.wordPanel.Size = new System.Drawing.Size(776, 454);
            this.wordPanel.TabIndex = 0;
            this.wordPanel.Visible = false;
            // 
            // PartOfSpeech
            // 
            this.PartOfSpeech.AutoSize = true;
            this.PartOfSpeech.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.PartOfSpeech.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartOfSpeech.Location = new System.Drawing.Point(261, 93);
            this.PartOfSpeech.Name = "PartOfSpeech";
            this.PartOfSpeech.Size = new System.Drawing.Size(92, 19);
            this.PartOfSpeech.TabIndex = 30;
            this.PartOfSpeech.Tag = "afterDefinitionItemsTag";
            this.PartOfSpeech.Text = "PartOfSpeech";
            // 
            // Word
            // 
            this.Word.AutoSize = true;
            this.Word.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Word.Location = new System.Drawing.Point(2, 5);
            this.Word.Name = "Word";
            this.Word.Size = new System.Drawing.Size(62, 26);
            this.Word.TabIndex = 27;
            this.Word.Text = "Word";
            // 
            // Transcription
            // 
            this.Transcription.AutoSize = true;
            this.Transcription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Transcription.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.Transcription.Location = new System.Drawing.Point(261, 173);
            this.Transcription.Name = "Transcription";
            this.Transcription.Size = new System.Drawing.Size(87, 19);
            this.Transcription.TabIndex = 29;
            this.Transcription.Tag = "afterDefinitionItemsTag";
            this.Transcription.Text = "Transcription";
            // 
            // DefinitionsTitle
            // 
            this.DefinitionsTitle.AutoSize = true;
            this.DefinitionsTitle.Location = new System.Drawing.Point(4, 75);
            this.DefinitionsTitle.Name = "DefinitionsTitle";
            this.DefinitionsTitle.Size = new System.Drawing.Size(78, 19);
            this.DefinitionsTitle.TabIndex = 22;
            this.DefinitionsTitle.Text = "Definitions";
            // 
            // ExamplesTitle
            // 
            this.ExamplesTitle.AutoSize = true;
            this.ExamplesTitle.BackColor = System.Drawing.Color.LavenderBlush;
            this.ExamplesTitle.Location = new System.Drawing.Point(466, 75);
            this.ExamplesTitle.Name = "ExamplesTitle";
            this.ExamplesTitle.Size = new System.Drawing.Size(67, 19);
            this.ExamplesTitle.TabIndex = 25;
            this.ExamplesTitle.Text = "Examples";
            // 
            // TranscriptionTitle
            // 
            this.TranscriptionTitle.AutoSize = true;
            this.TranscriptionTitle.Location = new System.Drawing.Point(261, 155);
            this.TranscriptionTitle.Name = "TranscriptionTitle";
            this.TranscriptionTitle.Size = new System.Drawing.Size(91, 19);
            this.TranscriptionTitle.TabIndex = 23;
            this.TranscriptionTitle.Text = "Transcription";
            // 
            // Definitions
            // 
            this.Definitions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Definitions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Definitions.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.Definitions.FormattingEnabled = true;
            this.Definitions.HorizontalScrollbar = true;
            this.Definitions.ItemHeight = 17;
            this.Definitions.Location = new System.Drawing.Point(6, 94);
            this.Definitions.Name = "Definitions";
            this.Definitions.Size = new System.Drawing.Size(215, 306);
            this.Definitions.TabIndex = 19;
            this.Definitions.SelectedIndexChanged += new System.EventHandler(this.Definitions_SelectedIndexChanged);
            // 
            // Definition
            // 
            this.Definition.AutoSize = true;
            this.Definition.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Definition.Location = new System.Drawing.Point(261, 33);
            this.Definition.Name = "Definition";
            this.Definition.Size = new System.Drawing.Size(72, 19);
            this.Definition.TabIndex = 26;
            this.Definition.Tag = "afterDefinitionItemsTag";
            this.Definition.Text = "Definition";
            // 
            // ToMenuButton
            // 
            this.ToMenuButton.BackColor = System.Drawing.Color.Turquoise;
            this.ToMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ToMenuButton.Font = new System.Drawing.Font("Copperplate Gothic Light", 7.8F);
            this.ToMenuButton.Location = new System.Drawing.Point(652, 413);
            this.ToMenuButton.Name = "ToMenuButton";
            this.ToMenuButton.Size = new System.Drawing.Size(122, 36);
            this.ToMenuButton.TabIndex = 31;
            this.ToMenuButton.Text = "To menu";
            this.ToMenuButton.UseVisualStyleBackColor = false;
            this.ToMenuButton.Click += new System.EventHandler(this.ToMenuButton_Click);
            // 
            // Examples
            // 
            this.Examples.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Examples.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Examples.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.Examples.ForeColor = System.Drawing.Color.Black;
            this.Examples.FormattingEnabled = true;
            this.Examples.HorizontalScrollbar = true;
            this.Examples.ItemHeight = 17;
            this.Examples.Location = new System.Drawing.Point(469, 94);
            this.Examples.Name = "Examples";
            this.Examples.Size = new System.Drawing.Size(305, 306);
            this.Examples.TabIndex = 21;
            this.Examples.Tag = "afterDefinitionItemsTag";
            // 
            // PartOfSpeechTitle
            // 
            this.PartOfSpeechTitle.AutoSize = true;
            this.PartOfSpeechTitle.Location = new System.Drawing.Point(261, 75);
            this.PartOfSpeechTitle.Name = "PartOfSpeechTitle";
            this.PartOfSpeechTitle.Size = new System.Drawing.Size(98, 19);
            this.PartOfSpeechTitle.TabIndex = 24;
            this.PartOfSpeechTitle.Text = "Part of speech";
            // 
            // NextButton
            // 
            this.NextButton.BackColor = System.Drawing.Color.Turquoise;
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NextButton.Font = new System.Drawing.Font("Copperplate Gothic Light", 7.8F);
            this.NextButton.Location = new System.Drawing.Point(470, 413);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(122, 36);
            this.NextButton.TabIndex = 28;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = false;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // startPanel
            // 
            this.startPanel.BackColor = System.Drawing.Color.LavenderBlush;
            this.startPanel.Controls.Add(this.OutputFileSelectButton);
            this.startPanel.Controls.Add(this.StartButton);
            this.startPanel.Controls.Add(this.InputFileSelectButton);
            this.startPanel.Location = new System.Drawing.Point(239, 12);
            this.startPanel.Name = "startPanel";
            this.startPanel.Size = new System.Drawing.Size(236, 467);
            this.startPanel.TabIndex = 1;
            // 
            // OutputFileSelectButton
            // 
            this.OutputFileSelectButton.BackColor = System.Drawing.Color.Thistle;
            this.OutputFileSelectButton.Enabled = false;
            this.OutputFileSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OutputFileSelectButton.Font = new System.Drawing.Font("Copperplate Gothic Light", 7.8F);
            this.OutputFileSelectButton.Location = new System.Drawing.Point(38, 220);
            this.OutputFileSelectButton.Name = "OutputFileSelectButton";
            this.OutputFileSelectButton.Size = new System.Drawing.Size(160, 26);
            this.OutputFileSelectButton.TabIndex = 5;
            this.OutputFileSelectButton.Text = "Select output ";
            this.OutputFileSelectButton.UseVisualStyleBackColor = false;
            this.OutputFileSelectButton.Click += new System.EventHandler(this.OutputFileSelectButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.Thistle;
            this.StartButton.Enabled = false;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartButton.Font = new System.Drawing.Font("Copperplate Gothic Light", 7.8F);
            this.StartButton.Location = new System.Drawing.Point(38, 252);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(160, 26);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // InputFileSelectButton
            // 
            this.InputFileSelectButton.BackColor = System.Drawing.Color.Thistle;
            this.InputFileSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.InputFileSelectButton.Font = new System.Drawing.Font("Copperplate Gothic Light", 7.8F);
            this.InputFileSelectButton.Location = new System.Drawing.Point(38, 188);
            this.InputFileSelectButton.Name = "InputFileSelectButton";
            this.InputFileSelectButton.Size = new System.Drawing.Size(160, 26);
            this.InputFileSelectButton.TabIndex = 3;
            this.InputFileSelectButton.Text = "Select input ";
            this.InputFileSelectButton.UseVisualStyleBackColor = false;
            this.InputFileSelectButton.Click += new System.EventHandler(this.InputFileSelectButton_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "csv files|*.csv";
            this.saveFileDialog.FilterIndex = 2;
            this.saveFileDialog.OverwritePrompt = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "txt files (*.txt)|*.txt";
            this.openFileDialog.FilterIndex = 2;
            this.openFileDialog.RestoreDirectory = true;
            // 
            // WindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(800, 478);
            this.Controls.Add(this.startPanel);
            this.Controls.Add(this.wordPanel);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "WindowForm";
            this.ShowIcon = false;
            this.Text = "Vocabulator";
            this.wordPanel.ResumeLayout(false);
            this.wordPanel.PerformLayout();
            this.startPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel wordPanel;
        private System.Windows.Forms.Label PartOfSpeech;
        private System.Windows.Forms.Label Word;
        private System.Windows.Forms.Label Transcription;
        private System.Windows.Forms.Label DefinitionsTitle;
        private System.Windows.Forms.Label ExamplesTitle;
        private System.Windows.Forms.Label TranscriptionTitle;
        private System.Windows.Forms.ListBox Definitions;
        private System.Windows.Forms.Label Definition;
        private System.Windows.Forms.Button ToMenuButton;
        private System.Windows.Forms.ListBox Examples;
        private System.Windows.Forms.Label PartOfSpeechTitle;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Panel startPanel;
        private System.Windows.Forms.Button OutputFileSelectButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button InputFileSelectButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

