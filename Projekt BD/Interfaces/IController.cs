namespace Projekt_BD.Interfaces
{
    using System.Windows.Forms;

    /// <summary>
    /// Interface for controller class.
    /// </summary>
    public interface IController
    {
        #region Properties

        /// <summary>
        /// Gets the form.
        /// </summary>
        /// <value>
        /// The form.
        /// </value>
        Form Form { get; }

        /// <summary>
        /// Gets or sets the client ID.
        /// </summary>
        /// <value>
        /// The client ID.
        /// </value>
        int ClientID { get; set; }

        /// <summary>
        /// Gets or sets the item to edit ID.
        /// </summary>
        /// <value>
        /// The item to edit ID.
        /// </value>
        int ItemToEditID { get; set; }

        /// <summary>
        /// Gets or sets the secondary id.
        /// </summary>
        /// <value>
        /// The secondary id.
        /// </value>
        int SecondaryId { get; set; }

        #endregion
    }
}
