namespace PandaRestaurant.Models
{
    public class Table
    {
        public int TableId { get; set; }
        public bool TableOccupied { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Staff Staff { get; set; }

    }
}
