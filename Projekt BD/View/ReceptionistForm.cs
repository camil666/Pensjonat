namespace Projekt_BD.View
{
    using System.Windows.Forms;

    public partial class ReceptionistForm : Form
    {
        #region Constructors

        public ReceptionistForm()
        {
            this.InitializeComponent();
            this.ClientSearchWindow = ControllerFactory.Instance.Create(ControllerTypes.ClientSearch).Form as ClientSearch;
            this.ClientSearchWindow.ParentForm = this;
            this.ClientSearchWindow.Show();
        }

        #endregion

        #region Properties

        public ClientSearch ClientSearchWindow { get; private set; }

        public ToolStripMenuItem ClientSearchEnabled
        {
            get
            {
                return this.ClientSearchEnabledStripMenuItem;
            }
        }

        #endregion
    }
}
