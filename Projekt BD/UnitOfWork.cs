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
            _objectContext = objectContext;
        }

        #endregion

        #region Methods

        public void Dispose()
        {
            if (_objectContext != null)
            {
                _objectContext.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            _objectContext.SaveChanges();
        }

        #endregion
    }
}
