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
                return ClientSearchEnabledStripMenuItem;
            }
        }

        public ReceptionistForm()
        {
            InitializeComponent();
            ClientSearchWindow = ControllerFactory.Instance.Create(ControllerTypes.ClientSearch).Form as ClientSearch;
            ClientSearchWindow.ParentForm = this;
            ClientSearchWindow.Show();
        }
    }
}
