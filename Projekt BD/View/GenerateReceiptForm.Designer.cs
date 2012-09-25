namespace Projekt_BD.View
{
    partial class GenerateReceiptForm
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
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.RoomsToBeReservedLabel = new System.Windows.Forms.Label();
            this.GenerateForGridView = new System.Windows.Forms.DataGridView();
            this.RemoveGuestFromReceiptButton = new System.Windows.Forms.Button();
            this.AddGuestToReceiptButton = new System.Windows.Forms.Button();
            this.GuestsDataGridView = new System.Windows.Forms.DataGridView();
            this.FreeRoomsLabel = new System.Windows.Forms.Label();
            this.EndDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.StartDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GenerateForGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuestsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(730, 274);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 57;
            this.OkButton.Text = "Generuj";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(608, 274);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 56;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // RoomsToBeReservedLabel
            // 
            this.RoomsToBeReservedLabel.AutoSize = true;
            this.RoomsToBeReservedLabel.Location = new System.Drawing.Point(434, 88);
            this.RoomsToBeReservedLabel.Name = "RoomsToBeReservedLabel";
            this.RoomsToBeReservedLabel.Size = new System.Drawing.Size(78, 13);
            this.RoomsToBeReservedLabel.TabIndex = 63;
            this.RoomsToBeReservedLabel.Text = "Wygeneruj dla:";
            // 
            // GenerateForGridView
            // 
            this.GenerateForGridView.AllowUserToAddRows = false;
            this.GenerateForGridView.AllowUserToDeleteRows = false;
            this.GenerateForGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GenerateForGridView.Location = new System.Drawing.Point(437, 104);
            this.GenerateForGridView.Name = "GenerateForGridView";
            this.GenerateForGridView.ReadOnly = true;
            this.GenerateForGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GenerateForGridView.Size = new System.Drawing.Size(368, 150);
            this.GenerateForGridView.TabIndex = 62;
            this.GenerateForGridView.TabStop = false;
            // 
            // RemoveGuestFromReceiptButton
            // 
            this.RemoveGuestFromReceiptButton.Location = new System.Drawing.Point(389, 173);
            this.RemoveGuestFromReceiptButton.Name = "RemoveGuestFromReceiptButton";
            this.RemoveGuestFromReceiptButton.Size = new System.Drawing.Size(42, 23);
            this.RemoveGuestFromReceiptButton.TabIndex = 55;
            this.RemoveGuestFromReceiptButton.Text = "<-";
            this.RemoveGuestFromReceiptButton.UseVisualStyleBackColor = true;
            // 
            // AddGuestToReceiptButton
            // 
            this.AddGuestToReceiptButton.Location = new System.Drawing.Point(389, 144);
            this.AddGuestToReceiptButton.Name = "AddGuestToReceiptButton";
            this.AddGuestToReceiptButton.Size = new System.Drawing.Size(42, 23);
            this.AddGuestToReceiptButton.TabIndex = 54;
            this.AddGuestToReceiptButton.Text = "->";
            this.AddGuestToReceiptButton.UseVisualStyleBackColor = true;
            // 
            // GuestsDataGridView
            // 
            this.GuestsDataGridView.AllowUserToAddRows = false;
            this.GuestsDataGridView.AllowUserToDeleteRows = false;
            this.GuestsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GuestsDataGridView.Location = new System.Drawing.Point(15, 104);
            this.GuestsDataGridView.Name = "GuestsDataGridView";
            this.GuestsDataGridView.ReadOnly = true;
            this.GuestsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GuestsDataGridView.Size = new System.Drawing.Size(368, 150);
            this.GuestsDataGridView.TabIndex = 61;
            this.GuestsDataGridView.TabStop = false;
            // 
            // FreeRoomsLabel
            // 
            this.FreeRoomsLabel.AutoSize = true;
            this.FreeRoomsLabel.Location = new System.Drawing.Point(12, 88);
            this.FreeRoomsLabel.Name = "FreeRoomsLabel";
            this.FreeRoomsLabel.Size = new System.Drawing.Size(43, 13);
            this.FreeRoomsLabel.TabIndex = 60;
            this.FreeRoomsLabel.Text = "Goście:";
            // 
            // EndDateDateTimePicker
            // 
            this.EndDateDateTimePicker.Enabled = false;
            this.EndDateDateTimePicker.Location = new System.Drawing.Point(114, 46);
            this.EndDateDateTimePicker.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.EndDateDateTimePicker.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.EndDateDateTimePicker.Name = "EndDateDateTimePicker";
            this.EndDateDateTimePicker.Size = new System.Drawing.Size(249, 20);
            this.EndDateDateTimePicker.TabIndex = 50;
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(12, 49);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(96, 13);
            this.EndDateLabel.TabIndex = 59;
            this.EndDateLabel.Text = "Data zakończenia:";
            // 
            // StartDateDateTimePicker
            // 
            this.StartDateDateTimePicker.Enabled = false;
            this.StartDateDateTimePicker.Location = new System.Drawing.Point(114, 6);
            this.StartDateDateTimePicker.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.StartDateDateTimePicker.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.StartDateDateTimePicker.Name = "StartDateDateTimePicker";
            this.StartDateDateTimePicker.Size = new System.Drawing.Size(249, 20);
            this.StartDateDateTimePicker.TabIndex = 49;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(12, 9);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(93, 13);
            this.StartDateLabel.TabIndex = 58;
            this.StartDateLabel.Text = "Data rozpoczęcia:";
            // 
            // GenerateReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 311);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.RoomsToBeReservedLabel);
            this.Controls.Add(this.GenerateForGridView);
            this.Controls.Add(this.RemoveGuestFromReceiptButton);
            this.Controls.Add(this.AddGuestToReceiptButton);
            this.Controls.Add(this.GuestsDataGridView);
            this.Controls.Add(this.FreeRoomsLabel);
            this.Controls.Add(this.EndDateDateTimePicker);
            this.Controls.Add(this.EndDateLabel);
            this.Controls.Add(this.StartDateDateTimePicker);
            this.Controls.Add(this.StartDateLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GenerateReceiptForm";
            this.Text = "Wystawianie rachunku";
            ((System.ComponentModel.ISupportInitialize)(this.GenerateForGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuestsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button OkButton;
        public System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label RoomsToBeReservedLabel;
        public System.Windows.Forms.DataGridView GenerateForGridView;
        public System.Windows.Forms.Button RemoveGuestFromReceiptButton;
        public System.Windows.Forms.Button AddGuestToReceiptButton;
        public System.Windows.Forms.DataGridView GuestsDataGridView;
        private System.Windows.Forms.Label FreeRoomsLabel;
        public System.Windows.Forms.DateTimePicker EndDateDateTimePicker;
        private System.Windows.Forms.Label EndDateLabel;
        public System.Windows.Forms.DateTimePicker StartDateDateTimePicker;
        private System.Windows.Forms.Label StartDateLabel;
    }
}