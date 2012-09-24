namespace Projekt_BD.Controller
{
    using System;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.View;

    /// <summary>
    /// Controller class for Login form.
    /// </summary>
    public class LoginFormController : ControllerBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginFormController" /> class.
        /// </summary>
        public LoginFormController()
        {
            base.Form = new LoginForm();

            this.SetupEvents();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the form.
        /// </summary>
        /// <value>
        /// The form.
        /// </value>
        public new LoginForm Form
        {
            get
            {
                return base.Form as LoginForm;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets up the events.
        /// </summary>
        private void SetupEvents()
        {
            this.Form.LoginButton.Click += this.LoginButton_Click;
            this.Form.LoginTextBox.KeyDown += this.TextBox_KeyDown;
            this.Form.PasswordTextBox.KeyDown += this.TextBox_KeyDown;
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// Handles the KeyDown event of the TextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Form.LoginButton.PerformClick();
            }
        }

        /// <summary>
        /// Handles the Click event of the LoginButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Form.LoginTextBox.Text))
            {
                MessageBox.Show(
                    "Należy wpisać login.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            if (string.IsNullOrEmpty(this.Form.PasswordTextBox.Text))
            {
                MessageBox.Show(
                    "Należy wpisać hasło.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            Employee employee = DataAccess.Instance.Employees.Single(emp => emp.Username == this.Form.LoginTextBox.Text);

            if (employee == null || employee.Password != this.Form.PasswordTextBox.Text)
            {
                MessageBox.Show(
                    "Wprowadzono błędne dane.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            Form mainForm = LoginHelper.CreateMainForm(employee.RoleId);
            CurrentUser.Instance.Id = employee.Id;

            if (mainForm != null)
            {
                mainForm.Show();
            }

            this.Form.Hide();
        }

        #endregion
    }
}
