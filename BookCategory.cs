using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Online_Library_Test
{
    public partial class BookCategory : Form
    {
        public SqlConnection con;
        public BookCategory()
        {
            InitializeComponent();
            con = new SqlConnection("Server=LAPTOP-CT7N310O\\SQLEXPRESS;Database=Online_Library;Integrated Security = true;");
        }
        public void FillData()
        {
            string query = "select * from Book_Category";
            DataTable table = new DataTable();
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(table);
            dgvBookCategory.DataSource = table;
            con.Close();
        }
        private void BookCategory_Load(object sender, EventArgs e)
        {
            string query = "select CategoryID,CategoryName from Category";
            DataTable table = new DataTable();
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(table);
            cbxCategory.DataSource = table;
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryID";
            con.Close();
            FillData();
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
                string query = "select * from Book where BookID = @BookID";
                con.Open();
                SqlCommand cmdcheck = new SqlCommand(query, con);
                cmdcheck.Parameters.Add("@BookID", SqlDbType.Int);
                cmdcheck.Parameters["@BookID"].Value = Convert.ToInt32(BookID);
                SqlDataReader reader = cmdcheck.ExecuteReader();
                if (!reader.Read())
                {
                    error++;
                    lblBookError.Text = "ID doesn't exist";
                }
                else
                {
                    lblBookError.Text = "";
                }
            }
            string CategoryID = cbxCategory.ValueMember;
            if (CategoryID.Equals(""))
            {
                error++;
                lblCategoryError.Text = "Category Name can't be blank";
            }
            else
            {
                string query = "select * from Book_Category where BookID = @BookID and CategoryID = @CategoryID";
                con.Open();
                SqlCommand cmdcheck = new SqlCommand(query, con);
                cmdcheck.Parameters.Add("@BookID", SqlDbType.Int);
                cmdcheck.Parameters["@BookID"].Value = Convert.ToInt32(BookID);
                cmdcheck.Parameters.Add("@CategoryID", SqlDbType.Int);
                cmdcheck.Parameters["@CategoryID"].Value = Convert.ToInt32(CategoryID);
                SqlDataReader reader = cmdcheck.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    MessageBox.Show("Book Category already existed");
                }
                con.Close();
            }
            if (error == 0)
            {
                string insert = "insert into Book_Category values (@BookID,@CategoryID)";
                con.Open();
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.Parameters.Add("@BookID", SqlDbType.Int);
                cmd.Parameters["@BookID"].Value = BookID;
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int);
                cmd.Parameters["@CategoryID"].Value = CategoryID;
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
                lblBookError.Text = "select a Book ID to delete";
            }
            else if (!int.TryParse(txtBook.Text, out check))
            {
                error++;
                txtBook.Text = "";
                lblBookError.Text = "invalid ID";
            }
            string CategoryID = cbxCategory.ValueMember;
            if (CategoryID.Equals(""))
            {
                error++;
                lblCategoryError.Text = "select a Category name to delete";
            }
            if (error == 0)
            {
                con.Open();
                string query2 = "delete from Book_Category where BookID = @BookID and CategoryID = @CategoryID";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.Add("@BookID", SqlDbType.Int);
                cmd2.Parameters["@BookID"].Value = txtBook.Text;
                cmd2.Parameters.Add("@CategoryID", SqlDbType.Int);
                cmd2.Parameters["@CategoryID"].Value = CategoryID;
                cmd2.ExecuteNonQuery();
                MessageBox.Show("deleted successfully");
                con.Close();
                FillData();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.ShowDialog();
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtBook.Text = "";
            cbxCategory.Text = "";
        }

        private void dgvBookCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvBookCategory.Rows[e.RowIndex];
            txtBook.Text = row.Cells["BookID"].Value.ToString();
            
        }
    }
}
