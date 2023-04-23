using DB;
using ModelsClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesDB
{
    public class RingDB : BaseDB
    {
        protected override string GetTableName()
        {
            return "rings";
        }
        protected override object CreateModel(object[] row)
        {
            Ring r = new Ring();
            r.ringID= int.Parse(row[0].ToString());
            r.metal = row[1].ToString();
            r.gemID = int.Parse(row[2].ToString());
            return r;
        }
        protected override object CreateListModel(List<object[]> rows)
        {
            List<Ring> ringList = new List<Ring>();
            foreach (object[] item in rows)
            {
                Ring r = new Ring();
                r = (Ring)CreateModel(item);
                ringList.Add(r);
            }
            return ringList;
        }

        // specific queries
        public Ring SelectByPk(int id)
        {
            string sql = @"SELECT rings.* FROM rings WHERE (ringID = @id)";
            cmd.Parameters.AddWithValue("@id", id);
            List<Ring> list = (List<Ring>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }

        protected override object GetRowByPK(object pk)
        {
            string sql = @"SELECT rings.* FROM rings WHERE
			 	(ringID = @id)";
            cmd.Parameters.AddWithValue("@id", int.Parse(pk.ToString()));
            List<Ring> list = (List<Ring>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        public bool Insert(Ring ring)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("ringID", ring.ringID.ToString());
            val.Add("metal", ring.metal.ToString());
            val.Add("gemID", ring.gemID.ToString());
            return base.Insert(val) != -1;
        }
        public int Update(Ring ring)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("ringID", ring.ringID.ToString());
            val.Add("metal", ring.metal.ToString());
            val.Add("gemID", ring.gemID.ToString());
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("ringID", ring.ringID.ToString());
            return base.Update(val, param);
        }

        public int Delete(Ring ring)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("ringID", ring.ringID.ToString());
            return base.Delete(param);
        }
    }
}
