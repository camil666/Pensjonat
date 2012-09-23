// -----------------------------------------------------------------------
// <copyright file="EditTaskController.cs" company="">
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
    public class EditTaskController : ControllerBase
    {
        private Task task;

        #region Constructors
        public EditTaskController()
        {
            base.Form = new EditTaskForm();

            this.SetupEvents();
        }

        #endregion

        #region Properties
        public new EditTaskForm Form
        {
            get
            {
                return base.Form as EditTaskForm;
            }
        }
        #endregion

        #region Methods
        private void SetupEvents()
        {
            this.Form.Load += this.FormLoad;
            this.Form.CancButton.Click += this.CancelButtonClick;
            this.Form.OkButton.Click += this.OkButtonClick;
        }

        #endregion

        #region Event method

        private void FormLoad(object sender, EventArgs eventArgs)
        {
            var availableTypes = DataAccess.Instance.TaskTypes.GetAll().ToDictionary(availableType => availableType.Id, availableType => availableType.Name);
            this.Form.TaskTypeComboBox.DataSource = new BindingSource(availableTypes, null);
            this.Form.TaskTypeComboBox.DisplayMember = "Value";
            this.Form.TaskTypeComboBox.ValueMember = "Key";
            
            if (this.IsEditForm)
            {
                this.task = DataAccess.Instance.Tasks.Single(x => x.Id == this.ItemToEditID);
                
                this.Form.NameTextBox.Text = this.task.Name;
                this.Form.DescriptionTextBox.Text = this.task.Description;
                var startDate = this.task.StartDate;
                if (startDate != null)
                {
                    this.Form.StartDateTimePicker.Value = (DateTime)startDate;
                }

                var endDate = this.task.EndDate;
                if (endDate != null)
                {
                    this.Form.StartDateTimePicker.Value = (DateTime)endDate;
                }

                this.Form.IsDoneCheckBox.Checked = this.task.IsDone;
                this.Form.TaskTypeComboBox.Text = availableTypes.Where(x => x.Key == this.task.TypeId).Select(x => x.Value).FirstOrDefault();

                this.Form.Text = "Edycja zadania";
            }
            else
            {
                this.Form.Text = "Nowe zadanie";
            }
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            this.Form.Dispose();
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            string taskName = this.Form.NameTextBox.Text;
            string taskDescription = this.Form.DescriptionTextBox.Text;
            DateTime startDate = this.Form.StartDateTimePicker.Value;
            DateTime endDate = this.Form.EndDateTimePicker.Value.AddSeconds(1.0);
            bool isDone = this.Form.IsDoneCheckBox.Checked;
            int taskTypeId = 0;
            int.TryParse(this.Form.TaskTypeComboBox.SelectedValue.ToString(), out taskTypeId);

            if (string.IsNullOrEmpty(taskName) || string.IsNullOrEmpty(taskDescription) || startDate >= endDate)
            {
                MessageBox.Show(
                    "Podane wartości nie są prawidłowe lub pozostawiono niewypełnione pola.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            if (this.IsEditForm)
            {
                this.task.Name = taskName;
                this.task.Description = taskDescription;
                this.task.IsDone = isDone;
                this.task.StartDate = startDate;
                this.task.EndDate = endDate;
                this.task.TypeId = taskTypeId;
            }
            else
            {
                this.task = new Task
                {
                    Name = taskName,
                    Description = taskDescription,
                    IsDone = isDone,
                    TypeId = taskTypeId,
                    StartDate = startDate,
                    EndDate = endDate,
                    EmployeeId = this.SecondaryId
                };

                DataAccess.Instance.Tasks.Add(this.task);
            }

            DataAccess.Instance.UnitOfWork.Commit();

            this.Form.Dispose();
        }


        #endregion
    }
}
