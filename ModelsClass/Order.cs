using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsClass
{
    public class Order
    {
        public int orderID { get; set; }
        public int customerID { get; set; }
        public int ringID { get; set; }

        public Order(int customerID, int ringID)
        {
            customerID = this.customerID;
            ringID = this.ringID;
        }
        public Order() { }
    }
}
