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
public partial class Form3 : Form
{
    public Form3()
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

    private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        //MessageBox.Show($"{comboBox.SelectedValue}");
        var commandtext = $"SELECT  [Ins_Id],[Ins_Name],[Ins_Degree],[Salary]FROM [ITI].[dbo].[Instructor]where Ins_Id = '{comboBox.SelectedValue}'";
        SqlConnection con = new SqlConnection("Server=.;Database=ITI;trusted_connection=true;trustServerCertificate=true");
        SqlCommand command = new SqlCommand(commandtext, con);

        try
        {
            con.Open();
            SqlDataReader reader = command.ExecuteReader();

            DataTable td = new DataTable();

            td.Load(reader);

            textIDValue.Text = td.Rows[0]["Ins_Id"].ToString();
            textNameValue.Text = td.Rows[0]["Ins_Name"].ToString();
            textDegreeValue.Text = td.Rows[0]["Ins_Degree"].ToString();
            textSalaryValue.Text = td.Rows[0]["Salary"].ToString();

            textIDValue.Enabled = false;


        }
        catch { }
        finally
        {
            con.Close();
        }

    }

    private void button1_Click(object sender, EventArgs e)
    {
        var query = "update Instructor set Ins_Name=@name,Ins_Degree=@degree,Salary=@salary where Ins_Id=@id";
        SqlConnection connection = new SqlConnection("Server=.;Database=ITI;trusted_connection=true;trustServerCertificate=true");
        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(textIDValue.Text);
        command.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = textNameValue.Text;
        command.Parameters.Add("@degree", SqlDbType.NVarChar, 50).Value = textDegreeValue.Text;
        command.Parameters.Add("@salary", SqlDbType.Money).Value = decimal.Parse(textSalaryValue.Text);

        try
        {
            connection.Open();

            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show($"{result} row affected");

            }
            GetAllInnstractorNames();

        }
        catch
        {
            throw;
        }
        finally
        {
            connection.Close();
        }


    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show($"Are u Sure Delete {comboBox.Text} ? ", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        {
            var query = "  delete from Instructor where Ins_Id=@id";
            SqlConnection connection = new SqlConnection("Server=.;Database=ITI;trusted_connection=true;trustServerCertificate=true");
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(textIDValue.Text);

            try
            {
                connection.Open();

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show($"Deleted Sucsessfully");

                }
                GetAllInnstractorNames();

            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
