// -----------------------------------------------------------------------
// <copyright file="MealPlanController.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Projekt_BD.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    using Projekt_BD.View;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MealPlanController : ControllerBase
    {
        
        #region Constructors

        public MealPlanController()
        {
            base.Form = new MealPlansView();

            this.SetupEvents();
        }

        #endregion

        #region Properties

        public new MealPlansView Form
        {
            get
            {
                return base.Form as MealPlansView;
            }
        }

        #endregion

        #region Methods

        private void SetupEvents()
        {
            this.Form.Load += this.FormLoad;
            this.Form.OkButton.Click += this.OkButtonClick;
            this.Form.AddButton.Click += this.AddButtonClick;
            this.Form.EditButton.Click += this.EditButtonClick;
            this.Form.DeleteMealPlan.Click += this.DeleteButtonClick;

        }
        
        private void OkButtonClick(object sender, EventArgs e)
        {
            this.Form.Dispose();
        }

        private void SetColumnNamesAndVisibility()
        {
            this.Form.DataGridView.Columns["Id"].Visible = false;

        }

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

        private void DeleteButtonClick(object sender, EventArgs e)
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

        private void EditButtonClick(object sender, EventArgs e)
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

        private void AddButtonClick(object sender, EventArgs e)
        {
            var controller = ControllerFactory.Instance.Create(ControllerTypes.EditMealPlansForVisitForm);
            controller.ClientID = this.ItemToEditID;
            controller.Form.ShowDialog();
            this.RefreshDataGridView();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            this.RefreshDataGridView();
        }

        #endregion
    }
}
