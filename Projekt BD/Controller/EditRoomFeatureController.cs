namespace Projekt_BD.Controller
{
    using System;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.View;

    public class EditRoomFeatureController : ControllerBase
    {
        #region Constructors

        public EditRoomFeatureController()
        {
            base.Form = new EditRoomFeatureForm();

            this.SetupEvents();
        }

        #endregion

        #region Properties

        public new EditRoomFeatureForm Form
        {
            get
            {
                return base.Form as EditRoomFeatureForm;
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

        void CancelButton_Click(object sender, EventArgs e)
        {
            this.Form.Dispose();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (this.IsEditForm)
            {
                var feature = DataAccess.Instance.Features.Single(f => f.Id == this.ItemToEditID);
                this.Form.NameTextBox.Text = feature.Name;
                this.Form.DescriptionRichTextBox.Text = feature.Description;

                this.Form.Text = "Edycja udogodnienia";
            }
            else
            {
                this.Form.Text = "Nowe udogodnienie";
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            string featureName = this.Form.NameTextBox.Text;
            string featureDescription = this.Form.DescriptionRichTextBox.Text;

            if (string.IsNullOrEmpty(featureName) || string.IsNullOrEmpty(featureDescription))
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
                var feature = DataAccess.Instance.Features.Single(f => f.Id == this.ItemToEditID);
                feature.Name = featureName;
                feature.Description = featureDescription;
            }
            else
            {
                var feature = new Feature
                {
                    Name = featureName,
                    Description = featureDescription
                };

                DataAccess.Instance.Features.Add(feature);
            }

            DataAccess.Instance.UnitOfWork.Commit();

            this.Form.Dispose();
        }

        #endregion
    }
}
