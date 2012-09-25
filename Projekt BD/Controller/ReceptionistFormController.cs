namespace Projekt_BD.Controller
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.View;

    /// <summary>
    /// Controller class for Receptionist form.
    /// </summary>
    public class ReceptionistFormController : ControllerBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceptionistFormController" /> class.
        /// </summary>
        public ReceptionistFormController()
        {
            base.Form = new ReceptionistForm();

            this.SetupEvents();
            this.Init();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the form.
        /// </summary>
        /// <value>
        /// The form.
        /// </value>
        public new ReceptionistForm Form
        {
            get
            {
                return base.Form as ReceptionistForm;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Inits this instance.
        /// </summary>
        private void Init()
        {
            this.RefreshRooms();
            this.RefreshRoomTypes();
            this.RefreshFeatures();
            this.RefreshServices();
        }

        /// <summary>
        /// Sets up the events.
        /// </summary>
        private void SetupEvents()
        {
            this.Form.ClientSearchEnabledStripMenuItem.Click += this.ClientSearchEnabledStripMenuItem_Click;
            this.Form.ExitToolStripMenuItem.Click += this.ExitToolStripMenuItem_Click;
            this.Form.AboutToolStripMenuItem.Click += this.AboutToolStripMenuItem_Click;
            this.Form.GetHelpToolStripMenuItem.Click += this.GetHelpToolStripMenuItem_Click;
            this.Form.NewClientButton.Click += this.NewClientButton_Click;
            this.Form.NewReservationButton.Click += this.NewReservationButton_Click;
            this.Form.EditMealPlansForVisit.Click += this.EditMealPlansForVisit_Click;
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
            this.Form.RefreshServiceButton.Click += this.RefreshServiceButton_Click;
            this.Form.EditServiceButton.Click += this.EditServiceButton_Click;
            this.Form.NewServiceButton.Click += this.NewServiceButton_Click;
            this.Form.ReservationIntoVisitButton.Click += this.ReservationIntoVisitButton_Click;
            this.Form.ServicesButton.Click += this.EditServiceForVisit_Click;
            this.Form.GenerateReceiptButton.Click += this.GenerateReceiptButton_Click;
            this.Form.DeleteFeatureButton.Click += this.DeleteFeatureButton_Click;
            this.Form.DeleteRoomTypeButton.Click += this.DeleteRoomTypeButton_Click;
            this.Form.DeleteRoomButton.Click += this.DeleteRoomButton_Click;
            this.Form.DiscountsButton.Click += this.DiscountsButton_Click;
        }

        /// <summary>
        /// Refreshes the reservation search result data grid view.
        /// </summary>
        private void RefreshReservationSearchResultDataGridView()
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
                                        reservation.AdditionalInfo,
                                        reservation.IsVisit
                                    }).ToList();

                this.Form.ReservationSearchResultDataGridView.DataSource = reservations;

                this.Form.ReservationSearchResultDataGridView.Columns["Id"].Visible = false;
                this.Form.ReservationSearchResultDataGridView.Columns["StartDate"].HeaderText = "Data rozpoczęcia";
                this.Form.ReservationSearchResultDataGridView.Columns["EndDate"].HeaderText = "Data zakończenia";
                this.Form.ReservationSearchResultDataGridView.Columns["AdditionalInfo"].HeaderText = "Dodatkowe informacje";
                this.Form.ReservationSearchResultDataGridView.Columns["IsVisit"].Visible = false;
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

        /// <summary>
        /// Refreshes the rooms.
        /// </summary>
        private void RefreshRooms()
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
                             FeatureList = room.Features
                         }).ToList();

            this.Form.AllRoomsDataGridView.DataSource = rooms;
            this.Form.AllRoomsDataGridView.Columns.Add("Features", "Udogodnienia");

            foreach (var room in rooms)
            {
                foreach (var feature in room.FeatureList)
                {
                    this.Form.AllRoomsDataGridView.Rows[rooms.IndexOf(room)].Cells["Features"].Value += string.Concat(feature.Name, ", ");
                }
            }

            this.Form.AllRoomsDataGridView.Columns["Number"].HeaderText = "Numer";
            this.Form.AllRoomsDataGridView.Columns["Name"].HeaderText = "Typ";
            this.Form.AllRoomsDataGridView.Columns["Capacity"].HeaderText = "Pojemność";
            this.Form.AllRoomsDataGridView.Columns["Floor"].HeaderText = "Piętro";
            this.Form.AllRoomsDataGridView.Columns["Price"].HeaderText = "Cena";
            this.Form.AllRoomsDataGridView.Columns["PricePerPerson"].HeaderText = "Cena za osobę";
            this.Form.AllRoomsDataGridView.Columns["FeatureList"].Visible = false;
        }

        /// <summary>
        /// Refreshes the room types.
        /// </summary>
        private void RefreshRoomTypes()
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

        /// <summary>
        /// Refreshes the features.
        /// </summary>
        private void RefreshFeatures()
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

        /// <summary>
        /// Refreshes the services.
        /// </summary>
        private void RefreshServices()
        {
            var serviceTypes = (from serviceType in DataAccess.Instance.ServiceTypes.GetAll()
                                select new
                                {
                                    serviceType.Id,
                                    serviceType.Name,
                                    serviceType.Description,
                                    serviceType.Charge
                                }).ToList();

            this.Form.ServiceDataGridView.DataSource = serviceTypes;
            this.Form.ServiceDataGridView.Columns["Id"].Visible = false;
            this.Form.ServiceDataGridView.Columns["Name"].HeaderText = "Nazwa";
            this.Form.ServiceDataGridView.Columns["Description"].HeaderText = "Opis";
            this.Form.ServiceDataGridView.Columns["Charge"].HeaderText = "Opłata";
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// Handles the Click event of the DiscountsButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void DiscountsButton_Click(object sender, EventArgs e)
        {
            int selectedClientID = this.Form.ClientSearchWindow.SelectedClientID;

            if (selectedClientID > 0)
            {
                var controller = ControllerFactory.Instance.Create(ControllerTypes.GrantDiscountForm);
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

        /// <summary>
        /// Handles the Click event of the GenerateReceiptButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void GenerateReceiptButton_Click(object sender, EventArgs e)
        {
            if (this.Form.VisitSearchResultsDataGridView.SelectedRows.Count > 0)
            {
                var controller = ControllerFactory.Instance.Create(ControllerTypes.GenerateReceiptForm);

                controller.ItemToEditID = (int)this.Form.VisitSearchResultsDataGridView.SelectedRows[0].Cells["Id"].Value;

                controller.Form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Należy zaznaczyć wizytę", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Handles the Click event of the ClientSearchEnabledStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the ExitToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the Click event of the AboutToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Pensjonat\n\nKamil Socha\nMarcin Koba\nDawid Mazur\n2012",
            "About",
            MessageBoxButtons.OK,
            MessageBoxIcon.Asterisk,
            MessageBoxDefaultButton.Button1);
        }

        private void GetHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myProcess = new System.Diagnostics.Process();
            myProcess.StartInfo.FileName = "iexplore.exe";
            myProcess.StartInfo.Arguments = Application.StartupPath + "/help.html";
            myProcess.Start();
        }

        /// <summary>
        /// Handles the Click event of the NewClientButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void NewClientButton_Click(object sender, EventArgs e)
        {
            ControllerFactory.Instance.Create(ControllerTypes.NewClientForm).Form.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the NewReservationButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void NewReservationButton_Click(object sender, EventArgs e)
        {
            int selectedClientID = this.Form.ClientSearchWindow.SelectedClientID;

            if (selectedClientID > 0)
            {
                var controller = ControllerFactory.Instance.Create(ControllerTypes.ReservationForm);
                controller.ClientID = selectedClientID;
                controller.Form.ShowDialog();
                this.RefreshReservationSearchResultDataGridView();
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

        /// <summary>
        /// Handles the Click event of the NewVisitButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void NewVisitButton_Click(object sender, EventArgs e)
        {
            ControllerFactory.Instance.Create(ControllerTypes.NewVisitForm).Form.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the ReservationSearchButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void ReservationSearchButton_Click(object sender, EventArgs e)
        {
            this.RefreshReservationSearchResultDataGridView();
        }

        /// <summary>
        /// Handles the ValueChanged event of the StartDateReservationSearchDateTimePicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void StartDateReservationSearchDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.Form.StartDateReservationSearchDateTimePicker.Value >= this.Form.EndDateReservationSearchDateTimePicker.Value)
            {
                this.Form.EndDateReservationSearchDateTimePicker.Value = this.Form.StartDateReservationSearchDateTimePicker.Value.AddDays(1.0);
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the EndDateReservationSearchDateTimePicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void EndDateReservationSearchDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.Form.EndDateReservationSearchDateTimePicker.Value <= this.Form.StartDateReservationSearchDateTimePicker.Value)
            {
                this.Form.StartDateReservationSearchDateTimePicker.Value = this.Form.EndDateReservationSearchDateTimePicker.Value.Subtract(new TimeSpan(1, 0, 0, 0));
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the VisitEndDateSearchDateTimePicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void VisitEndDateSearchDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.Form.VisitEndDateSearchDateTimePicker.Value <= this.Form.VisitStartDateSearchDateTimePicker.Value)
            {
                this.Form.VisitStartDateSearchDateTimePicker.Value = this.Form.VisitEndDateSearchDateTimePicker.Value.Subtract(new TimeSpan(1, 0, 0, 0));
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the VisitStartDateSearchDateTimePicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void VisitStartDateSearchDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.Form.VisitStartDateSearchDateTimePicker.Value >= this.Form.VisitEndDateSearchDateTimePicker.Value)
            {
                this.Form.VisitEndDateSearchDateTimePicker.Value = this.Form.VisitStartDateSearchDateTimePicker.Value.AddDays(1.0);
            }
        }

        /// <summary>
        /// Handles the CellClick event of the ReservationSearchResultDataGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs" /> instance containing the event data.</param>
        private void ReservationSearchResultDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
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

        /// <summary>
        /// Handles the Click event of the DeleteReservationButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the EditReservationButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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
                this.RefreshReservationSearchResultDataGridView();
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

        /// <summary>
        /// Handles the Click event of the AddFeaturesButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AddFeaturesButton_Click(object sender, EventArgs e)
        {
            ControllerFactory.Instance.Create(ControllerTypes.EditRoomFeature).Form.ShowDialog();
            this.RefreshFeatures();
        }

        /// <summary>
        /// Handles the Click event of the EditFeaturesButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void EditFeaturesButton_Click(object sender, EventArgs e)
        {
            int selectedCellCount = this.Form.RoomFeaturesDataGridView.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                int rowIndex = this.Form.RoomFeaturesDataGridView.SelectedCells[0].RowIndex;
                int roomFeatureId = (int)this.Form.RoomFeaturesDataGridView["Id", rowIndex].Value;
                var controller = ControllerFactory.Instance.Create(ControllerTypes.EditRoomFeature);
                controller.ItemToEditID = roomFeatureId;
                controller.Form.ShowDialog();
                this.RefreshFeatures();
            }
        }

        /// <summary>
        /// Handles the Click event of the AddRoomTypeButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AddRoomTypeButton_Click(object sender, EventArgs e)
        {
            ControllerFactory.Instance.Create(ControllerTypes.EditRoomType).Form.ShowDialog();
            this.RefreshRoomTypes();
        }

        /// <summary>
        /// Handles the Click event of the EditRoomTypeButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void EditRoomTypeButton_Click(object sender, EventArgs e)
        {
            int selectedCellCount = this.Form.RoomTypesDataGridView.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                int rowIndex = this.Form.RoomTypesDataGridView.SelectedCells[0].RowIndex;
                int roomTypeId = (int)this.Form.RoomTypesDataGridView["Id", rowIndex].Value;
                var controller = ControllerFactory.Instance.Create(ControllerTypes.EditRoomType);
                controller.ItemToEditID = roomTypeId;
                controller.Form.ShowDialog();
                this.RefreshRoomTypes();
            }
        }

        /// <summary>
        /// Handles the Click event of the RefreshRoomsButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void RefreshRoomsButton_Click(object sender, EventArgs e)
        {
            this.RefreshRooms();
        }

        /// <summary>
        /// Handles the Click event of the RefreshRoomTypesButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void RefreshRoomTypesButton_Click(object sender, EventArgs e)
        {
            this.RefreshRoomTypes();
        }

        /// <summary>
        /// Handles the Click event of the RefreshFeaturesButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void RefreshFeaturesButton_Click(object sender, EventArgs e)
        {
            this.RefreshFeatures();
        }

        /// <summary>
        /// Handles the Click event of the NewRoomButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void NewRoomButton_Click(object sender, EventArgs e)
        {
            ControllerFactory.Instance.Create(ControllerTypes.EditRoom).Form.ShowDialog();
            this.RefreshRooms();
        }

        /// <summary>
        /// Handles the Click event of the EditRoomButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void EditRoomButton_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = this.Form.AllRoomsDataGridView.SelectedRows.Count;
            if (selectedRowsCount > 0)
            {
                int rowIndex = this.Form.AllRoomsDataGridView.SelectedRows[0].Index;
                int roomNumber = (int)this.Form.AllRoomsDataGridView["Number", rowIndex].Value;

                var controller = ControllerFactory.Instance.Create(ControllerTypes.EditRoom);
                controller.ItemToEditID = roomNumber;
                controller.Form.ShowDialog();
                this.RefreshRooms();
            }
        }

        /// <summary>
        /// Handles the Click event of the VisitSearchButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the SaveClientChangesButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void SaveClientChangesButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Form.ApartmentNumberClientDetailsTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.CountryClientDetailsTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.FirstNameClientDetailsTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.HouseNumberClientDetailsTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.LastNameClientDetailsTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.PhoneNumberClientDetailsTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.PostCodeClientDetailsTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.StreetClientDetailsTextBox.Text) ||
                string.IsNullOrEmpty(this.Form.TownClientDetailsTextBox.Text))
            {
                MessageBox.Show(
                    "Należy wpisać wymagane dane.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz zmienić dane gościa?", "Zmiana danych", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

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
        }

        /// <summary>
        /// Handles the Click event of the NewServiceButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void NewServiceButton_Click(object sender, System.EventArgs e)
        {
            ControllerFactory.Instance.Create(ControllerTypes.EditService).Form.ShowDialog();
            this.RefreshServices();
        }

        /// <summary>
        /// Handles the Click event of the EditServiceButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void EditServiceButton_Click(object sender, System.EventArgs e)
        {
            int selectedRowsCount = this.Form.ServiceDataGridView.SelectedRows.Count;
            if (selectedRowsCount > 0)
            {
                int rowIndex = this.Form.ServiceDataGridView.SelectedRows[0].Index;
                int index = (int)this.Form.ServiceDataGridView["Id", rowIndex].Value;
                var controller = ControllerFactory.Instance.Create(ControllerTypes.EditService);
                controller.ItemToEditID = index;
                controller.Form.ShowDialog();
                this.RefreshServices();
            }
        }

        /// <summary>
        /// Handles the Click event of the RefreshServiceButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void RefreshServiceButton_Click(object sender, System.EventArgs e)
        {
            this.RefreshServices();
        }

        /// <summary>
        /// Handles the Click event of the ReservationIntoVisitButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void ReservationIntoVisitButton_Click(object sender, EventArgs e)
        {
            if (this.Form.ReservationSearchResultDataGridView.SelectedRows.Count > 0)
            {
                if ((bool)this.Form.ReservationSearchResultDataGridView.SelectedRows[0].Cells["IsVisit"].Value == true)
                {
                    MessageBox.Show("Odpowiedni pobyt istnieje dla wybranej rezerwacji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }

                var controller = ControllerFactory.Instance.Create(ControllerTypes.NewVisitForm);
                controller.ItemToEditID = int.Parse(this.Form.ReservationIDDetailsTextBox.Text);
                controller.Form.ShowDialog();

                this.RefreshReservationSearchResultDataGridView();
            }
            else
            {
                MessageBox.Show("Należy zaznaczyć rezerwację", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Handles the Click event of the EditServiceForVisit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void EditServiceForVisit_Click(object sender, EventArgs e)
        {
            if (this.Form.VisitSearchResultsDataGridView.SelectedRows.Count > 0)
            {
                int rowIndex = this.Form.VisitSearchResultsDataGridView.SelectedRows[0].Index;
                int index = (int)this.Form.VisitSearchResultsDataGridView["Id", rowIndex].Value;
                var controller = ControllerFactory.Instance.Create(ControllerTypes.EditServiceForVisit);
                controller.ItemToEditID = index;
                controller.Form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Należy zaznaczyć rezerwację", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Handles the Click event of the EditMealPlansForVisit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void EditMealPlansForVisit_Click(object sender, EventArgs e)
        {
            if (this.Form.VisitSearchResultsDataGridView.SelectedRows.Count > 0)
            {
                int rowIndex = this.Form.VisitSearchResultsDataGridView.SelectedRows[0].Index;
                int index = (int)this.Form.VisitSearchResultsDataGridView["Id", rowIndex].Value;
                var controller = ControllerFactory.Instance.Create(ControllerTypes.MealPlansForm);
                controller.ItemToEditID = index;
                controller.Form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Należy zaznaczyć rezerwację", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Handles the Click event of the DeleteRoomButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void DeleteRoomButton_Click(object sender, EventArgs e)
        {
            if (this.Form.AllRoomsDataGridView.SelectedRows.Count > 0)
            {
                var selectedRowIndexes = this.Form.AllRoomsDataGridView.SelectedRows;
                foreach (DataGridViewRow item in selectedRowIndexes)
                {
                    var id = (int)this.Form.AllRoomsDataGridView["Number", item.Index].Value;
                    var room = DataAccess.Instance.Rooms.Single(t => t.Number == id);
                    DataAccess.Instance.Rooms.Delete(room);
                }

                DataAccess.Instance.UnitOfWork.Commit();
                this.RefreshRooms();
            }
            else
            {
                MessageBox.Show("Nie zaznaczono zadań do usunięcia!");
            }
        }

        /// <summary>
        /// Handles the Click event of the DeleteRoomTypeButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void DeleteRoomTypeButton_Click(object sender, EventArgs e)
        {
            if (this.Form.RoomTypesDataGridView.SelectedRows.Count > 0)
            {
                RoomType roomType = null;
                try
                {
                    var selectedRowIndexes = this.Form.RoomTypesDataGridView.SelectedRows;
                    foreach (DataGridViewRow item in selectedRowIndexes)
                    {
                        var id = (int)this.Form.RoomTypesDataGridView[0, item.Index].Value;
                        roomType = DataAccess.Instance.RoomTypes.Single(t => t.Id == id);
                        DataAccess.Instance.RoomTypes.Delete(roomType);
                    }

                    DataAccess.Instance.UnitOfWork.Commit();
                    this.RefreshFeatures();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nie wolno usunąć typu pokoju, ponieważ istnieje pokój o ww. typie!");
                    DataAccess.Instance.UnitOfWork.Refresh<RoomType>(roomType);
                }
            }
            else
            {
                MessageBox.Show("Nie zaznaczono zadań do usunięcia!");
            }
        }

        /// <summary>
        /// Handles the Click event of the DeleteFeatureButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void DeleteFeatureButton_Click(object sender, EventArgs e)
        {
            if (this.Form.RoomFeaturesDataGridView.SelectedRows.Count > 0)
            {
                var selectedRowIndexes = this.Form.RoomFeaturesDataGridView.SelectedRows;
                foreach (DataGridViewRow item in selectedRowIndexes)
                {
                    var id = (int)this.Form.RoomFeaturesDataGridView[0, item.Index].Value;
                    var feature = DataAccess.Instance.Features.Single(t => t.Id == id);
                    DataAccess.Instance.Features.Delete(feature);
                }

                DataAccess.Instance.UnitOfWork.Commit();
                this.RefreshFeatures();
            }
            else
            {
                MessageBox.Show("Nie zaznaczono zadań do usunięcia!");
            }
        }

        #endregion
    }
}
