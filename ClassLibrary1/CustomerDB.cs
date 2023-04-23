using ModelsClass;
using DB;
namespace TablesDB
{
    public class CustomerDB : BaseDB<Customer>
    {
        protected override string GetTableName()
        {
            return "Customers";
        }
        protected override Customer CreateModel(object[] row)
        {
            Customer c = new Customer();
            c.CustomerID = int.Parse(row[0].ToString());
            c.CustomerName = row[1].ToString();
            c.CustomerPassword = row[2].ToString();
            return c;
        }
        protected override async Task<Customer> CreateModelAsync(object[] row)
        {
            Customer c = new Customer();
            c.CustomerID = int.Parse(row[0].ToString());
            c.CustomerName = row[1].ToString();
            c.CustomerPassword = row[2].ToString();
            return c;
        }
        protected override List<Customer> CreateListModel(List<object[]> rows)
        {
            List<Customer> custList = new List<Customer>();
            foreach (object[] item in rows)
            {
                Customer c = new Customer();
                c = (Customer)CreateModel(item);
                custList.Add(c);
            }
            return custList;
        }
        protected override async Task<List<Customer>> CreateListModelAsync(List<object[]> rows)
        {
            List<Customer> custList = new List<Customer>();
            foreach (object[] item in rows)
            {
                Customer c = new Customer();
                c = (Customer)CreateModel(item);
                custList.Add(c);
            }
            return custList;
        }

        // specific queries
        public Customer SelectByPk(int id)
        {
            string sql = @"SELECT customers.* FROM customers WHERE (CustomerID = @id)";
            cmd.Parameters.AddWithValue("@id", id);
            List<Customer> list = (List<Customer>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }

        protected override Customer GetRowByPK(object pk)
        {
            string sql = @"SELECT customers.* FROM customers WHERE
			 	(CustomerID = @id)";
            cmd.Parameters.AddWithValue("@id", int.Parse(pk.ToString()));
            List<Customer> list = (List<Customer>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }

        protected override async Task<Customer> GetRowByPKAsync(object pk)
        {
            string sql = @"SELECT customers.* FROM customers WHERE
			 	(CustomerID = @id)";
            cmd.Parameters.AddWithValue("@id", int.Parse(pk.ToString()));
            List<Customer> list = (List<Customer>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }

        public bool Insert(Customer customer)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("customerID", customer.CustomerID.ToString());
            val.Add("customerName", customer.CustomerName);
            val.Add("customerPassword", customer.CustomerPassword);
            return base.Insert(val) != -1;
        }
        public int Update(Customer customer)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("customerID", customer.CustomerID.ToString());
            val.Add("customerName", customer.CustomerName);
            val.Add("customerPassword", customer.CustomerPassword);
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("customerID", customer.CustomerID.ToString());
            return base.Update(val, param);
        }

        public int Delete(Customer customer)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("customerID", customer.CustomerID.ToString());
            return base.Delete(param);
        }
    }
}