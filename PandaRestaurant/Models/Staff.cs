using System.ComponentModel.DataAnnotations;

namespace PandaRestaurant.Models
{
    public class Staff
    {
        public int StaffID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "You name cannot exceed 100 characters")]
        public string StaffName { get; set; }
        [Required]
        public string StaffPosition { get; set; }
        public ICollection<Table> Tables { get; set; }
    }
}
