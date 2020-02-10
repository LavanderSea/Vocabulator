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
            this.Definitions = new System.Windows.Forms.ListBox();
            this.DefinitionsButton = new System.Windows.Forms.Button();
            this.Examples = new System.Windows.Forms.ListBox();
            this.DefinitionsTitle = new System.Windows.Forms.Label();
            this.TranscriptionTitle = new System.Windows.Forms.Label();
            this.PartOfSpeechTitle = new System.Windows.Forms.Label();
            this.ExamplesTitle = new System.Windows.Forms.Label();
            this.Definition = new System.Windows.Forms.Label();
            this.Word = new System.Windows.Forms.Label();
            this.NextButton = new System.Windows.Forms.Button();
            this.Transcription = new System.Windows.Forms.Label();
            this.PartOfSpeech = new System.Windows.Forms.Label();
            this.ToMenuButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Definitions
            // 
            this.Definitions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Definitions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Definitions.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.Definitions.FormattingEnabled = true;
            this.Definitions.HorizontalScrollbar = true;
            this.Definitions.ItemHeight = 17;
            this.Definitions.Location = new System.Drawing.Point(11, 97);
            this.Definitions.Name = "Definitions";
            this.Definitions.Size = new System.Drawing.Size(215, 306);
            this.Definitions.TabIndex = 1;
            // 
            // DefinitionsButton
            // 
            this.DefinitionsButton.BackColor = System.Drawing.Color.Turquoise;
            this.DefinitionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DefinitionsButton.Font = new System.Drawing.Font("Copperplate Gothic Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefinitionsButton.Location = new System.Drawing.Point(11, 416);
            this.DefinitionsButton.Name = "DefinitionsButton";
            this.DefinitionsButton.Size = new System.Drawing.Size(129, 36);
            this.DefinitionsButton.TabIndex = 2;
            this.DefinitionsButton.Text = "Accept";
            this.DefinitionsButton.UseVisualStyleBackColor = false;
            this.DefinitionsButton.Click += new System.EventHandler(this.DefinitionsButton_Click);
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
            this.Examples.Location = new System.Drawing.Point(474, 97);
            this.Examples.Name = "Examples";
            this.Examples.Size = new System.Drawing.Size(305, 306);
            this.Examples.TabIndex = 5;
            this.Examples.Tag = "afterDefinitionItemsTag";
            // 
            // DefinitionsTitle
            // 
            this.DefinitionsTitle.AutoSize = true;
            this.DefinitionsTitle.Location = new System.Drawing.Point(9, 78);
            this.DefinitionsTitle.Name = "DefinitionsTitle";
            this.DefinitionsTitle.Size = new System.Drawing.Size(78, 19);
            this.DefinitionsTitle.TabIndex = 6;
            this.DefinitionsTitle.Text = "Definitions";
            // 
            // TranscriptionTitle
            // 
            this.TranscriptionTitle.AutoSize = true;
            this.TranscriptionTitle.Location = new System.Drawing.Point(266, 158);
            this.TranscriptionTitle.Name = "TranscriptionTitle";
            this.TranscriptionTitle.Size = new System.Drawing.Size(91, 19);
            this.TranscriptionTitle.TabIndex = 7;
            this.TranscriptionTitle.Text = "Transcription";
            // 
            // PartOfSpeechTitle
            // 
            this.PartOfSpeechTitle.AutoSize = true;
            this.PartOfSpeechTitle.Location = new System.Drawing.Point(266, 78);
            this.PartOfSpeechTitle.Name = "PartOfSpeechTitle";
            this.PartOfSpeechTitle.Size = new System.Drawing.Size(98, 19);
            this.PartOfSpeechTitle.TabIndex = 8;
            this.PartOfSpeechTitle.Text = "Part of speech";
            // 
            // ExamplesTitle
            // 
            this.ExamplesTitle.AutoSize = true;
            this.ExamplesTitle.BackColor = System.Drawing.Color.LavenderBlush;
            this.ExamplesTitle.Location = new System.Drawing.Point(471, 78);
            this.ExamplesTitle.Name = "ExamplesTitle";
            this.ExamplesTitle.Size = new System.Drawing.Size(67, 19);
            this.ExamplesTitle.TabIndex = 9;
            this.ExamplesTitle.Text = "Examples";
            // 
            // Definition
            // 
            this.Definition.AutoSize = true;
            this.Definition.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Definition.Location = new System.Drawing.Point(266, 36);
            this.Definition.Name = "Definition";
            this.Definition.Size = new System.Drawing.Size(72, 19);
            this.Definition.TabIndex = 10;
            this.Definition.Tag = "afterDefinitionItemsTag";
            this.Definition.Text = "Definition";
            // 
            // Word
            // 
            this.Word.AutoSize = true;
            this.Word.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Word.Location = new System.Drawing.Point(7, 8);
            this.Word.Name = "Word";
            this.Word.Size = new System.Drawing.Size(62, 26);
            this.Word.TabIndex = 11;
            this.Word.Text = "Word";
            // 
            // NextButton
            // 
            this.NextButton.BackColor = System.Drawing.Color.Turquoise;
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NextButton.Font = new System.Drawing.Font("Copperplate Gothic Light", 7.8F);
            this.NextButton.Location = new System.Drawing.Point(475, 416);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(122, 36);
            this.NextButton.TabIndex = 12;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = false;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // Transcription
            // 
            this.Transcription.AutoSize = true;
            this.Transcription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Transcription.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.Transcription.Location = new System.Drawing.Point(266, 176);
            this.Transcription.Name = "Transcription";
            this.Transcription.Size = new System.Drawing.Size(87, 19);
            this.Transcription.TabIndex = 13;
            this.Transcription.Tag = "afterDefinitionItemsTag";
            this.Transcription.Text = "Transcription";
            // 
            // PartOfSpeech
            // 
            this.PartOfSpeech.AutoSize = true;
            this.PartOfSpeech.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.PartOfSpeech.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartOfSpeech.Location = new System.Drawing.Point(266, 96);
            this.PartOfSpeech.Name = "PartOfSpeech";
            this.PartOfSpeech.Size = new System.Drawing.Size(92, 19);
            this.PartOfSpeech.TabIndex = 14;
            this.PartOfSpeech.Tag = "afterDefinitionItemsTag";
            this.PartOfSpeech.Text = "PartOfSpeech";
            // 
            // ToMenuButton
            // 
            this.ToMenuButton.BackColor = System.Drawing.Color.Turquoise;
            this.ToMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ToMenuButton.Font = new System.Drawing.Font("Copperplate Gothic Light", 7.8F);
            this.ToMenuButton.Location = new System.Drawing.Point(657, 416);
            this.ToMenuButton.Name = "ToMenuButton";
            this.ToMenuButton.Size = new System.Drawing.Size(122, 36);
            this.ToMenuButton.TabIndex = 18;
            this.ToMenuButton.Text = "To menu";
            this.ToMenuButton.UseVisualStyleBackColor = false;
            this.ToMenuButton.Click += new System.EventHandler(this.ToMenuButton_Click);
            // 
            // WindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(800, 478);
            this.Controls.Add(this.PartOfSpeech);
            this.Controls.Add(this.Word);
            this.Controls.Add(this.Transcription);
            this.Controls.Add(this.DefinitionsTitle);
            this.Controls.Add(this.ExamplesTitle);
            this.Controls.Add(this.DefinitionsButton);
            this.Controls.Add(this.TranscriptionTitle);
            this.Controls.Add(this.Definitions);
            this.Controls.Add(this.Definition);
            this.Controls.Add(this.ToMenuButton);
            this.Controls.Add(this.Examples);
            this.Controls.Add(this.PartOfSpeechTitle);
            this.Controls.Add(this.NextButton);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "WindowForm";
            this.ShowIcon = false;
            this.Text = "Vocabulator";
            this.Load += new System.EventHandler(this.WindowForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox Definitions;
        private System.Windows.Forms.Button DefinitionsButton;
        private System.Windows.Forms.ListBox Examples;
        private System.Windows.Forms.Label DefinitionsTitle;
        private System.Windows.Forms.Label TranscriptionTitle;
        private System.Windows.Forms.Label PartOfSpeechTitle;
        private System.Windows.Forms.Label ExamplesTitle;
        private System.Windows.Forms.Label Definition;
        private System.Windows.Forms.Label Word;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Label Transcription;
        private System.Windows.Forms.Label PartOfSpeech;
        private System.Windows.Forms.Button ToMenuButton;
    }
}

