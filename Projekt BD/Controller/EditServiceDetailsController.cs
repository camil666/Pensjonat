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
        /// Holds single service.
        /// </summary>
        private Service service;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EditServiceDetailsController" /> class.
        /// </summary>
        public EditServiceDetailsController()
        {
            base.Form = new EditServiceDetails();

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
                this.service = DataAccess.Instance.Services.Single(x => x.Id == this.ItemToEditID);
                this.Form.TypeComboBox.Text = availableTypes.Where(x => x.Key == this.service.TypeId).Select(x => x.Value).FirstOrDefault();

                this.Form.CustomNameTextBox.Text = this.service.CustomName;
                this.Form.CustomDescriptionTextBox.Text = this.service.CustomDescription;
                this.Form.AdditionalInfoTextBox.Text = this.service.AdditionalInfo;
                if (this.service.StartDate != null)
                {
                    this.Form.StartDateTimePicker.Value = (DateTime)this.service.StartDate;
                }

                if (this.service.EndDate != null)
                {
                    this.Form.EndDateTimePicker.Value = (DateTime)this.service.EndDate;
                }

                this.Form.QuantityTextBox.Text = this.service.Quantity.ToString();

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
            DateTime endDate = this.Form.EndDateTimePicker.Value.AddSeconds(1.0);
            int type;
            int.TryParse(this.Form.TypeComboBox.SelectedValue.ToString(), out type);
            var additionalInfo = this.Form.AdditionalInfoTextBox.Text;
            var customName = this.Form.CustomNameTextBox.Text;
            var customDescription = this.Form.CustomDescriptionTextBox.Text;
            int quantity = 0;
            int.TryParse(this.Form.QuantityTextBox.Text, out quantity);

            var visit = DataAccess.Instance.Visits.Single(x => x.Id == this.SecondaryId);

            if ((visit.StartDate > startDate) || (visit.EndDate < endDate))
            {
                MessageBox.Show(
                        "Usługa nie może znajdować się poza datą wizyty!",
                        "Błąd",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1);

                return;
            }

            if (startDate >= endDate || quantity <= 0)
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
                this.service.Quantity = quantity;
                this.service.AdditionalInfo = additionalInfo;
                this.service.CustomDescription = customDescription;
                this.service.CustomName = customName;
                this.service.TypeId = type;
                this.service.StartDate = startDate;
                this.service.EndDate = endDate;
            }
            else
            {
                this.service = new Service
                {
                    Quantity = quantity,
                    AdditionalInfo = additionalInfo,
                    CustomDescription = customDescription,
                    CustomName = customName,
                    TypeId = type,
                    StartDate = startDate,
                    EndDate = endDate,
                    VisitId = this.SecondaryId
                };

                DataAccess.Instance.Services.Add(this.service);
            }

            DataAccess.Instance.UnitOfWork.Commit();
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