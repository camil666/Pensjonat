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
            Context = new ObjectContextAdapter(new PensjonatContext());
            UnitOfWork = new UnitOfWork(Context);
        }

        #endregion

        #region Properties

        protected ObjectContextAdapter Context { get; set; }

        protected UnitOfWork UnitOfWork { get; set; }

        public Form Form { get; protected set; }

        #endregion
    }
}
