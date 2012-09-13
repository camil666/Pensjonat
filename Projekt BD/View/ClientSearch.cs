namespace Projekt_BD.View
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Domain;

    public partial class ClientSearch : Form
    {
        public ReceptionistForm ParentForm { get; set; }

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

        public ClientSearch()
        {
            InitializeComponent();
        }

        private void ClientSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                Hide();
                e.Cancel = true;
                this.ParentForm.ClientSearchEnabled.Checked = false;
            }
        }
    }
}
