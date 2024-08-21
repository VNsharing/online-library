using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Online_Library_Test
{
    public partial class AdminMenu : Form
    {
        public SqlConnection con;
        public AdminMenu(string username)
        {
            InitializeComponent();
            con = new SqlConnection("Server=LAPTOP-CT7N310O\\SQLEXPRESS;Database=Online_Library;Integrated Security = true;");
            lblUser.Text = "User:" + username;
        }
        public AdminMenu()
        {
            InitializeComponent();
            con = new SqlConnection("Server=LAPTOP-CT7N310O\\SQLEXPRESS;Database=Online_Library;Integrated Security = true;");
        }

        private void lblcustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            CustomerManagement customerManagement = new CustomerManagement();
            customerManagement.ShowDialog();
            this.Dispose();
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {

        }

        private void lblBooks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Books books = new Books();
            books.ShowDialog();
            this.Dispose();
        }

        private void lblAuthors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Author author = new Author();
            author.ShowDialog();
            this.Dispose();
        }

        private void lblCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Category category = new Category();
            category.ShowDialog();
            this.Dispose();
        }

        private void lblBookAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            BookAuthor bookAuthor = new BookAuthor();
            bookAuthor.ShowDialog();
            this.Dispose();
        }

        private void lblBookCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            BookCategory bookCategory = new BookCategory();
            bookCategory.ShowDialog();
            this.Dispose();
        }

        private void lblBookBorrow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            BorrowForm borrowForm = new BorrowForm();
            borrowForm.ShowDialog();
            this.Dispose();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Dispose();
        }
    }
}
