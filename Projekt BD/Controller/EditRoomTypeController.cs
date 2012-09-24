namespace Projekt_BD.Controller
{
    using System;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.View;

    /// <summary>
    /// Controller class for EditRoomType form.
    /// </summary>
    public class EditRoomTypeController : ControllerBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EditRoomTypeController" /> class.
        /// </summary>
        public EditRoomTypeController()
        {
            base.Form = new EditRoomTypeForm();

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
        public new EditRoomTypeForm Form
        {
            get
            {
                return base.Form as EditRoomTypeForm;
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
            this.Form.CancelButton.Click += this.CancelButton_Click;
        }

        #endregion

        #region Event Methods

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
        /// Handles the Load event of the Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void Form_Load(object sender, EventArgs e)
        {
            if (this.IsEditForm)
            {
                var roomType = DataAccess.Instance.RoomTypes.Single(f => f.Id == this.ItemToEditID);
                this.Form.DescriptionRichTextBox.Text = roomType.Description;
                this.Form.PriceTextBox.Text = roomType.Price.ToString();

                if (roomType.PricePerPerson != null)
                {
                    this.Form.PricePerPersonTextBox.Text = roomType.PricePerPerson.ToString();
                }

                this.Form.NameTextBox.Text = roomType.Name;

                this.Form.Text = "Edycja typu pokoju";
            }
            else
            {
                this.Form.Text = "Nowy typ pokoju";
            }
        }

        /// <summary>
        /// Handles the Click event of the OkButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            string description = this.Form.DescriptionRichTextBox.Text;
            string typeName = this.Form.NameTextBox.Text;
            double price = 0;
            double pricePerPerson = 0;

            double.TryParse(this.Form.PriceTextBox.Text, out price);
            double.TryParse(this.Form.PricePerPersonTextBox.Text, out pricePerPerson);

            if (string.IsNullOrEmpty(description) || string.IsNullOrEmpty(typeName) || price <= 0 || pricePerPerson <= 0)
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
                var roomType = DataAccess.Instance.RoomTypes.Single(f => f.Id == this.ItemToEditID);
                roomType.Description = description;
                roomType.Name = typeName;
                roomType.Price = price;
                roomType.PricePerPerson = pricePerPerson;
            }
            else
            {
                var roomType = new RoomType
                {
                    Description = description,
                    Name = typeName,
                    Price = price,
                    PricePerPerson = pricePerPerson
                };

                DataAccess.Instance.RoomTypes.Add(roomType);
            }

            DataAccess.Instance.UnitOfWork.Commit();

            this.Form.Dispose();
        }

        #endregion
    }
}
