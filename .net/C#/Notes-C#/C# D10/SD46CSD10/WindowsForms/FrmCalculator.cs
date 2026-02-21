using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class FrmCalculator : Form
    {
        double num1;
        double num2;
        char _operator;
        public FrmCalculator()
        {
            InitializeComponent();
        }

        private void btnNumbers_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            txtScreen.AppendText(btn.Text);
        }

        private void btnOperators_Click(object sender, EventArgs e)
        {
            
            num1 = double.Parse(txtScreen.Text);
            _operator =char.Parse( (sender as Button).Text);
            txtScreen.Clear();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            txtScreen.AppendText("1");
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            txtScreen.AppendText("2");
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(txtScreen.Text);
            _operator = '+';
            txtScreen.Clear();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(txtScreen.Text);
            _operator = '-';
            txtScreen.Clear();
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            num2 = double.Parse(txtScreen.Text);
            txtScreen.Clear();
            switch (_operator)
            {
                case '+':
                    txtScreen.Text = $"{num1 + num2}";
                    break;
                case '-':
                    txtScreen.Text = $"{num1 - num2}";
                    break;
            }
        }

        
    }
}
