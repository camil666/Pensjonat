namespace Projekt_BD.View
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Domain;

    public partial class ClientSearch : Form
    {
        #region Constructors

        public ClientSearch()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Properties

        public new ReceptionistForm ParentForm { get; set; }

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
