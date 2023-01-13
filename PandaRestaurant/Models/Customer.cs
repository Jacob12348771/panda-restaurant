using System.ComponentModel.DataAnnotations;

namespace PandaRestaurant.Models
{
    public class Customer
    {
        [Display(Name = "Customer ID")]
        [Range(0, 6)]
        public int CustomerID { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Customer name cannot exceed 50 characters.")]
        public string CustomerName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
