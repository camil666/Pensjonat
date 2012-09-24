// -----------------------------------------------------------------------
// <copyright file="ManagerFormController.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Projekt_BD.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    using Domain;

    using Projekt_BD.Enums;
    using Projekt_BD.Interfaces;
    using Projekt_BD.View;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ManagerFormController : ControllerBase
    {
        #region Fields

        private static readonly string IdColumnName = "Id";

        private static readonly string FirstNameColumnName = "FirstName";

        private static readonly string LastNameColumnName = "LastName";

        private MealPrice mealPrices;

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

            this.Form.AddTaskTypeButton.Click += this.AddTaskTypeButton_Click;
            this.Form.DeleteTaskTypeButton.Click += this.DeleteTaskTypeButton_Click;
            this.Form.EditTaskTypeButton.Click += this.EditTaskTypeButton_Click;
            this.Form.SaveButton.Click += this.SaveButtonClick;
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
                            where employee.RoleId == (int)Roles.Employee
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

        private void LoadSettings()
        {
            this.mealPrices = DataAccess.Instance.MealPrices.GetAll().FirstOrDefault();
            if (this.mealPrices != null)
            {
                this.Form.BreakfastTextBox.Text = this.mealPrices.BreakfastPrice.ToString(CultureInfo.InvariantCulture);
                this.Form.DinnerTextBox.Text = this.mealPrices.DinnerPrice.ToString(CultureInfo.InvariantCulture);
                this.Form.LunchTextBox.Text = this.mealPrices.LunchPrice.ToString(CultureInfo.InvariantCulture);
                this.Form.AllMealsTextBox.Text = this.mealPrices.ThreeMealsPrice.ToString(CultureInfo.InvariantCulture);
            }
        }

        #endregion

        #region Event Methods

        private void Form_Load(object sender, EventArgs e)
        {
            this.LoadEmployees();
            this.LoadTaskTypes();
            this.LoadSettings();
            this.SetVisibiltyAndHeaderNamesOfTasks();
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            double breakfast;
            double lunch;
            double dinner;
            double all;
            if (!double.TryParse(this.Form.BreakfastTextBox.Text, out breakfast) || !double.TryParse(this.Form.LunchTextBox.Text, out lunch) || 
                !double.TryParse(this.Form.DinnerTextBox.Text, out dinner) || !double.TryParse(this.Form.AllMealsTextBox.Text, out all))
            {
                MessageBox.Show("Wprowadź poprawne dane!");
                return;
            }

            this.mealPrices.BreakfastPrice = breakfast;
            this.mealPrices.DinnerPrice = dinner;
            this.mealPrices.LunchPrice = lunch;
            this.mealPrices.ThreeMealsPrice = all;
            DataAccess.Instance.UnitOfWork.Commit();
        }

        private void AddTasksButton_Click(object sender, EventArgs e)
        {
            if (DataAccess.Instance.TaskTypes.GetAll().Any())
            {
                var controller = ControllerFactory.Instance.Create(ControllerTypes.EditTaskForm);
                controller.SecondaryId = this.SelectedEmployeeId;
                controller.Form.ShowDialog();
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
                controller.Form.ShowDialog();
                this.LoadTasks();
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

        // task types

        private void EditTaskTypeButton_Click(object sender, EventArgs e)
        {
            if (this.IsTaskTypeSelected)
            {
                var controller = ControllerFactory.Instance.Create(ControllerTypes.EditTaskTypeForm);
                controller.ItemToEditID = this.SelectedTaskTypeId;
                controller.Form.ShowDialog();
                this.LoadTaskTypes();
            }
            else
            {
                MessageBox.Show("Nie zaznaczono typu zadania do edycji!");
            }
        }

        private void DeleteTaskTypeButton_Click(object sender, EventArgs e)
        {
            try
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
            catch (UpdateException)
            {
                MessageBox.Show("Nie można usunąć typu zadania, ponieważ istnieją zadania tego typu!");
            }
        }

        private void AddTaskTypeButton_Click(object sender, EventArgs e)
        {
            ControllerFactory.Instance.Create(ControllerTypes.EditTaskTypeForm).Form.ShowDialog();
            this.LoadTaskTypes();
        }

        #endregion
    }
}
