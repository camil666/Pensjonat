﻿namespace Projekt_BD.Controller
{
    using System;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.View;

    public class LoginFormController : ControllerBase
    {
        #region Constructors

        public LoginFormController()
        {
            base.Form = new LoginForm();

            this.SetupEvents();
        }

        #endregion

        #region Properties

        public new LoginForm Form
        {
            get
            {
                return base.Form as LoginForm;
            }
        }

        #endregion

        #region Methods

        private void SetupEvents()
        {
            this.Form.LoginButton.Click += LoginButton_Click;
            this.Form.LoginTextBox.KeyDown += TextBox_KeyDown;
            this.Form.PasswordTextBox.KeyDown += TextBox_KeyDown;
        }

        #endregion

        #region Event Methods

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Form.LoginButton.PerformClick();
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Form.LoginTextBox.Text))
            {
                MessageBox.Show("Należy wpisać login.",
                "Błąd",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);

                return;
            }

            if (string.IsNullOrEmpty(this.Form.PasswordTextBox.Text))
            {
                MessageBox.Show("Należy wpisać hasło.",
                "Błąd",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);

                return;
            }

            var employeeRepository = new Repository<Employee>(Context);

            Employee employee = employeeRepository.Single(emp => emp.Username == this.Form.LoginTextBox.Text);

            if (employee == null || employee.Password != this.Form.PasswordTextBox.Text)
            {
                MessageBox.Show("Wprowadzono błędne dane.",
                "Błąd",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);

                return;
            }

            switch (employee.Role)
            {
                case 0:
                    ControllerFactory.Instance.Create(ControllerTypes.AdminForm).Form.Show();
                    break;
                case 1:
                    ControllerFactory.Instance.Create(ControllerTypes.ReceptionistForm).Form.Show();
                    break;
            }

            this.Form.Hide();

            Context.Dispose();
        }

        #endregion
    }
}
