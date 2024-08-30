namespace TrainingManagerBuilder
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblSourcePath = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            txtSourcePath = new TextBox();
            btnBrowse = new Button();
            SuspendLayout();
            // 
            // lblSourcePath
            // 
            lblSourcePath.AutoSize = true;
            lblSourcePath.Location = new Point(12, 39);
            lblSourcePath.Name = "lblSourcePath";
            lblSourcePath.Size = new Size(228, 15);
            lblSourcePath.TabIndex = 0;
            lblSourcePath.Text = "Path to /source/ that contains the .sln file:";
            lblSourcePath.Click += label1_Click;
            // 
            // txtSourcePath
            // 
            txtSourcePath.Location = new Point(246, 31);
            txtSourcePath.Name = "txtSourcePath";
            txtSourcePath.Size = new Size(316, 23);
            txtSourcePath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(568, 31);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(75, 23);
            btnBrowse.TabIndex = 2;
            btnBrowse.Text = "Browse...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBrowse);
            Controls.Add(txtSourcePath);
            Controls.Add(lblSourcePath);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSourcePath;
        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox txtSourcePath;
        private Button btnBrowse;
    }
}
