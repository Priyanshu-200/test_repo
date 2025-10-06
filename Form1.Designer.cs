namespace TextBoxFinder
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
            lblFilePath = new Label();
            txtFilePath = new TextBox();
            btnBrowse = new Button();
            btnCheck = new Button();
            lblResult = new Label();
            SuspendLayout();
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Location = new Point(98, 64);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(119, 20);
            lblFilePath.TabIndex = 0;
            lblFilePath.Text = "Select Word File:";
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(256, 57);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(532, 27);
            txtFilePath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(306, 129);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(175, 29);
            btnBrowse.TabIndex = 2;
            btnBrowse.Text = "Browse...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnCheck
            // 
            btnCheck.Location = new Point(232, 189);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(249, 29);
            btnCheck.TabIndex = 3;
            btnCheck.Text = "Check for the Textbox";
            btnCheck.UseVisualStyleBackColor = true;
            btnCheck.Click += btnCheck_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(332, 267);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(0, 20);
            lblResult.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblResult);
            Controls.Add(btnCheck);
            Controls.Add(btnBrowse);
            Controls.Add(txtFilePath);
            Controls.Add(lblFilePath);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFilePath;
        private TextBox txtFilePath;
        private Button btnBrowse;
        private Button btnCheck;
        private Label lblResult;
    }
}
