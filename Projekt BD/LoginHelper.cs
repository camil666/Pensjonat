namespace Projekt_BD
{
    using System.Windows.Forms;

    using Projekt_BD.Enums;

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
                case (int)Roles.Administrator:
                    return ControllerFactory.Instance.Create(ControllerTypes.AdminForm).Form;
                case (int)Roles.Receptionist:
                    return ControllerFactory.Instance.Create(ControllerTypes.ReceptionistForm).Form;
                case (int)Roles.Manager:
                    return ControllerFactory.Instance.Create(ControllerTypes.ManagerForm).Form;
                case (int)Roles.Employee:
                    return ControllerFactory.Instance.Create(ControllerTypes.EmployeeForm).Form;
                case (int)Roles.Root:
                    return ControllerFactory.Instance.Create(ControllerTypes.AdminForm).Form;
                default:
                    return ControllerFactory.Instance.Create(ControllerTypes.EmployeeForm).Form;
            }
        }

        #endregion
    }
}
