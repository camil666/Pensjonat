// -----------------------------------------------------------------------
// <copyright file="EditServiceForVisit.cs" company="">
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

    using Projekt_BD.View;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class EditServiceForVisitController : ControllerBase
    {
        #region Constructors

        public EditServiceForVisitController()
        {
            base.Form = new EditServiceForVisitForm();

            this.SetupEvents();
        }

        #endregion

        #region Properties

        public new EditServiceForVisitForm Form
        {
            get
            {
                return base.Form as EditServiceForVisitForm;
            }
        }

        #endregion

        #region methods

        private void SetupEvents()
        {
            this.Form.Load += this.FormLoad;
            this.Form.OkButton.Click += this.OkButtonClick;
            this.Form.AddServiceButton.Click += this.AddServiceButtonClick;
            this.Form.EditServiceButton.Click += this.EditServiceButtonClick;
            this.Form.DeleteServicesButton.Click += this.DeleteServicesButtonClick;
        }

        private void DeleteServicesButtonClick(object sender, EventArgs e)
        {
            this.RefreshDataGridView();
        }

        private void EditServiceButtonClick(object sender, EventArgs e)
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

        private void AddServiceButtonClick(object sender, EventArgs e)
        {
            var controller = ControllerFactory.Instance.Create(ControllerTypes.NewVisitForm);
            if (controller.Form.ShowDialog() == DialogResult.OK)
            {
                this.RefreshDataGridView();
            }
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            this.Form.Dispose();
        }

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

        private void FormLoad(object sender, EventArgs e)
        {
            this.RefreshDataGridView();
        }

        #endregion
    }
}
