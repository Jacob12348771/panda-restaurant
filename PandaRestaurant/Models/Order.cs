using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PandaRestaurant.Models
{
    public class Order
    {

        public enum OrderStatus
        {
            Created, Preparing, Ready, Paid
        }

        public int Order_id { get; set; }
        public OrderStatus Order_status { get; set; }
        public DateTime Order_datetime { get; set; }
        public int Table_id { get; set; }
        public int Customer_id { get; set;}

    }
}
