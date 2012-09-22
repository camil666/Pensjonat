namespace Projekt_BD.Controller
{
    using System;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.View;

    public class EditServiceFormController : ControllerBase
    {

        #region Constructors

        public EditServiceFormController()
        {
            base.Form = new EditServiceForm();

            this.SetupEvents();
        }

        #endregion

        #region Properties

        public new EditServiceForm Form
        {
            get
            {
                return base.Form as EditServiceForm;
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

        private void Form_Load(object sender, EventArgs e)
        {
            if (this.IsEditForm)
            {
                var serviceType = DataAccess.Instance.ServiceTypes.Single(f => f.Id == this.ItemToEditID);
                this.Form.DescriptionRichTextBox.Text = serviceType.Description;
                this.Form.ChargeTextBox.Text = serviceType.Charge.ToString();

                this.Form.NameTextBox.Text = serviceType.Name;

                this.Form.Text = "Edycja typu us³ugi";
            }
            else
            {
                this.Form.Text = "Nowy typ us³ugi";
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            string description = this.Form.DescriptionRichTextBox.Text;
            string name = this.Form.NameTextBox.Text;
            double charge = 0;

            double.TryParse(this.Form.ChargeTextBox.Text, out charge);

            if (string.IsNullOrEmpty(description) || string.IsNullOrEmpty(name) || charge <= 0)
            {
                MessageBox.Show(
                    "Podane wartoœci nie s¹ prawid³owe lub pozostawiono niewype³nione pola.",
                    "B³¹d",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            if (this.IsEditForm)
            {
                var serviceType = DataAccess.Instance.ServiceTypes.Single(f => f.Id == this.ItemToEditID);
                serviceType.Description = description;
                serviceType.Name = name;
                serviceType.Charge = charge;
            }
            else
            {
                var serviceType = new ServiceType()
                {
                    Description = description,
                    Name = name,
                    Charge = charge
                };

                DataAccess.Instance.ServiceTypes.Add(serviceType);
            }

            DataAccess.Instance.UnitOfWork.Commit();

            this.Form.Dispose();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Form.Dispose();
        }

        #endregion
    }
}