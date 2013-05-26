namespace C_Sharp_Kursovoi_3_kurs
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.UrlInput = new System.Windows.Forms.TextBox();
			this.StartButton = new System.Windows.Forms.Button();
			this.LogInput = new System.Windows.Forms.TextBox();
			this.loadProgress = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// UrlInput
			// 
			this.UrlInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.UrlInput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.UrlInput.Location = new System.Drawing.Point(12, 12);
			this.UrlInput.Name = "UrlInput";
			this.UrlInput.Size = new System.Drawing.Size(617, 20);
			this.UrlInput.TabIndex = 0;
			this.UrlInput.Text = "http://chevrolet-aveo.ru/showthread.php?t=%(861-863)%#%(01/06/2013-05/06/2013)%";
			// 
			// StartButton
			// 
			this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.StartButton.Location = new System.Drawing.Point(635, 10);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(75, 23);
			this.StartButton.TabIndex = 1;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// LogInput
			// 
			this.LogInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LogInput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LogInput.Location = new System.Drawing.Point(12, 57);
			this.LogInput.Multiline = true;
			this.LogInput.Name = "LogInput";
			this.LogInput.ReadOnly = true;
			this.LogInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.LogInput.Size = new System.Drawing.Size(698, 262);
			this.LogInput.TabIndex = 2;
			this.LogInput.WordWrap = false;
			// 
			// loadProgress
			// 
			this.loadProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.loadProgress.Location = new System.Drawing.Point(12, 38);
			this.loadProgress.Name = "loadProgress";
			this.loadProgress.Size = new System.Drawing.Size(698, 13);
			this.loadProgress.Step = 1;
			this.loadProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.loadProgress.TabIndex = 3;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(722, 331);
			this.Controls.Add(this.loadProgress);
			this.Controls.Add(this.LogInput);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.UrlInput);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "URL Downloader";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UrlInput;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox LogInput;
		private System.Windows.Forms.ProgressBar loadProgress;
    }
}

