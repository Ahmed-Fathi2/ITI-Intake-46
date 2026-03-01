
using Company.BusinessLayer;

namespace Company.PresentationLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillAuthorsList();
        }

        private void FillAuthorsList()
        {
            gridAuthors.DataSource = Company.BusinessLayer.AuthorBL.GetAll2();
            comboAuthors.DataSource = Company.BusinessLayer.AuthorBL.GetAll2();
            comboAuthors.ValueMember = "au_id";
            comboAuthors.DisplayMember = "au_fname";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var a1 = new Author
            {
                Au_id = txtId.Text,
                Au_Fname = txtFName.Text,
                Au_Lname = txtLName.Text,
                Address = txtAddress.Text,
            };
            var affected = Company.BusinessLayer.AuthorBL.Add(a1);
            if (affected > 0)
            {
                lblResult.Text = "Done";
                FillAuthorsList();
            }
        }

        private void comboAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a1 = Company.BusinessLayer.AuthorBL.GetOne2(comboAuthors.SelectedValue.ToString());
            txtId.Text = a1.Au_id;
            txtFName.Text = a1.Au_Fname;
            txtLName.Text = a1.Au_Lname;
            txtAddress.Text = a1.Address;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var a1 = new Author
            {
                Au_id = txtId.Text,
                Au_Fname = txtFName.Text,
                Au_Lname = txtLName.Text,
                Address = txtAddress.Text,
            };
            var affected = Company.BusinessLayer.AuthorBL.Update(a1);
            if (affected > 0)
            {
                lblResult.Text = "Done";
                FillAuthorsList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if () { }
            var affected=Company.BusinessLayer.AuthorBL.Delete(comboAuthors.SelectedValue.ToString());
            if (affected > 0)
            {
                lblResult.Text = "Done";
                FillAuthorsList();
            }
        }
    }
}
