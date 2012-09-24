namespace Projekt_BD.View
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Domain;

    public partial class ClientSearch : Form
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientSearch" /> class.
        /// </summary>
        public ClientSearch()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the form that the container control is assigned to.
        /// </summary>
        /// <returns>The <see cref="T:System.Windows.Forms.Form" /> that the container control is assigned to. This property will return null if the control is hosted inside of Internet Explorer or in another hosting context where there is no parent form. </returns>
        public new ReceptionistForm ParentForm { get; set; }

        /// <summary>
        /// Gets the selected client ID.
        /// </summary>
        /// <value>
        /// The selected client ID.
        /// </value>
        public int SelectedClientID
        {
            get
            {
                int selectedCellCount = this.ClientSearchResultDataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedCellCount > 0)
                {
                    return (int)this.ClientSearchResultDataGridView.SelectedRows[0].Cells["id"].Value;
                }
                else
                {
                    return 0;
                }
            }
        }

        #endregion
    }
}
