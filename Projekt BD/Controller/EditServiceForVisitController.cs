namespace Projekt_BD.Controller
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Projekt_BD.View;

    /// <summary>
    /// Controller class for EditServiceForVisit form.
    /// </summary>
    public class EditServiceForVisitController : ControllerBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EditServiceForVisitController" /> class.
        /// </summary>
        public EditServiceForVisitController()
        {
            base.Form = new EditServiceForVisitForm();

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
        public new EditServiceForVisitForm Form
        {
            get
            {
                return base.Form as EditServiceForVisitForm;
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
            this.Form.OkButton.Click += this.OkButton_Click;
            this.Form.AddServiceButton.Click += this.AddServiceButton_Click;
            this.Form.EditServiceButton.Click += this.EditServiceButton_Click;
            this.Form.DeleteServicesButton.Click += this.DeleteServicesButton_Click;
        }

        /// <summary>
        /// Sets the column names and visibility.
        /// </summary>
        private void SetColumnNamesAndVisibility()
        {
            this.Form.ServicesDataGridView.Columns["Id"].Visible = false;

            this.Form.ServicesDataGridView.Columns["Quantity"].HeaderText = "Ilość";
            this.Form.ServicesDataGridView.Columns["Charge"].HeaderText = "Opłata";
            this.Form.ServicesDataGridView.Columns["Description"].HeaderText = "Opis typu usługi";
            this.Form.ServicesDataGridView.Columns["Name"].HeaderText = "Nazwa typu usługi";
            this.Form.ServicesDataGridView.Columns["CustomDescription"].HeaderText = "Opis usługi";
            this.Form.ServicesDataGridView.Columns["CustomName"].HeaderText = "Nazwa usługi";
        }

        /// <summary>
        /// Refreshes the data grid view.
        /// </summary>
        private void RefreshDataGridView()
        {
            var services = (from service in DataAccess.Instance.Services.GetAll()
                            where service.VisitId == ItemToEditID
                            join serviceType in DataAccess.Instance.ServiceTypes.GetAll() on service.TypeId equals serviceType.Id
                            select
                               new
                               {
                                   service.Id,
                                   serviceType.Name,
                                   service.Quantity,
                                   serviceType.Charge,
                                   serviceType.Description,
                                   service.CustomName,
                                   service.CustomDescription,
                               }).ToList();

            this.Form.ServicesDataGridView.DataSource = services;

            this.SetColumnNamesAndVisibility();
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
            this.RefreshDataGridView();
        }

        /// <summary>
        /// Handles the Click event of the DeleteServicesButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void DeleteServicesButton_Click(object sender, EventArgs e)
        {
            this.RefreshDataGridView();
        }

        /// <summary>
        /// Handles the Click event of the EditServiceButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void EditServiceButton_Click(object sender, EventArgs e)
        {
            if (this.Form.ServicesDataGridView.SelectedRows.Count > 0)
            {
                int rowIndex = this.Form.ServicesDataGridView.SelectedRows[0].Index;
                int index = (int)this.Form.ServicesDataGridView["Id", rowIndex].Value;
                var controller = ControllerFactory.Instance.Create(ControllerTypes.EditServiceDetailsForm);
                controller.ItemToEditID = index;
                if (controller.Form.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshDataGridView();
                }
            }
            else
            {
                MessageBox.Show("Należy zaznaczyć usługę", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Handles the Click event of the AddServiceButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AddServiceButton_Click(object sender, EventArgs e)
        {
            var controller = ControllerFactory.Instance.Create(ControllerTypes.NewVisitForm);
            if (controller.Form.ShowDialog() == DialogResult.OK)
            {
                this.RefreshDataGridView();
            }
        }

        /// <summary>
        /// Handles the Click event of the OkButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Form.Dispose();
        }

        #endregion
    }
}
