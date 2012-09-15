namespace Projekt_BD.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using Domain;
    using Projekt_BD.Interfaces;
    using Projekt_BD.View;

    public class NewEmployeeFormController : ControllerBase
    {
        #region Constructors

        public NewEmployeeFormController()
        {
            base.Form = new NewEmployeeForm();  

            this.SetupEvents();
        }

        #endregion

        #region Properties

        public new NewEmployeeForm Form
        {
            get
            {
                return base.Form as NewEmployeeForm;
            }
        }

        #endregion

        #region Methods

        private void SetupEvents()
        {
            this.Form.Load += this.Form_Load;
            this.Form.CancelButton.Click += this.CancelButton_Click;
            this.Form.AddButton.Click += this.AddButton_Click;
        }

        #endregion

        #region Event Methods

        void Form_Load(object sender, EventArgs e)
        {
            this.Form.ActualEmployee = new Employee()
            {
                Id = this.Form.EmployeeId
            };

            if (this.Form.EmployeeId != 0)
            {
                using (var context = new PensjonatContext())
                {
                    var employeeToModify = context.Employees.SingleOrDefault(x => x.Id == this.Form.ActualEmployee.Id);
                    if (employeeToModify != null)
                    {
                        this.Form.LoginTextBox.Text = employeeToModify.Username;
                        this.Form.PasswordTextBox.Text = employeeToModify.Password;
                        this.Form.FirstNameTextBox.Text = employeeToModify.FirstName;
                        this.Form.LastNameTextBox.Text = employeeToModify.LastName;
                        this.Form.TownTextBox.Text = employeeToModify.Town;
                        this.Form.StreetTextBox.Text = employeeToModify.Street;
                        this.Form.HouseNumberTextBox.Text = employeeToModify.HouseNumber;
                        this.Form.ApartmentNumberTextBox.Text = employeeToModify.ApartmentNumber;
                        this.Form.PostCodeTextBox.Text = employeeToModify.PostCode;
                        this.Form.EmailTextBox.Text = employeeToModify.Email;
                        this.Form.PhoneNumberTextBox.Text = employeeToModify.TelephoneNumber;
                        this.Form.ActualEmployee = employeeToModify;
                    }
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Form.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var newEmployee = new Employee
            {
                ApartmentNumber = this.Form.ApartmentNumberTextBox.Text,
                Email = this.Form.EmailTextBox.Text,
                FirstName = this.Form.FirstNameTextBox.Text,
                HouseNumber = this.Form.HouseNumberTextBox.Text,
                LastName = this.Form.LastNameTextBox.Text,
                Password = this.Form.PasswordTextBox.Text,
                PostCode = this.Form.PostCodeTextBox.Text,
                Street = this.Form.StreetTextBox.Text,
                TelephoneNumber = this.Form.PhoneNumberTextBox.Text,
                Town = this.Form.TownTextBox.Text,
                Username = this.Form.LoginTextBox.Text,
                Id = this.Form.ActualEmployee.Id
            };

            using (var context = new PensjonatContext())
            {
                context.AddToEmployees(newEmployee);
                if (newEmployee.Id != 0)
                {
                    context.ObjectStateManager.ChangeObjectState(newEmployee, EntityState.Modified);
                }
                context.SaveChanges();
            }

            this.Form.Close();
        }

        #endregion
    }
}
