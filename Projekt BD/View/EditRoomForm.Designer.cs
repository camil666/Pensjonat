namespace Projekt_BD.View
{
    partial class EditRoomForm
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
            this.CapacityTextBox = new System.Windows.Forms.TextBox();
            this.CapacityLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.FloorTextBox = new System.Windows.Forms.TextBox();
            this.FloorLabel = new System.Windows.Forms.Label();
            this.NumberTextBox = new System.Windows.Forms.TextBox();
            this.NumberLabel = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.FeaturesDataGridView = new System.Windows.Forms.DataGridView();
            this.FeaturesLabel = new System.Windows.Forms.Label();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.FeaturesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CapacityTextBox
            // 
            this.CapacityTextBox.Location = new System.Drawing.Point(253, 55);
            this.CapacityTextBox.Name = "CapacityTextBox";
            this.CapacityTextBox.Size = new System.Drawing.Size(120, 20);
            this.CapacityTextBox.TabIndex = 4;
            // 
            // CapacityLabel
            // 
            this.CapacityLabel.AutoSize = true;
            this.CapacityLabel.Location = new System.Drawing.Point(187, 58);
            this.CapacityLabel.Name = "CapacityLabel";
            this.CapacityLabel.Size = new System.Drawing.Size(62, 13);
            this.CapacityLabel.TabIndex = 93;
            this.CapacityLabel.Text = "Pojemność:";
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(7, 58);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(28, 13);
            this.TypeLabel.TabIndex = 91;
            this.TypeLabel.Text = "Typ:";
            // 
            // FloorTextBox
            // 
            this.FloorTextBox.Location = new System.Drawing.Point(253, 15);
            this.FloorTextBox.Name = "FloorTextBox";
            this.FloorTextBox.Size = new System.Drawing.Size(120, 20);
            this.FloorTextBox.TabIndex = 2;
            // 
            // FloorLabel
            // 
            this.FloorLabel.AutoSize = true;
            this.FloorLabel.Location = new System.Drawing.Point(187, 18);
            this.FloorLabel.Name = "FloorLabel";
            this.FloorLabel.Size = new System.Drawing.Size(37, 13);
            this.FloorLabel.TabIndex = 89;
            this.FloorLabel.Text = "Piętro:";
            // 
            // NumberTextBox
            // 
            this.NumberTextBox.Location = new System.Drawing.Point(56, 15);
            this.NumberTextBox.Name = "NumberTextBox";
            this.NumberTextBox.Size = new System.Drawing.Size(120, 20);
            this.NumberTextBox.TabIndex = 1;
            // 
            // NumberLabel
            // 
            this.NumberLabel.AutoSize = true;
            this.NumberLabel.Location = new System.Drawing.Point(7, 18);
            this.NumberLabel.Name = "NumberLabel";
            this.NumberLabel.Size = new System.Drawing.Size(41, 13);
            this.NumberLabel.TabIndex = 87;
            this.NumberLabel.Text = "Numer:";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(312, 338);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 6;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(190, 338);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // FeaturesDataGridView
            // 
            this.FeaturesDataGridView.AllowUserToAddRows = false;
            this.FeaturesDataGridView.AllowUserToDeleteRows = false;
            this.FeaturesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FeaturesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FeaturesDataGridView.Location = new System.Drawing.Point(19, 109);
            this.FeaturesDataGridView.Name = "FeaturesDataGridView";
            this.FeaturesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FeaturesDataGridView.Size = new System.Drawing.Size(368, 223);
            this.FeaturesDataGridView.TabIndex = 96;
            this.FeaturesDataGridView.TabStop = false;
            // 
            // FeaturesLabel
            // 
            this.FeaturesLabel.AutoSize = true;
            this.FeaturesLabel.Location = new System.Drawing.Point(16, 93);
            this.FeaturesLabel.Name = "FeaturesLabel";
            this.FeaturesLabel.Size = new System.Drawing.Size(76, 13);
            this.FeaturesLabel.TabIndex = 95;
            this.FeaturesLabel.Text = "Udogodnienia:";
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Location = new System.Drawing.Point(56, 54);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(120, 21);
            this.TypeComboBox.TabIndex = 3;
            // 
            // EditRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 373);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.FeaturesDataGridView);
            this.Controls.Add(this.FeaturesLabel);
            this.Controls.Add(this.CapacityTextBox);
            this.Controls.Add(this.CapacityLabel);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.FloorTextBox);
            this.Controls.Add(this.FloorLabel);
            this.Controls.Add(this.NumberTextBox);
            this.Controls.Add(this.NumberLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditRoomForm";
            ((System.ComponentModel.ISupportInitialize)(this.FeaturesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox CapacityTextBox;
        private System.Windows.Forms.Label CapacityLabel;
        private System.Windows.Forms.Label TypeLabel;
        public System.Windows.Forms.TextBox FloorTextBox;
        private System.Windows.Forms.Label FloorLabel;
        public System.Windows.Forms.TextBox NumberTextBox;
        private System.Windows.Forms.Label NumberLabel;
        public System.Windows.Forms.Button OkButton;
        public System.Windows.Forms.Button CancelButton;
        public System.Windows.Forms.DataGridView FeaturesDataGridView;
        private System.Windows.Forms.Label FeaturesLabel;
        public System.Windows.Forms.ComboBox TypeComboBox;

    }
}