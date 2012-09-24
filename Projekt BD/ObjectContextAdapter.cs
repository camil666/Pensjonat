namespace Projekt_BD
{
    using System.Data.Objects;
    using Projekt_BD.Interfaces;

    /// <summary>
    /// Adapter class for context.
    /// </summary>
    public class ObjectContextAdapter : IObjectContext
    {
        #region Fields

        /// <summary>
        /// Holds context.
        /// </summary>
        private readonly ObjectContext context;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectContextAdapter" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ObjectContextAdapter(ObjectContext context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.context.Dispose();
        }

        /// <summary>
        /// Creates the object set.
        /// </summary>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <returns>IObjectSet of given type.</returns>
        public IObjectSet<T> CreateObjectSet<T>() where T : class
        {
            return this.context.CreateObjectSet<T>();
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Refresh<T>(T entity)
        {
            this.context.Detach(entity);
        }

        #endregion
    }
}
