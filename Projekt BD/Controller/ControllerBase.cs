namespace Projekt_BD.Controller
{
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.Interfaces;

    public abstract class ControllerBase : IController
    {
        #region Constructors

        public ControllerBase()
        {
        }

        #endregion

        #region Properties

        public Form Form { get; protected set; }

        public int ClientID { get; set; }

        public int ItemToEditID { get; set; }

        public int EmployeeIdForManagerController { get; set; }

        public int VisitIdForServiceController { get; set; }

        protected bool IsEditForm
        {
            get
            {
                return this.ItemToEditID > 0;
            }
        }

        #endregion
    }
}
