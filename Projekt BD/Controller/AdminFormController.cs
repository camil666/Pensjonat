namespace Projekt_BD.Controller
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Projekt_BD.Enums;
    using Projekt_BD.View;

    /// <summary>
    /// Controller for Admin Form
    /// </summary>
    public class AdminFormController : ControllerBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminFormController" /> class.
        /// </summary>
        public AdminFormController()
        {
            base.Form = new AdminForm();

            this.SetupEvents();
            this.SearchForEmployees();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the form.
        /// </summary>
        /// <value>
        /// The form.
        /// </value>
        public new AdminForm Form
        {
            get
            {
                return base.Form as AdminForm;
            }
        }

        /// <summary>
        /// Gets a value indicating whether employee is selected.
        /// </summary>
        /// <value>
        /// <c>true</c> if employee is selected; otherwise, <c>false</c>.
        /// </value>
        private bool IsEmployeeSelected
        {
            get
            {
                return this.Form.SearchResultsDataGridView.SelectedRows.Count > 0;
            }
        }

        /// <summary>
        /// Gets the selected employee id.
        /// </summary>
        /// <value>
        /// The selected employee id.
        /// </value>
        private int SelectedEmployeeId
        {
            get
            {
                int selectedRowIndex = this.Form.SearchResultsDataGridView.SelectedRows[0].Index;
                return (int)this.Form.SearchResultsDataGridView[0, selectedRowIndex].Value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets up the events.
        /// </summary>
        private void SetupEvents()
        {
            this.Form.FormClosed += this.Form_Closed;
            this.Form.ExitToolStripMenuItem.Click += this.ExitToolStripMenuItem_Click;
            this.Form.AboutToolStripMenuItem.Click += this.AboutToolStripMenuItem_Click;
            this.Form.GetHelpToolStripMenuItem.Click += this.GetHelpToolStripMenuItem_Click;
            this.Form.SearchButton.Click += this.SearchButton_Click;
            this.Form.AddEmployeeButton.Click += this.AddEmployeeButton_Click;
            this.Form.DeleteEmployeeButton.Click += this.DeleteEmployeeButton_Click;
            this.Form.ChangeEmployeeDetailsButton.Click += this.ChangeEmployeeDetailsButton_Click;
        }

        /// <summary>
        /// Searches for employees.
        /// </summary>
        private void SearchForEmployees()
        {
            // sprawdz czy szukanie po ID
            bool idSearch = false;
            int id;
            idSearch = int.TryParse(this.Form.IDSearchTextBox.Text, out id);

            try
            {
                var employees = (from e in DataAccess.Instance.Employees.GetAll().Where(x => x.RoleId != (int)Roles.Root).ToList()
                                 select new { e.Id, e.Username, e.FirstName, e.LastName, e.Email, e.Town, e.Role.Name }).ToList();

                if (!string.IsNullOrEmpty(this.Form.IDSearchTextBox.Text))
                {
                    employees = employees.Where(l => l.Id == id).ToList();
                }

                if (!string.IsNullOrEmpty(this.Form.FirstNameSearchTextBox.Text))
                {
                    employees = employees.Where(l => l.FirstName.ToLowerInvariant().Contains(this.Form.FirstNameSearchTextBox.Text.ToLowerInvariant())).ToList();
                }

                if (!string.IsNullOrEmpty(this.Form.LastNameSearchTextBox.Text))
                {
                    employees = employees.Where(l => l.LastName.ToLowerInvariant().Contains(this.Form.LastNameSearchTextBox.Text.ToLowerInvariant())).ToList();
                }

                if (!string.IsNullOrEmpty(this.Form.LoginSearchTextBox.Text))
                {
                    employees = employees.Where(l => l.Username.ToLowerInvariant().Contains(this.Form.LoginSearchTextBox.Text.ToLowerInvariant())).ToList();
                }

                if (!string.IsNullOrEmpty(this.Form.EmailSearchTextBox.Text))
                {
                    employees = employees.Where(l => l.Email.ToLowerInvariant().Contains(this.Form.EmailSearchTextBox.Text.ToLowerInvariant())).ToList();
                }

                this.Form.SearchResultsDataGridView.DataSource = employees;

                this.Form.SearchResultsDataGridView.Columns["Id"].Visible = false;
                this.Form.SearchResultsDataGridView.Columns["Username"].HeaderText = "Login";
                this.Form.SearchResultsDataGridView.Columns["FirstName"].HeaderText = "Imię";
                this.Form.SearchResultsDataGridView.Columns["LastName"].HeaderText = "Nazwisko";
                this.Form.SearchResultsDataGridView.Columns["Name"].HeaderText = "Funkcja";
                this.Form.SearchResultsDataGridView.Columns["Email"].HeaderText = "E-mail";
                this.Form.SearchResultsDataGridView.Columns["Town"].HeaderText = "Miasto";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// Handles the Closed event of the Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void Form_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the Click event of the ExitToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the Click event of the AboutToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Pensjonat\n\nKamil Socha\nMarcin Koba\nDawid Mazur\n2012",
            "About",
            MessageBoxButtons.OK,
            MessageBoxIcon.Asterisk,
            MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Handles the Click event of the GetHelpToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void GetHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myProcess = new System.Diagnostics.Process();
            myProcess.StartInfo.FileName = "iexplore.exe";
            myProcess.StartInfo.Arguments = Application.StartupPath + "\\Help\\help.html";
            myProcess.Start();
        }

        /// <summary>
        /// Handles the Click event of the SearchButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.SearchForEmployees();
        }

        /// <summary>
        /// Handles the Click event of the AddEmployeeButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            ControllerFactory.Instance.Create(ControllerTypes.NewEmployeeForm).Form.ShowDialog();
            this.SearchForEmployees();
        }

        /// <summary>
        /// Handles the Click event of the DeleteEmployeeButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void DeleteEmployeeButton_Click(object sender, EventArgs e)
        {
            if (this.IsEmployeeSelected)
            {
                DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć pracownika?", "Usuwanie pracownika", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DataAccess.Instance.Employees.Delete(DataAccess.Instance.Employees.Single(emp => emp.Id == this.SelectedEmployeeId));

                    DataAccess.Instance.UnitOfWork.Commit();

                    this.SearchForEmployees();
                }
            }
            else
            {
                MessageBox.Show(
                    "Należy zaznaczyć pracownika",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Handles the Click event of the ChangeEmployeeDetailsButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void ChangeEmployeeDetailsButton_Click(object sender, EventArgs e)
        {
            if (this.IsEmployeeSelected)
            {
                var controller = ControllerFactory.Instance.Create(ControllerTypes.NewEmployeeForm);
                controller.ItemToEditID = this.SelectedEmployeeId;
                controller.Form.ShowDialog();
                this.SearchForEmployees();
            }
            else
            {
                MessageBox.Show(
                    "Należy zaznaczyć pracownika",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        #endregion
    }
}