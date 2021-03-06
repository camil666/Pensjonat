﻿namespace Projekt_BD.Controller
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.View;

    /// <summary>
    /// Controller for client search window. 
    /// </summary>
    public class ClientSearchController : ControllerBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientSearchController" /> class.
        /// </summary>
        public ClientSearchController()
        {
            base.Form = new ClientSearch();

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
        public new ClientSearch Form
        {
            get
            {
                return base.Form as ClientSearch;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets up the events.
        /// </summary>
        private void SetupEvents()
        {
            this.Form.ClientSearchButton.Click += this.ClientSearchButton_Click;
            this.Form.ClientSearchResultDataGridView.CellClick += this.ClientSearchResultDataGridView_CellClick;
            this.Form.FormClosing += this.FormClosing;
            this.Form.Load += this.Form_Load;
        }

        /// <summary>
        /// Searches for guests.
        /// </summary>
        private void SearchForGuests()
        {
            // sprawdz czy szukanie po ID
            bool idSearch = false;
            int id;
            idSearch = int.TryParse(this.Form.IDClientSearchTextBox.Text, out id);

            try
            {
                var clients = DataAccess.Instance.Guests.GetAll().ToList();

                if (!string.IsNullOrEmpty(this.Form.IDClientSearchTextBox.Text))
                {
                    clients = clients.Where(l => l.Id == id).ToList();
                }

                if (!string.IsNullOrEmpty(this.Form.FirstNameClientSearchTextBox.Text))
                {
                    clients = clients.Where(l => l.FirstName.ToLowerInvariant().Contains(this.Form.FirstNameClientSearchTextBox.Text.ToLowerInvariant())).ToList();
                }

                if (!string.IsNullOrEmpty(this.Form.LastNameClientSearchTextBox.Text))
                {
                    clients = clients.Where(l => l.LastName.ToLowerInvariant().Contains(this.Form.LastNameClientSearchTextBox.Text.ToLowerInvariant())).ToList();
                }

                if (!string.IsNullOrEmpty(this.Form.IDNumberClientSearchTextBox.Text))
                {
                    clients = clients.Where(l => l.IdNumber.ToLowerInvariant().Contains(this.Form.IDNumberClientSearchTextBox.Text.ToLowerInvariant())).ToList();
                }

                if (!string.IsNullOrEmpty(this.Form.EmailClientSearchTextBox.Text))
                {
                    clients = clients.Where(l => l.Email.ToLowerInvariant().Contains(this.Form.EmailClientSearchTextBox.Text.ToLowerInvariant())).ToList();
                }

                if (!string.IsNullOrEmpty(this.Form.CompanyNameClientSearchTextBox.Text))
                {
                    clients = clients.Where(l => l.CompanyName.ToLowerInvariant().Contains(this.Form.CompanyNameClientSearchTextBox.Text.ToLowerInvariant())).ToList();
                }

                if (!string.IsNullOrEmpty(this.Form.CountryClientSearchTextBox.Text))
                {
                    clients = clients.Where(l => l.CountryId.Contains(this.Form.CountryClientSearchTextBox.Text)).ToList();
                }

                if (!string.IsNullOrEmpty(this.Form.StreetClientSearchTextBox.Text))
                {
                    clients = clients.Where(l => l.Street.ToLowerInvariant().Contains(this.Form.StreetClientSearchTextBox.Text.ToLowerInvariant())).ToList();
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

                if (!string.IsNullOrEmpty(this.Form.TownClientSearchTextBox.Text))
                {
                    clients = clients.Where(l => l.Town.ToLowerInvariant().Contains(this.Form.TownClientSearchTextBox.Text.ToLowerInvariant())).ToList();
                }

                this.Form.ClientSearchResultDataGridView.DataSource = clients;

                if (clients.Count == 0)
                {
                    return;
                }

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
                this.Form.ClientSearchResultDataGridView.Columns["IsVerified"].HeaderText = "Zweryfikowany";
                this.Form.ClientSearchResultDataGridView.Columns["Discounts"].Visible = false;
                this.Form.ClientSearchResultDataGridView.Columns["Reservations"].Visible = false;
                this.Form.ClientSearchResultDataGridView.Columns["Visits"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Sends the client information to parent form.
        /// </summary>
        private void SendClientInformationToParentForm()
        {
            int guestId = (int)this.Form.ClientSearchResultDataGridView.SelectedRows[0].Cells["Id"].Value;

            Guest selectedGuest = DataAccess.Instance.Guests.Single(g => g.Id == guestId);

            this.Form.ParentForm.ApartmentNumberClientDetailsTextBox.Text = selectedGuest.ApartmentNumber;
            this.Form.ParentForm.CompanyNameClientDetailsTextBox.Text = selectedGuest.CompanyName;
            this.Form.ParentForm.IDClientDetailsTextBox.Text = selectedGuest.Id.ToString();
            this.Form.ParentForm.IDNumberClientDetailsTextBox.Text = selectedGuest.IdNumber;
            this.Form.ParentForm.CountryClientDetailsTextBox.Text = selectedGuest.CountryId;
            this.Form.ParentForm.EmailClientDetailsTextBox.Text = selectedGuest.Email;
            this.Form.ParentForm.FirstNameClientDetailsTextBox.Text = selectedGuest.FirstName;
            this.Form.ParentForm.HouseNumberClientDetailsTextBox.Text = selectedGuest.HouseNumber;
            this.Form.ParentForm.LastNameClientDetailsTextBox.Text = selectedGuest.LastName;
            this.Form.ParentForm.PhoneNumberClientDetailsTextBox.Text = selectedGuest.TelephoneNumber;
            this.Form.ParentForm.PostCodeClientDetailsTextBox.Text = selectedGuest.PostCode;
            this.Form.ParentForm.StreetClientDetailsTextBox.Text = selectedGuest.Street;
            this.Form.ParentForm.TownClientDetailsTextBox.Text = selectedGuest.Town;
            this.Form.ParentForm.VerifiedClientDetailsCheckBox.Checked = selectedGuest.IsVerified;
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// Handles the form closing event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs" /> instance containing the event data.</param>
        private void FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                this.Form.Hide();
                e.Cancel = true;
                this.Form.ParentForm.ClientSearchEnabled.Checked = false;
            }
        }

        /// <summary>
        /// Handles the Load event of the Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void Form_Load(object sender, EventArgs e)
        {
            this.SearchForGuests();
            if (this.Form.ClientSearchResultDataGridView.Rows.Count > 0)
            {
                this.Form.ClientSearchResultDataGridView.CurrentCell = this.Form.ClientSearchResultDataGridView.Rows[0].Cells[1];
            }

            this.SendClientInformationToParentForm();
        }

        /// <summary>
        /// Handles the CellClick event of the ClientSearchResultDataGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs" /> instance containing the event data.</param>
        private void ClientSearchResultDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.SendClientInformationToParentForm();
            }
        }

        /// <summary>
        /// Handles the Click event of the ClientSearchButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void ClientSearchButton_Click(object sender, EventArgs e)
        {
            this.SearchForGuests();
        }

        #endregion
    }
}
