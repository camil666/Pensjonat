// -----------------------------------------------------------------------
// <copyright file="EditTaskTypeController.cs" company="">
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
    public class EditTaskTypeController : ControllerBase
    {
        private TaskType taskType;

        #region Constructors
        public EditTaskTypeController()
        {
            base.Form = new EditTaskTypeForm();

            this.SetupEvents();

            this.SetupButtons();
        }

        #endregion

        #region Properties
        public new EditTaskTypeForm Form
        {
            get
            {
                return base.Form as EditTaskTypeForm;
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

        private void SetupButtons()
        {
            this.Form.OkButton.DialogResult = DialogResult.OK;
            this.Form.CancButton.DialogResult = DialogResult.Cancel;
        }

        #endregion

        #region Event method

        private void FormLoad(object sender, EventArgs eventArgs)
        {
            if (this.IsEditForm)
            {
                taskType = DataAccess.Instance.TaskTypes.Single(x => x.Id == this.ItemToEditID);
                this.Form.NameTextBox.Text = taskType.Name;
                this.Form.DescriptionRichTextBox.Text = taskType.Description;
                this.Form.Text = "Edycja typu zadania";
            }
            else
            {
                this.Form.Text = "Nowy typ zadania";
            }
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            this.Form.Dispose();
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            string taskTypeName = this.Form.NameTextBox.Text;
            string taskTypeDescription = this.Form.DescriptionRichTextBox.Text;
            if (string.IsNullOrEmpty(taskTypeName) || string.IsNullOrEmpty(taskTypeDescription))
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
                this.taskType.Name = taskTypeName;
                this.taskType.Description = taskTypeDescription;
            }
            else
            {
                taskType = new TaskType
                {
                    Name = taskTypeName,
                    Description = taskTypeDescription
                };

                DataAccess.Instance.TaskTypes.Add(this.taskType);
            }

            DataAccess.Instance.UnitOfWork.Commit();

            this.Form.Dispose();
        }


        #endregion
    }
}
