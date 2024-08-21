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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Online_Library_Test
{
    public partial class Books : Form
    {
        public SqlConnection con;
        public Books()
        {
            InitializeComponent();
            con = new SqlConnection("Server=LAPTOP-CT7N310O\\SQLEXPRESS;Database=Online_Library;Integrated Security = true;");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dtpPublishDate.MaxDate = DateTime.Now;
            FillData();
        }
        public void FillData()
        {
            string query = "select * from Book";
            DataTable table = new DataTable();
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(table);
            dgvBook.DataSource = table;
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int error = 0;
            int check;
            string BookID = txtID.Text;
            if (BookID.Equals(""))
            {
                error++;
                lblIDError.Text = "Id can't be blank";
            }
            else if (!int.TryParse(txtID.Text, out check))
            {
                error++;
                txtID.Text = "";
                lblIDError.Text = "invalid ID";
            }
            else
            {
                string query = "select * from Book where BookID = @BookID";
                con.Open();
                SqlCommand cmdcheck = new SqlCommand(query, con);
                cmdcheck.Parameters.Add("@BookID", SqlDbType.Int);
                cmdcheck.Parameters["@BookID"].Value = Convert.ToInt32(BookID);
                SqlDataReader reader = cmdcheck.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    lblIDError.Text = "ID has already existed";
                }
                else
                {
                    lblIDError.Text = "";
                }
                con.Close();
            }
            string BookName = txtName.Text;
            if (BookName.Equals(""))
            {
                error++;
                lblNameError.Text = "Book Name can't be blank";
            }
            else
            {
                lblNameError.Text = "";
            }
            string publisher = txtPublisher.Text;
            if (publisher.Equals(""))
            {
                error++;
                lblPublisherError.Text = "Publisher can't be blank";
            }
            else
            {
                lblPublisherError.Text = "";
            }
            string PublishDate = dtpPublishDate.Text;
            if (PublishDate.Equals(""))
            {
                error++;
                lblPublisherError.Text = "Publish date can't be blank";
            }
            else
            {
                lblPublishDateError.Text = "";
            }
            if (error == 0)
            {
                string insert = "insert into Book values (@BookID,@BookName,@Publisher,@PublishDate)";
                con.Open();
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.Parameters.Add("@BookID", SqlDbType.Int);
                cmd.Parameters["@BookID"].Value = BookID;
                cmd.Parameters.Add("@BookName", SqlDbType.NVarChar);
                cmd.Parameters["@BookName"].Value = BookName;
                cmd.Parameters.Add("@Publisher", SqlDbType.NVarChar);
                cmd.Parameters["@Publisher"].Value = publisher;
                cmd.Parameters.Add("@PublishDate", SqlDbType.Date);
                cmd.Parameters["@PublishDate"].Value = PublishDate;
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
            string ID = txtID.Text;
            if (ID.Equals(""))
            {
                lblIDError.Text = "select a ID to Delete";
            }
            else if (!int.TryParse(txtID.Text, out check))
            {
                error++;
                txtID.Text = "";
                lblIDError.Text = "invalid ID";
            }
            else
            {
                string BookID = txtID.Text;
                if (BookID.Equals(""))
                {
                    error++;
                    lblIDError.Text = "Id can't be blank";
                }
                else
                {
                    string query1 = "select * from Borrow_Form where BookID = @BookID";
                    con.Open();
                    SqlCommand cmdcheck1 = new SqlCommand(query1, con);
                    cmdcheck1.Parameters.Add("@BookID", SqlDbType.Int);
                    cmdcheck1.Parameters["@BookID"].Value = Convert.ToInt32(BookID);
                    SqlDataReader reader1 = cmdcheck1.ExecuteReader();
                    if (reader1.Read())
                    {
                        error++;
                        MessageBox.Show("you must delete every borrow attempt of this book");
                    }
                    con.Close();
                    string query2 = "select * from Book_Category where BookID = @BookID";
                    con.Open();
                    SqlCommand cmdcheck2 = new SqlCommand(query2, con);
                    cmdcheck2.Parameters.Add("@BookID", SqlDbType.Int);
                    cmdcheck2.Parameters["@BookID"].Value = Convert.ToInt32(BookID);
                    SqlDataReader reader2 = cmdcheck2.ExecuteReader();
                    if (reader2.Read())
                    {
                        error++;
                        MessageBox.Show("you must delete every book category of this book");
                    }
                    con.Close();
                    string query3 = "select * from Book_Author where BookID = @BookID";
                    con.Open();
                    SqlCommand cmdcheck3 = new SqlCommand(query3, con);
                    cmdcheck3.Parameters.Add("@BookID", SqlDbType.Int);
                    cmdcheck3.Parameters["@BookID"].Value = Convert.ToInt32(BookID);
                    SqlDataReader reader3 = cmdcheck3.ExecuteReader();
                    if (reader3.Read())
                    {
                        error++;
                        MessageBox.Show("you must delete every book author of this book");
                    }
                    con.Close();
                }
                if (error == 0)
                {
                    con.Open();
                    string query2 = "delete from Book where BookID = @BookID";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.Parameters.Add("@BookID", SqlDbType.Int);
                    cmd2.Parameters["@BookID"].Value = txtID.Text;
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("deleted successfully");
                    con.Close();
                    FillData();
                }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int error = 0;
            int check;
            string BookID = txtID.Text;
            if (BookID.Equals(""))
            {
                error++;
                lblIDError.Text = "Id can't be blank";
            }
            else if (!int.TryParse(txtID.Text, out check))
            {
                error++;
                txtID.Text = "";
                lblIDError.Text = "invalid ID";
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
                    lblIDError.Text = "ID doesn't exist";
                }
                else
                {
                    lblIDError.Text = "";
                }
                con.Close();
            }
            string BookName = txtName.Text;
            if (BookName.Equals(""))
            {
                error++;
                lblNameError.Text = "Book Name can't be blank";
            }
            else
            {
                lblNameError.Text = "";
            }
            string publisher = txtPublisher.Text;
            if (publisher.Equals(""))
            {
                error++;
                lblPublisherError.Text = "Publisher can't be blank";
            }
            else
            {
                lblPublisherError.Text = "";
            }
            string PublishDate = dtpPublishDate.Text;
            if (PublishDate.Equals(""))
            {
                error++;
                lblPublisherError.Text = "Publish date can't be blank";
            }
            else 
            {
                lblPublishDateError.Text = "";
            }
            if (error == 0)
            {
                string update = "update Book set BookName = @BookName, Publisher = @Publisher, PublishDate = @PublishDate where BookID = @BookID,";
                con.Open();
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.Parameters.Add("@BookID", SqlDbType.Int);
                cmd.Parameters["@BookID"].Value = BookID;
                cmd.Parameters.Add("@BookName", SqlDbType.NVarChar);
                cmd.Parameters["@BookName"].Value = BookName;
                cmd.Parameters.Add("@Publisher", SqlDbType.NVarChar);
                cmd.Parameters["@Publisher"].Value = publisher;
                cmd.Parameters.Add("@PublishDate", SqlDbType.Date);
                cmd.Parameters["@PublishDate"].Value = PublishDate;
                cmd.ExecuteNonQuery();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    MessageBox.Show("updated successfully");
                }
                else
                {
                    MessageBox.Show("update failed");
                }
                FillData();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            txtPublisher.Text = "";
            dtpPublishDate.Value = DateTime.Now;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.ShowDialog();
            this.Dispose();
        }

        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvBook.Rows[e.RowIndex];
            txtID.Text = row.Cells["BookID"].Value.ToString();
            txtName.Text = row.Cells["BookName"].Value.ToString();
            txtPublisher.Text = row.Cells["Publisher"].Value.ToString();
            dtpPublishDate.Text = row.Cells["PublishDate"].Value.ToString();
        }
    }
}
