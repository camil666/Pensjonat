namespace Projekt_BD.Controller
{
    using System;
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

            this.Guests = new Repository<Guest>(Context);
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

        private Repository<Guest> Guests { get; set; }

        #endregion

        #region Methods

        private void SetupEvents()
        {
            this.Form.CancelButton.Click += CancelButton_Click;
            this.Form.AddButton.Click += AddButton_Click;
        }

        #endregion

        #region Event Methods

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Form.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
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
            this.Guests.Add(newGuest);

            this.UnitOfWork.Commit();

            this.Form.Close();
        }

        #endregion
    }
}
