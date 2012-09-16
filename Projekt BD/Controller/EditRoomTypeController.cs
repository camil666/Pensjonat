namespace Projekt_BD.Controller
{
    using System;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.View;

    public class EditRoomTypeController : ControllerBase
    {
        #region Constructors

        public EditRoomTypeController()
        {
            base.Form = new EditRoomTypeForm();

            this.SetupEvents();
        }

        #endregion

        #region Properties

        public new EditRoomTypeForm Form
        {
            get
            {
                return base.Form as EditRoomTypeForm;
            }
        }

        #endregion

        #region Methods

        private void SetupEvents()
        {
            this.Form.Load += this.Form_Load;
            this.Form.OkButton.Click += this.OkButton_Click;
            this.Form.CancelButton.Click += this.CancelButton_Click;
        }

        #endregion

        #region Event Methods

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Form.Dispose();
        }

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
