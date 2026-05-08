using System.Data;
using System.Data.SqlClient;

namespace SeriesUI.DAL
{
    public class DbHelper
    {
        private readonly string conStr;

        public DbHelper()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            conStr = config.GetConnectionString("db");

            if (string.IsNullOrEmpty(conStr))
            {
                throw new Exception("Connection string is NULL or EMPTY");
            }
        }

        public int ExecuteNonQuery(string spName, SqlParameter[] param)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (param != null)
                        {
                            cmd.Parameters.AddRange(param);
                        }

                        con.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database Error: " + ex.Message);
            }
        }
        public DataTable ExecuteSelect(string spName, SqlParameter[] param)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (param != null)
                        cmd.Parameters.AddRange(param);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public static List<Dictionary<string, object>> ConvertDataTable(DataTable dt)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in dt.Rows)
            {
                var dict = new Dictionary<string, object>();

                foreach (DataColumn col in dt.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }

                list.Add(dict);
            }

            return list;
        }
        public DataTable ExecuteQuery(string spName, SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}