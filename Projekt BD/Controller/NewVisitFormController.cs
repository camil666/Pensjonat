namespace Projekt_BD.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Projekt_BD.Interfaces;
    using Projekt_BD.View;

    public class NewVisitFormController : ControllerBase
    {
        #region Constructors

        public NewVisitFormController()
        {
            base.Form = new NewVisitForm();

            this.SetupEvents();
        }

        #endregion

        #region Properties

        public new NewVisitForm Form
        {
            get
            {
                return base.Form as NewVisitForm;
            }
        }

        #endregion

        #region Methods

        private void SetupEvents()
        {
            this.Form.CancelButton.Click += this.CancelButton_Click;
        }

        #endregion

        #region Event Methods

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Form.Close();
        }

        #endregion
    }
}
