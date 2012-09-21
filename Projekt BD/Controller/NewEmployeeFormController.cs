﻿namespace Projekt_BD.Controller
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Domain;
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

        private void Form_Load(object sender, EventArgs e)
        {
            var roles = DataAccess.Instance.Roles.GetAll().ToList();
            this.Form.RoleComboBox.DataSource = roles;
            this.Form.RoleComboBox.DisplayMember = "Name";
            this.Form.RoleComboBox.ValueMember = "Id";

            if (this.IsEditForm)
            {
                var employeeToModify = DataAccess.Instance.Employees.Single(emp => emp.Id == this.ItemToEditID);
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
                    this.Form.RoleComboBox.SelectedValue = employeeToModify.RoleId;
                }

                this.Form.Text = "Edycja pracownika";
            }
            else
            {
                this.Form.Text = "Nowy pracownik";
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Form.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Form.ApartmentNumberTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.EmailTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.FirstNameTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.HouseNumberTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.LastNameTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.PostCodeTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.StreetTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.PhoneNumberTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.TownTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.LoginTextBox.Text))
            {
                MessageBox.Show(
                    "Należy wpisać wymagane dane.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            if (this.IsEditForm)
            {
                var employeeToModify = DataAccess.Instance.Employees.Single(emp => emp.Id == this.ItemToEditID);

                employeeToModify.ApartmentNumber = this.Form.ApartmentNumberTextBox.Text;
                employeeToModify.Email = this.Form.EmailTextBox.Text;
                employeeToModify.FirstName = this.Form.FirstNameTextBox.Text;
                employeeToModify.HouseNumber = this.Form.HouseNumberTextBox.Text;
                employeeToModify.LastName = this.Form.LastNameTextBox.Text;
                employeeToModify.Password = this.Form.PasswordTextBox.Text;
                employeeToModify.PostCode = this.Form.PostCodeTextBox.Text;
                employeeToModify.Street = this.Form.StreetTextBox.Text;
                employeeToModify.TelephoneNumber = this.Form.PhoneNumberTextBox.Text;
                employeeToModify.Town = this.Form.TownTextBox.Text;
                employeeToModify.Username = this.Form.LoginTextBox.Text;
                employeeToModify.RoleId = (int)this.Form.RoleComboBox.SelectedValue;
            }
            else
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
                };

                DataAccess.Instance.Employees.Add(newEmployee);
            }

            DataAccess.Instance.UnitOfWork.Commit();

            this.Form.Close();
        }

        #endregion
    }
}
