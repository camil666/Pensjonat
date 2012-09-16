namespace Projekt_BD
{
    using System;
    using System.Data.Entity;
    using System.Data.Objects;
    using System.Linq;
    using System.Linq.Expressions;
    using Projekt_BD.Interfaces;

    /// <summary>
    /// Generic class of repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class Repository<TEntity> where TEntity : class
    {
        #region Fields

        /// <summary>
        /// Holds set of objects.
        /// </summary>
        private IObjectSet<TEntity> objectSet;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}" /> class.
        /// </summary>
        /// <param name="objectContext">The object context.</param>
        public Repository(IObjectContext objectContext)
        {
            this.objectSet = objectContext.CreateObjectSet<TEntity>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all data.
        /// </summary>
        /// <returns>IQueryable containing all data.</returns>
        public IQueryable<TEntity> GetAll()
        {
            return this.objectSet;
        }

        /// <summary>
        /// Finds the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by parameter.</param>
        /// <param name="includeProperties">The properties to be included.</param>
        /// <returns>IQueryable containing found data.</returns>
        public IQueryable<TEntity> Find(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = this.objectSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }

        /// <summary>
        /// Gets single item that meets criteria specified by filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>Found object.</returns>
        public TEntity Single(Expression<Func<TEntity, bool>> filter)
        {
            return this.objectSet.SingleOrDefault(filter);
        }

        /// <summary>
        /// Gets the first item that meets criteria specified by filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>Found object.</returns>
        public TEntity First(Expression<Func<TEntity, bool>> filter)
        {
            return this.objectSet.FirstOrDefault(filter);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        public void Delete(TEntity entity)
        {
            this.objectSet.DeleteObject(entity);
        }

        /// <summary>
        /// Adds the specified entity to database.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(TEntity entity)
        {
            this.objectSet.AddObject(entity);
        }

        #endregion
    }
}