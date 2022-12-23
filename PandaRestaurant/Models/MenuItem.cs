using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PandaRestaurant.Models
{
    public class MenuItem
    {
        [Display(Name = "Product ID")]
        public int MenuItemID { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        [StringLength(50, MinimumLength = 3)]
        public string MenuItemName { get; set; }
        [Display(Name = "Preparation Time (Minutes)")]
        public int? MenuItemPrepTime { get; set; }
        [DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "Price")]
        public double MenuItemPrice { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
