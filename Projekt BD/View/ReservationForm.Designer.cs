namespace Projekt_BD.View
{
    partial class ReservationForm
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
            this.FreeRoomsDataGridView = new System.Windows.Forms.DataGridView();
            this.FreeRoomsLabel = new System.Windows.Forms.Label();
            this.EndDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.StartDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.AddToReservationButton = new System.Windows.Forms.Button();
            this.RemoveFromReservationButton = new System.Windows.Forms.Button();
            this.RoomsToBeReservedDataGridView = new System.Windows.Forms.DataGridView();
            this.RoomsToBeReservedLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.AddInfoTextBox = new System.Windows.Forms.TextBox();
            this.AddInfoLabel = new System.Windows.Forms.Label();
            this.ClientTextBox = new System.Windows.Forms.TextBox();
            this.ClientLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FreeRoomsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoomsToBeReservedDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // FreeRoomsDataGridView
            // 
            this.FreeRoomsDataGridView.AllowUserToAddRows = false;
            this.FreeRoomsDataGridView.AllowUserToDeleteRows = false;
            this.FreeRoomsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FreeRoomsDataGridView.Location = new System.Drawing.Point(15, 114);
            this.FreeRoomsDataGridView.Name = "FreeRoomsDataGridView";
            this.FreeRoomsDataGridView.ReadOnly = true;
            this.FreeRoomsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FreeRoomsDataGridView.Size = new System.Drawing.Size(368, 150);
            this.FreeRoomsDataGridView.TabIndex = 17;
            // 
            // FreeRoomsLabel
            // 
            this.FreeRoomsLabel.AutoSize = true;
            this.FreeRoomsLabel.Location = new System.Drawing.Point(12, 98);
            this.FreeRoomsLabel.Name = "FreeRoomsLabel";
            this.FreeRoomsLabel.Size = new System.Drawing.Size(76, 13);
            this.FreeRoomsLabel.TabIndex = 16;
            this.FreeRoomsLabel.Text = "Wolne pokoje:";
            // 
            // EndDateDateTimePicker
            // 
            this.EndDateDateTimePicker.Location = new System.Drawing.Point(114, 46);
            this.EndDateDateTimePicker.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.EndDateDateTimePicker.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.EndDateDateTimePicker.Name = "EndDateDateTimePicker";
            this.EndDateDateTimePicker.Size = new System.Drawing.Size(249, 20);
            this.EndDateDateTimePicker.TabIndex = 15;
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(12, 49);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(96, 13);
            this.EndDateLabel.TabIndex = 14;
            this.EndDateLabel.Text = "Data zakończenia:";
            // 
            // StartDateDateTimePicker
            // 
            this.StartDateDateTimePicker.Location = new System.Drawing.Point(114, 6);
            this.StartDateDateTimePicker.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.StartDateDateTimePicker.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.StartDateDateTimePicker.Name = "StartDateDateTimePicker";
            this.StartDateDateTimePicker.Size = new System.Drawing.Size(249, 20);
            this.StartDateDateTimePicker.TabIndex = 13;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(12, 9);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(93, 13);
            this.StartDateLabel.TabIndex = 12;
            this.StartDateLabel.Text = "Data rozpoczęcia:";
            // 
            // AddToReservationButton
            // 
            this.AddToReservationButton.Location = new System.Drawing.Point(389, 154);
            this.AddToReservationButton.Name = "AddToReservationButton";
            this.AddToReservationButton.Size = new System.Drawing.Size(42, 23);
            this.AddToReservationButton.TabIndex = 21;
            this.AddToReservationButton.Text = "->";
            this.AddToReservationButton.UseVisualStyleBackColor = true;
            // 
            // RemoveFromReservationButton
            // 
            this.RemoveFromReservationButton.Location = new System.Drawing.Point(389, 183);
            this.RemoveFromReservationButton.Name = "RemoveFromReservationButton";
            this.RemoveFromReservationButton.Size = new System.Drawing.Size(42, 23);
            this.RemoveFromReservationButton.TabIndex = 22;
            this.RemoveFromReservationButton.Text = "<-";
            this.RemoveFromReservationButton.UseVisualStyleBackColor = true;
            // 
            // RoomsToBeReservedDataGridView
            // 
            this.RoomsToBeReservedDataGridView.AllowUserToAddRows = false;
            this.RoomsToBeReservedDataGridView.AllowUserToDeleteRows = false;
            this.RoomsToBeReservedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoomsToBeReservedDataGridView.Location = new System.Drawing.Point(437, 114);
            this.RoomsToBeReservedDataGridView.Name = "RoomsToBeReservedDataGridView";
            this.RoomsToBeReservedDataGridView.ReadOnly = true;
            this.RoomsToBeReservedDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RoomsToBeReservedDataGridView.Size = new System.Drawing.Size(368, 150);
            this.RoomsToBeReservedDataGridView.TabIndex = 23;
            // 
            // RoomsToBeReservedLabel
            // 
            this.RoomsToBeReservedLabel.AutoSize = true;
            this.RoomsToBeReservedLabel.Location = new System.Drawing.Point(434, 98);
            this.RoomsToBeReservedLabel.Name = "RoomsToBeReservedLabel";
            this.RoomsToBeReservedLabel.Size = new System.Drawing.Size(74, 13);
            this.RoomsToBeReservedLabel.TabIndex = 24;
            this.RoomsToBeReservedLabel.Text = "Do rezerwacji:";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(608, 294);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 25;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(730, 294);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 26;
            this.AddButton.Text = "Dodaj";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // AddInfoTextBox
            // 
            this.AddInfoTextBox.Location = new System.Drawing.Point(556, 46);
            this.AddInfoTextBox.Name = "AddInfoTextBox";
            this.AddInfoTextBox.Size = new System.Drawing.Size(249, 20);
            this.AddInfoTextBox.TabIndex = 28;
            // 
            // AddInfoLabel
            // 
            this.AddInfoLabel.AutoSize = true;
            this.AddInfoLabel.Location = new System.Drawing.Point(434, 49);
            this.AddInfoLabel.Name = "AddInfoLabel";
            this.AddInfoLabel.Size = new System.Drawing.Size(116, 13);
            this.AddInfoLabel.TabIndex = 27;
            this.AddInfoLabel.Text = "Dodatkowe informacje:";
            // 
            // ClientTextBox
            // 
            this.ClientTextBox.Location = new System.Drawing.Point(556, 6);
            this.ClientTextBox.Name = "ClientTextBox";
            this.ClientTextBox.ReadOnly = true;
            this.ClientTextBox.Size = new System.Drawing.Size(249, 20);
            this.ClientTextBox.TabIndex = 29;
            // 
            // ClientLabel
            // 
            this.ClientLabel.AutoSize = true;
            this.ClientLabel.Location = new System.Drawing.Point(437, 8);
            this.ClientLabel.Name = "ClientLabel";
            this.ClientLabel.Size = new System.Drawing.Size(36, 13);
            this.ClientLabel.TabIndex = 30;
            this.ClientLabel.Text = "Klient:";
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 326);
            this.Controls.Add(this.ClientLabel);
            this.Controls.Add(this.ClientTextBox);
            this.Controls.Add(this.AddInfoTextBox);
            this.Controls.Add(this.AddInfoLabel);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.RoomsToBeReservedLabel);
            this.Controls.Add(this.RoomsToBeReservedDataGridView);
            this.Controls.Add(this.RemoveFromReservationButton);
            this.Controls.Add(this.AddToReservationButton);
            this.Controls.Add(this.FreeRoomsDataGridView);
            this.Controls.Add(this.FreeRoomsLabel);
            this.Controls.Add(this.EndDateDateTimePicker);
            this.Controls.Add(this.EndDateLabel);
            this.Controls.Add(this.StartDateDateTimePicker);
            this.Controls.Add(this.StartDateLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ReservationForm";
            ((System.ComponentModel.ISupportInitialize)(this.FreeRoomsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoomsToBeReservedDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FreeRoomsLabel;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.Label RoomsToBeReservedLabel;
        private System.Windows.Forms.Label AddInfoLabel;
        private System.Windows.Forms.Label ClientLabel;
        public System.Windows.Forms.DataGridView FreeRoomsDataGridView;
        public System.Windows.Forms.DateTimePicker EndDateDateTimePicker;
        public System.Windows.Forms.DateTimePicker StartDateDateTimePicker;
        public System.Windows.Forms.Button AddToReservationButton;
        public System.Windows.Forms.Button RemoveFromReservationButton;
        public System.Windows.Forms.DataGridView RoomsToBeReservedDataGridView;
        public System.Windows.Forms.Button CancelButton;
        public System.Windows.Forms.Button AddButton;
        public System.Windows.Forms.TextBox AddInfoTextBox;
        public System.Windows.Forms.TextBox ClientTextBox;
    }
}