namespace Projekt_BD.Controller
{
    using System;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.View;

    /// <summary>
    /// Controller class for EditTaskType form.
    /// </summary>
    public class EditTaskTypeController : ControllerBase
    {
        #region Fields

        /// <summary>
        /// Holds single taskType.
        /// </summary>
        private TaskType taskType;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EditTaskTypeController" /> class.
        /// </summary>
        public EditTaskTypeController()
        {
            base.Form = new EditTaskTypeForm();

            this.SetupEvents();
            this.SetupButtons();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the form.
        /// </summary>
        /// <value>
        /// The form.
        /// </value>
        public new EditTaskTypeForm Form
        {
            get
            {
                return base.Form as EditTaskTypeForm;
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
            this.Form.CancButton.Click += this.CancelButton_Click;
            this.Form.OkButton.Click += this.OkButton_Click;
        }

        /// <summary>
        /// Sets up the buttons.
        /// </summary>
        private void SetupButtons()
        {
            this.Form.OkButton.DialogResult = DialogResult.OK;
            this.Form.CancButton.DialogResult = DialogResult.Cancel;
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// Handles the Load event of the Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="eventArgs">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void Form_Load(object sender, EventArgs eventArgs)
        {
            if (this.IsEditForm)
            {
                this.taskType = DataAccess.Instance.TaskTypes.Single(x => x.Id == this.ItemToEditID);
                this.Form.NameTextBox.Text = this.taskType.Name;
                this.Form.DescriptionRichTextBox.Text = this.taskType.Description;
                this.Form.Text = "Edycja typu zadania";
            }
            else
            {
                this.Form.Text = "Nowy typ zadania";
            }
        }

        /// <summary>
        /// Handles the Click event of the CancelButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Form.Dispose();
        }

        /// <summary>
        /// Handles the Click event of the OkButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void OkButton_Click(object sender, EventArgs e)
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
                this.taskType = new TaskType
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
