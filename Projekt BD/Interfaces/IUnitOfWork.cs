namespace Projekt_BD.Interfaces
{
    /// <summary>
    /// Interface for UnitOdWork class.
    /// </summary>
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
