namespace Projekt_BD.View
{
    partial class LoginForm
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
            this.LoginButton = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(100, 127);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(90, 23);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "Zaloguj";
            this.LoginButton.UseVisualStyleBackColor = true;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(129, 72);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(143, 20);
            this.PasswordTextBox.TabIndex = 1;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(129, 39);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(143, 20);
            this.LoginTextBox.TabIndex = 2;
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Location = new System.Drawing.Point(13, 42);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(36, 13);
            this.LoginLabel.TabIndex = 3;
            this.LoginLabel.Text = "Login:";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(12, 75);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Password:";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 162);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.LoginButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.Text = "Logowanie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label PasswordLabel;
        public System.Windows.Forms.Button LoginButton;
        public System.Windows.Forms.TextBox PasswordTextBox;
        public System.Windows.Forms.TextBox LoginTextBox;
    }
}

