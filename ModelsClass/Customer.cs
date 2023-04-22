using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsClass
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPassword { get; set; }

        public Customer(int customerID, string customerName, string customerPassword)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            CustomerPassword = customerPassword;
        }
        public Customer() { }
    }
}
