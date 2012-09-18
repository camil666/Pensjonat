namespace Projekt_BD.Controller
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.Interfaces;
    using Projekt_BD.View;

    public class ReceptionistFormController : ControllerBase
    {
        #region Constructors

        public ReceptionistFormController()
        {
            base.Form = new ReceptionistForm();

            this.SetupEvents();
        }

        #endregion

        #region Properties

        public new ReceptionistForm Form
        {
            get
            {
                return base.Form as ReceptionistForm;
            }
        }

        #endregion

        #region Methods

        private void SetupEvents()
        {
            this.Form.ClientSearchEnabledStripMenuItem.Click += this.ClientSearchEnabledStripMenuItem_Click;
            this.Form.ExitToolStripMenuItem.Click += this.ExitToolStripMenuItem_Click;
            this.Form.AboutToolStripMenuItem.Click += this.AboutToolStripMenuItem_Click;
            this.Form.NewClientButton.Click += this.NewClientButton_Click;
            this.Form.NewReservationButton.Click += this.NewReservationButton_Click;
            this.Form.NewVisitButton.Click += this.NewVisitButton_Click;
            this.Form.ReservationSearchButton.Click += this.ReservationSearchButton_Click;
            this.Form.StartDateReservationSearchDateTimePicker.ValueChanged += this.StartDateReservationSearchDateTimePicker_ValueChanged;
            this.Form.EndDateReservationSearchDateTimePicker.ValueChanged += this.EndDateReservationSearchDateTimePicker_ValueChanged;
            this.Form.ReservationSearchResultDataGridView.CellClick += this.ReservationSearchResultDataGridView_CellClick;
            this.Form.EditReservationButton.Click += this.EditReservationButton_Click;
            this.Form.AddFeaturesButton.Click += this.AddFeaturesButton_Click;
            this.Form.EditFeaturesButton.Click += this.EditFeaturesButton_Click;
            this.Form.AddRoomTypeButton.Click += this.AddRoomTypeButton_Click;
            this.Form.EditRoomTypeButton.Click += this.EditRoomTypeButton_Click;
            this.Form.RefreshRoomsButton.Click += this.RefreshRoomsButton_Click;
            this.Form.RefreshRoomTypesButton.Click += this.RefreshRoomTypesButton_Click;
            this.Form.RefreshFeaturesButton.Click += this.RefreshFeaturesButton_Click;
            this.Form.VisitSearchButton.Click += this.VisitSearchButton_Click;
            this.Form.SaveClientChangesButton.Click += this.SaveClientChangesButton_Click;
            this.Form.EditRoomButton.Click += this.EditRoomButton_Click;
            this.Form.NewRoomButton.Click += this.NewRoomButton_Click;
            this.Form.DeleteReservationButton.Click += this.DeleteReservationButton_Click;
            this.Form.VisitStartDateSearchDateTimePicker.ValueChanged += this.VisitStartDateSearchDateTimePicker_ValueChanged;
            this.Form.VisitEndDateSearchDateTimePicker.ValueChanged += this.VisitEndDateSearchDateTimePicker_ValueChanged;
        }

        #endregion

        #region Event Methods

        private void ClientSearchEnabledStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Form.ClientSearchWindow != null)
            {
                if (this.Form.ClientSearchEnabledStripMenuItem.Checked == true)
                {
                    this.Form.ClientSearchWindow.Show();
                }
                else
                {
                    this.Form.ClientSearchWindow.Hide();
                }
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Pensjonat\n\nKamil Socha\nMarcin Koba\nDawid Mazur\n2012",
            "About",
            MessageBoxButtons.OK,
            MessageBoxIcon.Asterisk,
            MessageBoxDefaultButton.Button1);
        }

        private void NewClientButton_Click(object sender, EventArgs e)
        {
            ControllerFactory.Instance.Create(ControllerTypes.NewClientForm).Form.ShowDialog();
        }

        private void NewReservationButton_Click(object sender, EventArgs e)
        {
            int selectedClientID = this.Form.ClientSearchWindow.SelectedClientID;

            if (selectedClientID > 0)
            {
                var controller = ControllerFactory.Instance.Create(ControllerTypes.ReservationForm);
                controller.ClientID = selectedClientID;
                controller.Form.ShowDialog();
            }
            else
            {
                MessageBox.Show(
                    "Należy zaznaczyć klienta",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void NewVisitButton_Click(object sender, EventArgs e)
        {
            ControllerFactory.Instance.Create(ControllerTypes.NewVisitForm).Form.ShowDialog();
        }

        private void ReservationSearchButton_Click(object sender, EventArgs e)
        {
            int selectedClientID = this.Form.ClientSearchWindow.SelectedClientID;

            if (selectedClientID > 0)
            {
                var reservations = (from reservation in DataAccess.Instance.Reservations.Find(r => r.GuestId == selectedClientID
                                   && r.StartDate >= this.Form.StartDateReservationSearchDateTimePicker.Value.Date
                                   && r.EndDate <= this.Form.EndDateReservationSearchDateTimePicker.Value.Date).ToList()
                                    select new
                                    {
                                        reservation.Id,
                                        reservation.StartDate,
                                        reservation.EndDate,
                                        reservation.AdditionalInfo
                                    }).ToList();

                this.Form.ReservationSearchResultDataGridView.DataSource = reservations;

                this.Form.ReservationSearchResultDataGridView.Columns["Id"].Visible = false;
                this.Form.ReservationSearchResultDataGridView.Columns["StartDate"].HeaderText = "Data rozpoczęcia";
                this.Form.ReservationSearchResultDataGridView.Columns["EndDate"].HeaderText = "Data zakończenia";
                this.Form.ReservationSearchResultDataGridView.Columns["AdditionalInfo"].HeaderText = "Dodatkowe informacje";
            }
            else
            {
                MessageBox.Show(
                    "Należy zaznaczyć klienta",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void StartDateReservationSearchDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.Form.StartDateReservationSearchDateTimePicker.Value >= this.Form.EndDateReservationSearchDateTimePicker.Value)
            {
                this.Form.EndDateReservationSearchDateTimePicker.Value = this.Form.StartDateReservationSearchDateTimePicker.Value.AddDays(1.0);
            }
        }

        private void EndDateReservationSearchDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.Form.EndDateReservationSearchDateTimePicker.Value <= this.Form.StartDateReservationSearchDateTimePicker.Value)
            {
                this.Form.StartDateReservationSearchDateTimePicker.Value = this.Form.EndDateReservationSearchDateTimePicker.Value.Subtract(new TimeSpan(1, 0, 0, 0));
            }
        }

        private void VisitEndDateSearchDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.Form.VisitEndDateSearchDateTimePicker.Value <= this.Form.VisitStartDateSearchDateTimePicker.Value)
            {
                this.Form.VisitStartDateSearchDateTimePicker.Value = this.Form.VisitEndDateSearchDateTimePicker.Value.Subtract(new TimeSpan(1, 0, 0, 0));
            }
        }

        private void VisitStartDateSearchDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.Form.VisitStartDateSearchDateTimePicker.Value >= this.Form.VisitEndDateSearchDateTimePicker.Value)
            {
                this.Form.VisitEndDateSearchDateTimePicker.Value = this.Form.VisitStartDateSearchDateTimePicker.Value.AddDays(1.0);
            }
        }

        private void ReservationSearchResultDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                this.Form.StartDateDetailsDateTimePicker.Value = (DateTime)this.Form.ReservationSearchResultDataGridView.SelectedRows[0].Cells["StartDate"].Value;
                this.Form.EndDateDetailsDateTimePicker.Value = (DateTime)this.Form.ReservationSearchResultDataGridView.SelectedRows[0].Cells["EndDate"].Value;
                this.Form.ReservationIDDetailsTextBox.Text = this.Form.ReservationSearchResultDataGridView.SelectedRows[0].Cells["Id"].Value.ToString();
                this.Form.AdditionalInfoDetailsTextBox.Text = this.Form.ReservationSearchResultDataGridView.SelectedRows[0].Cells["AdditionalInfo"].Value.ToString();

                int reservationId = int.Parse(this.Form.ReservationIDDetailsTextBox.Text);

                var roomsReservations = (from room in DataAccess.Instance.RoomReservations.Find(r => r.ReservationId == reservationId).ToList()
                                         select new
                                         {
                                             room.Room.Number,
                                             room.Room.Capacity,
                                             room.Room.Floor
                                         }).ToList();

                this.Form.RoomsDataGridView.DataSource = roomsReservations;

                this.Form.RoomsDataGridView.Columns["Number"].HeaderText = "Numer pokoju";
                this.Form.RoomsDataGridView.Columns["Capacity"].HeaderText = "Pojemność";
                this.Form.RoomsDataGridView.Columns["Floor"].HeaderText = "Piętro";
            }
        }

        private void DeleteReservationButton_Click(object sender, EventArgs e)
        {
            // if a reservation is selected
            if (!string.IsNullOrEmpty(this.Form.ReservationIDDetailsTextBox.Text))
            {
                DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć rezerwację?", "Usuwanie rezerwacji", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int selectedReservationId = int.Parse(this.Form.ReservationIDDetailsTextBox.Text);
                    Reservation reservationToBeDeleted = DataAccess.Instance.Reservations.Single(r => r.Id == selectedReservationId);

                    var roomReservations = DataAccess.Instance.RoomReservations.Find(r => r.ReservationId == selectedReservationId);

                    foreach (var roomReservation in roomReservations)
                    {
                        DataAccess.Instance.RoomReservations.Delete(roomReservation);
                    }

                    DataAccess.Instance.Reservations.Delete(reservationToBeDeleted);

                    DataAccess.Instance.UnitOfWork.Commit();

                    this.Form.ReservationSearchButton.PerformClick();
                }
            }
            else
            {
                MessageBox.Show(
                    "Należy zaznaczyć rezerwację",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void EditReservationButton_Click(object sender, EventArgs e)
        {
            // if a reservation is selected
            if (!string.IsNullOrEmpty(this.Form.ReservationIDDetailsTextBox.Text))
            {
                int id = int.Parse(this.Form.ReservationIDDetailsTextBox.Text);
                var controller = ControllerFactory.Instance.Create(ControllerTypes.ReservationForm);
                controller.ItemToEditID = id;
                controller.ClientID = this.Form.ClientSearchWindow.SelectedClientID;
                controller.Form.ShowDialog();
            }
            else
            {
                MessageBox.Show(
                    "Należy zaznaczyć rezerwację",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void AddFeaturesButton_Click(object sender, EventArgs e)
        {
            ControllerFactory.Instance.Create(ControllerTypes.EditRoomFeature).Form.ShowDialog();
        }

        private void EditFeaturesButton_Click(object sender, EventArgs e)
        {
            int selectedCellCount = this.Form.RoomFeaturesDataGridView.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                int rowIndex = this.Form.RoomFeaturesDataGridView.SelectedCells[0].RowIndex;
                int roomFeatureId = (int)this.Form.RoomFeaturesDataGridView[0, rowIndex].Value;
                var controller = ControllerFactory.Instance.Create(ControllerTypes.EditRoomFeature);
                controller.ItemToEditID = roomFeatureId;
                controller.Form.ShowDialog();
            }
        }

        private void AddRoomTypeButton_Click(object sender, EventArgs e)
        {
            ControllerFactory.Instance.Create(ControllerTypes.EditRoomType).Form.ShowDialog();
        }

        private void EditRoomTypeButton_Click(object sender, EventArgs e)
        {
            int selectedCellCount = this.Form.RoomTypesDataGridView.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                int rowIndex = this.Form.RoomTypesDataGridView.SelectedCells[0].RowIndex;
                int roomTypeId = (int)this.Form.RoomTypesDataGridView[0, rowIndex].Value;
                var controller = ControllerFactory.Instance.Create(ControllerTypes.EditRoomType);
                controller.ItemToEditID = roomTypeId;
                controller.Form.ShowDialog();
            }
        }

        private void RefreshRoomsButton_Click(object sender, EventArgs e)
        {
            var rooms = (from room in DataAccess.Instance.Rooms.GetAll()
                         select new
                         {
                             room.Number,
                             room.RoomType.Name,
                             room.Capacity,
                             room.Floor,
                             room.RoomType.Price,
                             room.RoomType.PricePerPerson,
                             /* room.Features*/
                         }).ToList();

            //TODO: Dodać wyświetlanie ficzerów

            this.Form.AllRoomsDataGridView.DataSource = rooms;
            this.Form.AllRoomsDataGridView.Columns["Number"].HeaderText = "Numer";
            this.Form.AllRoomsDataGridView.Columns["Name"].HeaderText = "Typ";
            this.Form.AllRoomsDataGridView.Columns["Capacity"].HeaderText = "Pojemność";
            this.Form.AllRoomsDataGridView.Columns["Floor"].HeaderText = "Piętro";
            this.Form.AllRoomsDataGridView.Columns["Price"].HeaderText = "Cena";
            this.Form.AllRoomsDataGridView.Columns["PricePerPerson"].HeaderText = "Cena za osobę";
            //this.Form.AllRoomsDataGridView.Columns["Features"].HeaderText = "Udogodnienia";
        }

        private void RefreshRoomTypesButton_Click(object sender, EventArgs e)
        {
            var roomTypes = from roomType in DataAccess.Instance.RoomTypes.GetAll()
                            select new
                            {
                                roomType.Id,
                                roomType.Name,
                                roomType.Description,
                                roomType.Price,
                                roomType.PricePerPerson
                            };

            this.Form.RoomTypesDataGridView.DataSource = roomTypes;
            this.Form.RoomTypesDataGridView.Columns["Id"].Visible = false;
            this.Form.RoomTypesDataGridView.Columns["Price"].HeaderText = "Cena";
            this.Form.RoomTypesDataGridView.Columns["PricePerPerson"].HeaderText = "Cena od osoby";
            this.Form.RoomTypesDataGridView.Columns["Name"].HeaderText = "Nazwa";
            this.Form.RoomTypesDataGridView.Columns["Description"].HeaderText = "Opis";
        }

        private void RefreshFeaturesButton_Click(object sender, EventArgs e)
        {
            var features = from feature in DataAccess.Instance.Features.GetAll()
                           select new
                           {
                               feature.Id,
                               feature.Name,
                               feature.Description
                           };

            this.Form.RoomFeaturesDataGridView.DataSource = features;
            this.Form.RoomFeaturesDataGridView.Columns["Id"].Visible = false;
            this.Form.RoomFeaturesDataGridView.Columns["Name"].HeaderText = "Nazwa";
            this.Form.RoomFeaturesDataGridView.Columns["Description"].HeaderText = "Opis";
        }

        private void NewRoomButton_Click(object sender, EventArgs e)
        {
            ControllerFactory.Instance.Create(ControllerTypes.EditRoom).Form.ShowDialog();
        }

        private void EditRoomButton_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = this.Form.AllRoomsDataGridView.SelectedRows.Count;
            if (selectedRowsCount > 0)
            {
                int rowIndex = this.Form.AllRoomsDataGridView.SelectedRows[0].Index;
                int roomNumber = (int)this.Form.AllRoomsDataGridView[0, rowIndex].Value;

                var controller = ControllerFactory.Instance.Create(ControllerTypes.EditRoom);
                controller.ItemToEditID = roomNumber;
                controller.Form.ShowDialog();
            }
        }

        private void VisitSearchButton_Click(object sender, EventArgs e)
        {
            int selectedClientID = this.Form.ClientSearchWindow.SelectedClientID;

            if (selectedClientID > 0)
            {
                var visits = (from visit in DataAccess.Instance.Visits.Find(v => v.GuestId == selectedClientID
                                   && v.StartDate >= this.Form.VisitStartDateSearchDateTimePicker.Value.Date
                                   && v.EndDate <= this.Form.VisitEndDateSearchDateTimePicker.Value.Date)
                              select visit).ToList();


                if (visits.Count == 0)
                {
                    return;
                }

                var visitsIds = (from visit in visits
                                 select visit.Id).ToList();

                var parentVisitsIds = (from visit in visits
                                       where visit.ParentId != null
                                       select visit.ParentId).ToList();

                if (visitsIds.Count > 0)
                {
                    foreach (var id in visitsIds)
                    {
                        var childVisits = DataAccess.Instance.Visits.Find(v => v.ParentId == id).ToList();
                        foreach (var visit in childVisits)
                        {
                            visits.Add(visit);
                        }
                    }
                }

                if (parentVisitsIds.Count > 0)
                {
                    foreach (var id in parentVisitsIds)
                    {
                        var parentVisit = DataAccess.Instance.Visits.Single(v => v.Id == id);

                        var parentVisits = DataAccess.Instance.Visits.Find(v => (v.Id == id || v.ParentId == parentVisit.Id));

                        foreach (var visit in parentVisits)
                        {
                            visits.Add(visit);
                        }
                    }
                }

                var displayableVisits = (from visit in visits
                                         select new
                                          {
                                              visit.Id,
                                              visit.Guest.FirstName,
                                              visit.Guest.LastName,
                                              visit.RoomId,
                                              visit.Advance,
                                              visit.StartDate,
                                              visit.EndDate,
                                              visit.AdditionalInfo
                                          }).ToList();

                this.Form.VisitSearchResultsDataGridView.DataSource = displayableVisits;

                this.Form.VisitSearchResultsDataGridView.Columns["Id"].Visible = false;
                this.Form.VisitSearchResultsDataGridView.Columns["FirstName"].HeaderText = "Imię";
                this.Form.VisitSearchResultsDataGridView.Columns["LastName"].HeaderText = "Nazwisko";
                this.Form.VisitSearchResultsDataGridView.Columns["RoomId"].HeaderText = "Pokój";
                this.Form.VisitSearchResultsDataGridView.Columns["Advance"].HeaderText = "Zaliczka";
                this.Form.VisitSearchResultsDataGridView.Columns["StartDate"].HeaderText = "Data rozpoczęcia";
                this.Form.VisitSearchResultsDataGridView.Columns["EndDate"].HeaderText = "Data zakończenia";
                this.Form.VisitSearchResultsDataGridView.Columns["AdditionalInfo"].HeaderText = "Dodatkowe informacje";
            }
            else
            {
                MessageBox.Show(
                    "Należy zaznaczyć klienta",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void SaveClientChangesButton_Click(object sender, EventArgs e)
        {
            var guestId = int.Parse(this.Form.IDClientDetailsTextBox.Text);
            Guest guestToBeUpdated = DataAccess.Instance.Guests.Single(g => g.Id == guestId);

            guestToBeUpdated.ApartmentNumber = this.Form.ApartmentNumberClientDetailsTextBox.Text;
            guestToBeUpdated.CompanyName = this.Form.CompanyNameClientDetailsTextBox.Text;
            guestToBeUpdated.IdNumber = this.Form.IDNumberClientDetailsTextBox.Text;
            guestToBeUpdated.CountryId = this.Form.CountryClientDetailsTextBox.Text;
            guestToBeUpdated.Email = this.Form.EmailClientDetailsTextBox.Text;
            guestToBeUpdated.FirstName = this.Form.FirstNameClientDetailsTextBox.Text;
            guestToBeUpdated.HouseNumber = this.Form.HouseNumberClientDetailsTextBox.Text;
            guestToBeUpdated.LastName = this.Form.LastNameClientDetailsTextBox.Text;
            guestToBeUpdated.TelephoneNumber = this.Form.PhoneNumberClientDetailsTextBox.Text;
            guestToBeUpdated.PostCode = this.Form.PostCodeClientDetailsTextBox.Text;
            guestToBeUpdated.Street = this.Form.StreetClientDetailsTextBox.Text;
            guestToBeUpdated.Town = this.Form.TownClientDetailsTextBox.Text;
            guestToBeUpdated.IsVerified = this.Form.VerifiedClientDetailsCheckBox.Checked;

            DataAccess.Instance.UnitOfWork.Commit();

            //TODO: weryfikacja wprowadzonych danych.
        }

        #endregion
    }
}
