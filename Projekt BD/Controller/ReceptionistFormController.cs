namespace Projekt_BD.Controller
{
    using System;
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
            this.Form.ClientSearchEnabledStripMenuItem.Click += ClientSearchEnabledStripMenuItem_Click;
            this.Form.ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            this.Form.AboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            this.Form.NewClientButton.Click += NewClientButton_Click;
            this.Form.NewReservationButton.Click += NewReservationButton_Click;
            this.Form.NewVisitButton.Click += NewVisitButton_Click;
            this.Form.ReservationSearchButton.Click += ReservationSearchButton_Click;
            this.Form.StartDateReservationSearchDateTimePicker.ValueChanged += StartDateReservationSearchDateTimePicker_ValueChanged;
            this.Form.EndDateReservationSearchDateTimePicker.ValueChanged += EndDateReservationSearchDateTimePicker_ValueChanged;
            this.Form.ReservationSearchResultDataGridView.CellClick += ReservationSearchResultDataGridView_CellClick;
            this.Form.EditReservationButton.Click += EditReservationButton_Click;
            this.Form.AddFeaturesButton.Click += AddFeaturesButton_Click;
            this.Form.EditFeaturesButton.Click += EditFeaturesButton_Click;
            this.Form.AddRoomTypeButton.Click += AddRoomTypeButton_Click;
            this.Form.EditRoomTypeButton.Click += EditRoomTypeButton_Click;
            this.Form.RefreshRoomsButton.Click += RefreshRoomsButton_Click;
            this.Form.RefreshRoomTypesButton.Click += RefreshRoomTypesButton_Click;
            this.Form.RefreshFeaturesButton.Click += RefreshFeaturesButton_Click;
            this.Form.VisitSearchButton.Click += VisitSearchButton_Click;
            this.Form.SaveClientChangesButton.Click += SaveClientChangesButton_Click;
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
            "Pensjonat\n\nKamil Socha\nMarcin Koba\nDawid Mazur\n2012", "About",
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
                MessageBox.Show("Należy zaznaczyć klienta",
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
                using (var context = new PensjonatContext())
                {
                    try
                    {
                        var reservations = from rs in context.Reservations
                                           where rs.GuestId == selectedClientID
                                           && rs.StartDate >= this.Form.StartDateReservationSearchDateTimePicker.Value.Date
                                           && rs.EndDate <= this.Form.EndDateReservationSearchDateTimePicker.Value.Date
                                           select new
                                           {
                                               rs.Id,
                                               rs.StartDate,
                                               rs.EndDate,
                                               rs.AdditionalInfo
                                           };

                        this.Form.ReservationSearchResultDataGridView.DataSource = reservations;

                        this.Form.ReservationSearchResultDataGridView.Columns["Id"].Visible = false;
                        this.Form.ReservationSearchResultDataGridView.Columns["StartDate"].HeaderText = "Data rozpoczęcia";
                        this.Form.ReservationSearchResultDataGridView.Columns["EndDate"].HeaderText = "Data zakończenia";
                        this.Form.ReservationSearchResultDataGridView.Columns["AdditionalInfo"].HeaderText = "Dodatkowe informacje";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Należy zaznaczyć klienta",
                "Błąd",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }
        }

        private void StartDateReservationSearchDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.Form.StartDateReservationSearchDateTimePicker.Value > this.Form.EndDateReservationSearchDateTimePicker.Value)
            {
                this.Form.EndDateReservationSearchDateTimePicker.Value = this.Form.StartDateReservationSearchDateTimePicker.Value;
            }
        }

        private void EndDateReservationSearchDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.Form.EndDateReservationSearchDateTimePicker.Value < this.Form.StartDateReservationSearchDateTimePicker.Value)
            {
                this.Form.StartDateReservationSearchDateTimePicker.Value = this.Form.EndDateReservationSearchDateTimePicker.Value;
            }
        }

        private void ReservationSearchResultDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Form.StartDateDetailsDateTimePicker.Value = (DateTime)this.Form.ReservationSearchResultDataGridView.SelectedRows[0].Cells["StartDate"].Value;
            this.Form.EndDateDetailsDateTimePicker.Value = (DateTime)this.Form.ReservationSearchResultDataGridView.SelectedRows[0].Cells["EndDate"].Value;
            this.Form.ReservationIDDetailsTextBox.Text = this.Form.ReservationSearchResultDataGridView.SelectedRows[0].Cells["Id"].Value.ToString();
            this.Form.AdditionalInfoDetailsTextBox.Text = this.Form.ReservationSearchResultDataGridView.SelectedRows[0].Cells["AdditionalInfo"].Value.ToString();

            using (var context = new PensjonatContext())
            {
                try
                {
                    int reservationId = int.Parse(this.Form.ReservationIDDetailsTextBox.Text);

                    var roomsReservations = from room in context.RoomReservations
                                            where room.ReservationId == reservationId
                                            select new
                                            {
                                                room.RoomId
                                            };

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Number");
                    dataTable.Columns.Add("Capacity");
                    dataTable.Columns.Add("Floor");

                    foreach (var roomReservation in roomsReservations)
                    {
                        var reservedRooms = from room in context.Rooms
                                            where room.Number == roomReservation.RoomId
                                            select new
                                            {
                                                room.Number,
                                                room.Capacity,
                                                room.Floor
                                            };

                        foreach (var roomDetails in reservedRooms)
                        {
                            object[] items = new object[] { roomDetails.Number, roomDetails.Capacity, roomDetails.Floor };
                            dataTable.Rows.Add(items);
                        }
                    }

                    this.Form.RoomsDataGridView.DataSource = dataTable;

                    this.Form.RoomsDataGridView.Columns["Number"].HeaderText = "Numer pokoju";
                    this.Form.RoomsDataGridView.Columns["Capacity"].HeaderText = "Pojemność";
                    this.Form.RoomsDataGridView.Columns["Floor"].HeaderText = "Piętro";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void EditReservationButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.Form.ReservationIDDetailsTextBox.Text))   //if a reservation is selected
            {
                int id = int.Parse(this.Form.ReservationIDDetailsTextBox.Text);
                var controller = ControllerFactory.Instance.Create(ControllerTypes.ReservationForm);
                controller.ItemToEditID = id;
                controller.ClientID = this.Form.ClientSearchWindow.SelectedClientID;
                controller.Form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Należy zaznaczyć rezerwację",
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

        }

        private void RefreshRoomTypesButton_Click(object sender, EventArgs e)
        {
            using (var context = new PensjonatContext())
            {
                var roomTypes = from roomType in context.RoomTypes
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
        }

        private void RefreshFeaturesButton_Click(object sender, EventArgs e)
        {
            using (var context = new PensjonatContext())
            {
                var features = from feature in context.Features
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
        }

        private void VisitSearchButton_Click(object sender, EventArgs e)
        {

        }

        private void SaveClientChangesButton_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
