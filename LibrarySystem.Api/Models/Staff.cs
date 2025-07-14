using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Api.Models
{
    public class Staff : Person
    {
        // Fields.
        private string _employeeId;
        private string _department;

        // Constructors.
        public Staff(string id, string name, string email, string employeeId, string department)
            : base(id, name, email)
        {
            _employeeId = employeeId;
            _department = department;
        }
        public Staff()
        {
            // Default constructor for EF Core.
        }


        // Properties.
        [Required(ErrorMessage = "Employee ID is required.")]
        public string EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }

        [Required(ErrorMessage = "Department is required.")]
        public string Department
        {
            get { return _department; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Department cannot be null or empty.", nameof(value));
                }
                _department = value;
            }
        }
    }
}
