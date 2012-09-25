namespace Projekt_BD.View
{
    partial class ManagerForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TasksTabPage = new System.Windows.Forms.TabPage();
            this.TasksGroupBox = new System.Windows.Forms.GroupBox();
            this.RemoveTasksButton = new System.Windows.Forms.Button();
            this.EditTaskButton = new System.Windows.Forms.Button();
            this.AddTaskButton = new System.Windows.Forms.Button();
            this.TasksDataGridView = new System.Windows.Forms.DataGridView();
            this.EmployeesGroupBox = new System.Windows.Forms.GroupBox();
            this.EmployeesDataGridView = new System.Windows.Forms.DataGridView();
            this.TaskTypesTabPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DeleteTaskTypeButton = new System.Windows.Forms.Button();
            this.EditTaskTypeButton = new System.Windows.Forms.Button();
            this.AddTaskTypeButton = new System.Windows.Forms.Button();
            this.TaskTypesDataGridView = new System.Windows.Forms.DataGridView();
            this.SettingsTabPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.AllMealsTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DinnerTextBox = new System.Windows.Forms.TextBox();
            this.LunchTextBox = new System.Windows.Forms.TextBox();
            this.BreakfastTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GetHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.TasksTabPage.SuspendLayout();
            this.TasksGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGridView)).BeginInit();
            this.EmployeesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeesDataGridView)).BeginInit();
            this.TaskTypesTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaskTypesDataGridView)).BeginInit();
            this.SettingsTabPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TasksTabPage);
            this.tabControl1.Controls.Add(this.TaskTypesTabPage);
            this.tabControl1.Controls.Add(this.SettingsTabPage);
            this.tabControl1.Location = new System.Drawing.Point(3, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(718, 378);
            this.tabControl1.TabIndex = 0;
            // 
            // TasksTabPage
            // 
            this.TasksTabPage.Controls.Add(this.TasksGroupBox);
            this.TasksTabPage.Controls.Add(this.EmployeesGroupBox);
            this.TasksTabPage.Location = new System.Drawing.Point(4, 22);
            this.TasksTabPage.Name = "TasksTabPage";
            this.TasksTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.TasksTabPage.Size = new System.Drawing.Size(710, 352);
            this.TasksTabPage.TabIndex = 0;
            this.TasksTabPage.Text = "Zadania";
            this.TasksTabPage.UseVisualStyleBackColor = true;
            // 
            // TasksGroupBox
            // 
            this.TasksGroupBox.Controls.Add(this.RemoveTasksButton);
            this.TasksGroupBox.Controls.Add(this.EditTaskButton);
            this.TasksGroupBox.Controls.Add(this.AddTaskButton);
            this.TasksGroupBox.Controls.Add(this.TasksDataGridView);
            this.TasksGroupBox.Location = new System.Drawing.Point(364, 3);
            this.TasksGroupBox.Name = "TasksGroupBox";
            this.TasksGroupBox.Size = new System.Drawing.Size(343, 370);
            this.TasksGroupBox.TabIndex = 1;
            this.TasksGroupBox.TabStop = false;
            this.TasksGroupBox.Text = "Zadania";
            // 
            // RemoveTasksButton
            // 
            this.RemoveTasksButton.Location = new System.Drawing.Point(229, 15);
            this.RemoveTasksButton.Name = "RemoveTasksButton";
            this.RemoveTasksButton.Size = new System.Drawing.Size(113, 29);
            this.RemoveTasksButton.TabIndex = 3;
            this.RemoveTasksButton.Text = "Usuń zadania";
            this.RemoveTasksButton.UseVisualStyleBackColor = true;
            // 
            // EditTaskButton
            // 
            this.EditTaskButton.Location = new System.Drawing.Point(114, 15);
            this.EditTaskButton.Name = "EditTaskButton";
            this.EditTaskButton.Size = new System.Drawing.Size(114, 29);
            this.EditTaskButton.TabIndex = 2;
            this.EditTaskButton.Text = "Edytuj zadanie";
            this.EditTaskButton.UseVisualStyleBackColor = true;
            // 
            // AddTaskButton
            // 
            this.AddTaskButton.Location = new System.Drawing.Point(3, 15);
            this.AddTaskButton.Name = "AddTaskButton";
            this.AddTaskButton.Size = new System.Drawing.Size(108, 29);
            this.AddTaskButton.TabIndex = 1;
            this.AddTaskButton.Text = "Dodaj zadanie";
            this.AddTaskButton.UseVisualStyleBackColor = true;
            // 
            // TasksDataGridView
            // 
            this.TasksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TasksDataGridView.Location = new System.Drawing.Point(3, 50);
            this.TasksDataGridView.Name = "TasksDataGridView";
            this.TasksDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TasksDataGridView.Size = new System.Drawing.Size(339, 318);
            this.TasksDataGridView.TabIndex = 0;
            // 
            // EmployeesGroupBox
            // 
            this.EmployeesGroupBox.Controls.Add(this.EmployeesDataGridView);
            this.EmployeesGroupBox.Location = new System.Drawing.Point(2, 1);
            this.EmployeesGroupBox.Name = "EmployeesGroupBox";
            this.EmployeesGroupBox.Size = new System.Drawing.Size(356, 374);
            this.EmployeesGroupBox.TabIndex = 0;
            this.EmployeesGroupBox.TabStop = false;
            this.EmployeesGroupBox.Text = "Pracownicy";
            // 
            // EmployeesDataGridView
            // 
            this.EmployeesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeesDataGridView.Location = new System.Drawing.Point(5, 17);
            this.EmployeesDataGridView.Name = "EmployeesDataGridView";
            this.EmployeesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EmployeesDataGridView.Size = new System.Drawing.Size(350, 354);
            this.EmployeesDataGridView.TabIndex = 0;
            // 
            // TaskTypesTabPage
            // 
            this.TaskTypesTabPage.Controls.Add(this.groupBox1);
            this.TaskTypesTabPage.Location = new System.Drawing.Point(4, 22);
            this.TaskTypesTabPage.Name = "TaskTypesTabPage";
            this.TaskTypesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.TaskTypesTabPage.Size = new System.Drawing.Size(710, 352);
            this.TaskTypesTabPage.TabIndex = 1;
            this.TaskTypesTabPage.Text = "Typy zadań";
            this.TaskTypesTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DeleteTaskTypeButton);
            this.groupBox1.Controls.Add(this.EditTaskTypeButton);
            this.groupBox1.Controls.Add(this.AddTaskTypeButton);
            this.groupBox1.Controls.Add(this.TaskTypesDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(709, 372);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Typy zadań";
            // 
            // DeleteTaskTypeButton
            // 
            this.DeleteTaskTypeButton.Location = new System.Drawing.Point(7, 79);
            this.DeleteTaskTypeButton.Name = "DeleteTaskTypeButton";
            this.DeleteTaskTypeButton.Size = new System.Drawing.Size(82, 23);
            this.DeleteTaskTypeButton.TabIndex = 3;
            this.DeleteTaskTypeButton.Text = "Usuń";
            this.DeleteTaskTypeButton.UseVisualStyleBackColor = true;
            // 
            // EditTaskTypeButton
            // 
            this.EditTaskTypeButton.Location = new System.Drawing.Point(7, 50);
            this.EditTaskTypeButton.Name = "EditTaskTypeButton";
            this.EditTaskTypeButton.Size = new System.Drawing.Size(82, 23);
            this.EditTaskTypeButton.TabIndex = 2;
            this.EditTaskTypeButton.Text = "Edytuj";
            this.EditTaskTypeButton.UseVisualStyleBackColor = true;
            // 
            // AddTaskTypeButton
            // 
            this.AddTaskTypeButton.Location = new System.Drawing.Point(7, 20);
            this.AddTaskTypeButton.Name = "AddTaskTypeButton";
            this.AddTaskTypeButton.Size = new System.Drawing.Size(82, 23);
            this.AddTaskTypeButton.TabIndex = 1;
            this.AddTaskTypeButton.Text = "Dodaj";
            this.AddTaskTypeButton.UseVisualStyleBackColor = true;
            // 
            // TaskTypesDataGridView
            // 
            this.TaskTypesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TaskTypesDataGridView.Location = new System.Drawing.Point(95, 16);
            this.TaskTypesDataGridView.Name = "TaskTypesDataGridView";
            this.TaskTypesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TaskTypesDataGridView.Size = new System.Drawing.Size(613, 354);
            this.TaskTypesDataGridView.TabIndex = 0;
            // 
            // SettingsTabPage
            // 
            this.SettingsTabPage.Controls.Add(this.groupBox2);
            this.SettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.SettingsTabPage.Name = "SettingsTabPage";
            this.SettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTabPage.Size = new System.Drawing.Size(710, 352);
            this.SettingsTabPage.TabIndex = 2;
            this.SettingsTabPage.Text = "Ustawienia";
            this.SettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SaveButton);
            this.groupBox2.Controls.Add(this.AllMealsTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.DinnerTextBox);
            this.groupBox2.Controls.Add(this.LunchTextBox);
            this.groupBox2.Controls.Add(this.BreakfastTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(701, 367);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ustawienia";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(69, 149);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(115, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Zapisz ustawienia";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // AllMealsTextBox
            // 
            this.AllMealsTextBox.Location = new System.Drawing.Point(145, 114);
            this.AllMealsTextBox.Name = "AllMealsTextBox";
            this.AllMealsTextBox.Size = new System.Drawing.Size(100, 20);
            this.AllMealsTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cena trzech posiłków";
            // 
            // DinnerTextBox
            // 
            this.DinnerTextBox.Location = new System.Drawing.Point(145, 88);
            this.DinnerTextBox.Name = "DinnerTextBox";
            this.DinnerTextBox.Size = new System.Drawing.Size(100, 20);
            this.DinnerTextBox.TabIndex = 5;
            // 
            // LunchTextBox
            // 
            this.LunchTextBox.Location = new System.Drawing.Point(145, 63);
            this.LunchTextBox.Name = "LunchTextBox";
            this.LunchTextBox.Size = new System.Drawing.Size(100, 20);
            this.LunchTextBox.TabIndex = 4;
            // 
            // BreakfastTextBox
            // 
            this.BreakfastTextBox.Location = new System.Drawing.Point(145, 34);
            this.BreakfastTextBox.Name = "BreakfastTextBox";
            this.BreakfastTextBox.Size = new System.Drawing.Size(100, 20);
            this.BreakfastTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cena kolacji";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cena obiadu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cena śniadania";
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(721, 24);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.FileToolStripMenuItem.Text = "&Plik";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.ExitToolStripMenuItem.Text = "&Wyjście";
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem,
            this.GetHelpToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.HelpToolStripMenuItem.Text = "&Pomoc";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.AboutToolStripMenuItem.Text = "&O programie";
            // 
            // GetHelpToolStripMenuItem
            // 
            this.GetHelpToolStripMenuItem.Name = "GetHelpToolStripMenuItem";
            this.GetHelpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.GetHelpToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.GetHelpToolStripMenuItem.Text = "&Pomoc";
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 405);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "ManagerForm";
            this.Text = "Moduł Kierownika";
            this.tabControl1.ResumeLayout(false);
            this.TasksTabPage.ResumeLayout(false);
            this.TasksGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGridView)).EndInit();
            this.EmployeesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeesDataGridView)).EndInit();
            this.TaskTypesTabPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TaskTypesDataGridView)).EndInit();
            this.SettingsTabPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TasksTabPage;
        private System.Windows.Forms.GroupBox TasksGroupBox;
        public System.Windows.Forms.Button RemoveTasksButton;
        public System.Windows.Forms.Button EditTaskButton;
        public System.Windows.Forms.Button AddTaskButton;
        public System.Windows.Forms.DataGridView TasksDataGridView;
        private System.Windows.Forms.GroupBox EmployeesGroupBox;
        public System.Windows.Forms.DataGridView EmployeesDataGridView;
        private System.Windows.Forms.TabPage TaskTypesTabPage;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button DeleteTaskTypeButton;
        public System.Windows.Forms.Button EditTaskTypeButton;
        public System.Windows.Forms.Button AddTaskTypeButton;
        public System.Windows.Forms.DataGridView TaskTypesDataGridView;
        private System.Windows.Forms.TabPage SettingsTabPage;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button SaveButton;
        public System.Windows.Forms.TextBox AllMealsTextBox;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox DinnerTextBox;
        public System.Windows.Forms.TextBox LunchTextBox;
        public System.Windows.Forms.TextBox BreakfastTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem GetHelpToolStripMenuItem;
    }
}