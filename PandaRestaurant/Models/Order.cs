using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PandaRestaurant.Models
{
    public class Order
    {

        public enum OrderStatusEnum
        {
            Created, Preparing, Ready, Paid
        }

        [Display(Name = "Order ID")]
        public int OrderID { get; set; }
        [Display(Name = "Order Status")]
        public OrderStatusEnum OrderStatus { get; set; }
        [Display(Name = "Date & Time Ordered")]
        public DateTime OrderDatetime { get; set; }
        [ForeignKey("Table")]
        [Display(Name = "Table ID")]
        public int TableID { get; set; }
        [ForeignKey("Customer")]
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set;}
        public ICollection<MenuItem> MenuItem { get; set; }
        public Table Table { get; set; }
        public Customer Customer { get; set; }

    }
}
