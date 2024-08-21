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
    public partial class BookView : Form
    {
        public SqlConnection con;
        public BookView()
        {
            InitializeComponent();
            con = new SqlConnection("Server=LAPTOP-CT7N310O\\SQLEXPRESS;Database=Online_Library;Integrated Security = true;");
        }
        public BookView(string username)
        {
            InitializeComponent();
            con = new SqlConnection("Server=LAPTOP-CT7N310O\\SQLEXPRESS;Database=Online_Library;Integrated Security = true;");
            lblUser.Text = "User: " +username;
        }
        public void FillData()
        {
            string query = "select * from Book";
            DataTable table = new DataTable();
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(table);
            dgvBookView.DataSource = table;
            con.Close();
        }
        private void BookView_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Dispose();
        }
    }
}
