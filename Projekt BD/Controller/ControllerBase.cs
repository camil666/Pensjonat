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
            this.Context = new ObjectContextAdapter(new PensjonatContext());
            this.UnitOfWork = new UnitOfWork(this.Context);
        }

        #endregion

        #region Finalizer

        ~ControllerBase()
        {
            this.UnitOfWork.Dispose();
        }

        #endregion

        #region Properties

        public Form Form { get; protected set; }

        public int ClientID { get; set; }

        public int ItemToEditID { get; set; }

        protected ObjectContextAdapter Context { get; set; }

        protected UnitOfWork UnitOfWork { get; set; }

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
