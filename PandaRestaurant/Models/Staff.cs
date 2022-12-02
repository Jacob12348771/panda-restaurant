using System.ComponentModel.DataAnnotations;

namespace PandaRestaurant.Models
{
    public class Staff
    {
        public int staffID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "You name cannot exceed 100 characters")]
        public string staffName { get; set; }
        [Required]
        public string staffPosition { get; set; }
    }
}
