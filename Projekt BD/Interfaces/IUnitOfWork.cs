namespace Projekt_BD.Interfaces
{
    public interface IUnitOfWork
    {
        #region Methods

        /// <summary>
        /// Commits changes.
        /// </summary>
        void Commit();

        #endregion
    }
}
