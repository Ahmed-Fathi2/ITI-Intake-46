using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADODotNETConnected
{
    public partial class FrmInsert : Form
    {
        public FrmInsert()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=pubs;Integrated Security=True;Trust Server Certificate=True");


            SqlCommand command = new SqlCommand();
            command.CommandText = $"insert into authors (au_id,au_fname,au_lname,address) values('{txtId.Text}','{txtFName.Text}','{txtLName.Text}','{txtAddress.Text}')";

            command.Connection = con;

            try
            {
                con.Open();
                lblResult.Text = $"{command.ExecuteNonQuery()} rows affected"; 
            }
            catch (Exception)
            {

                throw;
            }
            finally { con.Close(); }
        }
    }
}
