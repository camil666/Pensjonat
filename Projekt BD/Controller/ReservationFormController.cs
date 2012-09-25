namespace Projekt_BD.Controller
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.View;

    /// <summary>
    /// Controller class for Reservation form.
    /// </summary>
    public class ReservationFormController : ControllerBase
    {
        #region Fields

        /// <summary>
        /// Name of the Number column.
        /// </summary>
        private static readonly string NumberColumnName = "Number";

        /// <summary>
        /// Name of the Name column.
        /// </summary>
        private static readonly string NameColumnName = "Name";

        /// <summary>
        /// Name of the Capacity column.
        /// </summary>
        private static readonly string CapacityColumnName = "Capacity";

        /// <summary>
        /// Name of the Floor column.
        /// </summary>
        private static readonly string FloorColumnName = "Floor";

        /// <summary>
        /// Name of the Price column.
        /// </summary>
        private static readonly string PriceColumnName = "Price";

        /// <summary>
        /// Indicates if form is loaded.
        /// </summary>
        private bool formIsLoaded;

        /// <summary>
        /// Indicates if any edits were made.
        /// </summary>
        private bool editsWereMade;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationFormController" /> class.
        /// </summary>
        public ReservationFormController()
        {
            base.Form = new ReservationForm();

            this.SetupEvents();

            this.formIsLoaded = false;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the form.
        /// </summary>
        /// <value>
        /// The form.
        /// </value>
        public new ReservationForm Form
        {
            get
            {
                return base.Form as ReservationForm;
            }
        }

        /// <summary>
        /// Gets or sets the free rooms source.
        /// </summary>
        /// <value>
        /// The free rooms source.
        /// </value>
        private BindingSource FreeRoomsSource { get; set; }

        /// <summary>
        /// Gets or sets the reserved rooms source.
        /// </summary>
        /// <value>
        /// The reserved rooms source.
        /// </value>
        private BindingSource ReservedRoomsSource { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the column names.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if given grid was null.</exception>
        private static void SetColumnNames(DataGridView grid)
        {
            if (grid != null)
            {
                grid.Columns[NumberColumnName].HeaderText = "Numer";
                grid.Columns[NameColumnName].HeaderText = "Typ";
                grid.Columns[CapacityColumnName].HeaderText = "Pojemność";
                grid.Columns[FloorColumnName].HeaderText = "Piętro";
                grid.Columns[PriceColumnName].HeaderText = "Cena";
            }
            else
            {
                throw new ArgumentNullException("grid");
            }
        }

        /// <summary>
        /// Sets up the events.
        /// </summary>
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

        /// <summary>
        /// Handles the Load event of the Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                var client = DataAccess.Instance.Guests.Single(guest => guest.Id == this.ClientID);
                this.Form.ClientTextBox.Text = string.Concat(client.FirstName, " ", client.LastName);

                this.ReservedRoomsSource = new BindingSource();

                this.Form.RoomsToBeReservedDataGridView.DataSource = this.ReservedRoomsSource;

                if (this.IsEditForm)
                {
                    this.Form.Text = "Edycja Rezerwacji";

                    var reservationToEdit = DataAccess.Instance.Reservations.Single(reservation => reservation.Id == this.ItemToEditID);

                    this.Form.AddInfoTextBox.Text = reservationToEdit.AdditionalInfo;
                    this.Form.StartDateDateTimePicker.Value = reservationToEdit.StartDate;
                    this.Form.EndDateDateTimePicker.Value = reservationToEdit.EndDate;

                    var roomsReservations = (from room in DataAccess.Instance.RoomReservations.Find(room => room.ReservationId == this.ItemToEditID)
                                             select new { room.Room.Number, room.Room.RoomType.Name, room.Room.Capacity, room.Room.Floor, room.Room.RoomType.Price }).ToList();

                    this.ReservedRoomsSource.DataSource = roomsReservations;

                    SetColumnNames(this.Form.RoomsToBeReservedDataGridView);
                }
                else
                {
                    this.Form.Text = "Nowa Rezerwacja";
                    this.Form.EndDateDateTimePicker.Value = DateTime.Now.AddDays(1.0);
                }

                this.FreeRoomsSource = new BindingSource();
                this.FreeRoomsSource.DataSource = this.GetFreeRooms(this.Form.StartDateDateTimePicker.Value, this.Form.EndDateDateTimePicker.Value);

                this.Form.FreeRoomsDataGridView.DataSource = this.FreeRoomsSource;

                SetColumnNames(this.Form.FreeRoomsDataGridView);

                this.formIsLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the CancelButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Form.Close();
        }

        /// <summary>
        /// Handles the Click event of the AddToReservationButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AddToReservationButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.Form.FreeRoomsDataGridView.SelectedRows)
            {
                this.ReservedRoomsSource.Add(this.FreeRoomsSource.List[item.Index]);
                this.FreeRoomsSource.RemoveAt(item.Index);
            }

            this.editsWereMade = true;
            SetColumnNames(this.Form.RoomsToBeReservedDataGridView);
        }

        /// <summary>
        /// Handles the Click event of the RemoveFromReservationButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void RemoveFromReservationButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.Form.RoomsToBeReservedDataGridView.SelectedRows)
            {
                this.FreeRoomsSource.Add(this.ReservedRoomsSource.List[item.Index]);
                this.ReservedRoomsSource.RemoveAt(item.Index);
            }

            this.editsWereMade = true;
        }

        /// <summary>
        /// Handles the Click event of the AddButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (this.Form.RoomsToBeReservedDataGridView.Rows.Count < 1)
            {
                MessageBox.Show(
                    "Należy zarezerwować minimum 1 pokój.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            if (!this.editsWereMade)
            {
                this.Form.Close();
                return;
            }

            if (this.IsEditForm)
            {
                DataAccess.Instance.Reservations.Delete(DataAccess.Instance.Reservations.Single(r => r.Id == this.ItemToEditID));

                var roomReservationsToDelete = from room in DataAccess.Instance.RoomReservations.Find(r => r.ReservationId == this.ItemToEditID)
                                               select room;

                foreach (var roomReservation in roomReservationsToDelete)
                {
                    DataAccess.Instance.RoomReservations.Delete(roomReservation);
                }
            }

            var reservation = new Reservation
            {
                AdditionalInfo = this.Form.AddInfoTextBox.Text,
                StartDate = this.Form.StartDateDateTimePicker.Value,
                EndDate = this.Form.EndDateDateTimePicker.Value,
                GuestId = this.ClientID
            };

            DataAccess.Instance.Reservations.Add(reservation);

            foreach (DataGridViewRow row in this.Form.RoomsToBeReservedDataGridView.Rows)
            {
                int roomNumber = (int)row.Cells[NumberColumnName].Value;

                DataAccess.Instance.RoomReservations.Add(
                    new RoomReservation
                    {
                        RoomId = roomNumber,
                        StartDate = this.Form.StartDateDateTimePicker.Value,
                        EndDate = this.Form.EndDateDateTimePicker.Value,
                        ReservationId = reservation.Id
                    });
            }

            DataAccess.Instance.UnitOfWork.Commit();
            this.Form.Close();
        }

        /// <summary>
        /// Handles the ValueChanged event of the EndDateDateTimePicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void EndDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.Form.StartDateDateTimePicker.Value >= this.Form.EndDateDateTimePicker.Value)
            {
                this.Form.StartDateDateTimePicker.Value = this.Form.EndDateDateTimePicker.Value.Subtract(new TimeSpan(1, 0, 0, 0));
            }

            this.RefreshGrids();
        }

        /// <summary>
        /// Handles the ValueChanged event of the StartDateDateTimePicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void StartDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.Form.StartDateDateTimePicker.Value >= this.Form.EndDateDateTimePicker.Value)
            {
                this.Form.EndDateDateTimePicker.Value = this.Form.StartDateDateTimePicker.Value.AddDays(1.0);
            }

            this.RefreshGrids();
        }

        /// <summary>
        /// Refreshes the grids.
        /// </summary>
        private void RefreshGrids()
        {
            if (this.formIsLoaded)
            {
                this.FreeRoomsSource.DataSource = this.GetFreeRooms(this.Form.StartDateDateTimePicker.Value, this.Form.EndDateDateTimePicker.Value);
                this.ReservedRoomsSource.Clear();
            }
        }

        /// <summary>
        /// Gets the free rooms.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>List of free rooms.</returns>
        private IList GetFreeRooms(DateTime startDate, DateTime endDate)
        {
            DateTime reservationStart = this.Form.StartDateDateTimePicker.Value;
            DateTime reservationEnd = this.Form.EndDateDateTimePicker.Value;

            var collidingReservations = DataAccess.Instance.RoomReservations
                                        .Find(r => (r.StartDate > reservationStart && r.StartDate < reservationEnd) ||
                                        (r.EndDate > reservationStart && r.EndDate < reservationEnd) ||
                                        (r.StartDate < reservationStart && r.EndDate > reservationEnd));

            return (from room in DataAccess.Instance.Rooms.GetAll().ToList()
                    where !(from r in collidingReservations
                            select r.RoomId).Contains(room.Number)
                    select new { room.Number, room.RoomType.Name, room.Capacity, room.Floor, room.RoomType.Price }).ToList();
        }

        #endregion
    }
}
