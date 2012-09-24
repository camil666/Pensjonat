namespace Projekt_BD.Controller
{
    using System.Windows.Forms;
    using Projekt_BD.Interfaces;

    /// <summary>
    /// Base class for controller class objects.
    /// </summary>
    public abstract class ControllerBase : IController
    {
        #region Properties

        /// <summary>
        /// Gets or sets the form.
        /// </summary>
        /// <value>
        /// The form.
        /// </value>
        public Form Form { get; protected set; }

        /// <summary>
        /// Gets or sets the client ID.
        /// </summary>
        /// <value>
        /// The client ID.
        /// </value>
        public int ClientID { get; set; }

        /// <summary>
        /// Gets or sets the item to edit ID.
        /// </summary>
        /// <value>
        /// The item to edit ID.
        /// </value>
        public int ItemToEditID { get; set; }

        /// <summary>
        /// Gets or sets the secondary id.
        /// </summary>
        /// <value>
        /// The secondary id.
        /// </value>
        public int SecondaryId { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is edit form.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is edit form; otherwise, <c>false</c>.
        /// </value>
        protected bool IsEditForm
        {
            get
            {
                return this.ItemToEditID > 0;
            }
        }

        #endregion
    }
}
