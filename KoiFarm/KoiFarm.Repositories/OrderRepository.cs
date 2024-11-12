using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarm.Repositories
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }

        public Order(int orderID, string customerID, DateTime orderDate, decimal totalAmount, string status)
        {
            OrderID = orderID;
            CustomerID = customerID;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            Status = status;
        }
    }

}
