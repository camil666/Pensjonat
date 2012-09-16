namespace Projekt_BD.Controller
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
            this.Form.ClientSearchResultDataGridView.CellClick += this.ClientSearchResultDataGridView_CellClick;
            this.Form.FormClosing += this.FormClosing;
        }

        #endregion

        #region Event Methods

        private void FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                this.Form.Hide();
                e.Cancel = true;
                this.Form.ParentForm.ClientSearchEnabled.Checked = false;
            }
        }

        private void ClientSearchResultDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                int guestId = (int)this.Form.ClientSearchResultDataGridView.Rows[e.RowIndex].Cells["Id"].Value;

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
        }

        private void ClientSearchButton_Click(object sender, EventArgs e)
        {
            //sprawdz czy szukanie po ID
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

                //TODO: szukanie po nazwie kraju a nie jego id, albo zmiana bazy
                //if (!string.IsNullOrEmpty(this.Form.CountryClientSearchTextBox.Text))
                //{
                //    clients = clients.Where(l => l.CountryId.Contains(this.Form.CountryClientSearchTextBox.Text)).ToList();
                //}

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
                    clients = clients.Where(l => l.Town.ToLowerInvariant().Contains(this.Form.PostCodeClientSearchTextBox.Text.ToLowerInvariant())).ToList();
                }

                this.Form.ClientSearchResultDataGridView.DataSource = clients;

                if (clients.Count == 0)
                    return;

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

        #endregion
    }
}
