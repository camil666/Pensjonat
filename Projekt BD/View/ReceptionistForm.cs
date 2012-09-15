namespace Projekt_BD.View
{
    using System.Windows.Forms;

    public partial class ReceptionistForm : Form
    {
        public ClientSearch ClientSearchWindow { get; private set; }

        public ToolStripMenuItem ClientSearchEnabled
        {
            get
            {
                return this.ClientSearchEnabledStripMenuItem;
            }
        }

        public ReceptionistForm()
        {
            InitializeComponent();
            this.ClientSearchWindow = ControllerFactory.Instance.Create(ControllerTypes.ClientSearch).Form as ClientSearch;
            this.ClientSearchWindow.ParentForm = this;
            this.ClientSearchWindow.Show();
        }
    }
}
