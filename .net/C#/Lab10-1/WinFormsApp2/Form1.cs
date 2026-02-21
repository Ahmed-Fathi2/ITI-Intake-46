using System.Data;
using System.Globalization;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNumbers_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            txtScreen.AppendText(btn.Text);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            txtScreen.Clear();
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            try
            {
                var expression = txtScreen.Text;

                double result = EvaluateExpression(expression);

                txtScreen.Text = result.ToString();
            }

            catch
            {
                MessageBox.Show("invalid operation", "Error");
                txtScreen.Clear();
            }

        }


        private double EvaluateExpression(string expr)
        {
            if (string.IsNullOrWhiteSpace(expr))
                //MessageBox.Show("Empty expression", "Error");
                throw new Exception("Empty expression");

            var table = new DataTable();
            var resultObj = table.Compute(expr, "");

            double result = Convert.ToDouble(resultObj, CultureInfo.InvariantCulture);

            if (double.IsInfinity(result) || double.IsNaN(result))
                throw new Exception("Division by zero");

            return result;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            txtScreen.AppendText(btn.Text);
        }
    }
}



