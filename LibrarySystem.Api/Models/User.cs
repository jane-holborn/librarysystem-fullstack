using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Api.Models
{
    public class User : Person
    {
        // Fields.
        private string _userLibraryNumber;
        private int _numberOfBooksBorrowed;

        // Constructors.
        public User(string id, string name, string email, string userLibraryNumber)
            : base(id, name, email)
        {
            _userLibraryNumber = userLibraryNumber;
            _numberOfBooksBorrowed = 0;
        }

        public User()
        {
            // Default constructor for EF Core.
        }

        // Properties.
        [Required(ErrorMessage = "User Library Number is required.")]
        public string UserLibraryNumber
        {
            get { return _userLibraryNumber; }
            set { _userLibraryNumber = value; }
        }

        [Required(ErrorMessage = "Number of Books Borrowed is required.")]
        public int NumberOfBooksBorrowed
        {
            get { return _numberOfBooksBorrowed; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number of books borrowed cannot be negative.", nameof(value));
                }
                _numberOfBooksBorrowed = value;
            }
        }
    }
}
