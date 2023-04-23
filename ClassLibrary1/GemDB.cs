using DB;
using ModelsClass;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesDB
{
    public class GemDB : BaseDB<Gem>
    {
        protected override string GetTableName()
        {
            return "gems";
        }
        protected override Gem CreateModel(object[] row)
        {
            Gem g = new Gem();
            g.gemID = int.Parse(row[0].ToString());
            g.name = row[1].ToString();
            g.weight = double.Parse(row[3].ToString());
            g.price = int.Parse(row[4].ToString());
            return g;
        }
        protected override async Task<Gem> CreateModelAsync(object[] row)
        {
            Gem g = new Gem();
            g.gemID = int.Parse(row[0].ToString());
            g.name = row[1].ToString();
            g.weight = double.Parse(row[3].ToString());
            g.price = int.Parse(row[4].ToString());
            return g;
        }
        protected override List<Gem> CreateListModel(List<object[]> rows)
        {
            List<Gem> GemList = new List<Gem>();
            foreach (object[] item in rows)
            {
                Gem g = new Gem();
                g = (Gem)CreateModel(item);
                GemList.Add(g);
            }
            return GemList;
        }
        protected override async Task<List<Gem>> CreateListModelAsync(List<object[]> rows)
        {
            List<Gem> GemList = new List<Gem>();
            foreach (object[] item in rows)
            {
                Gem g = new Gem();
                g = (Gem)CreateModel(item);
                GemList.Add(g);
            }
            return GemList;
        }

        // specific queries
        public Gem SelectByPk(int id)
        {
            string sql = @"SELECT * FROM gems WHERE (gemID = @id)";
            cmd.Parameters.AddWithValue("@id", id);
            List<Gem> list = (List<Gem>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }

        protected override Gem GetRowByPK(object pk)
        {
            string sql = @"SELECT * FROM gems WHERE
			 	(gemID = @id)";
            cmd.Parameters.AddWithValue("@id", int.Parse(pk.ToString()));
            List<Gem> list = (List<Gem>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        protected override async Task<Gem> GetRowByPKAsync(object pk)
        {
            string sql = @"SELECT * FROM gems WHERE
			 	(gemID = @id)";
            cmd.Parameters.AddWithValue("@id", int.Parse(pk.ToString()));
            List<Gem> list = (List<Gem>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        public bool Insert(Gem gem)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("gemID", gem.gemID.ToString());
            val.Add("name", gem.name);
            val.Add("weight", gem.weight.ToString());
            val.Add("price", gem.price.ToString());
            return base.Insert(val) != -1;
        }
        public int Update(Gem gem)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("gemID", gem.gemID.ToString());
            val.Add("name", gem.name);
            val.Add("weight", gem.weight.ToString());
            val.Add("price", gem.price.ToString());
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("gemID", gem.gemID.ToString());
            return base.Update(val, param);
        }

        public int Delete(Gem gem)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("gemID", gem.gemID.ToString());
            return base.Delete(param);
        }



    }
}
