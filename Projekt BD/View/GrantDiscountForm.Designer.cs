namespace Projekt_BD.View
{
    partial class GrantDiscountForm
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
            this.DiscountsDataGridView = new System.Windows.Forms.DataGridView();
            this.GrantDiscountButton = new System.Windows.Forms.Button();
            this.DiscountTextBox = new System.Windows.Forms.TextBox();
            this.DiscountLabel = new System.Windows.Forms.Label();
            this.DeleteDiscountButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DiscountsDataGridView
            // 
            this.DiscountsDataGridView.AllowUserToAddRows = false;
            this.DiscountsDataGridView.AllowUserToDeleteRows = false;
            this.DiscountsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DiscountsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DiscountsDataGridView.Location = new System.Drawing.Point(246, 12);
            this.DiscountsDataGridView.MultiSelect = false;
            this.DiscountsDataGridView.Name = "DiscountsDataGridView";
            this.DiscountsDataGridView.ReadOnly = true;
            this.DiscountsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DiscountsDataGridView.Size = new System.Drawing.Size(194, 237);
            this.DiscountsDataGridView.TabIndex = 0;
            // 
            // GrantDiscountButton
            // 
            this.GrantDiscountButton.Location = new System.Drawing.Point(61, 117);
            this.GrantDiscountButton.Name = "GrantDiscountButton";
            this.GrantDiscountButton.Size = new System.Drawing.Size(123, 23);
            this.GrantDiscountButton.TabIndex = 1;
            this.GrantDiscountButton.Text = "Przyznaj zniżkę";
            this.GrantDiscountButton.UseVisualStyleBackColor = true;
            // 
            // DiscountTextBox
            // 
            this.DiscountTextBox.Location = new System.Drawing.Point(61, 71);
            this.DiscountTextBox.Name = "DiscountTextBox";
            this.DiscountTextBox.Size = new System.Drawing.Size(122, 20);
            this.DiscountTextBox.TabIndex = 2;
            // 
            // DiscountLabel
            // 
            this.DiscountLabel.AutoSize = true;
            this.DiscountLabel.Location = new System.Drawing.Point(58, 55);
            this.DiscountLabel.Name = "DiscountLabel";
            this.DiscountLabel.Size = new System.Drawing.Size(89, 13);
            this.DiscountLabel.TabIndex = 3;
            this.DiscountLabel.Text = "Wysokość zniżki:";
            // 
            // DeleteDiscountButton
            // 
            this.DeleteDiscountButton.Location = new System.Drawing.Point(61, 171);
            this.DeleteDiscountButton.Name = "DeleteDiscountButton";
            this.DeleteDiscountButton.Size = new System.Drawing.Size(122, 23);
            this.DeleteDiscountButton.TabIndex = 4;
            this.DeleteDiscountButton.Text = "Usuń zniżkę";
            this.DeleteDiscountButton.UseVisualStyleBackColor = true;
            // 
            // GrantDiscountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 261);
            this.Controls.Add(this.DeleteDiscountButton);
            this.Controls.Add(this.DiscountLabel);
            this.Controls.Add(this.DiscountTextBox);
            this.Controls.Add(this.GrantDiscountButton);
            this.Controls.Add(this.DiscountsDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GrantDiscountForm";
            this.Text = "Przyznaj zniżkę";
            ((System.ComponentModel.ISupportInitialize)(this.DiscountsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DiscountLabel;
        public System.Windows.Forms.DataGridView DiscountsDataGridView;
        public System.Windows.Forms.Button GrantDiscountButton;
        public System.Windows.Forms.TextBox DiscountTextBox;
        public System.Windows.Forms.Button DeleteDiscountButton;
    }
}