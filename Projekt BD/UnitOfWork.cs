namespace Projekt_BD
{
    using System;
    using Projekt_BD.Interfaces;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Fields

        private readonly IObjectContext objectContext;

        #endregion

        #region Constructors

        public UnitOfWork(IObjectContext objectContext)
        {
            this.objectContext = objectContext;
        }

        #endregion

        #region Methods

        public void Dispose()
        {
            if (this.objectContext != null)
            {
                this.objectContext.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            this.objectContext.SaveChanges();
        }

        #endregion
    }
}
