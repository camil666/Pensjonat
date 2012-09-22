namespace Projekt_BD
{
    using System;
    using System.Collections;

    public class DisplayedGuest
    {
        #region Constructors

        public DisplayedGuest()
        {
        }

        public DisplayedGuest(int id, string firstName, string lastName, string town, bool isVerified)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Town = town;
            IsVerified = isVerified;
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Town { get; set; }

        public bool IsVerified { get; set; }

        #endregion

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
