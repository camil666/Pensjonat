namespace Projekt_BD.Interfaces
{
    using System.Windows.Forms;

    public interface IController
    {
        #region Properties

        Form Form { get; }

        int ClientID { get; set; }

        int ItemToEditID { get; set; }

        #endregion
    }
}
