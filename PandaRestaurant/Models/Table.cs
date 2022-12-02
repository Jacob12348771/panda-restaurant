using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PandaRestaurant.Models
{
    public class Table
    {
        [Display(Name = "Table Number")]
        public int TableID { get; set; }

        [Display(Name = "Table Availablity")]
        public bool TableOccupied { get; set; }

        public ICollection<Order> Orders { get; set; }
        public Staff Staff { get; set; }

    }
}
