namespace Projekt_BD.Controller
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Domain;
    using Projekt_BD.Interfaces;
    using Projekt_BD.View;

    public class EmployeeFormController : ControllerBase
    {
        #region Constructors

        public EmployeeFormController()
        {
            base.Form = new EmployeeForm();

            this.SetupEvents();
        }

        #endregion

        #region Properties

        public new EmployeeForm Form
        {
            get
            {
                return base.Form as EmployeeForm;
            }
        }

        #endregion

        #region Methods

        private void SetupEvents()
        {
            this.Form.LoadButton.Click += this.LoadButton_Click;
            this.Form.Load += this.Form_Load;
            this.Form.SaveButton.Click += this.SaveButton_Click;
        }

        private void LoadTasks()
        {
            //int employeeId = CurrentUser.Instance.Id;

            ///////////////////////////////////////

            int employeeId = 4;

            ///////////////////////////////////////

            //if (this.Form.ShowDoneTasksCheckBox.Checked)
            //{
            //    tasks = (from task in DataAccess.Instance.Tasks.Find(t => t.EmployeeId == employeeId).OrderBy(t => t.IsDone)
            //                 select new { task.TaskType.Name, task.Description, task.StartDate, task.EndDate, task.IsDone }).ToList();
            //}
            //else
            //{
            //    tasks = (from task in DataAccess.Instance.Tasks.Find(t => t.EmployeeId == employeeId && t.IsDone == false)
            //                 select new { task.TaskType.Name, task.Description, task.StartDate, task.EndDate, task.IsDone }).ToList();         
            //}

            //if (tasks != null)
            //{
            //    this.Form.TasksDataGridView.DataSource = tasks;

            //    int lastColumnIndex = this.Form.TasksDataGridView.Columns.Count - 1;

            //    foreach (var task in tasks)
            //    {
            //        if (task.)
            //        {
            //            this.Form.FeaturesDataGridView.Rows[featureList.IndexOf(feature)].Cells[lastColumnIndex].Value = true;
            //        }
            //    }
            //}
        }

        #endregion

        #region Event Methods

        private void LoadButton_Click(object sender, EventArgs e)
        {
            this.LoadTasks();
        }

        void Form_Load(object sender, EventArgs e)
        {
            this.LoadTasks();
        }

        void SaveButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
