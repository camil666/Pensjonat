namespace Projekt_BD.Controller
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.Interfaces;
    using Projekt_BD.View;

    public class AdminFormController : ControllerBase
    {
        #region Constructors

        public AdminFormController()
        {
            base.Form = new AdminForm();

            this.SetupEvents();
            this.SearchButton_Function();
        }

        #endregion

        #region Properties

        public new AdminForm Form
        {
            get
            {
                return base.Form as AdminForm;
            }
        }

        private bool IsEmployeeSelected
        {
            get
            {
                return this.Form.SearchResultsDataGridView.SelectedRows.Count > 0;
            }
        }

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

        private void SetupEvents()
        {
            this.Form.SearchButton.Click += this.SearchButton_Click;
            this.Form.AddEmployeeButton.Click += this.AddEmployeeButton_Click;
            this.Form.DeleteEmployeeButton.Click += this.DeleteEmployeeButton_Click;
            this.Form.ChangeEmployeeDetailsButton.Click += this.ChangeEmployeeDetailsButton_Click;
        }

        private void SearchButton_Function()
        {
            // sprawdz czy szukanie po ID
            bool idSearch = false;
            int id;
            idSearch = int.TryParse(this.Form.IDSearchTextBox.Text, out id);

            try
            {
                var employees = (from e in DataAccess.Instance.Employees.GetAll().ToList()
                                 select new { e.Id, e.Username, e.FirstName, e.LastName, e.Email, e.Town }).ToList();

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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.SearchButton_Function();
        }

        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            ControllerFactory.Instance.Create(ControllerTypes.NewEmployeeForm).Form.ShowDialog();
            this.SearchButton_Function();
        }

        private void DeleteEmployeeButton_Click(object sender, EventArgs e)
        {
            if (this.IsEmployeeSelected)
            {
                DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć pracownika?", "Usuwanie pracownika", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DataAccess.Instance.Employees.Delete(DataAccess.Instance.Employees.Single(emp => emp.Id == this.SelectedEmployeeId));

                    DataAccess.Instance.UnitOfWork.Commit();

                    this.SearchButton_Function();
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

        private void ChangeEmployeeDetailsButton_Click(object sender, EventArgs e)
        {
            if (this.IsEmployeeSelected)
            {
                var controller = ControllerFactory.Instance.Create(ControllerTypes.NewEmployeeForm);
                controller.ItemToEditID = this.SelectedEmployeeId;
                controller.Form.ShowDialog();
                this.SearchButton_Function();
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

        }

        private void DeleteEmployeeButton_Click(object sender, EventArgs e)
        {
            if (this.IsEmployeeSelected)
            {
                DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć pracownika?", "Usuwanie pracownika", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DataAccess.Instance.Employees.Delete(DataAccess.Instance.Employees.Single(emp => emp.Id == this.SelectedEmployeeId));

                    DataAccess.Instance.UnitOfWork.Commit();

                    this.SearchButton_Function();
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

        private void ChangeEmployeeDetailsButton_Click(object sender, EventArgs e)
        {
            if (this.IsEmployeeSelected)
            {
                var controller = ControllerFactory.Instance.Create(ControllerTypes.NewEmployeeForm);
                controller.ItemToEditID = this.SelectedEmployeeId;
                controller.Form.ShowDialog();
                this.SearchButton_Function();
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
