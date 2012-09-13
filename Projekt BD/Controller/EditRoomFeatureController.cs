namespace Projekt_BD.Controller
{
    using System;
    using System.Data;
    using System.Linq;
    using Domain;
    using Projekt_BD.Interfaces;
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
            this.Form.Load += Form_Load;
            this.Form.OkButton.Click += OkButton_Click;
        }

        #endregion

        #region Event Methods

        void Form_Load(object sender, EventArgs e)
        {
            if (this.Form.FeatureId != 0)
            {
                using (var context = new PensjonatContext())
                {
                    var feature = context.Features.SingleOrDefault(x => x.Id == this.Form.FeatureId);
                    this.Form.NameTextBox.Text = feature.Name;
                    this.Form.DescriptionRichTextBox.Text = feature.Description;
                }
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var feature = new Feature { Id = this.Form.FeatureId, Name = this.Form.NameTextBox.Text, Description = this.Form.DescriptionRichTextBox.Text };

            using (var context = new PensjonatContext())
            {
                context.AddToFeatures(feature);
                if (feature.Id != 0)
                {
                    context.ObjectStateManager.ChangeObjectState(feature, EntityState.Modified);
                }

                context.SaveChanges();
            }

            this.Form.Dispose();
        }

        #endregion
    }
}
