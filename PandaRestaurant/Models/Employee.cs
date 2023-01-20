using System.ComponentModel.DataAnnotations;

namespace PandaRestaurant.Models
{
    public class Employee
    {
        public enum EmployeePositionEnum
        {
            Waiter, Manager, Chef
        }

        [Display(Name = "Employee ID")]
        [Range(0, 6)]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Employee name cannot exceed 50 characters.")]
        public string EmployeeName { get; set; }

        [Required]
        public EmployeePositionEnum EmployeePosition { get; set; }

        public ICollection<Table> Tables { get; set; }
    }
}
