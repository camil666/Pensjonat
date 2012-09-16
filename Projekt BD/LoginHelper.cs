namespace Projekt_BD
{
    using System.Windows.Forms;

    public class LoginHelper
    {
        #region Methods

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
