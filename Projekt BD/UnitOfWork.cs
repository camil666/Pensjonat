namespace Projekt_BD
{
    using System;
    using Projekt_BD.Interfaces;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Fields

        private readonly IObjectContext _objectContext;

        #endregion

        #region Constructors

        public UnitOfWork(IObjectContext objectContext)
        {
            this._objectContext = objectContext;
        }

        #endregion

        #region Methods

        public void Dispose()
        {
            if (this._objectContext != null)
            {
                this._objectContext.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            this._objectContext.SaveChanges();
        }

        #endregion
    }
}
