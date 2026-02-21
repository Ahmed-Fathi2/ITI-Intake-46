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
    public partial class FrmUpdate : Form
    {
        public FrmUpdate()
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
            command.CommandText = $"select * from authors where au_id='{comboAuthors.SelectedValue}'";

            command.Connection = con;

            try
            {
                con.Open();
                SqlDataReader dr = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                txtId.Text = dt.Rows[0]["au_id"].ToString();
                txtFName.Text = dt.Rows[0]["au_fname"].ToString();
                txtLName.Text = dt.Rows[0]["au_lname"].ToString();
                txtAddress.Text = dt.Rows[0]["address"].ToString();
                txtId.Enabled = false;

            }
            catch (Exception)
            {

                throw;
            }
            finally { con.Close(); }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=pubs;Integrated Security=True;Trust Server Certificate=True");


            SqlCommand command = new SqlCommand();
            //command.CommandText = $"update authors set au_fname='{txtFName.Text}',au_lname='{txtLName.Text}',address='{txtAddress.Text}' where au_id='{txtId.Text}'";

            command.CommandText = $"update authors set au_fname=@fn,au_lname=@ln,address=@address where au_id=@id";
            command.Parameters.AddWithValue("@id", txtId.Text);
            command.Parameters.AddWithValue("@fn", txtFName.Text);
            command.Parameters.AddWithValue("@ln", txtLName.Text);
            command.Parameters.AddWithValue("@address", txtAddress.Text);
            command.Connection = con;

            try
            {
                con.Open();
                //lblResult.Text = $"{command.ExecuteNonQuery()} rows affected";
                int affected = command.ExecuteNonQuery();
                if (affected > 0)
                {
                    lblResult.Text = "Updated...";
                    FillAuthorsToComboBox();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { con.Close(); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are u sure Delete {comboAuthors.SelectedItem}","Warning!!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=pubs;Integrated Security=True;Trust Server Certificate=True");


                SqlCommand command = new SqlCommand();
                //command.CommandText = $"update authors set au_fname='{txtFName.Text}',au_lname='{txtLName.Text}',address='{txtAddress.Text}' where au_id='{txtId.Text}'";

                command.CommandText = $"delete from authors where au_id=@id";
                command.Parameters.AddWithValue("@id", comboAuthors.SelectedValue);
                command.Connection = con;

                try
                {
                    con.Open();
                    //lblResult.Text = $"{command.ExecuteNonQuery()} rows affected";
                    int affected = command.ExecuteNonQuery();
                    if (affected > 0)
                    {
                        lblResult.Text = "Updated...";
                        FillAuthorsToComboBox();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally { con.Close(); }
            }
        }
    }
}
