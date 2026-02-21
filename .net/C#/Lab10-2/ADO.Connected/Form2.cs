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

namespace ADO.Connected;
public partial class Form2 : Form
{
    public Form2()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        
        var connectionString = "Server=.;Database=ITI;trusted_connection=true;trustServerCertificate=true";
        var commandText = "insert into Instructor (Ins_Id,Ins_Name,Ins_Degree,Salary) values (@id,@name,@degree,@salary)";

        SqlConnection connection=new SqlConnection(connectionString);
        SqlCommand sqlCommand = new SqlCommand(commandText, connection);

        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(textIDValue.Text);
        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = textNameValue.Text;
        sqlCommand.Parameters.Add("@degree", SqlDbType.NVarChar, 50).Value = textDegreeValue.Text;
        sqlCommand.Parameters.Add("@salary", SqlDbType.Money).Value = decimal.Parse(textSalaryValue.Text);

        try
        {
            connection.Open();
            int result= sqlCommand.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show($"{result} row affected");
            }
        }
        catch(Exception ex) 
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            connection.Close();
        }

    }
}
