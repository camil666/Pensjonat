namespace Projekt_BD.Controller
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.View;

    /// <summary>
    /// Controller class for GrantDiscount form.
    /// </summary>
    public class GrantDiscountController : ControllerBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GrantDiscountController" /> class.
        /// </summary>
        public GrantDiscountController()
        {
            base.Form = new GrantDiscountForm();

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
        public new GrantDiscountForm Form
        {
            get
            {
                return base.Form as GrantDiscountForm;
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
            this.Form.GrantDiscountButton.Click += this.GrantDiscountButton_Click;
            this.Form.DeleteDiscountButton.Click += this.DeleteDiscountButton_Click;
        }

        /// <summary>
        /// Refreshes the discounts.
        /// </summary>
        private void RefreshDiscounts()
        {
            var discounts = (from discount in DataAccess.Instance.Discounts.Find(d => d.GuestId == this.ClientID)
                             select new { discount.Id, discount.Amount }).ToList();

            if (discounts != null && discounts.Count > 0)
            {
                this.Form.DiscountsDataGridView.DataSource = discounts;

                this.Form.DiscountsDataGridView.Columns["Id"].Visible = false;
                this.Form.DiscountsDataGridView.Columns["Amount"].HeaderText = "Zniżka";
            }
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
            this.RefreshDiscounts();
        }

        /// <summary>
        /// Handles the Click event of the GrantDiscountButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void GrantDiscountButton_Click(object sender, EventArgs e)
        {
            double discountValue;
            double.TryParse(this.Form.DiscountTextBox.Text, out discountValue);

            if (discountValue <= 0.0)
            {
                MessageBox.Show(
                    "Podane wartości nie są prawidłowe lub pozostawiono niewypełnione pola.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            var discount = new Discount()
            {
                GuestId = this.ClientID,
                Amount = discountValue
            };

            DataAccess.Instance.Discounts.Add(discount);
            DataAccess.Instance.UnitOfWork.Commit();

            this.RefreshDiscounts();
        }

        /// <summary>
        /// Handles the Click event of the DeleteDiscountButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void DeleteDiscountButton_Click(object sender, EventArgs e)
        {
            if (this.Form.DiscountsDataGridView.SelectedRows.Count > 0)
            {
                var discountId = (int)this.Form.DiscountsDataGridView.SelectedRows[0].Cells["Id"].Value;

                Discount discount = DataAccess.Instance.Discounts.Single(d => d.Id == discountId);

                if (discount != null)
                {
                    DataAccess.Instance.Discounts.Delete(discount);
                    DataAccess.Instance.UnitOfWork.Commit();

                    this.RefreshDiscounts();
                }
            }
        }

        #endregion
    }
}
