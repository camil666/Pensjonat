namespace Projekt_BD.Interfaces
{
    using System;
    using System.Data.Objects;

    public interface IObjectContext : IDisposable
    {
        #region Methods

        IObjectSet<T> CreateObjectSet<T>() where T : class;

        void SaveChanges();

        #endregion
    }
}
