namespace PandaRestaurant.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemPrepTime { get; set; }
        public float MenuItemPrice { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
