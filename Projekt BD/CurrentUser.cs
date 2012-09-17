namespace Projekt_BD
{
    using System;

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
            isUserLoggedIn = false;
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

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                if (this.isUserLoggedIn)
                {
                    throw new InvalidOperationException("It is only possible to assign user identity once.");
                }
                else
                {
                    id = value;
                    isUserLoggedIn = true;
                }
            }
        }

        #endregion
    }
}