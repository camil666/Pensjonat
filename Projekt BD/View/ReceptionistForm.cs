namespace Projekt_BD.View
{
    using System.Windows.Forms;

    public partial class ReceptionistForm : Form
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceptionistForm" /> class.
        /// </summary>
        public ReceptionistForm()
        {
            this.InitializeComponent();
            this.ClientSearchWindow = ControllerFactory.Instance.Create(ControllerTypes.ClientSearch).Form as ClientSearch;
            this.ClientSearchWindow.ParentForm = this;
            this.ClientSearchWindow.Show();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the client search window.
        /// </summary>
        /// <value>
        /// The client search window.
        /// </value>
        public ClientSearch ClientSearchWindow { get; private set; }

        /// <summary>
        /// Gets the value indicating whether client search is enabled.
        /// </summary>
        /// <value>
        /// Value indicating whether client search is enabled.
        /// </value>
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
