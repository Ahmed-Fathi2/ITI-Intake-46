using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BusinessLayer
{
    public class AuthorBL
    {
        public static DataTable GetAll()
        {
            string query = "select * from authors";
            return Company.DataAccessLayer.DBManager.ExecuteQuery(query);   
        }
        public static List<Author> GetAll2()
        {
            List<Author> authors = new List<Author>();
            string query = "select * from authors";
            var dt = Company.DataAccessLayer.DBManager.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                var a1 = new Author() 
                {
                    Au_id = item["au_id"].ToString(),
                    Au_Fname = item["au_fname"].ToString(),
                    Au_Lname = item["au_lname"].ToString(),
                    Address = item["address"].ToString(),
                };
                authors.Add(a1);
            }
            return authors;
        }
        public static DataTable GetOne(string id)
        {
            var query = $"select * from authors where au_id='{id}'";
            return Company.DataAccessLayer.DBManager.ExecuteQuery(query);
        }
        public static Author GetOne2(string id)
        {
            var query = $"select * from authors where au_id='{id}'";
            var dt= Company.DataAccessLayer.DBManager.ExecuteQuery(query);
            var a1=new Author() 
            {
                Au_id=dt.Rows[0]["au_id"].ToString(),
                Au_Fname=dt.Rows[0]["au_fname"].ToString(),
                Au_Lname=dt.Rows[0]["au_lname"].ToString(),
                Address=dt.Rows[0]["address"].ToString()
            };
            return a1;
        }
        public static int Add(Author param)
        {
            var query = "insert into authors (au_id,au_fname,au_lname,address) values(@id,@fname,@lname,@address)";
            SqlParameter[] sqlParameters = new SqlParameter[] 
            {
                new SqlParameter("@id",param.Au_id),
                new SqlParameter("@fname",param.Au_Fname),
                new SqlParameter("@lname",param.Au_Lname),
                new SqlParameter("@address",param.Address)
            };
            return Company.DataAccessLayer.DBManager.ExecuteNonQuery(query, sqlParameters);
        }
        public static int Update(Author param)
        {
            var query = "update authors set au_fname=@fname,au_lname=@lname,address=@address where au_id=@id";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@id",param.Au_id),
                new SqlParameter("@fname",param.Au_Fname),
                new SqlParameter("@lname",param.Au_Lname),
                new SqlParameter("@address",param.Address)
            };
            return Company.DataAccessLayer.DBManager.ExecuteNonQuery(query, sqlParameters);
        }

        public static int Delete(string id)
        {
            var query = "delete from authors where au_id=@id";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return Company.DataAccessLayer.DBManager.ExecuteNonQuery (query, sqlParameters);
        }
    }
}
