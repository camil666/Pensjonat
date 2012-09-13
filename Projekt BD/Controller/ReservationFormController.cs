namespace Projekt_BD.Controller
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.View;

    public class ReservationFormController : ControllerBase
    {
        #region Constructors

        public ReservationFormController()
        {
            base.Form = new ReservationForm();

            this.SetupEvents();
        }

        #endregion

        #region Properties

        public new ReservationForm Form
        {
            get
            {
                return base.Form as ReservationForm;
            }
        }

        public int ClientId { get; set; }

        public int ReservationId { get; set; }

        private bool IsEditForm
        {
            get
            {
                return this.ReservationId > 0;
            }
        }

        private BindingSource FreeRoomsSource { get; set; }

        private BindingSource ReservedRoomsSource { get; set; }

        #endregion

        #region Methods

        private static void SetColumnNames(DataGridView grid)
        {
            if (grid != null)
            {
                grid.Columns["Number"].HeaderText = "Numer";
                grid.Columns["Name"].HeaderText = "Typ";
                grid.Columns["Capacity"].HeaderText = "Pojemność";
                grid.Columns["Floor"].HeaderText = "Piętro";
                grid.Columns["Price"].HeaderText = "Cena";
            }
            else
            {
                throw new ArgumentNullException("grid");
            }
        }

        private void SetupEvents()
        {
            this.Form.Load += this.Form_Load;
            this.Form.CancelButton.Click += this.CancelButton_Click;
            this.Form.AddToReservationButton.Click += this.AddToReservationButton_Click;
            this.Form.RemoveFromReservationButton.Click += this.RemoveFromReservationButton_Click;
            this.Form.AddButton.Click += this.AddButton_Click;
            this.Form.StartDateDateTimePicker.ValueChanged += this.StartDateDateTimePicker_ValueChanged;
            this.Form.EndDateDateTimePicker.ValueChanged += this.EndDateDateTimePicker_ValueChanged;
        }

        #endregion

        #region Event Methods

        private void Form_Load(object sender, EventArgs e)
        {
            using (var context = new PensjonatContext())
            {
                try
                {
                    var freeRooms = (from room in context.Rooms
                                     where room.Vacancy == true
                                     select new { room.Number, room.RoomType.Name, room.Capacity, room.Floor, room.RoomType.Price }).ToList();

                    this.FreeRoomsSource = new BindingSource();
                    this.FreeRoomsSource.DataSource = freeRooms;

                    this.Form.FreeRoomsDataGridView.DataSource = this.FreeRoomsSource;

                    SetColumnNames(this.Form.FreeRoomsDataGridView);

                    var client = (from c in context.Guests
                                  where c.Id == this.ClientId
                                  select new { c.FirstName, c.LastName }).FirstOrDefault();

                    this.Form.ClientTextBox.Text = string.Concat(client.FirstName, " ", client.LastName);

                    if (this.IsEditForm)
                    {
                        this.Form.Text = "Edycja Rezerwacji";

                        var reservation = from r in context.Reservations
                                          where r.Id == this.ReservationId
                                          select r;

                        this.Form.AddInfoTextBox.Text = reservation.First().AdditionalInfo;
                        this.Form.StartDateDateTimePicker.Value = reservation.First().StartDate;
                        this.Form.EndDateDateTimePicker.Value = reservation.First().EndDate;

                        var roomsReservations = (from room in context.RoomReservations
                                                 where room.ReservationId == this.ReservationId
                                                 select new { room.Room.Number, room.Room.RoomType.Name, room.Room.Capacity, room.Room.Floor, room.Room.RoomType.Price }).ToList();

                        this.ReservedRoomsSource = new BindingSource();
                        this.ReservedRoomsSource.DataSource = roomsReservations;

                        this.Form.RoomsToBeReservedDataGridView.DataSource = this.ReservedRoomsSource;

                        SetColumnNames(this.Form.RoomsToBeReservedDataGridView);
                    }
                    else
                    {
                        this.Form.Text = "Nowa Rezerwacja";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.Message);
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Form.Close();
        }

        private void AddToReservationButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.Form.FreeRoomsDataGridView.SelectedRows)
            {
                this.ReservedRoomsSource.Add(this.FreeRoomsSource.List[item.Index]);
                this.FreeRoomsSource.RemoveAt(item.Index);
            }
        }

        private void RemoveFromReservationButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.Form.RoomsToBeReservedDataGridView.SelectedRows)
            {
                this.FreeRoomsSource.Add(this.ReservedRoomsSource.List[item.Index]);
                this.ReservedRoomsSource.RemoveAt(item.Index);
            }
        }

        //TODO: dokonczyc od tego momentu

        private void AddButton_Click(object sender, EventArgs e)
        {
            var reservation = new Reservation
            {
                AdditionalInfo = this.Form.AddInfoTextBox.Text,
                StartDate = this.Form.StartDateDateTimePicker.Value,
                EndDate = this.Form.EndDateDateTimePicker.Value,
                GuestId = this.ClientId
            };

            using (var context = new PensjonatContext())
            {
                context.AddToReservations(reservation);
                context.SaveChanges();
            }

            using (var context = new PensjonatContext())
            {
                foreach (DataGridViewRow row in this.Form.RoomsToBeReservedDataGridView.Rows)
                {
                    int roomNumber = (int)row.Cells["Number"].Value;

                    context.AddToRoomReservations(
                        new RoomReservation
                        {
                            RoomId = roomNumber,
                            StartDate = this.Form.StartDateDateTimePicker.Value,
                            EndDate = this.Form.EndDateDateTimePicker.Value,
                            ReservationId = reservation.Id
                        });
                }

                context.SaveChanges();
            }
        }

        private void StartDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.Form.StartDateDateTimePicker.Value > this.Form.EndDateDateTimePicker.Value)
            {
                this.Form.EndDateDateTimePicker.Value = this.Form.StartDateDateTimePicker.Value;
            }

            //this.Form.FreeRoomsDataGridView.DataSource = null;
            //this.Form.RoomsToBeReservedDataGridView.DataSource = null;
        }

        private void EndDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.Form.EndDateDateTimePicker.Value < this.Form.StartDateDateTimePicker.Value)
            {
                this.Form.StartDateDateTimePicker.Value = this.Form.EndDateDateTimePicker.Value;
            }

            //this.Form.FreeRoomsDataGridView.DataSource = null;
            //this.Form.RoomsToBeReservedDataGridView.DataSource = null;
        }
        #endregion
    }
}
