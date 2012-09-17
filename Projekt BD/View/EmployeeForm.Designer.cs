namespace Projekt_BD.View
{
    partial class EmployeeForm
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
            this.TasksDataGridView = new System.Windows.Forms.DataGridView();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.ShowDoneTasksCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TasksDataGridView
            // 
            this.TasksDataGridView.AllowUserToAddRows = false;
            this.TasksDataGridView.AllowUserToDeleteRows = false;
            this.TasksDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TasksDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TasksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TasksDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TasksDataGridView.Location = new System.Drawing.Point(0, 0);
            this.TasksDataGridView.MultiSelect = false;
            this.TasksDataGridView.Name = "TasksDataGridView";
            this.TasksDataGridView.Size = new System.Drawing.Size(544, 198);
            this.TasksDataGridView.TabIndex = 0;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(457, 227);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Zapisz";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(12, 227);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(160, 23);
            this.LoadButton.TabIndex = 2;
            this.LoadButton.Text = "Wczytaj niewykonane zadania";
            this.LoadButton.UseVisualStyleBackColor = true;
            // 
            // ShowDoneTasksCheckBox
            // 
            this.ShowDoneTasksCheckBox.AutoSize = true;
            this.ShowDoneTasksCheckBox.Location = new System.Drawing.Point(12, 204);
            this.ShowDoneTasksCheckBox.Name = "ShowDoneTasksCheckBox";
            this.ShowDoneTasksCheckBox.Size = new System.Drawing.Size(168, 17);
            this.ShowDoneTasksCheckBox.TabIndex = 3;
            this.ShowDoneTasksCheckBox.Text = "Wyświetlaj wykonane zadania";
            this.ShowDoneTasksCheckBox.UseVisualStyleBackColor = true;
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 262);
            this.Controls.Add(this.ShowDoneTasksCheckBox);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.TasksDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EmployeeForm";
            this.Text = "Moduł Pracownika";
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView TasksDataGridView;
        public System.Windows.Forms.Button SaveButton;
        public System.Windows.Forms.Button LoadButton;
        public System.Windows.Forms.CheckBox ShowDoneTasksCheckBox;
    }
}