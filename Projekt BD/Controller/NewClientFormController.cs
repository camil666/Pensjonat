namespace Projekt_BD.Controller
{
    using System;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.Interfaces;
    using Projekt_BD.View;

    public class NewClientFormController : ControllerBase
    {
        #region Constructors

        public NewClientFormController()
        {
            base.Form = new NewClientForm();

            this.SetupEvents();
        }

        #endregion

        #region Properties

        public new NewClientForm Form
        {
            get
            {
                return base.Form as NewClientForm;
            }
        }

        #endregion

        #region Methods

        private void SetupEvents()
        {
            this.Form.CancelButton.Click += this.CancelButton_Click;
            this.Form.AddButton.Click += this.AddButton_Click;
        }

        #endregion

        #region Event Methods

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Form.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Form.FirstNameTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.LastNameTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.EmailTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.CountryTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.StreetTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.PostCodeTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.ApartmentNumberTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.HouseNumberTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.TownTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.PhoneNumberTextBox.Text))
            {
                MessageBox.Show(
                    "Nie wpisano wszystkich wymaganych danych.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            var newGuest = new Guest
            {
                FirstName = this.Form.FirstNameTextBox.Text,
                LastName = this.Form.LastNameTextBox.Text,
                Email = this.Form.EmailTextBox.Text,
                CountryId = this.Form.CountryTextBox.Text,
                Street = this.Form.StreetTextBox.Text,
                PostCode = this.Form.PostCodeTextBox.Text,
                ApartmentNumber = this.Form.ApartmentNumberTextBox.Text,
                HouseNumber = this.Form.HouseNumberTextBox.Text,
                Town = this.Form.TownTextBox.Text,
                CompanyName = this.Form.CompanyNameTextBox.Text,
                IdNumber = this.Form.IDNumberTextBox.Text,
                TelephoneNumber = this.Form.PhoneNumberTextBox.Text
            };

            //TODO: Dorobić weryfikację danych.
            DataAccess.Instance.Guests.Add(newGuest);

            DataAccess.Instance.UnitOfWork.Commit();

            this.Form.Close();
        }

        #endregion
    }
}
