namespace Projekt_BD
{
    using System.Data.Objects;
    using Projekt_BD.Interfaces;

    public class ObjectContextAdapter : IObjectContext
    {
        #region Fields

        readonly ObjectContext _context;

        #endregion

        #region Constructors

        public ObjectContextAdapter(ObjectContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public void Dispose()
        {
            _context.Dispose();
        }

        public IObjectSet<T> CreateObjectSet<T>() where T : class
        {
            return _context.CreateObjectSet<T>();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
