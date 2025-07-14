using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.WpfFrontend.Models
{
    public class User : Person, INotifyPropertyChanged
    {
        // Fields.
        private string _userLibraryNumber;
        private int _numberOfBooksBorrowed;

        // Properties.
        public string UserLibraryNumber
        {
            get { return _userLibraryNumber; }
            set
            {
                if (_userLibraryNumber != value)
                {
                    _userLibraryNumber = value;
                    OnPropertyChanged(nameof(UserLibraryNumber));
                }
            }

        }

        public int NumberOfBooksBorrowed
        {
            get { return _numberOfBooksBorrowed; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number of books borrowed cannot be negative.", nameof(value));
                }
                if(_numberOfBooksBorrowed != value)
                {
                    _numberOfBooksBorrowed = value;
                    OnPropertyChanged(nameof(NumberOfBooksBorrowed));
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
