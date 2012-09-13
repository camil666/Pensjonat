namespace Projekt_BD
{
    using Projekt_BD.Controller;
    using Projekt_BD.Interfaces;
    using Projekt_BD.View;

    /// <summary>
    /// Factory for creating controller instances.
    /// </summary>
    public class ControllerFactory
    {
        #region Field

        /// <summary>
        /// Factory instance.
        /// </summary>
        private static ControllerFactory factoryInstance;

        #endregion

        #region Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="ControllerFactory" /> class from being created.
        /// </summary>
        private ControllerFactory()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static ControllerFactory Instance
        {
            get
            {
                if (factoryInstance == null)
                {
                    factoryInstance = new ControllerFactory();
                }

                return factoryInstance;
            }
        }

        #endregion

        #region Methods

        public IController Create(ControllerTypes type)
        {
            switch (type)
            {
                case ControllerTypes.AdminForm:
                    return new AdminFormController();

                case ControllerTypes.ClientSearch:
                    return new ClientSearchController();

                case ControllerTypes.EditRoomFeature:
                    return new EditRoomFeatureController();

                case ControllerTypes.EditRoomType:
                    return new EditRoomTypeController();

                case ControllerTypes.EmployeeForm:
                    return new EmployeeFormController();

                case ControllerTypes.LoginForm:
                    return new LoginFormController();

                case ControllerTypes.NewClientForm:
                    return new NewClientFormController();

                case ControllerTypes.NewEmployeeForm:
                    return new NewEmployeeFormController();

                case ControllerTypes.ReservationForm:
                    return new ReservationFormController();

                case ControllerTypes.NewVisitForm:
                    return new NewVisitFormController();

                case ControllerTypes.ReceptionistForm:
                    return new ReceptionistFormController();

                default:
                    return null;
            }
        }

        #endregion
    }
}
