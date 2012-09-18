namespace Projekt_BD
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Domain;

    /// <summary>
    /// Singleton class for accessing the data.
    /// </summary>
    public class DataAccess
    {
        #region Fields

        /// <summary>
        /// Holds instance of the class.
        /// </summary>
        private static DataAccess instance;

        #endregion

        #region Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="DataAccess" /> class from being created.
        /// </summary>
        private DataAccess()
        {
            this.Context = new ObjectContextAdapter(new PensjonatContext());
            this.UnitOfWork = new UnitOfWork(this.Context);

            this.Rooms = new Repository<Room>(this.Context);
            this.RoomTypes = new Repository<RoomType>(this.Context);
            this.Features = new Repository<Feature>(this.Context);
            this.Reservations = new Repository<Reservation>(this.Context);
            this.RoomReservations = new Repository<RoomReservation>(this.Context);
            this.Guests = new Repository<Guest>(this.Context);
            this.Employees = new Repository<Employee>(this.Context);
            this.Roles = new Repository<Role>(this.Context);
            this.Visits = new Repository<Visit>(this.Context);
            this.Tasks = new Repository<Task>(this.Context);
            this.Services = new Repository<Service>(this.Context);
            this.ServiceTypes = new Repository<ServiceType>(this.Context);
        }

        #endregion

        #region Finalizer

        /// <summary>
        /// Finalizes an instance of the <see cref="DataAccess" /> class.
        /// </summary>
        ~DataAccess()
        {
            this.UnitOfWork.Dispose();
            this.Context.Dispose();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static DataAccess Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataAccess();
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets or sets the unit of work.
        /// </summary>
        /// <value>
        /// The unit of work.
        /// </value>
        public UnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// Gets the rooms.
        /// </summary>
        /// <value>
        /// The rooms.
        /// </value>
        public Repository<Room> Rooms { get; private set; }

        /// <summary>
        /// Gets the room types.
        /// </summary>
        /// <value>
        /// The room types.
        /// </value>
        public Repository<RoomType> RoomTypes { get; private set; }

        /// <summary>
        /// Gets the features.
        /// </summary>
        /// <value>
        /// The features.
        /// </value>
        public Repository<Feature> Features { get; private set; }

        /// <summary>
        /// Gets the reservations.
        /// </summary>
        /// <value>
        /// The reservations.
        /// </value>
        public Repository<Reservation> Reservations { get; private set; }

        /// <summary>
        /// Gets the room reservations.
        /// </summary>
        /// <value>
        /// The room reservations.
        /// </value>
        public Repository<RoomReservation> RoomReservations { get; private set; }

        /// <summary>
        /// Gets the guests.
        /// </summary>
        /// <value>
        /// The guests.
        /// </value>
        public Repository<Guest> Guests { get; private set; }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <value>
        /// The employees.
        /// </value>
        public Repository<Employee> Employees { get; private set; }

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        public Repository<Role> Roles { get; private set; }

        /// <summary>
        /// Gets the visits.
        /// </summary>
        /// <value>
        /// The visits.
        /// </value>
        public Repository<Visit> Visits { get; private set; }

        /// <summary>
        /// Gets the tasks.
        /// </summary>
        /// <value>
        /// The tasks.
        /// </value>
        public Repository<Task> Tasks { get; private set; }

        /// <summary>
        /// Gets services.
        /// </summary>
        /// <value>
        /// Service.
        /// </value>
        public Repository<Service> Services { get; private set; }

        /// <summary>
        /// Gets service types.
        /// </summary>
        /// <value>
        /// Service type.
        /// </value>
        public Repository<ServiceType> ServiceTypes { get; private set; }

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        private ObjectContextAdapter Context { get; set; }

        #endregion
    }
}