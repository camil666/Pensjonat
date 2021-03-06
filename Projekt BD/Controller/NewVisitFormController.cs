﻿namespace Projekt_BD.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.View;

    /// <summary>
    /// Controller class for NewVisit form.
    /// </summary>
    public class NewVisitFormController : ControllerBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NewVisitFormController" /> class.
        /// </summary>
        public NewVisitFormController()
        {
            base.Form = new NewVisitForm();

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
        public new NewVisitForm Form
        {
            get
            {
                return base.Form as NewVisitForm;
            }
        }

        /// <summary>
        /// Gets or sets the guests data source.
        /// </summary>
        /// <value>
        /// The guests data source.
        /// </value>
        private BindingSource GuestsDataSource { get; set; }

        /// <summary>
        /// Gets or sets the added guests data sources.
        /// </summary>
        /// <value>
        /// The added guests data sources.
        /// </value>
        private List<BindingSource> AddedGuestsDataSources { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Sets up the events.
        /// </summary>
        private void SetupEvents()
        {
            this.Form.CancelButton.Click += this.CancelButton_Click;
            this.Form.Load += this.Form_Load;
            this.Form.AddGuestToVisitButton.Click += this.AddGuestToVisitButton_Click;
            this.Form.RemoveGuestFromVisitButton.Click += this.RemoveGuestFromVisitButton_Click;
            this.Form.OkButton.Click += this.OkButton_Click;
            this.Form.RoomNumberComboBox.SelectedValueChanged += this.RoomNumberComboBox_SelectedValueChanged;
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// Handles the SelectedValueChanged event of the RoomNumberComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void RoomNumberComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            int roomIndex = this.Form.RoomNumberComboBox.SelectedIndex;

            this.Form.GuestsToVisitDataGridView.DataSource = this.AddedGuestsDataSources[roomIndex];
        }

        /// <summary>
        /// Handles the Click event of the OkButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            int parentVisitId = 0;
            var visitsToBeAdded = new List<Visit>();
            double advance;
            double.TryParse(this.Form.AdvanceTextBox.Text, out advance);

            foreach (var datasource in this.AddedGuestsDataSources)
            {
                foreach (var item in datasource.List)
                {
                    var guest = item as DisplayedGuest;

                    visitsToBeAdded.Add(new Visit()
                    {
                        AdditionalInfo = this.Form.AddInfoTextBox.Text,
                        Advance = advance,
                        EndDate = this.Form.EndDateDateTimePicker.Value,
                        StartDate = this.Form.StartDateDateTimePicker.Value,
                        RoomId = (int)this.Form.RoomNumberComboBox.Items[this.AddedGuestsDataSources.IndexOf(datasource)],
                        GuestId = guest.Id
                    });
                }
            }

            if (advance < 0)
            {
                MessageBox.Show(
                    "Zaliczka nie może być ujemna!",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            if (visitsToBeAdded.Count < 1)
            {
                MessageBox.Show(
                    "Należy dodać do pokoju minimum jednego gościa.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            var reservation = DataAccess.Instance.Reservations.Single(r => r.Id == this.ItemToEditID);

            Visit parentVisit = visitsToBeAdded.SingleOrDefault(v => v.GuestId == reservation.GuestId);
            if (parentVisit != null)
            {
                DataAccess.Instance.Visits.Add(parentVisit);
                DataAccess.Instance.UnitOfWork.Commit();
                parentVisitId = parentVisit.Id;
                visitsToBeAdded.Remove(parentVisit);
            }
            else
            {
                DataAccess.Instance.Visits.Add(visitsToBeAdded[0]);
                DataAccess.Instance.UnitOfWork.Commit();
                parentVisitId = visitsToBeAdded[0].Id;
                visitsToBeAdded.RemoveAt(0);
            }

            foreach (var visit in visitsToBeAdded)
            {
                visit.ParentId = parentVisitId;
                DataAccess.Instance.Visits.Add(visit);
            }

            reservation.IsVisit = true;

            DataAccess.Instance.UnitOfWork.Commit();
            this.Form.Close();
        }

        /// <summary>
        /// Handles the Load event of the Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void Form_Load(object sender, EventArgs e)
        {
            this.AddedGuestsDataSources = new List<BindingSource>();
            this.GuestsDataSource = new BindingSource();
            this.Form.GuestsDataGridView.DataSource = this.GuestsDataSource;

            if (this.IsEditForm)
            {
                var reservation = DataAccess.Instance.Reservations.Single(r => r.Id == this.ItemToEditID);

                this.Form.AddInfoTextBox.Text = reservation.AdditionalInfo;
                this.Form.StartDateDateTimePicker.Value = reservation.StartDate;
                this.Form.EndDateDateTimePicker.Value = reservation.EndDate;

                this.GuestsDataSource.DataSource = (from guest in DataAccess.Instance.Guests.GetAll()
                                                    select new DisplayedGuest()
                                                    {
                                                        Id = guest.Id,
                                                        FirstName = guest.FirstName,
                                                        LastName = guest.LastName,
                                                        Town = guest.Town,
                                                        IsVerified = guest.IsVerified
                                                    }).ToList();

                int reservedRoomsCount = reservation.RoomReservations.Count();

                foreach (var room in reservation.RoomReservations)
                {
                    this.Form.RoomNumberComboBox.Items.Add(room.RoomId);
                }

                for (int i = 0; i < reservedRoomsCount; ++i)
                {
                    this.AddedGuestsDataSources.Add(new BindingSource());
                }

                this.Form.RoomNumberComboBox.SelectedIndex = 0;

                this.Form.GuestsDataGridView.Columns["Id"].Visible = false;
                this.Form.GuestsDataGridView.Columns["FirstName"].HeaderText = "Imię";
                this.Form.GuestsDataGridView.Columns["LastName"].HeaderText = "Nazwisko";
                this.Form.GuestsDataGridView.Columns["Town"].HeaderText = "Miasto";
                this.Form.GuestsDataGridView.Columns["IsVerified"].HeaderText = "Zweryfikowany";
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
        /// Handles the Click event of the RemoveGuestFromVisitButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void RemoveGuestFromVisitButton_Click(object sender, EventArgs e)
        {
            int roomIndex = this.Form.RoomNumberComboBox.SelectedIndex;

            foreach (DataGridViewRow item in this.Form.GuestsToVisitDataGridView.SelectedRows)
            {
                this.GuestsDataSource.Add(this.AddedGuestsDataSources[roomIndex].List[item.Index]);
                this.AddedGuestsDataSources[roomIndex].RemoveAt(item.Index);
            }
        }

        /// <summary>
        /// Handles the Click event of the AddGuestToVisitButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AddGuestToVisitButton_Click(object sender, EventArgs e)
        {
            int roomIndex = this.Form.RoomNumberComboBox.SelectedIndex;
            var number = (int)this.Form.RoomNumberComboBox.Items[roomIndex];
            var room = DataAccess.Instance.Rooms.Single(x => x.Number == number);
            if (room.Capacity <= this.AddedGuestsDataSources[roomIndex].Count)
            {
                MessageBox.Show(
                    "Zbyt dużo gości w jednym pokoju!.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            foreach (DataGridViewRow item in this.Form.GuestsDataGridView.SelectedRows)
            {
                this.AddedGuestsDataSources[roomIndex].Add(this.GuestsDataSource.List[item.Index]);
                this.GuestsDataSource.RemoveAt(item.Index);
            }

            this.Form.GuestsToVisitDataGridView.Columns["Id"].Visible = false;
            this.Form.GuestsToVisitDataGridView.Columns["FirstName"].HeaderText = "Imię";
            this.Form.GuestsToVisitDataGridView.Columns["LastName"].HeaderText = "Nazwisko";
            this.Form.GuestsToVisitDataGridView.Columns["Town"].HeaderText = "Miasto";
            this.Form.GuestsToVisitDataGridView.Columns["IsVerified"].HeaderText = "Zweryfikowany";
        }

        #endregion
    }
}
