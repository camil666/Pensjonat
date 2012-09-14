namespace Projekt_BD.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class
    {
        #region Methods

        /// <summary>
        /// Returns the repository as queryable object.
        /// </summary>
        /// <returns>IQueryable object.</returns>
        IQueryable<T> AsQueryable();

        /// <summary>
        /// Gets all the data.
        /// </summary>
        /// <returns>All the data.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Finds the specified entities.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Found entities.</returns>
        IQueryable<T> Find(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties);

        T Single(Expression<Func<T, bool>> where);

        T First(Expression<Func<T, bool>> where);

        void Delete(T entity);

        void Add(T entity);

        void Attach(T entity);

        #endregion
    }
}
