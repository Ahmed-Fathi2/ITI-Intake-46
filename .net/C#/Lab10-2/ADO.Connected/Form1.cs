
using Microsoft.Data.SqlClient;
using System.Data;

namespace ADO.Connected
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetAllInnstractorNames();
        }

        private void GetAllInnstractorNames()
        {
            SqlConnection sqlConnection = new SqlConnection("Server=.;Database=ITI;trusted_connection=true;trustServerCertificate=true");
            SqlCommand sqlCommand = new SqlCommand("SELECT Ins_Name as IName,Ins_Id FROM Instructor", sqlConnection);

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(reader);

                comboBox.DataSource = dt;
                comboBox.DisplayMember = "IName";
                comboBox.ValueMember = "Ins_Id";

            }
            catch { }
            finally
            {
                sqlConnection.Close();
            }

        }

        //GetAllInstractorTopics();
        /*
        private void GetAllInstractorTopics()
        {
            var commandText = "select I.*,T.* from Instructor I,Ins_Course IC,Course C,Topic T where I.Ins_Id=IC.Ins_Id and C.Crs_Id=Ic.Crs_Id and T.Top_Id=C.Top_Id";
            SqlConnection con = new SqlConnection("Server=.;Database=ITI;trusted_connection=true;trustServerCertificate=true");
            SqlCommand command = new SqlCommand(commandText, con);

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                DataTable td = new DataTable();

                td.Load(reader);

                gridData.DataSource = td;


            }
            catch { }
            finally
            {
                con.Close();
            }

        }
        */

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show($"{comboBox.SelectedValue}");
            var commandtext= $"select I.Ins_Name,T.* from Instructor I,Ins_Course IC,Course C,Topic T where I.Ins_Id=IC.Ins_Id and C.Crs_Id=IC.Crs_Id and T.Top_Id=C.Top_Id and I.Ins_Id='{comboBox.SelectedValue}'";
            SqlConnection con = new SqlConnection("Server=.;Database=ITI;trusted_connection=true;trustServerCertificate=true");
            SqlCommand command = new SqlCommand(commandtext, con);

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                DataTable td = new DataTable();

                td.Load(reader);

                gridData.DataSource = td;


            }
            catch { }
            finally
            {
                con.Close();
            }
        }
    }
}
