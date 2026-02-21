using Microsoft.Data.SqlClient;
using System.Data;
namespace ADODotNETConnected
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FullAuthorsList();
        }

        private void FullAuthorsList()
        {
            //1- 2- 3-
            SqlConnection con = new SqlConnection("Server=.;Database=pubs;trusted_connection=true;trustServerCertificate=true");

            //4-
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from authors";

            //REMEMBER link command to connection
            command.Connection= con;

            try
            {
                con.Open();
                //5-container
                SqlDataReader dr = command.ExecuteReader();
                
                //6- data binding
                DataTable dt=new DataTable();
                dt.Load(dr);

                gridAuthors.DataSource = dt;

            }
            catch (Exception)
            {

                throw;
            }
            finally { con.Close(); }
        }
    }
}
