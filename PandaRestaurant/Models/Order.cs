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

        public int OrderId { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public DateTime OrderDatetime { get; set; }
        [ForeignKey("Table")]
        public int TableId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set;}

    }
}
