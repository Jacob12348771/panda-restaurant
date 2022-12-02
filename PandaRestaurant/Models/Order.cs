using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace PandaRestaurant.Models
{
    public class Order
    {

        public enum OrderStatusEnum
        {
            Created, Preparing, Ready, Paid
        }

        public int OrderID { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public DateTime OrderDatetime { get; set; }
        [ForeignKey("Table")]
        public int TableID { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set;}

    }
}
