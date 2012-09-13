namespace Projekt_BD.Controller
{
    using System;
    using System.Data;
    using System.Linq;
    using Domain;
    using Projekt_BD.Interfaces;
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
            this.Form.Load += Form_Load;
            this.Form.OkButton.Click += OkButton_Click;
        }

        #endregion

        #region Event Methods

        void Form_Load(object sender, EventArgs e)
        {
            if (this.Form.RoomTypeId != 0)
            {
                using (var context = new PensjonatContext())
                {
                    var roomType = context.RoomTypes.SingleOrDefault(x => x.Id == this.Form.RoomTypeId);
                    this.Form.DescriptionRichTextBox.Text = roomType.Description;
                    this.Form.PriceTextBox.Text = roomType.Price.ToString();
                    this.Form.PricePerPersonTextBox.Text = roomType.PricePerPerson.ToString();
                    this.Form.NameTextBox.Text = roomType.Name;
                }
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var roomType = new RoomType
            {
                Id = this.Form.RoomTypeId,
                Description = this.Form.DescriptionRichTextBox.Text,
                Name = this.Form.NameTextBox.Text,
                Price = double.Parse(this.Form.PriceTextBox.Text),
                PricePerPerson = double.Parse(this.Form.PricePerPersonTextBox.Text)
            };

            using (var context = new PensjonatContext())
            {
                context.AddToRoomTypes(roomType);
                if (roomType.Id != 0)
                {
                    context.ObjectStateManager.ChangeObjectState(roomType, EntityState.Modified);
                }

                context.SaveChanges();
            }

            this.Form.Dispose();
        }

        #endregion
    }
}
