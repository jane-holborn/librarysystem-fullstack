using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Api.Models
{
    public abstract class Person
    {
        // Fields.
        private string _id;
        private string _name;
        private string _email;

        // Constructors.
        public Person(string id, string name, string email)
        {
            _id = id;
            _name = name;
            _email = email;
        }

        public Person() 
        {
            // Default constructor for EF Core.
        }

        // Properties.
        [Key]
        public string Id {
            get { return _id; }
            set {                     
                if (string.IsNullOrWhiteSpace(value)) 
                    { 
                        throw new ArgumentException("Id cannot be null or empty.", nameof(value)); 
                    }
                    _id = value;
            }
        }

        [Required(ErrorMessage = "Name is required.")]
        public string Name {
            get { return _name; }
            set {
                    if (string.IsNullOrWhiteSpace(value)) 
                    { 
                        throw new ArgumentException("Name cannot be null or empty.", nameof(value)); 
                    }
                    _name = value;
            }
        }

        [Required(ErrorMessage = "Email is required.")]
        public string Email {
            get { return _email; }
            set {
                    if (string.IsNullOrWhiteSpace(value)) 
                    { 
                        throw new ArgumentException("Email cannot be null or empty.", nameof(value)); 
                    }
                    _email = value;
            }
        }
    }
}
