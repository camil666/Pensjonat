namespace Projekt_BD.Controller
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Projekt_BD.View;

    /// <summary>
    /// Controller class for MealPlan form.
    /// </summary>
    public class MealPlanController : ControllerBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MealPlanController" /> class.
        /// </summary>
        public MealPlanController()
        {
            base.Form = new MealPlansView();

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
        public new MealPlansView Form
        {
            get
            {
                return base.Form as MealPlansView;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets up the events.
        /// </summary>
        private void SetupEvents()
        {
            this.Form.Load += this.Form_Load;
            this.Form.OkButton.Click += this.OkButton_Click;
            this.Form.AddButton.Click += this.AddButton_Click;
            this.Form.EditButton.Click += this.EditButton_Click;
            this.Form.DeleteMealPlan.Click += this.DeleteButton_Click;
        }

        /// <summary>
        /// Sets the column names and visibility.
        /// </summary>
        private void SetColumnNamesAndVisibility()
        {
            this.Form.DataGridView.Columns["Id"].Visible = false;
        }

        /// <summary>
        /// Refreshes the data grid view.
        /// </summary>
        private void RefreshDataGridView()
        {
            var mealplans = (from visitMealPlan in DataAccess.Instance.VisitMealPlans.GetAll()
                             where visitMealPlan.VisitId == ItemToEditID
                             join mealPlan in DataAccess.Instance.MealPlans.GetAll() on visitMealPlan.PlanId equals mealPlan.Id
                             select
                                new
                                {
                                    VisitMealPlanId = visitMealPlan.Id,
                                    mealPlan.Id,
                                    mealPlan.Price,
                                    visitMealPlan.StartDate,
                                    visitMealPlan.EndDate,
                                    mealPlan.PeopleCount
                                }).ToList();

            this.Form.DataGridView.DataSource = mealplans;

            this.SetColumnNamesAndVisibility();
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
            this.Form.Dispose();
        }

        /// <summary>
        /// Handles the Click event of the DeleteButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (this.Form.DataGridView.SelectedRows.Count > 0)
            {
                var selectedRowIndexes = this.Form.DataGridView.SelectedRows;
                foreach (DataGridViewRow item in selectedRowIndexes)
                {
                    var id = (int)this.Form.DataGridView[0, item.Index].Value;
                    var visitMealPlan = DataAccess.Instance.VisitMealPlans.Single(t => t.Id == id);
                    DataAccess.Instance.MealPlans.Delete(visitMealPlan.MealPlan);
                    DataAccess.Instance.VisitMealPlans.Delete(visitMealPlan);
                }

                DataAccess.Instance.UnitOfWork.Commit();
                this.RefreshDataGridView();
            }
            else
            {
                MessageBox.Show("Nie zaznaczono zadań do usunięcia!");
            }
        }

        /// <summary>
        /// Handles the Click event of the EditButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (this.Form.DataGridView.SelectedRows.Count > 0)
            {
                int rowIndex = this.Form.DataGridView.SelectedRows[0].Index;
                int index = (int)this.Form.DataGridView["VisitMealPlanId", rowIndex].Value;

                var controller = ControllerFactory.Instance.Create(ControllerTypes.EditMealPlansForVisitForm);
                controller.ItemToEditID = index;
                controller.ClientID = this.ItemToEditID;
                controller.Form.ShowDialog();
                this.RefreshDataGridView();
            }
            else
            {
                MessageBox.Show("Należy zaznaczyć usługę", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Handles the Click event of the AddButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            var controller = ControllerFactory.Instance.Create(ControllerTypes.EditMealPlansForVisitForm);
            controller.ClientID = this.ItemToEditID;
            controller.Form.ShowDialog();
            this.RefreshDataGridView();
        }

        /// <summary>
        /// Handles the Load event of the Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void Form_Load(object sender, EventArgs e)
        {
            this.RefreshDataGridView();
        }

        #endregion
    }
}
