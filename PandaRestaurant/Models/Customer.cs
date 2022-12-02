using System.ComponentModel.DataAnnotations;

namespace PandaRestaurant.Models
{
    public class Customer
    {
        [Range(0, 6)]
        public int CustomerId { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string customerName { get; set; }
    }
}
