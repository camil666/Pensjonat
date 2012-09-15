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

        private IObjectSet<TEntity> _objectSet;

        #endregion

        #region Constructors

        public Repository(IObjectContext objectContext)
        {
            _objectSet = objectContext.CreateObjectSet<TEntity>();
        }

        #endregion

        #region Methods

        public IQueryable<TEntity> GetAll()
        {
            return _objectSet;
        }

        public IQueryable<TEntity> Find(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _objectSet;

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
                return _objectSet.Single(filter);
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
                return _objectSet.First(filter);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public void Delete(TEntity entity)
        {
            _objectSet.DeleteObject(entity);
        }

        public void Add(TEntity entity)
        {
            _objectSet.AddObject(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            _objectSet.Attach(entityToUpdate);
        }

        #endregion
    }
}