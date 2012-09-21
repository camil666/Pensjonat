// -----------------------------------------------------------------------
// <copyright file="ManagerFormController.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Projekt_BD.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    using Domain;

    using Projekt_BD.View;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ManagerFormController : ControllerBase
    {
        #region Field

        private static readonly string IdColumnName = "Id";

        private static readonly string FirstNameColumnName = "FirstName";

        private static readonly string LastNameColumnName = "LastName";

        #endregion

        #region Constructors

        public ManagerFormController()
        {
            base.Form = new ManagerForm();

            this.SetupEvents();
        }

        #endregion

        #region Properties

        public new ManagerForm Form
        {
            get
            {
                return base.Form as ManagerForm;
            }
        }

        private bool IsEmployeeSelected
        {
            get
            {
                return this.Form.EmployeesDataGridView.SelectedRows.Count > 0;
            }
        }

        private bool IsTaskTypeSelected
        {
            get
            {
                return this.Form.TaskTypesDataGridView.SelectedRows.Count > 0;
            }
        }

        private bool IsTaskSelected
        {
            get
            {
                return this.Form.TasksDataGridView.SelectedRows.Count > 0;
            }
        }

        private int SelectedEmployeeId
        {
            get
            {
                int selectedRowIndex = this.Form.EmployeesDataGridView.SelectedRows[0].Index;
                return (int)this.Form.EmployeesDataGridView[0, selectedRowIndex].Value;
            }
        }

        private int SelectedTaskTypeId
        {
            get
            {
                var selectedRowIndex = this.Form.TaskTypesDataGridView.SelectedRows[0].Index;
                return (int)this.Form.TaskTypesDataGridView[0, selectedRowIndex].Value;
            }
        }

        private int SelectedTaskId
        {
            get
            {
                var selectedRowIndex = this.Form.TasksDataGridView.SelectedRows[0].Index;
                return (int)this.Form.TasksDataGridView[0, selectedRowIndex].Value;
            }
        }

        #endregion

        #region Methods

        private void SetupEvents()
        {
            this.Form.Load += this.Form_Load;
            this.Form.AddTaskButton.Click += this.AddTasksButton_Click;
            this.Form.RemoveTasksButton.Click += this.RemoveTasksButton_Click;
            this.Form.EditTaskButton.Click += this.EditTasksButton_Click;
            this.Form.EmployeesDataGridView.CellMouseClick += this.EmployeeCellMouse_Click;
            this.Form.TasksDataGridView.CellMouseClick += this.TaskCellMouse_Click;

            this.Form.AddTaskTypeButton.Click += this.AddTaskTypeButton_Click;
            this.Form.DeleteTaskTypeButton.Click += this.DeleteTaskTypeButton_Click;
            this.Form.EditTaskTypeButton.Click += this.EditTaskTypeButton_Click;

        }

        private void SetVisibiltyAndHeaderNamesOfEmployees()
        {
            this.Form.EmployeesDataGridView.Columns[IdColumnName].Visible = false;
            this.Form.EmployeesDataGridView.Columns[FirstNameColumnName].HeaderText = "Imię";
            this.Form.EmployeesDataGridView.Columns[LastNameColumnName].HeaderText = "Nazwisko";
            this.Form.EmployeesDataGridView.Columns["UserName"].HeaderText = "Login";
        }

        private void SetVisibiltyAndHeaderNamesOfTasks()
        {
            this.Form.TasksDataGridView.Columns[IdColumnName].Visible = false;
            this.Form.TasksDataGridView.Columns["Name"].HeaderText = "Nazwa";
            this.Form.TasksDataGridView.Columns["Description"].HeaderText = "Opis";
            this.Form.TasksDataGridView.Columns["StartDate"].HeaderText = "Rozpoczęcie";
            this.Form.TasksDataGridView.Columns["EndDate"].HeaderText = "Zakończenie";
        }

        private void LoadTaskTypes()
        {
            var taskTypes = from taskType in DataAccess.Instance.TaskTypes.GetAll()
                            select new
                            {
                                taskType.Id,
                                taskType.Name,
                                taskType.Description
                            };

            this.Form.TaskTypesDataGridView.DataSource = taskTypes;
        }

        private void LoadEmployees()
        {
            var employees = from employee in DataAccess.Instance.Employees.GetAll()
                            select new
                            {
                                employee.Id,
                                employee.Username,
                                employee.FirstName,
                                employee.LastName
                            };

            this.Form.EmployeesDataGridView.DataSource = employees;
            this.SetVisibiltyAndHeaderNamesOfEmployees();
        }

        private void LoadTasks()
        {
            if (this.IsEmployeeSelected)
            {
                var employee = DataAccess.Instance.Employees.Single(emp => emp.Id == this.SelectedEmployeeId);
                var tasks = (from task in employee.Tasks
                             select new { task.Id, task.Name, task.Description, task.StartDate, task.EndDate }).ToList();
                this.Form.TasksDataGridView.DataSource = tasks;
            }
        }

        #endregion

        #region Event Methods

        private void Form_Load(object sender, EventArgs e)
        {
            this.LoadEmployees();
            this.LoadTaskTypes();
            this.SetVisibiltyAndHeaderNamesOfTasks();
        }

        private void AddTasksButton_Click(object sender, EventArgs e)
        {
            if (ControllerFactory.Instance.Create(ControllerTypes.EditTaskForm).Form.ShowDialog() == DialogResult.OK)
            {
                this.LoadTasks();
            }
        }

        private void RemoveTasksButton_Click(object sender, EventArgs e)
        {
            if (this.IsTaskSelected)
            {
                var selectedRowIndexes = this.Form.TasksDataGridView.SelectedRows;
                foreach (DataGridViewRow item in selectedRowIndexes)
                {
                    var id = (int)this.Form.TasksDataGridView[0, item.Index].Value;
                    var task = DataAccess.Instance.Tasks.Single(t => t.Id == id);
                    DataAccess.Instance.Tasks.Delete(task);
                }
                DataAccess.Instance.UnitOfWork.Commit();
                this.LoadTasks();
            }
            else
            {
                MessageBox.Show("Nie zaznaczono zadań do usunięcia!");
            }
        }


        private void EditTasksButton_Click(object sender, EventArgs e)
        {
            if (this.IsTaskSelected)
            {
                var controller = ControllerFactory.Instance.Create(ControllerTypes.EditTaskForm);
                controller.ItemToEditID = this.SelectedTaskId;
                if (controller.Form.ShowDialog() == DialogResult.OK)
                {
                    this.LoadTasks();
                }
            }
            else
            {
                MessageBox.Show("Nie zaznaczono zadania do edycji!");
            }
        }

        private void EmployeeCellMouse_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.LoadTasks();
        }


        private void TaskCellMouse_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        // task types

        private void EditTaskTypeButton_Click(object sender, EventArgs e)
        {
            if (this.IsTaskTypeSelected)
            {
                var controller = ControllerFactory.Instance.Create(ControllerTypes.EditTaskTypeForm);
                controller.ItemToEditID = this.SelectedTaskTypeId;
                if (controller.Form.ShowDialog() == DialogResult.OK)
                {
                    this.LoadTaskTypes();
                }
            }
            else
            {
                MessageBox.Show("Nie zaznaczono typu zadania do edycji!");
            }
        }

        private void DeleteTaskTypeButton_Click(object sender, EventArgs e)
        {
            if (this.IsTaskTypeSelected)
            {
                var selectedRowIndexes = this.Form.TaskTypesDataGridView.SelectedRows;
                foreach (DataGridViewRow item in selectedRowIndexes)
                {
                    var id = (int)this.Form.TaskTypesDataGridView[0, item.Index].Value;
                    var taskType = DataAccess.Instance.TaskTypes.Single(t => t.Id == id);
                    DataAccess.Instance.TaskTypes.Delete(taskType);
                }
                DataAccess.Instance.UnitOfWork.Commit();
                this.LoadTaskTypes();
            }
            else
            {
                MessageBox.Show("Nie zaznaczono zadań do usunięcia!");
            }
        }

        private void AddTaskTypeButton_Click(object sender, EventArgs e)
        {
            if (ControllerFactory.Instance.Create(ControllerTypes.EditTaskTypeForm).Form.ShowDialog() == DialogResult.OK)
            {
                this.LoadTaskTypes();
            }
        }

        #endregion
    }
}
