namespace Projekt_BD.Controller
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.View;

    public class EmployeeFormController : ControllerBase
    {
        #region Fields

        private static readonly string IdColumnName = "Id";

        private static readonly string NameColumnName = "Name";

        private static readonly string StartDateColumnName = "StartDate";

        private static readonly string EndDateColumnName = "EndDate";

        private static readonly string DescriptionColumnName = "Description";

        private static readonly string StatusesColumnName = "Statuses";

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeFormController" /> class.
        /// </summary>
        public EmployeeFormController()
        {
            base.Form = new EmployeeForm();

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
        public new EmployeeForm Form
        {
            get
            {
                return base.Form as EmployeeForm;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets up the events.
        /// </summary>
        private void SetupEvents()
        {
            this.Form.LoadButton.Click += this.LoadButton_Click;
            this.Form.Load += this.Form_Load;
            this.Form.SaveButton.Click += this.SaveButton_Click;
        }

        /// <summary>
        /// Loads the tasks.
        /// </summary>
        private void LoadTasks()
        {
            if (this.Form.TasksDataGridView.Columns.Count > 0)
            {
                this.Form.TasksDataGridView.Columns.Clear();
            }

            int employeeId = CurrentUser.Instance.Id;

            var taskWithStatuses = (from task in DataAccess.Instance.Tasks.Find(t => t.EmployeeId == employeeId).OrderBy(t => t.IsDone)
                                    select new { task.Id, task.TaskType.Name, task.Description, task.StartDate, task.EndDate, task.IsDone }).ToList();

            if (this.Form.ShowDoneTasksCheckBox.Checked)
            {
                var tasks = (from task in taskWithStatuses
                             select new { task.Id, task.Description, task.Name, task.StartDate, task.EndDate }).ToList();

                this.Form.TasksDataGridView.DataSource = tasks;
            }
            else
            {
                var tasks = (from task in taskWithStatuses.Where(t => t.IsDone == false)
                             select new { task.Id, task.Description, task.Name, task.StartDate, task.EndDate }).ToList();

                this.Form.TasksDataGridView.DataSource = tasks;
            }

            this.Form.TasksDataGridView.Columns.Add(new DataGridViewCheckBoxColumn() { Name = StatusesColumnName });

            if (taskWithStatuses != null)
            {
                int lastColumnIndex = this.Form.TasksDataGridView.Columns.Count - 1;

                foreach (DataGridViewRow row in this.Form.TasksDataGridView.Rows)
                {
                    var taskId = (int)row.Cells[IdColumnName].Value;

                    bool isDoneValue = (from task in taskWithStatuses
                                        where task.Id == taskId
                                        select task.IsDone).FirstOrDefault();

                    if (isDoneValue)
                    {
                        row.Cells[StatusesColumnName].Value = isDoneValue;
                    }
                }

                this.Form.TasksDataGridView.Columns[IdColumnName].Visible = false;
                this.Form.TasksDataGridView.Columns[NameColumnName].HeaderText = "Typ";
                this.Form.TasksDataGridView.Columns[StartDateColumnName].HeaderText = "Data rozpoczęcia";
                this.Form.TasksDataGridView.Columns[EndDateColumnName].HeaderText = "Data zakończenia";
                this.Form.TasksDataGridView.Columns[DescriptionColumnName].HeaderText = "Opis";
                this.Form.TasksDataGridView.Columns[StatusesColumnName].HeaderText = "Zrobione";
            }
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// Handles the Click event of the LoadButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void LoadButton_Click(object sender, EventArgs e)
        {
            this.LoadTasks();
        }

        /// <summary>
        /// Handles the Load event of the Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void Form_Load(object sender, EventArgs e)
        {
            this.LoadTasks();
        }

        /// <summary>
        /// Handles the Click event of the SaveButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.Form.TasksDataGridView.Rows)
            {
                var taskId = (int)row.Cells[IdColumnName].Value;

                var isDoneCell = row.Cells[StatusesColumnName] as DataGridViewCheckBoxCell;
                bool isDone = Convert.ToBoolean(isDoneCell.Value);

                Task taskToUpdate = DataAccess.Instance.Tasks.Single(t => t.Id == taskId);
                taskToUpdate.IsDone = isDone;

                if (isDone)
                {
                    taskToUpdate.EndDate = DateTime.Now;
                }

                DataAccess.Instance.UnitOfWork.Commit();
            }

            this.LoadTasks();
        }

        #endregion
    }
}
