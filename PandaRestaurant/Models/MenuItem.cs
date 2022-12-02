using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PandaRestaurant.Models
{
    public class MenuItem
    {
        [Display(Name = "Reference Number")]
        public int MenuItemID { get; set; }
        [Required]
        [Display(Name = "Menu Item Name")]
        [StringLength(50, MinimumLength = 3)]
        public string MenuItemName { get; set; }
        [Display(Name = "Preparation Time (Minutes)")]
        public string? MenuItemPrepTime { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "Dish Price")]
        public float MenuItemPrice { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
