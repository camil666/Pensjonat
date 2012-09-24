namespace Projekt_BD.Controller
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.View;

    /// <summary>
    /// Controller class for EditMealPlan form.
    /// </summary>
    public class EditMealPlanController : ControllerBase
    {
        #region Fields

        /// <summary>
        /// Single mealplan.
        /// </summary>
        private VisitMealPlan visitMealPlan;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EditMealPlanController" /> class.
        /// </summary>
        public EditMealPlanController()
        {
            base.Form = new EditMealPlan();

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
        public new EditMealPlan Form
        {
            get
            {
                return base.Form as EditMealPlan;
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
            this.Form.CancButton.Click += this.CancelButton_Click;
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// Handles the Click event of the CancelButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Form.Dispose();
        }

        /// <summary>
        /// Handles the Click event of the OkButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            string additionalInfo = this.Form.AdditionalInfoTextBox.Text;
            int count = 0;
            DateTime startDate = this.Form.StartDateTimePicker.Value;
            DateTime endDate = this.Form.EndDateTimePicker.Value.AddSeconds(1.0);
            bool breakfast = this.Form.BreakfastCheckBox.Checked;
            bool diet = this.Form.DietCheckBox.Checked;
            bool dinner = this.Form.DinnerCheckBox.Checked;
            bool lunch = this.Form.LunchCheckBox.Checked;
            bool toRoom = this.Form.ToRoomCheckBox.Checked;
            bool vegetarian = this.Form.VegetarianCheckBox.Checked;
            
            int.TryParse(this.Form.CountTextBox.Text, out count);

            var visit = DataAccess.Instance.Visits.Single(x => x.Id == this.SecondaryId);

            if ((visit.StartDate > startDate) || (visit.EndDate < endDate))
            {
                MessageBox.Show(
                        "Posiłek nie może znajdować się poza datą wizyty!",
                        "Błąd",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1);

                    return;
            }

            if ((startDate >= endDate) || count <= 0)
            {
                MessageBox.Show(
                    "Podane wartości nie są prawidłowe lub pozostawiono niewypełnione pola.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            double price = 0;
            var mealPrice = DataAccess.Instance.MealPrices.GetAll().FirstOrDefault();
            if (dinner && breakfast && lunch)
            {
                price = mealPrice.ThreeMealsPrice;
            }
            else
            {
                if (dinner)
                {
                    price += mealPrice.DinnerPrice;
                }

                if (breakfast)
                {
                    price += mealPrice.BreakfastPrice;
                }

                if (lunch)
                {
                    price += mealPrice.LunchPrice;
                }
            }

            price *= count;
            price *= endDate.Subtract(startDate).Days + 1;
            if (this.IsEditForm)
            {
                this.visitMealPlan.MealPlan.PeopleCount = count;
                this.visitMealPlan.MealPlan.Diet = diet;
                this.visitMealPlan.MealPlan.Breakfast = breakfast;
                this.visitMealPlan.MealPlan.Dinner = dinner;
                this.visitMealPlan.MealPlan.Lunch = lunch;
                this.visitMealPlan.MealPlan.ToRoom = toRoom;
                this.visitMealPlan.MealPlan.Vegetarian = vegetarian;
                this.visitMealPlan.MealPlan.Price = price;
                this.visitMealPlan.StartDate = startDate;
                this.visitMealPlan.EndDate = endDate;
                this.visitMealPlan.MealPlan.AdditionalInfo = additionalInfo;
            }
            else
            {
                var mealPlan = new MealPlan
                    {
                        AdditionalInfo = additionalInfo,
                        Breakfast = breakfast,
                        Diet = diet,
                        Dinner = dinner,
                        Lunch = lunch,
                        PeopleCount = count,
                        Price = price,
                        ToRoom = toRoom,
                        Vegetarian = vegetarian
                    };
                DataAccess.Instance.MealPlans.Add(mealPlan);
                DataAccess.Instance.UnitOfWork.Commit();
                this.visitMealPlan = new VisitMealPlan
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    MealPlan = mealPlan,
                    VisitId = this.SecondaryId
                };

                DataAccess.Instance.VisitMealPlans.Add(this.visitMealPlan);
            }

            DataAccess.Instance.UnitOfWork.Commit();

            this.Form.Dispose();
        }

        /// <summary>
        /// Handles the Load event of the Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void Form_Load(object sender, EventArgs e)
        {
            if (this.IsEditForm)
            {
                this.visitMealPlan = DataAccess.Instance.VisitMealPlans.Single(x => x.Id == this.ItemToEditID);
                this.Form.DietCheckBox.Checked = this.visitMealPlan.MealPlan.Diet;
                this.Form.DinnerCheckBox.Checked = this.visitMealPlan.MealPlan.Dinner;
                this.Form.LunchCheckBox.Checked = this.visitMealPlan.MealPlan.Lunch;
                this.Form.ToRoomCheckBox.Checked = this.visitMealPlan.MealPlan.ToRoom;
                this.Form.VegetarianCheckBox.Checked = this.visitMealPlan.MealPlan.Vegetarian;
                this.Form.BreakfastCheckBox.Checked = this.visitMealPlan.MealPlan.Breakfast;
                this.Form.StartDateTimePicker.Value = this.visitMealPlan.StartDate;
                this.Form.EndDateTimePicker.Value = this.visitMealPlan.EndDate;
                this.Form.AdditionalInfoTextBox.Text = this.visitMealPlan.MealPlan.AdditionalInfo;
                this.Form.CountTextBox.Text = this.visitMealPlan.MealPlan.PeopleCount.ToString(CultureInfo.InvariantCulture);
                this.Form.Text = "Edycja posiłku";
            }
            else
            {
                this.Form.Text = "Nowy posiłek";
            }
        }

        #endregion
    }
}
