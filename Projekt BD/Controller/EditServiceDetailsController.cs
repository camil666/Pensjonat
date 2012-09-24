namespace Projekt_BD.Controller
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.View;

    /// <summary>
    /// Controller class for EditServiceDetails form.
    /// </summary>
    public class EditServiceDetailsController : ControllerBase
    {
        #region Fields

        /// <summary>
        /// Name of the Id column.
        /// </summary>
        private static readonly string IdColumnName = "Id";

        /// <summary>
        /// Name of the Name column.
        /// </summary>
        private static readonly string NameColumnName = "Name";

        /// <summary>
        /// Name of the IsAdded column.
        /// </summary>
        private static readonly string IsAddedColumnName = "IsAdded";

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EditServiceDetailsController" /> class.
        /// </summary>
        public EditServiceDetailsController()
        {
            base.Form = new EditServiceDetails();

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
        public new EditServiceDetails Form
        {
            get
            {
                return base.Form as EditServiceDetails;
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
            this.Form.CancButton.Click += this.CancelButton_Click;
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// Sets up the buttons.
        /// </summary>
        private void SetupButtons()
        {
            this.Form.OkButton.DialogResult = DialogResult.OK;
            this.Form.CancButton.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the Load event of the Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the OkButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void OkButton_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Handles the Click event of the CancelButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Form.Dispose();
        }

        #endregion
    }
}