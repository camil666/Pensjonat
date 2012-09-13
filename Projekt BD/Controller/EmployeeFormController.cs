namespace Projekt_BD.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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
        }

        #endregion

        #region Event Methods

        private void LoadButton_Click(object sender, EventArgs e)
        {
            //using (PensjonatEntities context = new PensjonatEntities())
            //{
            //    int id = int.Parse(IDEmployeeTextBox.Text);
            //    var tasksAndServicesForEmployee = (from tasks in context.Task
            //                                      where tasks.employee_id == id
            //                                      from taskType in context.TaskType
            //                                      where taskType.id == tasks.type_id
            //                                      select new{
            //                                          tasks.id, taskType.name, taskType.description, tasks.is_done
            //                                      }).ToList();
            //    this.TasksDataGridView.DataSource = tasksAndServicesForEmployee;
            //}
        }

        #endregion
    }
}
