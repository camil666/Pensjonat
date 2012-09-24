namespace Projekt_BD.View
{
    partial class EditServiceForVisitForm
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
            this.ServicesDataGridView = new System.Windows.Forms.DataGridView();
            this.AddServiceButton = new System.Windows.Forms.Button();
            this.EditServiceButton = new System.Windows.Forms.Button();
            this.DeleteServicesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ServicesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(202, 290);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // ServicesDataGridView
            // 
            this.ServicesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServicesDataGridView.Location = new System.Drawing.Point(12, 46);
            this.ServicesDataGridView.Name = "ServicesDataGridView";
            this.ServicesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ServicesDataGridView.Size = new System.Drawing.Size(452, 233);
            this.ServicesDataGridView.TabIndex = 2;
            // 
            // AddServiceButton
            // 
            this.AddServiceButton.Location = new System.Drawing.Point(13, 13);
            this.AddServiceButton.Name = "AddServiceButton";
            this.AddServiceButton.Size = new System.Drawing.Size(75, 23);
            this.AddServiceButton.TabIndex = 3;
            this.AddServiceButton.Text = "Dodaj";
            this.AddServiceButton.UseVisualStyleBackColor = true;
            // 
            // EditServiceButton
            // 
            this.EditServiceButton.Location = new System.Drawing.Point(95, 13);
            this.EditServiceButton.Name = "EditServiceButton";
            this.EditServiceButton.Size = new System.Drawing.Size(75, 23);
            this.EditServiceButton.TabIndex = 4;
            this.EditServiceButton.Text = "Edytuj";
            this.EditServiceButton.UseVisualStyleBackColor = true;
            // 
            // DeleteServicesButton
            // 
            this.DeleteServicesButton.Location = new System.Drawing.Point(177, 13);
            this.DeleteServicesButton.Name = "DeleteServicesButton";
            this.DeleteServicesButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteServicesButton.TabIndex = 5;
            this.DeleteServicesButton.Text = "Usuń";
            this.DeleteServicesButton.UseVisualStyleBackColor = true;
            // 
            // EditServiceForVisitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 325);
            this.Controls.Add(this.DeleteServicesButton);
            this.Controls.Add(this.EditServiceButton);
            this.Controls.Add(this.AddServiceButton);
            this.Controls.Add(this.ServicesDataGridView);
            this.Controls.Add(this.OkButton);
            this.Name = "EditServiceForVisitForm";
            this.Text = "Edytuj usługi";
            ((System.ComponentModel.ISupportInitialize)(this.ServicesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button OkButton;
        public System.Windows.Forms.DataGridView ServicesDataGridView;
        public System.Windows.Forms.Button AddServiceButton;
        public System.Windows.Forms.Button EditServiceButton;
        public System.Windows.Forms.Button DeleteServicesButton;
    }
}