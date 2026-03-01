using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace DisconnectedMode
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["pubs"].ConnectionString);
            command = new SqlCommand();
            adapter = new SqlDataAdapter();
            dt = new DataTable();
            FillAuthorsList();
        }

        private void FillAuthorsList()
        {
            //4- command
            command.CommandText = "select au_id,au_fname,au_lname,address from authors";

            //REMEMBER Command to connection
            command.Connection = con;

            //adapter ->command?
            adapter.SelectCommand = command;

            //SqlDataAdapter Quickly 1-open 2-execute cmd 3-fill to DT 4-close
            adapter.Fill(dt);

            //data binding
            gridAuthors.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow dr = dt.NewRow();
            dr["au_id"] = txtId.Text;
            dr["au_fname"] = txtFName.Text;
            dr["au_lname"] = txtLName.Text;
            dr["address"] = txtAddress.Text;

            //add row into dt
            dt.Rows.Add(dr);
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            #region Insert
            SqlCommand insCommand = new SqlCommand();
            insCommand.CommandText = "insert into authors(au_id,au_fname,au_lname,address) values(@id,@fname,@lname,@address)";
            insCommand.Parameters.Add("@id", SqlDbType.VarChar, 20, "au_id");
            insCommand.Parameters.Add("@fname", SqlDbType.VarChar, 20, "au_fname");
            insCommand.Parameters.Add("@lname", SqlDbType.VarChar, 20, "au_lname");
            insCommand.Parameters.Add("@address", SqlDbType.VarChar, 20, "address");
            insCommand.Connection= con;
            #endregion

            #region Update
            SqlCommand updCommand = new SqlCommand();
            updCommand.CommandText = "update authors set au_fname=@fname,au_lname=@lname,address=@address where au_id=@id";
            updCommand.Parameters.Add("@id", SqlDbType.VarChar, 20, "au_id");
            updCommand.Parameters.Add("@fname", SqlDbType.VarChar, 20, "au_fname");
            updCommand.Parameters.Add("@lname", SqlDbType.VarChar, 20, "au_lname");
            updCommand.Parameters.Add("@address", SqlDbType.VarChar, 20, "address");
            updCommand.Connection = con;
            #endregion

            #region Delete
            SqlCommand delCommand = new SqlCommand();
            delCommand.CommandText = "delete from authors where au_id=@id";
            delCommand.Parameters.Add("@id", SqlDbType.VarChar, 20, "au_id");
            delCommand.Connection = con;
            #endregion

            adapter.InsertCommand = insCommand;
            adapter.UpdateCommand = updCommand;
            adapter.DeleteCommand = delCommand;

            ///Return Quickly 1-open   2-execute by rowState 3-close     Update()
            var affected= adapter.Update(dt);
        }
    }
}
