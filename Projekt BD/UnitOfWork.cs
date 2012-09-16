namespace Projekt_BD
{
    using System;
    using Projekt_BD.Interfaces;

    /// <summary>
    /// Holds context and allows to commit changes.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Fields

        /// <summary>
        /// Holds context.
        /// </summary>
        private readonly IObjectContext objectContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="objectContext">The object context.</param>
        public UnitOfWork(IObjectContext objectContext)
        {
            this.objectContext = objectContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this.objectContext != null)
            {
                this.objectContext.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Commits changes.
        /// </summary>
        public void Commit()
        {
            this.objectContext.SaveChanges();
        }

        #endregion
    }
}
