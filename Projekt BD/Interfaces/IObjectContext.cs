namespace Projekt_BD.Interfaces
{
    using System;
    using System.Data.Objects;

    /// <summary>
    /// Interface for ObjectContext.
    /// </summary>
    public interface IObjectContext : IDisposable
    {
        #region Methods

        /// <summary>
        /// Creates the object set.
        /// </summary>
        /// <typeparam name="T">Class of objects in the set.</typeparam>
        /// <returns>Instance of IObjectSet.</returns>
        IObjectSet<T> CreateObjectSet<T>() where T : class;

        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Refreshes the specified entity.
        /// </summary>
        /// <typeparam name="T">Class of object to refresh.</typeparam>
        /// <param name="entity">The entity.</param>
        void Refresh<T>(T entity);
        
        #endregion
    }
}
