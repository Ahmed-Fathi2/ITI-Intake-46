using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Company.DataAccessLayer
{
    public class DBManager
    {
        //select [disconnected]
        public static DataTable ExecuteQuery(string query)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["pubs"].ConnectionString);
            SqlCommand command = new SqlCommand(query,con);
            SqlDataAdapter adapter= new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }


        //insert/update/delete [connected]
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            int affected = -1;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["pubs"].ConnectionString);
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddRange(parameters);
            try
            {
                con.Open();
                affected= command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { con.Close(); }
            return affected;
        }
    }
}
