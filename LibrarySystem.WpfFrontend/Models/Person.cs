using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.WpfFrontend.Models
{
    public abstract class Person
    {
        // Fields.
        private readonly string _id;
        private string _name;
        private string _email;

        // Properties.
        public string Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.", nameof(value));
                }
                _name = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email cannot be null or empty.", nameof(value));
                }
                _email = value;
            }
        }
    }
}
