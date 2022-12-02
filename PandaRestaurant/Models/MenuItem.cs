using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PandaRestaurant.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        [Required]
        [Display(Name = "Menu Item Name")]
        [StringLength(50, MinimumLength = 3)]
        public string MenuItemName { get; set; }
        [Display(Name = "Preparation Time")]
        public string? MenuItemPrepTime { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "Dish Price")]
        public float MenuItemPrice { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
