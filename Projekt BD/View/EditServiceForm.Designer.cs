namespace Projekt_BD.View
{
    partial class EditServiceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ChargeTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Opłata";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Opis";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(68, 16);
            this.NameTextBox.MaxLength = 50;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(204, 20);
            this.NameTextBox.TabIndex = 1;
            // 
            // ChargeTextBox
            // 
            this.ChargeTextBox.Location = new System.Drawing.Point(68, 46);
            this.ChargeTextBox.Name = "ChargeTextBox";
            this.ChargeTextBox.Size = new System.Drawing.Size(204, 20);
            this.ChargeTextBox.TabIndex = 2;
            // 
            // DescriptionRichTextBox
            // 
            this.DescriptionRichTextBox.Location = new System.Drawing.Point(68, 76);
            this.DescriptionRichTextBox.MaxLength = 50;
            this.DescriptionRichTextBox.Name = "DescriptionRichTextBox";
            this.DescriptionRichTextBox.Size = new System.Drawing.Size(204, 132);
            this.DescriptionRichTextBox.TabIndex = 3;
            this.DescriptionRichTextBox.Text = "";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(25, 221);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(117, 23);
            this.OkButton.TabIndex = 4;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(148, 221);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(124, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // EditServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.DescriptionRichTextBox);
            this.Controls.Add(this.ChargeTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditServiceForm";
            this.Text = "EditServiceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox NameTextBox;
        public System.Windows.Forms.TextBox ChargeTextBox;
        public System.Windows.Forms.RichTextBox DescriptionRichTextBox;
        public System.Windows.Forms.Button OkButton;
        public System.Windows.Forms.Button CancelButton;
    }
}