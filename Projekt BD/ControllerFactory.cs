﻿namespace Projekt_BD
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

        /// <summary>
        /// Creates the specified type of controller.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Instance of controller.</returns>
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

                case ControllerTypes.EditRoom:
                    return new EditRoomController();

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

                case ControllerTypes.EditService:
                    return new EditServiceFormController();

                case ControllerTypes.ManagerForm:
                    return new ManagerFormController();

                case ControllerTypes.EditTaskForm:
                    return new EditTaskController();

                case ControllerTypes.EditTaskTypeForm:
                    return new EditTaskTypeController();

                case ControllerTypes.EditServiceForVisit:
                    return new EditServiceForVisitController();

                case ControllerTypes.EditServiceDetailsForm:
                    return new EditServiceDetailsController();

                case ControllerTypes.MealPlansForm:
                    return new MealPlanController();

                case ControllerTypes.GenerateReceiptForm:
                    return new GenerateReceiptController();

                case ControllerTypes.EditMealPlansForVisitForm:
                    return new EditMealPlanController();

                case ControllerTypes.GrantDiscountForm:
                    return new GrantDiscountController();

                default:
                    return null;
            }
        }

        #endregion
    }
}
