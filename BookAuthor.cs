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
    public partial class BookAuthor : Form
    {
        public SqlConnection con;
        public BookAuthor()
        {
            InitializeComponent();
            con = new SqlConnection("Server=LAPTOP-CT7N310O\\SQLEXPRESS;Database=Online_Library;Integrated Security = true;");
        }
        public void FillData()
        {
            string query = "select * from Book_Author";
            DataTable table = new DataTable();
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(table);
            dgvBookAuthor.DataSource = table;
            con.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvBookAuthor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvBookAuthor.Rows[e.RowIndex];
            txtBook.Text = row.Cells["BookID"].Value.ToString();
            txtAuthor.Text = row.Cells["AuthorID"].Value.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtAuthor.Text = "";
            txtBook.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.ShowDialog();
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int error = 0;
            int check;
            string BookID = txtBook.Text;
            if (BookID.Equals(""))
            {
                error++;
                lblBookError.Text = "Id can't be blank";
            }
            else if (!int.TryParse(txtBook.Text, out check))
            {
                error++;
                txtBook.Text = "";
                lblBookError.Text = "invalid ID";
            }
            else
            {
                string query1 = "select * from Book where BookID = @BookID";
                con.Open();
                SqlCommand cmdcheck1 = new SqlCommand(query1, con);
                cmdcheck1.Parameters.Add("@BookID", SqlDbType.Int);
                cmdcheck1.Parameters["@BookID"].Value = Convert.ToInt32(BookID);
                SqlDataReader reader1 = cmdcheck1.ExecuteReader();
                if (!reader1.Read())
                {
                    error++;
                    lblBookError.Text = "ID doesn't exist";
                }
                else
                {
                    lblBookError.Text = "";
                }
            }
            string AuthorID = txtAuthor.Text;
            if (AuthorID.Equals(""))
            {
                error++;
                lblAuthorError.Text = "Author ID can't be blank";
            }
            else if (!int.TryParse(txtAuthor.Text, out check))
            {
                error++;
                txtAuthor.Text = "";
                lblAuthorError.Text = "invalid ID";
            }
            else
            {
                string query2 = "select * from Author where AuthorID = @AuthorID";
                con.Open();
                SqlCommand cmdcheck2 = new SqlCommand(query2, con);
                cmdcheck2.Parameters.Add("@AuthorID", SqlDbType.Int);
                cmdcheck2.Parameters["@AuthorID"].Value = Convert.ToInt32(AuthorID);
                SqlDataReader reader2 = cmdcheck2.ExecuteReader();
                if (!reader2.Read())
                {
                    error++;
                    lblAuthorError.Text = "ID doesn't exist";
                }
                else
                {
                    lblAuthorError.Text = "";
                }
            }
            string query = "select * from Book_Author where BookID = @BookID and AuthorID = @AuthorID";
            con.Open();
            SqlCommand cmdcheck = new SqlCommand(query, con);
            cmdcheck.Parameters.Add("@BookID", SqlDbType.Int);
            cmdcheck.Parameters["@BookID"].Value = Convert.ToInt32(BookID);
            cmdcheck.Parameters.Add("@AuthorID", SqlDbType.Int);
            cmdcheck.Parameters["@AuthorID"].Value = Convert.ToInt32(AuthorID);
            SqlDataReader reader = cmdcheck.ExecuteReader();
            if (reader.Read())
            {
                error++;
                MessageBox.Show("Book Author already existed");
            }
            con.Close();
            if (error == 0)
            {
                string insert = "insert into Book_Author values (@BookID,@AuthorID)";
                con.Open();
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.Parameters.Add("@BookID", SqlDbType.Int);
                cmd.Parameters["@BookID"].Value = BookID;
                cmd.Parameters.Add("@AuthorID", SqlDbType.Int);
                cmd.Parameters["@AuthorID"].Value = AuthorID;
                cmd.ExecuteNonQuery();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    MessageBox.Show("inserted successfully");
                }
                else
                {
                    MessageBox.Show("insert failed");
                }
                FillData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int error = 0;
            int check;
            string BookID = txtBook.Text;
            if (BookID.Equals(""))
            {
                error++;
                lblBookError.Text = "Id can't be blank";
            }
            else if (!int.TryParse(txtBook.Text, out check))
            {
                error++;
                txtBook.Text = "";
                lblBookError.Text = "invalid ID";
            }
            string AuthorID = txtAuthor.Text;
            if (AuthorID.Equals(""))
            {
                error++;
                lblAuthorError.Text = "Author ID can't be blank";
            }
            else if (!int.TryParse(txtAuthor.Text, out check))
            {
                error++;
                txtAuthor.Text = "";
                lblAuthorError.Text = "invalid ID";
            }
            if (error == 0)
            {
                con.Open();
                string query2 = "delete from Book_Author where BookID = @BookID and AuthorID = @AuthorID";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.Add("@BookID", SqlDbType.Int);
                cmd2.Parameters["@BookID"].Value = txtBook.Text;
                cmd2.Parameters.Add("@AuthorID", SqlDbType.Int);
                cmd2.Parameters["@AuthorID"].Value = AuthorID;
                cmd2.ExecuteNonQuery();
                MessageBox.Show("deleted successfully");
                con.Close();
                FillData();
            }
        }
    }
}
