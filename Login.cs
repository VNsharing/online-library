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

namespace Online_Library_Test
{
    
    public partial class Login : Form
    {
        public SqlConnection con;
        public Login()
        {
            InitializeComponent();
            con = new SqlConnection("Server=LAPTOP-CT7N310O\\SQLEXPRESS;Database=Online_Library;Integrated Security = true;");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string query = "select * from account where username = '"+username+"'and u_password ='"+password+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string role = reader["u_role"].ToString();
                if (role.Equals("admin"))
                {
                    this.Hide();
                    AdminMenu adminMenu = new AdminMenu(username);
                    adminMenu.ShowDialog();
                    this.Dispose();
                }
                else if (role.Equals("user"))
                {
                    this.Hide();
                    BookView bookView = new BookView();
                    bookView.ShowDialog();
                    this.Dispose();
                }
                else
                {
                    lblError.Text = "you are not allowed to access";
                }
            }
            else
            {
                lblUserError.Text = "wrong username or password";
            }
            con.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPass.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
