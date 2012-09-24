// -----------------------------------------------------------------------
// <copyright file="EditServiceDetailsController.cs" company="">
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
    public class EditServiceDetailsController : ControllerBase
    {
        #region Field

        private static readonly string IdColumnName = "Id";

        private static readonly string NameColumnName = "Name";

        private static readonly string IsAddedColumnName = "IsAdded";

        #endregion

        #region Constructors

        public EditServiceDetailsController()
        {
            base.Form = new EditServiceDetails();

            this.SetupEvents();
            this.SetupButtons();
        }

        #endregion

        #region Properties

        public new EditServiceDetails Form
        {
            get
            {
                return base.Form as EditServiceDetails;
            }
        }

        #endregion

        #region Methods

        private void SetupEvents()
        {
            this.Form.Load += this.Form_Load;
            this.Form.OkButton.Click += this.OkButtonClick;
            this.Form.CancButton.Click += this.CancelButtonClick;
        }

        #endregion

        #region Event Methods

        private void SetupButtons()
        {
            this.Form.OkButton.DialogResult = DialogResult.OK;
            this.Form.CancButton.DialogResult = DialogResult.Cancel;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            var availableTypes = DataAccess.Instance.ServiceTypes.GetAll().ToDictionary(availableType => availableType.Id, availableType => availableType.Name);
            this.Form.TypeComboBox.DataSource = new BindingSource(availableTypes, null);
            this.Form.TypeComboBox.DisplayMember = "Value";
            this.Form.TypeComboBox.ValueMember = "Key";
            if (this.IsEditForm)
            {
                var service = DataAccess.Instance.Services.Single(x => x.Id == ItemToEditID);
                this.Form.TypeComboBox.Text = availableTypes.Where(x => x.Key == service.TypeId).Select(x => x.Value).FirstOrDefault();

                this.Form.CustomNameTextBox.Text = service.CustomName;
                this.Form.CustomDescriptionTextBox.Text = service.CustomDescription;
                this.Form.AdditionalInfoTextBox.Text = service.AdditionalInfo;
                if (service.StartDate != null)
                {
                    this.Form.StartDateTimePicker.Value = (DateTime)service.StartDate;
                }

                if (service.EndDate != null)
                {
                    this.Form.EndDateTimePicker.Value = (DateTime)service.EndDate;
                }

                this.Form.QuantityTextBox.Text = service.Quantity.ToString();

                this.Form.Text = "Edycja usługi";
            }
            else
            {
                this.Form.Text = "Nowa usługa";
            }
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            DateTime startDate = this.Form.StartDateTimePicker.Value;
            DateTime endDate = this.Form.EndDateTimePicker.Value;
            int type;
            int.TryParse(this.Form.TypeComboBox.SelectedValue.ToString(), out type);
            var additionalInfo = this.Form.AdditionalInfoTextBox.Text;
            var customName = this.Form.CustomNameTextBox.Text;
            var customDescription = this.Form.CustomDescriptionTextBox.Text;
            int quantity;
            int.TryParse(this.Form.QuantityTextBox.Text, out quantity);

            if (startDate > endDate)
            {
                MessageBox.Show(
                    "Podane wartości nie są prawidłowe lub pozostawiono niewypełnione pola.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                this.Form.OkButton.DialogResult = DialogResult.None;
                return;
            }

            if (this.IsEditForm)
            {
                var service = DataAccess.Instance.Services.Single(r => r.Id == this.ItemToEditID);
                service.Quantity = quantity;
                service.AdditionalInfo = additionalInfo;
                service.CustomDescription = customDescription;
                service.CustomName = customName;
                service.TypeId = type;
                service.StartDate = startDate;
                service.EndDate = endDate;
            }
            else
            {
                var service = new Service
                {
                    Quantity = quantity,
                    AdditionalInfo = additionalInfo,
                    CustomDescription = customDescription,
                    CustomName = customName,
                    TypeId = type,
                    StartDate = startDate,
                    EndDate = endDate
                };

                DataAccess.Instance.Services.Add(service);
            }

            DataAccess.Instance.UnitOfWork.Commit();
            this.Form.OkButton.DialogResult = DialogResult.OK;
            this.Form.Dispose();
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            this.Form.Dispose();
        }

        #endregion
    }
}