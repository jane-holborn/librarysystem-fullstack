using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Api.Models
{
    public class Book
    {

        // Enum for book states.
        public enum BookState
        {
            Available,
            CheckedOut,
            Reserved,
            Overdue,
            Lost
        }

        // Fields.
        private readonly string _libraryReferenceNumber;
        private string _title;
        private string _author;
        private string _publicationYear;
        private BookState _state;
        private DateTime _dueDate;

        // Constructors.
        public Book(string libraryReferenceNumber, string title, string author, string publicationYear)
        {
            _libraryReferenceNumber = libraryReferenceNumber;
            _title = title;
            _author = author;
            _publicationYear = publicationYear;
            _state = BookState.Available;
            _dueDate = DateTime.MinValue;
        }

        public Book()
        {
            // Default constructor for EF Core.
        }

        // Properties.
        [Required(ErrorMessage = "Library Reference Number is required.")]
        public string Title 
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title cannot be null or empty.", nameof(value));
                }
                _title = value;
            }
        }

        [Required(ErrorMessage = "Author is required.")]
        public string Author 
        {
            get { return _author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Author cannot be null or empty.", nameof(value));
                }
                _author = value;
            }
        }

        [Required(ErrorMessage = "Library Reference Number is required.")]
        public string LibraryReferenceNumber 
        {
            get { return _libraryReferenceNumber; }
        }

        [Required(ErrorMessage = "Publication year is required.")]
        public string PublicationYear 
        {
            get { return _publicationYear; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Publication date cannot be null or empty.", nameof(value));
                }
                _publicationYear = value;
            }
        }

        public BookState State 
        {
            get { return _state; }
        }

        public void SetSate(BookState state)
        {
            _state = state;
        }

        public DateTime DueDate 
        {
            get { return _dueDate; }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Due date cannot be in the past.", nameof(value));
                }
                _dueDate = value;
            }
        }
    }
}
