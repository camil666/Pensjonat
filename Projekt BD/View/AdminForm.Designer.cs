namespace Projekt_BD.View
{
    partial class AdminForm
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
            this.ActionsGroupBox = new System.Windows.Forms.GroupBox();
            this.ChangeEmployeeDetailsButton = new System.Windows.Forms.Button();
            this.DeleteEmployeeButton = new System.Windows.Forms.Button();
            this.AddEmployeeButton = new System.Windows.Forms.Button();
            this.SearchGroupBox = new System.Windows.Forms.GroupBox();
            this.SearchResultsDataGridView = new System.Windows.Forms.DataGridView();
            this.SearchButton = new System.Windows.Forms.Button();
            this.EmailSearchTextBox = new System.Windows.Forms.TextBox();
            this.EmailSearchLabel = new System.Windows.Forms.Label();
            this.LoginSearchTextBox = new System.Windows.Forms.TextBox();
            this.LoginSearchLabel = new System.Windows.Forms.Label();
            this.IDSearchTextBox = new System.Windows.Forms.TextBox();
            this.IDSearchLabel = new System.Windows.Forms.Label();
            this.LastNameSearchTextBox = new System.Windows.Forms.TextBox();
            this.LastNameSearchLabel = new System.Windows.Forms.Label();
            this.FirstNameSearchTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameSearchLabel = new System.Windows.Forms.Label();
            this.ActionsGroupBox.SuspendLayout();
            this.SearchGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchResultsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ActionsGroupBox
            // 
            this.ActionsGroupBox.Controls.Add(this.ChangeEmployeeDetailsButton);
            this.ActionsGroupBox.Controls.Add(this.DeleteEmployeeButton);
            this.ActionsGroupBox.Controls.Add(this.AddEmployeeButton);
            this.ActionsGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.ActionsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.ActionsGroupBox.Name = "ActionsGroupBox";
            this.ActionsGroupBox.Size = new System.Drawing.Size(200, 562);
            this.ActionsGroupBox.TabIndex = 1;
            this.ActionsGroupBox.TabStop = false;
            this.ActionsGroupBox.Text = "Akcje predefiniowane";
            // 
            // ChangeEmployeeDetailsButton
            // 
            this.ChangeEmployeeDetailsButton.Location = new System.Drawing.Point(12, 93);
            this.ChangeEmployeeDetailsButton.Name = "ChangeEmployeeDetailsButton";
            this.ChangeEmployeeDetailsButton.Size = new System.Drawing.Size(180, 23);
            this.ChangeEmployeeDetailsButton.TabIndex = 2;
            this.ChangeEmployeeDetailsButton.Text = "Modyfikuj dane pracownika...";
            this.ChangeEmployeeDetailsButton.UseVisualStyleBackColor = true;
            // 
            // DeleteEmployeeButton
            // 
            this.DeleteEmployeeButton.Location = new System.Drawing.Point(12, 64);
            this.DeleteEmployeeButton.Name = "DeleteEmployeeButton";
            this.DeleteEmployeeButton.Size = new System.Drawing.Size(180, 23);
            this.DeleteEmployeeButton.TabIndex = 1;
            this.DeleteEmployeeButton.Text = "Usuń pracownika";
            this.DeleteEmployeeButton.UseVisualStyleBackColor = true;
            // 
            // AddEmployeeButton
            // 
            this.AddEmployeeButton.Location = new System.Drawing.Point(12, 35);
            this.AddEmployeeButton.Name = "AddEmployeeButton";
            this.AddEmployeeButton.Size = new System.Drawing.Size(180, 23);
            this.AddEmployeeButton.TabIndex = 0;
            this.AddEmployeeButton.Text = "Dodaj pracownika...";
            this.AddEmployeeButton.UseVisualStyleBackColor = true;
            // 
            // SearchGroupBox
            // 
            this.SearchGroupBox.Controls.Add(this.SearchResultsDataGridView);
            this.SearchGroupBox.Controls.Add(this.SearchButton);
            this.SearchGroupBox.Controls.Add(this.EmailSearchTextBox);
            this.SearchGroupBox.Controls.Add(this.EmailSearchLabel);
            this.SearchGroupBox.Controls.Add(this.LoginSearchTextBox);
            this.SearchGroupBox.Controls.Add(this.LoginSearchLabel);
            this.SearchGroupBox.Controls.Add(this.IDSearchTextBox);
            this.SearchGroupBox.Controls.Add(this.IDSearchLabel);
            this.SearchGroupBox.Controls.Add(this.LastNameSearchTextBox);
            this.SearchGroupBox.Controls.Add(this.LastNameSearchLabel);
            this.SearchGroupBox.Controls.Add(this.FirstNameSearchTextBox);
            this.SearchGroupBox.Controls.Add(this.FirstNameSearchLabel);
            this.SearchGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchGroupBox.Location = new System.Drawing.Point(200, 0);
            this.SearchGroupBox.Name = "SearchGroupBox";
            this.SearchGroupBox.Size = new System.Drawing.Size(584, 562);
            this.SearchGroupBox.TabIndex = 2;
            this.SearchGroupBox.TabStop = false;
            this.SearchGroupBox.Text = "Wyszukiwanie";
            // 
            // SearchResultsDataGridView
            // 
            this.SearchResultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SearchResultsDataGridView.Location = new System.Drawing.Point(266, 16);
            this.SearchResultsDataGridView.Name = "SearchResultsDataGridView";
            this.SearchResultsDataGridView.Size = new System.Drawing.Size(306, 534);
            this.SearchResultsDataGridView.TabIndex = 75;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(77, 205);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(100, 23);
            this.SearchButton.TabIndex = 74;
            this.SearchButton.Text = "Wyszukaj";
            this.SearchButton.UseVisualStyleBackColor = true;
            // 
            // EmailSearchTextBox
            // 
            this.EmailSearchTextBox.Location = new System.Drawing.Point(77, 139);
            this.EmailSearchTextBox.Name = "EmailSearchTextBox";
            this.EmailSearchTextBox.Size = new System.Drawing.Size(120, 20);
            this.EmailSearchTextBox.TabIndex = 73;
            // 
            // EmailSearchLabel
            // 
            this.EmailSearchLabel.AutoSize = true;
            this.EmailSearchLabel.Location = new System.Drawing.Point(11, 142);
            this.EmailSearchLabel.Name = "EmailSearchLabel";
            this.EmailSearchLabel.Size = new System.Drawing.Size(38, 13);
            this.EmailSearchLabel.TabIndex = 72;
            this.EmailSearchLabel.Text = "E-mail:";
            // 
            // LoginSearchTextBox
            // 
            this.LoginSearchTextBox.Location = new System.Drawing.Point(77, 113);
            this.LoginSearchTextBox.Name = "LoginSearchTextBox";
            this.LoginSearchTextBox.Size = new System.Drawing.Size(120, 20);
            this.LoginSearchTextBox.TabIndex = 71;
            // 
            // LoginSearchLabel
            // 
            this.LoginSearchLabel.AutoSize = true;
            this.LoginSearchLabel.Location = new System.Drawing.Point(11, 116);
            this.LoginSearchLabel.Name = "LoginSearchLabel";
            this.LoginSearchLabel.Size = new System.Drawing.Size(36, 13);
            this.LoginSearchLabel.TabIndex = 70;
            this.LoginSearchLabel.Text = "Login:";
            // 
            // IDSearchTextBox
            // 
            this.IDSearchTextBox.Location = new System.Drawing.Point(77, 35);
            this.IDSearchTextBox.Name = "IDSearchTextBox";
            this.IDSearchTextBox.Size = new System.Drawing.Size(120, 20);
            this.IDSearchTextBox.TabIndex = 68;
            // 
            // IDSearchLabel
            // 
            this.IDSearchLabel.AutoSize = true;
            this.IDSearchLabel.Location = new System.Drawing.Point(11, 38);
            this.IDSearchLabel.Name = "IDSearchLabel";
            this.IDSearchLabel.Size = new System.Drawing.Size(21, 13);
            this.IDSearchLabel.TabIndex = 67;
            this.IDSearchLabel.Text = "ID:";
            // 
            // LastNameSearchTextBox
            // 
            this.LastNameSearchTextBox.Location = new System.Drawing.Point(77, 87);
            this.LastNameSearchTextBox.Name = "LastNameSearchTextBox";
            this.LastNameSearchTextBox.Size = new System.Drawing.Size(120, 20);
            this.LastNameSearchTextBox.TabIndex = 66;
            // 
            // LastNameSearchLabel
            // 
            this.LastNameSearchLabel.AutoSize = true;
            this.LastNameSearchLabel.Location = new System.Drawing.Point(11, 90);
            this.LastNameSearchLabel.Name = "LastNameSearchLabel";
            this.LastNameSearchLabel.Size = new System.Drawing.Size(56, 13);
            this.LastNameSearchLabel.TabIndex = 65;
            this.LastNameSearchLabel.Text = "Nazwisko:";
            // 
            // FirstNameSearchTextBox
            // 
            this.FirstNameSearchTextBox.Location = new System.Drawing.Point(77, 61);
            this.FirstNameSearchTextBox.Name = "FirstNameSearchTextBox";
            this.FirstNameSearchTextBox.Size = new System.Drawing.Size(120, 20);
            this.FirstNameSearchTextBox.TabIndex = 64;
            // 
            // FirstNameSearchLabel
            // 
            this.FirstNameSearchLabel.AutoSize = true;
            this.FirstNameSearchLabel.Location = new System.Drawing.Point(11, 64);
            this.FirstNameSearchLabel.Name = "FirstNameSearchLabel";
            this.FirstNameSearchLabel.Size = new System.Drawing.Size(29, 13);
            this.FirstNameSearchLabel.TabIndex = 63;
            this.FirstNameSearchLabel.Text = "Imię:";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.SearchGroupBox);
            this.Controls.Add(this.ActionsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AdminForm";
            this.Text = "Moduł Administratora";
            this.ActionsGroupBox.ResumeLayout(false);
            this.SearchGroupBox.ResumeLayout(false);
            this.SearchGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchResultsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ActionsGroupBox;
        private System.Windows.Forms.GroupBox SearchGroupBox;
        private System.Windows.Forms.Label IDSearchLabel;
        private System.Windows.Forms.Label LastNameSearchLabel;
        private System.Windows.Forms.Label FirstNameSearchLabel;
        private System.Windows.Forms.Label EmailSearchLabel;
        private System.Windows.Forms.Label LoginSearchLabel;
        public System.Windows.Forms.Button ChangeEmployeeDetailsButton;
        public System.Windows.Forms.Button DeleteEmployeeButton;
        public System.Windows.Forms.Button AddEmployeeButton;
        public System.Windows.Forms.TextBox IDSearchTextBox;
        public System.Windows.Forms.TextBox LastNameSearchTextBox;
        public System.Windows.Forms.TextBox FirstNameSearchTextBox;
        public System.Windows.Forms.TextBox EmailSearchTextBox;
        public System.Windows.Forms.TextBox LoginSearchTextBox;
        public System.Windows.Forms.Button SearchButton;
        public System.Windows.Forms.DataGridView SearchResultsDataGridView;
    }
}