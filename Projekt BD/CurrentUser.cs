namespace Projekt_BD
{
    using System;

    /// <summary>
    /// Holds information of currently logged user.
    /// </summary>
    public class CurrentUser
    {
        #region Fields

        /// <summary>
        /// Holds instance of the class.
        /// </summary>
        private static CurrentUser instance;

        /// <summary>
        /// Indicates if user is logged in and his identity is saved.
        /// </summary>
        private bool isUserLoggedIn;

        /// <summary>
        /// Holds user id.
        /// </summary>
        private int id;

        #endregion

        #region Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="CurrentUser" /> class from being created.
        /// </summary>
        private CurrentUser()
        {
            this.isUserLoggedIn = false;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static CurrentUser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CurrentUser();
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        /// <exception cref="System.InvalidOperationException">Thrown when setter is fired more then once.</exception>
        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (this.isUserLoggedIn)
                {
                    throw new InvalidOperationException("It is only possible to assign user identity once.");
                }
                else
                {
                    this.id = value;
                    this.isUserLoggedIn = true;
                }
            }
        }

        #endregion
    }
}