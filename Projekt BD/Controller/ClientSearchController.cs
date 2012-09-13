﻿namespace Projekt_BD.Controller
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.Interfaces;
    using Projekt_BD.View;

    public class ClientSearchController : ControllerBase
    {
        #region Constructors

        public ClientSearchController()
        {
            base.Form = new ClientSearch();
            
            this.SetupEvents();
        }

        #endregion

        #region Properties

        public new ClientSearch Form
        {
            get
            {
                return base.Form as ClientSearch;
            }
        }

        #endregion

        #region Methods

        private void SetupEvents()
        {
            this.Form.ClientSearchButton.Click += this.ClientSearchButton_Click;
        }

        #endregion

        #region Event Methods

        private void ClientSearchButton_Click(object sender, EventArgs e)
        {
            //sprawdz czy szukanie po ID
            bool idSearch = false;
            int id;
            idSearch = int.TryParse(this.Form.IDClientSearchTextBox.Text, out id);

            using (var context = new PensjonatContext())
            {
                try
                {
                    var clients = context.Guests.ToList();

                    if (!string.IsNullOrEmpty(this.Form.IDClientSearchTextBox.Text))
                    {
                        clients = clients.Where(l => l.Id == id).ToList();
                    }

                    if (!string.IsNullOrEmpty(this.Form.FirstNameClientSearchTextBox.Text))
                    {
                        clients = clients.Where(l => l.FirstName.Contains(this.Form.FirstNameClientSearchTextBox.Text)).ToList();
                    }

                    if (!string.IsNullOrEmpty(this.Form.LastNameClientSearchTextBox.Text))
                    {
                        clients = clients.Where(l => l.LastName.Contains(this.Form.LastNameClientSearchTextBox.Text)).ToList();
                    }

                    if (!string.IsNullOrEmpty(this.Form.IDNumberClientSearchTextBox.Text))
                    {
                        clients = clients.Where(l => l.IdNumber.Contains(this.Form.IDNumberClientSearchTextBox.Text)).ToList();
                    }

                    if (!string.IsNullOrEmpty(this.Form.EmailClientSearchTextBox.Text))
                    {
                        clients = clients.Where(l => l.Email.Contains(this.Form.EmailClientSearchTextBox.Text)).ToList();
                    }

                    if (!string.IsNullOrEmpty(this.Form.CompanyNameClientSearchTextBox.Text))
                    {
                        clients = clients.Where(l => l.CompanyName.Contains(this.Form.CompanyNameClientSearchTextBox.Text)).ToList();
                    }

                    if (!string.IsNullOrEmpty(this.Form.CountryClientSearchTextBox.Text))
                    {
                        clients = clients.Where(l => l.CountryId.Contains(this.Form.CountryClientSearchTextBox.Text)).ToList();
                    }

                    if (!string.IsNullOrEmpty(this.Form.StreetClientSearchTextBox.Text))
                    {
                        clients = clients.Where(l => l.Street.Contains(this.Form.StreetClientSearchTextBox.Text)).ToList();
                    }

                    if (!string.IsNullOrEmpty(this.Form.HouseNumberClientSearchTextBox.Text))
                    {
                        clients = clients.Where(l => l.HouseNumber.Contains(this.Form.HouseNumberClientSearchTextBox.Text)).ToList();
                    }

                    if (!string.IsNullOrEmpty(this.Form.ApartmentNumberClientSearchTextBox.Text))
                    {
                        clients = clients.Where(l => l.ApartmentNumber.Contains(this.Form.ApartmentNumberClientSearchTextBox.Text)).ToList();
                    }

                    if (!string.IsNullOrEmpty(this.Form.PostCodeClientSearchTextBox.Text))
                    {
                        clients = clients.Where(l => l.PostCode.Contains(this.Form.PostCodeClientSearchTextBox.Text)).ToList();
                    }

                    if (!string.IsNullOrEmpty(this.Form.PhoneClientSearchTextBox.Text))
                    {
                        clients = clients.Where(l => l.TelephoneNumber.Contains(this.Form.PhoneClientSearchTextBox.Text)).ToList();
                    }

                    if (!string.IsNullOrEmpty(this.Form.PostCodeClientSearchTextBox.Text))
                    {
                        clients = clients.Where(l => l.PostCode.Contains(this.Form.PostCodeClientSearchTextBox.Text)).ToList();
                    }

                    this.Form.ClientSearchResultDataGridView.DataSource = clients;

                    this.Form.ClientSearchResultDataGridView.Columns["Id"].Visible = false;
                    this.Form.ClientSearchResultDataGridView.Columns["FirstName"].HeaderText = "Imię";
                    this.Form.ClientSearchResultDataGridView.Columns["LastName"].HeaderText = "Nazwisko";
                    this.Form.ClientSearchResultDataGridView.Columns["Email"].HeaderText = "E-mail";
                    this.Form.ClientSearchResultDataGridView.Columns["IdNumber"].HeaderText = "Numer dokumentu tożsamości";
                    this.Form.ClientSearchResultDataGridView.Columns["Town"].HeaderText = "Miejscowość";
                    this.Form.ClientSearchResultDataGridView.Columns["Street"].HeaderText = "Ulica";
                    this.Form.ClientSearchResultDataGridView.Columns["HouseNumber"].HeaderText = "Nr domu";
                    this.Form.ClientSearchResultDataGridView.Columns["ApartmentNumber"].HeaderText = "Nr mieszkania";
                    this.Form.ClientSearchResultDataGridView.Columns["PostCode"].HeaderText = "Kod pocztowy";
                    this.Form.ClientSearchResultDataGridView.Columns["CompanyName"].HeaderText = "Firma";
                    this.Form.ClientSearchResultDataGridView.Columns["CountryId"].HeaderText = "Kraj";
                    this.Form.ClientSearchResultDataGridView.Columns["Discounts"].Visible = false;
                    this.Form.ClientSearchResultDataGridView.Columns["Reservations"].Visible = false;
                    this.Form.ClientSearchResultDataGridView.Columns["Visits"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.Message);
                }
            }
        }

        #endregion
    }
}
