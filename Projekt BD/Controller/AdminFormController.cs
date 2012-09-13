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
            //sprawdz czy szukanie po ID
            bool idSearch = false;
            int id;
            idSearch = int.TryParse(this.Form.IDSearchTextBox.Text, out id);

            try
            {
                using (var context = new PensjonatContext())
                {
                    var employees = context.Employees.ToList();

                    if (!string.IsNullOrEmpty(this.Form.IDSearchTextBox.Text))
                    {
                        employees = employees.Where(l => l.Id == id).ToList();
                    }

                    if (!string.IsNullOrEmpty(this.Form.FirstNameSearchTextBox.Text))
                    {
                        employees = employees.Where(l => l.FirstName.Contains(this.Form.FirstNameSearchTextBox.Text)).ToList();
                    }

                    if (!string.IsNullOrEmpty(this.Form.LastNameSearchTextBox.Text))
                    {
                        employees = employees.Where(l => l.LastName.Contains(this.Form.LastNameSearchTextBox.Text)).ToList();
                    }

                    if (!string.IsNullOrEmpty(this.Form.LoginSearchTextBox.Text))
                    {
                        employees = employees.Where(l => l.Username.Contains(this.Form.LoginSearchTextBox.Text)).ToList();
                    }

                    if (!string.IsNullOrEmpty(this.Form.EmailSearchTextBox.Text))
                    {
                        employees = employees.Where(l => l.Email.Contains(this.Form.EmailSearchTextBox.Text)).ToList();
                    }

                    this.Form.SearchResultsDataGridView.DataSource = employees;
                }
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
            //var newEmployeeForm = new NewEmployeeForm(0);
            //newEmployeeForm.ShowDialog();
        }

        private void DeleteEmployeeButton_Click(object sender, EventArgs e)
        {
            int selectedCellCount = this.Form.SearchResultsDataGridView.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                int rowIndex = this.Form.SearchResultsDataGridView.SelectedCells[0].RowIndex;
                int id = (int)this.Form.SearchResultsDataGridView[0, rowIndex].Value;

                using (var context = new PensjonatContext())
                {
                    var employee = new Employee() { Id = id };
                    context.Employees.Attach(employee);
                    context.Employees.DeleteObject(employee);
                    context.SaveChanges();
                }

                this.SearchButton_Function();
            }
        }

        private void ChangeEmployeeDetailsButton_Click(object sender, EventArgs e)
        {
            int selectedCellCount = this.Form.SearchResultsDataGridView.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                int rowIndex = this.Form.SearchResultsDataGridView.SelectedCells[0].RowIndex;
                int employeeId = (int)this.Form.SearchResultsDataGridView[0, rowIndex].Value;
                //var changeEmployeeDetailsForm = new NewEmployeeForm(employeeId);
                //changeEmployeeDetailsForm.ShowDialog();
                var form = ControllerFactory.Instance.Create(ControllerTypes.NewEmployeeForm).Form;
                (form as NewEmployeeForm).EmployeeId = employeeId;
                form.ShowDialog();
                this.SearchButton_Function();
            }
        }

        #endregion
    }
}
