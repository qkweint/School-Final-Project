using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace DB
{
    public abstract class BaseDB<T> : DB
    {
        protected MySqlDataReader reader;
        protected abstract string GetTableName();
        protected abstract T GetRowByPK(object pk);
        protected abstract Task<T> GetRowByPKAsync(object pk);
        protected abstract T CreateModel(object[] row);
        protected abstract Task<T> CreateModelAsync(object[] row);
        protected abstract List<T> CreateListModel(List<object[]> rows);
        protected abstract Task<List<T>> CreateListModelAsync(List<object[]> rows);

        public object SelectAll()
        {
            List<object[]> list = (List<object[]>)StringListSelectAll("", new Dictionary<string, string>());
            return CreateListModel(list);
        }
        public object SelectAll(Dictionary<string, string> parameters)
        {
            List<object[]> list = (List<object[]>)StringListSelectAll("", parameters);
            return CreateListModel(list);
        }
        public object SelectAll(string query)
        {
            List<object[]> list = (List<object[]>)StringListSelectAll(query, new Dictionary<string, string>());
            return CreateListModel(list);
        }
        public object SelectAll(string query, Dictionary<string, string> parameters)
        {
            List<object[]> list = (List<object[]>)StringListSelectAll(query, parameters);
            return CreateListModel(list);
        }
        protected object StringListSelectAll(string query, Dictionary<string, string> parameters)
        {
            object list = new List<object[]>();
            string where = "WHERE ";
            if (parameters != null && parameters.Count > 0)
            {
                int i = 0;
                foreach (KeyValuePair<string, string> param in parameters)
                {
                    where += $"{param.Key} = {param.Value}";
                    i++;
                    if (i < parameters.Count)
                        where += " AND ";
                }
            }
            else
                where = "";
            string sqlCommand = $"{query} {where}";
            if (String.IsNullOrEmpty(query))
                sqlCommand = $"SELECT * FROM {GetTableName()} {where}";
            base.cmd.CommandText = sqlCommand;
            if (DB.conn.State != System.Data.ConnectionState.Open)
                DB.conn.Open();
            if (base.cmd.Connection.State != System.Data.ConnectionState.Open)
                base.cmd.Connection = DB.conn;

            try
            {
                this.reader = base.cmd.ExecuteReader();
                int size = reader.GetColumnSchema().ToArray().Length;
                object[] row;
                while (this.reader.Read())
                {
                    row = new object[size];
                    this.reader.GetValues(row);
                    ((List<object[]>)list).Add(row);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nsql:" + cmd.CommandText);
                ((List<string[]>)list).Clear();
            }
            finally
            {
                base.cmd.Parameters.Clear();
                if (reader != null) reader.Close();
                if (DB.conn.State == System.Data.ConnectionState.Open)
                    DB.conn.Close();
            }
            return list;
        }
        protected int exeNONquery(string query)
        {
            int num = -1;
            try
            {
                base.cmd.CommandText = query;
                if (DB.conn.State != System.Data.ConnectionState.Open)
                    DB.conn.Open();
                if (base.cmd.Connection.State != System.Data.ConnectionState.Open)
                    base.cmd.Connection = DB.conn;
                num = base.cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nsql:" + cmd.CommandText);
            }
            finally
            {
                base.cmd.Parameters.Clear();
                if (DB.conn.State == System.Data.ConnectionState.Open)
                    DB.conn.Close();
            }
            return num;
        }
        public int Insert(Dictionary<string, string> FindValue) 
        {
            //INSERT INTO table_name (column1, column2, column3, ...)
            //VALUES(value1, value2, value3, ...);
            string s = $"INSERT INTO {GetTableName()} (";
            string s2 = "VALUES (";
            foreach (KeyValuePair<string, string> param in FindValue)
            {
                s += $"{param.Key}, ";
                s2 += $"'{param.Value}', ";
            }
            s = s.Remove(s.Length - 2);
            s2 = s2.Remove(s2.Length - 2);
            s += ")";
            s2 += ")";
            s += $" {s2};";
            return exeNONquery(s);
        }
        protected int Update(Dictionary<string, string> FildValue, Dictionary<string, string> parameters)
        {
            string query = $"UPDATE {GetTableName()} ";
            string val = "SET ";
            if (FildValue != null && FildValue.Count > 0)
            {
                int i = 0;
                foreach (KeyValuePair<string, string> param in FildValue)
                {
                    val += $"{param.Key} = '{param.Value}'";
                    i++;
                    if (i < FildValue.Count)
                        val += ", ";
                }
            }
            string where = "WHERE ";
            if (parameters != null && parameters.Count > 0)
            {
                int i = 0;
                foreach (KeyValuePair<string, string> param in parameters)
                {
                    where += $"{param.Key} = '{param.Value}'";
                    i++;
                    if (i < parameters.Count)
                        where += " AND ";
                    else
                        where += ";";
                }
            }
            else
                where = "";
            query += val + " " + where;
            return exeNONquery(query);
        }
        protected int Delete(Dictionary<string, string> parameters)
        {
            string query = $"DELETE FROM {GetTableName()} ";
            string where = "WHERE ";
            if (parameters != null && parameters.Count > 0)
            {
                int i = 0;
                foreach (KeyValuePair<string, string> param in parameters)
                {
                    where += $"{param.Key} = {param.Value}";
                    i++;
                    if (i < parameters.Count)
                        where += " AND ";
                    else
                        where += ";";
                }
            }
            else
                where = "";
            query += where;
            return exeNONquery(query);
        }
    }

}
 