namespace BoothCampStudentCourseApp.UI
{
    partial class MainUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.enrollButton = new System.Windows.Forms.Button();
            this.enterResultButton = new System.Windows.Forms.Button();
            this.showResultSheetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // enrollButton
            // 
            this.enrollButton.Location = new System.Drawing.Point(78, 34);
            this.enrollButton.Name = "enrollButton";
            this.enrollButton.Size = new System.Drawing.Size(185, 55);
            this.enrollButton.TabIndex = 0;
            this.enrollButton.Text = "Enroll";
            this.enrollButton.UseVisualStyleBackColor = true;
            this.enrollButton.Click += new System.EventHandler(this.enrollButton_Click);
            // 
            // enterResultButton
            // 
            this.enterResultButton.Location = new System.Drawing.Point(78, 114);
            this.enterResultButton.Name = "enterResultButton";
            this.enterResultButton.Size = new System.Drawing.Size(185, 56);
            this.enterResultButton.TabIndex = 1;
            this.enterResultButton.Text = "Enter Result";
            this.enterResultButton.UseVisualStyleBackColor = true;
            this.enterResultButton.Click += new System.EventHandler(this.enterResultButton_Click);
            // 
            // showResultSheetButton
            // 
            this.showResultSheetButton.Location = new System.Drawing.Point(78, 194);
            this.showResultSheetButton.Name = "showResultSheetButton";
            this.showResultSheetButton.Size = new System.Drawing.Size(185, 50);
            this.showResultSheetButton.TabIndex = 2;
            this.showResultSheetButton.Text = "Show Result Sheet";
            this.showResultSheetButton.UseVisualStyleBackColor = true;
            this.showResultSheetButton.Click += new System.EventHandler(this.showResultSheetButton_Click);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 305);
            this.Controls.Add(this.showResultSheetButton);
            this.Controls.Add(this.enterResultButton);
            this.Controls.Add(this.enrollButton);
            this.Name = "MainUI";
            this.Text = "MainUI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button enrollButton;
        private System.Windows.Forms.Button enterResultButton;
        private System.Windows.Forms.Button showResultSheetButton;
    }
}