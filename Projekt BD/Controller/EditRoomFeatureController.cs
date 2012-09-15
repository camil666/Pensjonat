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

            this.Features = new Repository<Feature>(Context);
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

        private Repository<Feature> Features { get; set; }

        #endregion

        #region Methods

        private void SetupEvents()
        {
            this.Form.Load += Form_Load;
            this.Form.OkButton.Click += OkButton_Click;
        }

        #endregion

        #region Event Methods

        private void Form_Load(object sender, EventArgs e)
        {
            if (this.IsEditForm)
            {
                var feature = Features.Single(f => f.Id == this.ItemToEditID);
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
                var feature = Features.Single(f => f.Id == this.ItemToEditID);
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

                Features.Add(feature);
            }

            this.UnitOfWork.Commit();

            this.Form.Dispose();
        }

        #endregion
    }
}
