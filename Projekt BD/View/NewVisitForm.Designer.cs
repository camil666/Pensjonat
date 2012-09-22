namespace Projekt_BD.View
{
    partial class NewVisitForm
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
            this.AddInfoTextBox = new System.Windows.Forms.TextBox();
            this.AddInfoLabel = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.RoomsToBeReservedLabel = new System.Windows.Forms.Label();
            this.GuestsToVisitDataGridView = new System.Windows.Forms.DataGridView();
            this.RemoveGuestFromVisitButton = new System.Windows.Forms.Button();
            this.AddGuestToVisitButton = new System.Windows.Forms.Button();
            this.GuestsDataGridView = new System.Windows.Forms.DataGridView();
            this.FreeRoomsLabel = new System.Windows.Forms.Label();
            this.EndDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.StartDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.AdvanceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RoomNumberComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GuestsToVisitDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuestsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // AddInfoTextBox
            // 
            this.AddInfoTextBox.Location = new System.Drawing.Point(557, 48);
            this.AddInfoTextBox.Name = "AddInfoTextBox";
            this.AddInfoTextBox.Size = new System.Drawing.Size(249, 20);
            this.AddInfoTextBox.TabIndex = 4;
            // 
            // AddInfoLabel
            // 
            this.AddInfoLabel.AutoSize = true;
            this.AddInfoLabel.Location = new System.Drawing.Point(436, 51);
            this.AddInfoLabel.Name = "AddInfoLabel";
            this.AddInfoLabel.Size = new System.Drawing.Size(116, 13);
            this.AddInfoLabel.TabIndex = 44;
            this.AddInfoLabel.Text = "Dodatkowe informacje:";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(731, 307);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 9;
            this.OkButton.Text = "Dodaj";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(609, 307);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // RoomsToBeReservedLabel
            // 
            this.RoomsToBeReservedLabel.AutoSize = true;
            this.RoomsToBeReservedLabel.Location = new System.Drawing.Point(435, 121);
            this.RoomsToBeReservedLabel.Name = "RoomsToBeReservedLabel";
            this.RoomsToBeReservedLabel.Size = new System.Drawing.Size(115, 13);
            this.RoomsToBeReservedLabel.TabIndex = 41;
            this.RoomsToBeReservedLabel.Text = "Przydzieleni do pokoju:";
            // 
            // GuestsToVisitDataGridView
            // 
            this.GuestsToVisitDataGridView.AllowUserToAddRows = false;
            this.GuestsToVisitDataGridView.AllowUserToDeleteRows = false;
            this.GuestsToVisitDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GuestsToVisitDataGridView.Location = new System.Drawing.Point(438, 137);
            this.GuestsToVisitDataGridView.Name = "GuestsToVisitDataGridView";
            this.GuestsToVisitDataGridView.ReadOnly = true;
            this.GuestsToVisitDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GuestsToVisitDataGridView.Size = new System.Drawing.Size(368, 150);
            this.GuestsToVisitDataGridView.TabIndex = 40;
            this.GuestsToVisitDataGridView.TabStop = false;
            // 
            // RemoveGuestFromVisitButton
            // 
            this.RemoveGuestFromVisitButton.Location = new System.Drawing.Point(390, 206);
            this.RemoveGuestFromVisitButton.Name = "RemoveGuestFromVisitButton";
            this.RemoveGuestFromVisitButton.Size = new System.Drawing.Size(42, 23);
            this.RemoveGuestFromVisitButton.TabIndex = 7;
            this.RemoveGuestFromVisitButton.Text = "<-";
            this.RemoveGuestFromVisitButton.UseVisualStyleBackColor = true;
            // 
            // AddGuestToVisitButton
            // 
            this.AddGuestToVisitButton.Location = new System.Drawing.Point(390, 177);
            this.AddGuestToVisitButton.Name = "AddGuestToVisitButton";
            this.AddGuestToVisitButton.Size = new System.Drawing.Size(42, 23);
            this.AddGuestToVisitButton.TabIndex = 6;
            this.AddGuestToVisitButton.Text = "->";
            this.AddGuestToVisitButton.UseVisualStyleBackColor = true;
            // 
            // GuestsDataGridView
            // 
            this.GuestsDataGridView.AllowUserToAddRows = false;
            this.GuestsDataGridView.AllowUserToDeleteRows = false;
            this.GuestsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GuestsDataGridView.Location = new System.Drawing.Point(16, 137);
            this.GuestsDataGridView.Name = "GuestsDataGridView";
            this.GuestsDataGridView.ReadOnly = true;
            this.GuestsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GuestsDataGridView.Size = new System.Drawing.Size(368, 150);
            this.GuestsDataGridView.TabIndex = 34;
            this.GuestsDataGridView.TabStop = false;
            // 
            // FreeRoomsLabel
            // 
            this.FreeRoomsLabel.AutoSize = true;
            this.FreeRoomsLabel.Location = new System.Drawing.Point(13, 121);
            this.FreeRoomsLabel.Name = "FreeRoomsLabel";
            this.FreeRoomsLabel.Size = new System.Drawing.Size(43, 13);
            this.FreeRoomsLabel.TabIndex = 33;
            this.FreeRoomsLabel.Text = "Goście:";
            // 
            // EndDateDateTimePicker
            // 
            this.EndDateDateTimePicker.Enabled = false;
            this.EndDateDateTimePicker.Location = new System.Drawing.Point(115, 48);
            this.EndDateDateTimePicker.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.EndDateDateTimePicker.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.EndDateDateTimePicker.Name = "EndDateDateTimePicker";
            this.EndDateDateTimePicker.Size = new System.Drawing.Size(249, 20);
            this.EndDateDateTimePicker.TabIndex = 2;
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(13, 51);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(96, 13);
            this.EndDateLabel.TabIndex = 31;
            this.EndDateLabel.Text = "Data zakończenia:";
            // 
            // StartDateDateTimePicker
            // 
            this.StartDateDateTimePicker.Enabled = false;
            this.StartDateDateTimePicker.Location = new System.Drawing.Point(115, 8);
            this.StartDateDateTimePicker.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.StartDateDateTimePicker.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.StartDateDateTimePicker.Name = "StartDateDateTimePicker";
            this.StartDateDateTimePicker.Size = new System.Drawing.Size(249, 20);
            this.StartDateDateTimePicker.TabIndex = 1;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(13, 11);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(93, 13);
            this.StartDateLabel.TabIndex = 29;
            this.StartDateLabel.Text = "Data rozpoczęcia:";
            // 
            // AdvanceTextBox
            // 
            this.AdvanceTextBox.Location = new System.Drawing.Point(557, 8);
            this.AdvanceTextBox.Name = "AdvanceTextBox";
            this.AdvanceTextBox.Size = new System.Drawing.Size(250, 20);
            this.AdvanceTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Zaliczka:";
            // 
            // RoomNumberComboBox
            // 
            this.RoomNumberComboBox.FormattingEnabled = true;
            this.RoomNumberComboBox.Location = new System.Drawing.Point(557, 88);
            this.RoomNumberComboBox.Name = "RoomNumberComboBox";
            this.RoomNumberComboBox.Size = new System.Drawing.Size(121, 21);
            this.RoomNumberComboBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(514, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Pokój:";
            // 
            // NewVisitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 342);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RoomNumberComboBox);
            this.Controls.Add(this.AdvanceTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddInfoTextBox);
            this.Controls.Add(this.AddInfoLabel);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.RoomsToBeReservedLabel);
            this.Controls.Add(this.GuestsToVisitDataGridView);
            this.Controls.Add(this.RemoveGuestFromVisitButton);
            this.Controls.Add(this.AddGuestToVisitButton);
            this.Controls.Add(this.GuestsDataGridView);
            this.Controls.Add(this.FreeRoomsLabel);
            this.Controls.Add(this.EndDateDateTimePicker);
            this.Controls.Add(this.EndDateLabel);
            this.Controls.Add(this.StartDateDateTimePicker);
            this.Controls.Add(this.StartDateLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewVisitForm";
            this.Text = "Nowy pobyt";
            ((System.ComponentModel.ISupportInitialize)(this.GuestsToVisitDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuestsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AddInfoLabel;
        private System.Windows.Forms.Label RoomsToBeReservedLabel;
        private System.Windows.Forms.Label FreeRoomsLabel;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.Label StartDateLabel;
        public System.Windows.Forms.TextBox AddInfoTextBox;
        public System.Windows.Forms.Button OkButton;
        public System.Windows.Forms.Button CancelButton;
        public System.Windows.Forms.DataGridView GuestsToVisitDataGridView;
        public System.Windows.Forms.Button RemoveGuestFromVisitButton;
        public System.Windows.Forms.Button AddGuestToVisitButton;
        public System.Windows.Forms.DataGridView GuestsDataGridView;
        public System.Windows.Forms.DateTimePicker EndDateDateTimePicker;
        public System.Windows.Forms.DateTimePicker StartDateDateTimePicker;
        public System.Windows.Forms.TextBox AdvanceTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox RoomNumberComboBox;
    }
}