using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PandaRestaurant.Models
{
    public class Table
    {
        [Display(Name = "Table Number")]
        [Range(0, 6)]
        public int TableID { get; set; }

        [Display(Name = "Occupied")]
        public bool TableOccupied { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
