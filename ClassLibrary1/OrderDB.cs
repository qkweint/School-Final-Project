using DB;
using ModelsClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesDB
{
    public class OrderDB : BaseDB<Order>
    {
        protected override string GetTableName()
        {
            return "orders";
        }
        protected override Order CreateModel(object[] row)
        {
            Order o = new Order();
            o.orderID = int.Parse(row[0].ToString());
            o.customerID = int.Parse(row[1].ToString());
            o.ringID = int.Parse(row[2].ToString());

            return o;
        }
        protected override async Task<Order> CreateModelAsync(object[] row)
        {
            Order o = new Order();
            o.orderID = int.Parse(row[0].ToString());
            o.customerID = int.Parse(row[1].ToString());
            o.ringID = int.Parse(row[2].ToString());

            return o;
        }

        protected override List<Order> CreateListModel(List<object[]> rows)
        {
            List<Order> ordList = new List<Order>();
            foreach (object[] item in rows)
            {
                Order o = new Order();
                o = (Order)CreateModel(item);
                ordList.Add(o);
            }
            return ordList;
        }
        protected override async Task<List<Order>> CreateListModelAsync(List<object[]> rows)
        {
            List<Order> ordList = new List<Order>();
            foreach (object[] item in rows)
            {
                Order o = new Order();
                o = (Order)CreateModel(item);
                ordList.Add(o);
            }
            return ordList;
        }


        // specific queries
        public Order SelectByPk(int id)
        {
            string sql = @"SELECT orders.* FROM orders WHERE (OrderID = @id)";
            cmd.Parameters.AddWithValue("@id", id);
            List<Order> list = (List<Order>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }

        protected override Order GetRowByPK(object pk)
        {
            string sql = @"SELECT orders.* FROM orders WHERE
			 	(orderID = @id)";
            cmd.Parameters.AddWithValue("@id", int.Parse(pk.ToString()));
            List<Order> list = (List<Order>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        protected override async Task<Order> GetRowByPKAsync(object pk)
        {
            string sql = @"SELECT orders.* FROM orders WHERE
			 	(orderID = @id)";
            cmd.Parameters.AddWithValue("@id", int.Parse(pk.ToString()));
            List<Order> list = (List<Order>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        
        public bool Insert(Order order)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("orderID", order.orderID.ToString());
            val.Add("customerID", order.customerID.ToString());
            val.Add("ringID", order.ringID.ToString());
            return base.Insert(val) != -1;
        }
        public int Update(Order order)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("orderID", order.orderID.ToString());
            val.Add("customerID", order.customerID.ToString());
            val.Add("ringID", order.ringID.ToString());
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("orderID", order.orderID.ToString());
            return base.Update(val, param);
        }

        public int Delete(Order order)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("orderID", order.orderID.ToString());
            return base.Delete(param);
        }

        public bool PlaceOrder(Order order)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("orderID", order.orderID.ToString());
            val.Add("customerID", order.customerID.ToString());
            val.Add("ringID", order.ringID.ToString());
            return base.Insert(val) != -1;
        }

        

        

        
    }
}
