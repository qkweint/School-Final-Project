using DB;
using ModelsClass;
using MySql.Data.MySqlClient;
using TablesDB;
namespace Console_MainProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////TEST CustomerDB Get by id
            //CustomerDB cdb = new CustomerDB();
            //Dictionary<string, string> param = new Dictionary<string, string>();
            //param.Add("customerID", "1");
            //List<Customer> list = (List<Customer>)cdb.SelectAll(param);
            //if (list != null)
            //{
            //    Console.WriteLine($" name: {list[0].CustomerName}");
            //}


            ////TEST CustomerDB SelectAll
            //list = (List<Customer>)cdb.SelectAll();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(@$" id={list[i].CustomerID} name={list[i].CustomerName}");
            //}

            //Customer c = new Customer(5, "maximizi");

            //CustomerDB cdb = new CustomerDB();
            //cdb.Insert(c);

            ////Gem g = new Gem(5,"booby", 0.2, 100);
            ////GemDB gdb = new GemDB();
            ////gdb.Insert(g);

            //Ring r = new Ring(6, "shwoop", 5);
            //RingDB rdb = new RingDB();
             

            //Order o = new Order(5, 5, 5);
            //OrderDB odb = new OrderDB();
            //odb.Insert(o);


        }
    }
}