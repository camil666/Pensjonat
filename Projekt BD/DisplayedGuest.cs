namespace Projekt_BD
{
    using System;
    using System.Collections;

    /// <summary>
    /// Holds information of guests displayed in grids.
    /// </summary>
    public class DisplayedGuest
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayedGuest" /> class.
        /// </summary>
        public DisplayedGuest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayedGuest" /> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="town">The town.</param>
        /// <param name="isVerified">if set to <c>true</c> [is verified].</param>
        public DisplayedGuest(int id, string firstName, string lastName, string town, bool isVerified)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Town = town;
            this.IsVerified = isVerified;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the town.
        /// </summary>
        /// <value>
        /// The town.
        /// </value>
        public string Town { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this guest is verified.
        /// </summary>
        /// <value>
        /// <c>true</c> if this guest is verified; otherwise, <c>false</c>.
        /// </value>
        public bool IsVerified { get; set; }

        #endregion
    }
}
