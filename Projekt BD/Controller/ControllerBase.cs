namespace Projekt_BD.Controller
{
    using System.Windows.Forms;
    using Projekt_BD.Interfaces;

    public abstract class ControllerBase : IController
    {
        #region Properties

        public Form Form { get; protected set; }

        #endregion
    }
}
