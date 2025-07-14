using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.WpfFrontend.Models
{
    public class Book : INotifyPropertyChanged
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

        // Properties.
        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title cannot be null or empty.", nameof(value));
                }
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public string Author
        {
            get { return _author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Author cannot be null or empty.", nameof(value));
                }
                if( _author != value)
                {
                    _author = value;
                    OnPropertyChanged(nameof(Author));
                }
            }
        }

        public string LibraryReferenceNumber
        {
            get { return _libraryReferenceNumber; }
        }

        public string PublicationYear
        {
            get { return _publicationYear; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Publication date cannot be null or empty.", nameof(value));
                }
                if( _publicationYear != value)
                {
                    _publicationYear = value;
                    OnPropertyChanged(nameof(PublicationYear));
                }
            }
        }

        public BookState State
        {
            get { return _state; }
        }

        public void SetSate(BookState state)
        {
            if(_state != state)
            {
                _state = state;
                OnPropertyChanged(nameof(State));
            }
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
                if(_dueDate != value)
                {
                    _dueDate = value;
                    OnPropertyChanged(nameof(DueDate));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
