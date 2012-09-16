namespace Projekt_BD
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Domain;

    public class DataAccess
    {
        #region Fields

        private static DataAccess instance;

        #endregion

        #region Constructors

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
        }

        #endregion

        #region Finalizer

        ~DataAccess()
        {
            this.UnitOfWork.Dispose();
            this.Context.Dispose();
        }

        #endregion

        #region Properties

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

        public UnitOfWork UnitOfWork { get; set; }

        public Repository<Room> Rooms { get; set; }

        public Repository<RoomType> RoomTypes { get; set; }

        public Repository<Feature> Features { get; set; }

        public Repository<Reservation> Reservations { get; set; }

        public Repository<RoomReservation> RoomReservations { get; set; }

        public Repository<Guest> Guests { get; set; }

        public Repository<Employee> Employees { get; set; }

        public Repository<Role> Roles { get; set; }

        public Repository<Visit> Visits { get; set; }

        private ObjectContextAdapter Context { get; set; }

        #endregion
    }
}