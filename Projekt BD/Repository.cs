namespace Projekt_BD
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Objects;
    using System.Linq;
    using System.Linq.Expressions;
    using Projekt_BD.Interfaces;

    public class Repository<TEntity> where TEntity : class
    {
        #region Fields

        private IObjectSet<TEntity> objectSet;

        #endregion

        #region Constructors

        public Repository(IObjectContext objectContext)
        {
            this.objectSet = objectContext.CreateObjectSet<TEntity>();
        }

        #endregion

        #region Methods

        public IQueryable<TEntity> GetAll()
        {
            return this.objectSet;
        }

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

        public TEntity Single(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                return this.objectSet.Single(filter);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public TEntity First(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                return this.objectSet.First(filter);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public void Delete(TEntity entity)
        {
            this.objectSet.DeleteObject(entity);
        }

        public void Add(TEntity entity)
        {
            this.objectSet.AddObject(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            this.objectSet.Attach(entityToUpdate);
        }

        #endregion
    }
}