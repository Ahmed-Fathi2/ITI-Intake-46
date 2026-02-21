
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using System.Data;

namespace ADO.Disconnected
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITI"].ConnectionString);
        DataTable dataTable = new DataTable();
        public Form1()
        {
            InitializeComponent();

            GetAllInstractors();
        }

        private void GetAllInstractors()
        {
            var query = "SELECT  [Ins_Id],[Ins_Name],[Ins_Degree],[Salary] FROM [ITI].[dbo].[Instructor]";
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataAdapter adapter = new SqlDataAdapter();


            adapter.SelectCommand = command;
            adapter.Fill(dataTable);

            griddata.DataSource = dataTable;



        }

        private void btnAdd_Click(object sender, EventArgs e)
        {


            DataRow row = dataTable.NewRow();

            row["Ins_Id"] = int.Parse(txtId.Text);
            row["Ins_Name"] = txtName.Text;
            row["Ins_Degree"] = txtDegree.Text;
            row["Salary"] = decimal.Parse(txtSalary.Text);

            dataTable.Rows.Add(row);

        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            var addQuery = " insert into[Instructor]( [Ins_Id],[Ins_Name],[Ins_Degree],[Salary])values(@id,@name,@degree,@salary)";
            SqlCommand addCommand =new SqlCommand(addQuery, connection);
            addCommand.Parameters.Add("@id",SqlDbType.Int,0, "Ins_Id");
            addCommand.Parameters.Add("@name", SqlDbType.NVarChar,100, "Ins_Name");
            addCommand.Parameters.Add("@degree", SqlDbType.NVarChar, 100, "Ins_Degree");
            addCommand.Parameters.Add("@salary", SqlDbType.Decimal,0, "Salary");


            var updateQuery = "update Instructor set Ins_Name=@name, Ins_Degree=@degree, Salary=@salary where Ins_Id=@id";
            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
            updateCommand.Parameters.Add("@id", SqlDbType.Int, 0, "Ins_Id");
            updateCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100, "Ins_Name");
            updateCommand.Parameters.Add("@degree", SqlDbType.NVarChar, 100, "Ins_Degree");
            updateCommand.Parameters.Add("@salary", SqlDbType.Decimal, 0, "Salary");




            var deleteQuery = "delete from Instructor where Ins_Id=@id";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
            deleteCommand.Parameters.Add("@id", SqlDbType.Int, 0, "Ins_Id");

            adapter.InsertCommand = addCommand;
            adapter.UpdateCommand= updateCommand;
            adapter.DeleteCommand= deleteCommand;

            adapter.Update(dataTable);

            MessageBox.Show("Database Updated Sucssesfully");





        }
    }
}
