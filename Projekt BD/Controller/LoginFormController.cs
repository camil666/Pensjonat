namespace Projekt_BD.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Projekt_BD.Interfaces;
    using Projekt_BD.View;

    public class LoginFormController : ControllerBase
    {
        #region Constructors

        public LoginFormController()
        {
            base.Form = new LoginForm();

            this.SetupEvents();
        }

        #endregion

        #region Properties

        public new LoginForm Form
        {
            get
            {
                return base.Form as LoginForm;
            }
        }

        #endregion

        #region Methods

        private void SetupEvents()
        {

        }

        #endregion

        #region Event Methods

        #endregion
    }
}
