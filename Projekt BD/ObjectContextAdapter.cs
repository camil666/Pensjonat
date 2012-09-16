namespace Projekt_BD
{
    using System.Data.Objects;
    using Projekt_BD.Interfaces;

    public class ObjectContextAdapter : IObjectContext
    {
        #region Fields

        private readonly ObjectContext context;

        #endregion

        #region Constructors

        public ObjectContextAdapter(ObjectContext context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        public void Dispose()
        {
            this.context.Dispose();
        }

        public IObjectSet<T> CreateObjectSet<T>() where T : class
        {
            return this.context.CreateObjectSet<T>();
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        #endregion
    }
}
