﻿namespace Projekt_BD
{
    using System.Windows.Forms;

    /// <summary>
    /// Helper class for creating forms for different users.
    /// </summary>
    public class LoginHelper
    {
        #region Methods

        /// <summary>
        /// Creates the main form for user of given roleId.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <returns>Created form.</returns>
        public static Form CreateMainForm(int? roleId)
        {
            switch (roleId)
            {
                case 0:
                    return ControllerFactory.Instance.Create(ControllerTypes.AdminForm).Form;
                case 1:
                    return ControllerFactory.Instance.Create(ControllerTypes.ReceptionistForm).Form;
                default:
                    return null;
            }
        }

        #endregion
    }
}