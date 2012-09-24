namespace Projekt_BD.Controller
{
    using System;
    using System.Data;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.Enums;
    using Projekt_BD.View;

    /// <summary>
    /// Controller class for Manager form.
    /// </summary>
    public class ManagerFormController : ControllerBase
    {
        #region Fields

        /// <summary>
        /// Name of the Id column.
        /// </summary>
        private static readonly string IdColumnName = "Id";

        /// <summary>
        /// Name of the FirstName column.
        /// </summary>
        private static readonly string FirstNameColumnName = "FirstName";

        /// <summary>
        /// Name of the LastName column.
        /// </summary>
        private static readonly string LastNameColumnName = "LastName";

        /// <summary>
        /// Single mealPrice.
        /// </summary>
        private MealPrice mealPrices;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerFormController" /> class.
        /// </summary>
        public ManagerFormController()
        {
            base.Form = new ManagerForm();

            this.SetupEvents();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the form.
        /// </summary>
        /// <value>
        /// The form.
        /// </value>
        public new ManagerForm Form
        {
            get
            {
                return base.Form as ManagerForm;
            }
        }

        /// <summary>
        /// Gets a value indicating whether employee is selected.
        /// </summary>
        /// <value>
        /// <c>true</c> if employee is selected; otherwise, <c>false</c>.
        /// </value>
        private bool IsEmployeeSelected
        {
            get
            {
                return this.Form.EmployeesDataGridView.SelectedRows.Count > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether task type is selected.
        /// </summary>
        /// <value>
        /// <c>true</c> if task type is selected; otherwise, <c>false</c>.
        /// </value>
        private bool IsTaskTypeSelected
        {
            get
            {
                return this.Form.TaskTypesDataGridView.SelectedRows.Count > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether task is selected.
        /// </summary>
        /// <value>
        /// <c>true</c> if task is selected; otherwise, <c>false</c>.
        /// </value>
        private bool IsTaskSelected
        {
            get
            {
                return this.Form.TasksDataGridView.SelectedRows.Count > 0;
            }
        }

        /// <summary>
        /// Gets the selected employee id.
        /// </summary>
        /// <value>
        /// The selected employee id.
        /// </value>
        private int SelectedEmployeeId
        {
            get
            {
                int selectedRowIndex = this.Form.EmployeesDataGridView.SelectedRows[0].Index;
                return (int)this.Form.EmployeesDataGridView[0, selectedRowIndex].Value;
            }
        }

        /// <summary>
        /// Gets the selected task type id.
        /// </summary>
        /// <value>
        /// The selected task type id.
        /// </value>
        private int SelectedTaskTypeId
        {
            get
            {
                var selectedRowIndex = this.Form.TaskTypesDataGridView.SelectedRows[0].Index;
                return (int)this.Form.TaskTypesDataGridView[0, selectedRowIndex].Value;
            }
        }

        /// <summary>
        /// Gets the selected task id.
        /// </summary>
        /// <value>
        /// The selected task id.
        /// </value>
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

        /// <summary>
        /// Sets up the events.
        /// </summary>
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
            this.Form.SaveButton.Click += this.SaveButton_Click;
        }

        /// <summary>
        /// Sets the visibilty and header names of employees.
        /// </summary>
        private void SetVisibiltyAndHeaderNamesOfEmployees()
        {
            this.Form.EmployeesDataGridView.Columns[IdColumnName].Visible = false;
            this.Form.EmployeesDataGridView.Columns[FirstNameColumnName].HeaderText = "Imię";
            this.Form.EmployeesDataGridView.Columns[LastNameColumnName].HeaderText = "Nazwisko";
            this.Form.EmployeesDataGridView.Columns["UserName"].HeaderText = "Login";
        }

        /// <summary>
        /// Sets the visibilty and header names of tasks.
        /// </summary>
        private void SetVisibiltyAndHeaderNamesOfTasks()
        {
            this.Form.TasksDataGridView.Columns[IdColumnName].Visible = false;
            this.Form.TasksDataGridView.Columns["Name"].HeaderText = "Nazwa";
            this.Form.TasksDataGridView.Columns["Description"].HeaderText = "Opis";
            this.Form.TasksDataGridView.Columns["StartDate"].HeaderText = "Rozpoczęcie";
            this.Form.TasksDataGridView.Columns["EndDate"].HeaderText = "Zakończenie";
        }

        /// <summary>
        /// Loads the task types.
        /// </summary>
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

        /// <summary>
        /// Loads the employees.
        /// </summary>
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

        /// <summary>
        /// Loads the tasks.
        /// </summary>
        private void LoadTasks()
        {
            if (this.IsEmployeeSelected)
            {
                var employee = DataAccess.Instance.Employees.Single(emp => emp.Id == this.SelectedEmployeeId);
                var tasks = (from task in employee.Tasks
                             select new { task.Id, task.Name, task.Description, task.StartDate, task.EndDate }).ToList();
                this.Form.TasksDataGridView.DataSource = tasks;
                this.SetVisibiltyAndHeaderNamesOfTasks();
            }
        }

        /// <summary>
        /// Loads the settings.
        /// </summary>
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

        /// <summary>
        /// Handles the Load event of the Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void Form_Load(object sender, EventArgs e)
        {
            this.LoadEmployees();
            this.LoadTaskTypes();
            this.LoadSettings();
        }

        /// <summary>
        /// Handles the Click event of the SaveButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void SaveButton_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Handles the Click event of the AddTasksButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the RemoveTasksButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the EditTasksButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the EmployeeCellMouse control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellMouseEventArgs" /> instance containing the event data.</param>
        private void EmployeeCellMouse_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.LoadTasks();
        }

        // TODO:task types

        /// <summary>
        /// Handles the Click event of the EditTaskTypeButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the DeleteTaskTypeButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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
            catch (Exception)
            {
                MessageBox.Show("Nie można usunąć typu zadania, ponieważ istnieją zadania tego typu!");
            }
        }

        /// <summary>
        /// Handles the Click event of the AddTaskTypeButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AddTaskTypeButton_Click(object sender, EventArgs e)
        {
            ControllerFactory.Instance.Create(ControllerTypes.EditTaskTypeForm).Form.ShowDialog();
            this.LoadTaskTypes();
        }

        #endregion
    }
}
