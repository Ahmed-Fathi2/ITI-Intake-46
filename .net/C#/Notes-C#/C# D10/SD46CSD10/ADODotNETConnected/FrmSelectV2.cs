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
    public partial class FrmSelectV2 : Form
    {
        public FrmSelectV2()
        {
            InitializeComponent();
            FillAuthorsToComboBox();
        }

        private void FillAuthorsToComboBox()
        {
            //using (SqlConnection con=new SqlConnection())
            //{
            //    //u have to  use con.Open()
            //    //no need to use con.Close()
            //}

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=pubs;Integrated Security=True;Trust Server Certificate=True");


            SqlCommand command = new SqlCommand();
            command.CommandText = "select au_fname+' '+au_lname  fullname,au_id  ABC from authors";

            command.Connection = con;

            try
            {
                con.Open();
                SqlDataReader dr = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                comboAuthors.DataSource = dt;
                comboAuthors.DisplayMember = "fullname";
                comboAuthors.ValueMember = "ABC";

            }
            catch (Exception)
            {

                throw;
            }
            finally { con.Close(); }
        }

        private void comboAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=pubs;Integrated Security=True;Trust Server Certificate=True");


            SqlCommand command = new SqlCommand();
            command.CommandText = $"select t.* from authors a,titles t,titleauthor ta where a.au_id=ta.au_id and ta.title_id=t.title_id and a.au_id='{comboAuthors.SelectedValue}'";

            command.Connection = con;

            try
            {
                con.Open();
                SqlDataReader dr = command.ExecuteReader(); 
                DataTable dt = new DataTable();
                dt.Load(dr);
                gridTitles.DataSource = dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally { con.Close(); }
        }
    }
}
