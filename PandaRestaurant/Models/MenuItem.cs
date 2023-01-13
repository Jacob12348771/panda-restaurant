using System.ComponentModel.DataAnnotations;

namespace PandaRestaurant.Models
{
    public class MenuItem
    {
        [Display(Name = "Product ID")]
        [Range(0, 6)]
        public int MenuItemID { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Product name cannot exceed 50 characters.")]
        public string MenuItemName { get; set; }

        [Display(Name = "Preparation Time (Minutes)")]
        public int? MenuItemPrepTime { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public double MenuItemPrice { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
