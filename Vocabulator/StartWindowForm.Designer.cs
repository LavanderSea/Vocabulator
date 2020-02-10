namespace Vocabulator
{
    partial class StartWindowForm
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
            this.StartButton = new System.Windows.Forms.Button();
            this.InputFileSelectButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.OutputFileSelectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.Thistle;
            this.StartButton.Enabled = false;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartButton.Font = new System.Drawing.Font("Copperplate Gothic Light", 7.8F);
            this.StartButton.Location = new System.Drawing.Point(312, 201);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(160, 26);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // InputFileSelectButton
            // 
            this.InputFileSelectButton.BackColor = System.Drawing.Color.Thistle;
            this.InputFileSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.InputFileSelectButton.Font = new System.Drawing.Font("Copperplate Gothic Light", 7.8F);
            this.InputFileSelectButton.Location = new System.Drawing.Point(312, 137);
            this.InputFileSelectButton.Name = "InputFileSelectButton";
            this.InputFileSelectButton.Size = new System.Drawing.Size(160, 26);
            this.InputFileSelectButton.TabIndex = 0;
            this.InputFileSelectButton.Text = "Select input ";
            this.InputFileSelectButton.UseVisualStyleBackColor = false;
            this.InputFileSelectButton.Click += new System.EventHandler(this.InputFileSelectButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "txt files (*.txt)|*.txt";
            this.openFileDialog.FilterIndex = 2;
            this.openFileDialog.RestoreDirectory = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "csv files|*.csv";
            this.saveFileDialog.FilterIndex = 2;
            this.saveFileDialog.OverwritePrompt = false;
            // 
            // OutputFileSelectButton
            // 
            this.OutputFileSelectButton.BackColor = System.Drawing.Color.Thistle;
            this.OutputFileSelectButton.Enabled = false;
            this.OutputFileSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OutputFileSelectButton.Font = new System.Drawing.Font("Copperplate Gothic Light", 7.8F);
            this.OutputFileSelectButton.Location = new System.Drawing.Point(312, 169);
            this.OutputFileSelectButton.Name = "OutputFileSelectButton";
            this.OutputFileSelectButton.Size = new System.Drawing.Size(160, 26);
            this.OutputFileSelectButton.TabIndex = 2;
            this.OutputFileSelectButton.Text = "Select output ";
            this.OutputFileSelectButton.UseVisualStyleBackColor = false;
            this.OutputFileSelectButton.Click += new System.EventHandler(this.OutputFileSelectButton_Click);
            // 
            // StartWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(802, 453);
            this.Controls.Add(this.OutputFileSelectButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.InputFileSelectButton);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "StartWindowForm";
            this.ShowIcon = false;
            this.Text = "Vocabulator";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button InputFileSelectButton;
        private System.Windows.Forms.Button OutputFileSelectButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

