using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PandaRestaurant.Models
{
    public class Customer
    {
        [Range(0, 6)]
        public int CustomerID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string CustomerName { get; set; }
    }
}
