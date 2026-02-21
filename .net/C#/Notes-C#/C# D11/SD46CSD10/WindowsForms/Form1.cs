namespace WindowsForms
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"Welcome {txtFName.Text} {txtLName.Text}");
            FrmWelcome welcome= new FrmWelcome($"{txtFName.Text} {txtLName.Text}");
            welcome.Show();
            this.Hide();
        }
    }
}
