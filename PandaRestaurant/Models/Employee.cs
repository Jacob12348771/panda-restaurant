using System.ComponentModel.DataAnnotations;

namespace PandaRestaurant.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "You name cannot exceed 100 characters")]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeePosition { get; set; }
        public ICollection<Table> Tables { get; set; }
    }
}
