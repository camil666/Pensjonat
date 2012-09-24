namespace Projekt_BD.Controller
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.View;

    /// <summary>
    /// Controller class for GenerateReceipt form.
    /// </summary>
    public class GenerateReceiptController : ControllerBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateReceiptController" /> class.
        /// </summary>
        public GenerateReceiptController()
        {
            base.Form = new GenerateReceiptForm();

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
        public new GenerateReceiptForm Form
        {
            get
            {
                return base.Form as GenerateReceiptForm;
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
        /// Gets or sets the generate for data source.
        /// </summary>
        /// <value>
        /// The generate for data source.
        /// </value>
        private BindingSource GenerateForDataSource { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Sets up the events.
        /// </summary>
        private void SetupEvents()
        {
            this.Form.CancelButton.Click += this.CancelButton_Click;
            this.Form.Load += this.Form_Load;
            this.Form.AddGuestToReceiptButton.Click += this.AddGuestToVisitButton_Click;
            this.Form.RemoveGuestFromReceiptButton.Click += this.RemoveGuestFromVisitButton_Click;
            this.Form.OkButton.Click += this.OkButton_Click;
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// Handles the Click event of the OkButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (this.GenerateForDataSource.Count > 0)
            {
                var dialog = new SaveFileDialog();
                dialog.DefaultExt = "txt";
                dialog.Filter = "txt files (*.txt)|*.txt";
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    double totalGroupCost = 0;

                    TextWriter writer = new StreamWriter(dialog.FileName);

                    writer.WriteLine("Faktura");
                    writer.WriteLine();

                    foreach (DataGridViewRow row in this.Form.GenerateForGridView.Rows)
                    {
                        int visitId = (int)row.Cells["Id"].Value;
                        var visit = DataAccess.Instance.Visits.Single(r => r.Id == visitId);

                        int visitDuration = visit.EndDate.Subtract(visit.StartDate).Days;
                        double roomPrice = (double)visit.Room.RoomType.PricePerPerson;
                        double totalRoomCost = visitDuration * roomPrice;
                        double totalVisitCost = totalRoomCost;

                        writer.WriteLine(string.Format("Klient: {0} {1}", visit.Guest.FirstName, visit.Guest.LastName));
                        writer.WriteLine("---");
                        writer.WriteLine(string.Format("Cena za pokój: {0}zł/os.", roomPrice));
                        writer.WriteLine(string.Format("Ilość dni: {0}", visitDuration));
                        writer.WriteLine(string.Format("Cena za wynajem pokoju: {0} zł", totalRoomCost));
                        writer.WriteLine("---");
                        writer.WriteLine("Usługi:");

                        foreach (var service in visit.Services)
                        {
                            totalVisitCost += (double)service.ServiceType.Charge;
                            writer.WriteLine(string.Format("{0}: {1}", service.ServiceType.Name, service.ServiceType.Charge));
                        }

                        writer.WriteLine("---");
                        writer.WriteLine("Posiłki:");

                        foreach (var mealPlan in visit.VisitMealPlans)
                        {
                            totalVisitCost += (double)mealPlan.MealPlan.Price;
                            writer.WriteLine(string.Format("Cena: {0} zł\t{1} - {2}", mealPlan.MealPlan.Price, mealPlan.StartDate, mealPlan.EndDate));
                        }

                        writer.WriteLine("---");
                        writer.WriteLine("Zniżki:");

                        var discounts = DataAccess.Instance.Discounts.Find(d => d.GuestId == visit.GuestId);
                        if (discounts == null)
                        {
                            writer.WriteLine(string.Format("Brak zniżek!"));
                        }

                        foreach (var discount in discounts)
                        {
                            totalVisitCost -= discount.Amount;
                            writer.WriteLine(string.Format("-{0}", discount.Amount));

                            if (totalVisitCost < 0)
                            {
                                totalVisitCost = 0;
                            }
                        }

                        writer.WriteLine("---");
                        writer.WriteLine("Cena za pobyt: {0} zł", totalVisitCost);
                        writer.WriteLine();
                        totalGroupCost += totalVisitCost;
                    }

                    if (this.GenerateForDataSource.Count > 1)
                    {
                        writer.WriteLine();
                        writer.WriteLine("------");
                        writer.WriteLine("Cena za grupę: {0} zł", totalGroupCost);
                    }

                    writer.Close();
                }

                MessageBox.Show(
                    "Faktura została wygenerowana.",
                    "Sukces",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);

                this.Form.Close();
            }
            else
            {
                MessageBox.Show(
                    "Należy wybrać przynajmniej jednego gościa.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Handles the Load event of the Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void Form_Load(object sender, EventArgs e)
        {
            this.GenerateForDataSource = new BindingSource();
            this.GuestsDataSource = new BindingSource();
            this.Form.GuestsDataGridView.DataSource = this.GuestsDataSource;
            this.Form.GenerateForGridView.DataSource = this.GenerateForDataSource;

            if (this.IsEditForm)
            {
                var visitsToBeDisplayed = new List<Visit>();

                var visit = DataAccess.Instance.Visits.Single(r => r.Id == this.ItemToEditID);

                this.Form.StartDateDateTimePicker.Value = visit.StartDate;
                this.Form.EndDateDateTimePicker.Value = visit.EndDate;

                if (visit.ParentId != null)
                {
                    Visit parentVisit = DataAccess.Instance.Visits.Single(v => v.Id == visit.ParentId);

                    var visits = DataAccess.Instance.Visits.Find(v => v.ParentId == parentVisit.Id).ToList();

                    visitsToBeDisplayed.Add(parentVisit);
                    visitsToBeDisplayed.AddRange(visits);
                }
                else
                {
                    var childVisits = DataAccess.Instance.Visits.Find(v => v.ParentId == visit.Id).ToList();

                    visitsToBeDisplayed.Add(visit);
                    visitsToBeDisplayed.AddRange(childVisits);
                }

                this.GuestsDataSource.DataSource = (from v in visitsToBeDisplayed
                                                    select new
                                                    {
                                                        Id = v.Id,
                                                        FirstName = v.Guest.FirstName,
                                                        LastName = v.Guest.LastName,
                                                        StartDate = v.StartDate,
                                                        EndDate = v.EndDate
                                                    }).ToList();

                this.Form.GuestsDataGridView.Columns["Id"].Visible = false;
                this.Form.GuestsDataGridView.Columns["FirstName"].HeaderText = "Imię";
                this.Form.GuestsDataGridView.Columns["LastName"].HeaderText = "Nazwisko";
                this.Form.GuestsDataGridView.Columns["StartDate"].HeaderText = "Data rozpoczęcia";
                this.Form.GuestsDataGridView.Columns["EndDate"].HeaderText = "Data zakończenia";
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
            foreach (DataGridViewRow item in this.Form.GenerateForGridView.SelectedRows)
            {
                this.GuestsDataSource.Add(this.GenerateForDataSource.List[item.Index]);
                this.GenerateForDataSource.RemoveAt(item.Index);
            }
        }

        /// <summary>
        /// Handles the Click event of the AddGuestToVisitButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AddGuestToVisitButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.Form.GuestsDataGridView.SelectedRows)
            {
                this.GenerateForDataSource.Add(this.GuestsDataSource.List[item.Index]);
                this.GuestsDataSource.RemoveAt(item.Index);
            }

            this.Form.GenerateForGridView.Columns["Id"].Visible = false;
            this.Form.GenerateForGridView.Columns["FirstName"].HeaderText = "Imię";
            this.Form.GenerateForGridView.Columns["LastName"].HeaderText = "Nazwisko";
            this.Form.GenerateForGridView.Columns["StartDate"].HeaderText = "Data rozpoczęcia";
            this.Form.GenerateForGridView.Columns["EndDate"].HeaderText = "Data zakończenia";
        }

        #endregion
    }
}
