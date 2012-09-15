namespace Projekt_BD
{
    using System.Data.Objects;
    using Projekt_BD.Interfaces;

    public class ObjectContextAdapter : IObjectContext
    {
        #region Fields

        private readonly ObjectContext _context;

        #endregion

        #region Constructors

        public ObjectContextAdapter(ObjectContext context)
        {
            this._context = context;
        }

        #endregion

        #region Methods

        public void Dispose()
        {
            this._context.Dispose();
        }

        public IObjectSet<T> CreateObjectSet<T>() where T : class
        {
            return this._context.CreateObjectSet<T>();
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        #endregion
    }
}
