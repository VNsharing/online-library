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
    public partial class BorrowForm : Form
    {
        public SqlConnection con;
        public BorrowForm()
        {
            InitializeComponent();
            con = new SqlConnection("Server=LAPTOP-CT7N310O\\SQLEXPRESS;Database=Online_Library;Integrated Security = true;");
        }
        public void FillData()
        {
            string query = "select * from Borrow_Form";
            DataTable table = new DataTable();
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(table);
            dgvBorrow.DataSource = table;
            con.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void BorrowForm_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int error = 0;
            int check;
            string BorrowID = txtBorrowID.Text;
            if (BorrowID.Equals(""))
            {
                error++;
                lblBorrowError.Text = "Id can't be blank";
            }
            else if (!int.TryParse(txtBorrowID.Text, out check))
            {
                error++;
                txtBorrowID.Text = "";
                lblBorrowError.Text = "invalid ID";
            }
            else
            {
                string query = "select * from Borrow_Form where BorrowAttemptID = @BorrowID";
                con.Open();
                SqlCommand cmdcheck = new SqlCommand(query, con);
                cmdcheck.Parameters.Add("@BorrowID", SqlDbType.Int);
                cmdcheck.Parameters["@BorrowID"].Value = Convert.ToInt32(BorrowID);
                SqlDataReader reader = cmdcheck.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    lblBorrowError.Text = "ID has already existed";
                }
                else
                {
                    lblBorrowError.Text = "";
                }
                con.Close();
            }
            string BookID = txtBookID.Text;
            if (BookID.Equals(""))
            {
                error++;
                lblBookError.Text = "Id can't be blank";
            }
            else if (!int.TryParse(txtBookID.Text, out check))
            {
                error++;
                txtBookID.Text = "";
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
                con.Close();
            }
            string CustomerID = txtCustomerID.Text;
            if (CustomerID.Equals(""))
            {
                error++;
                lblCustomerError.Text = "Id can't be blank";
            }
            else if (!int.TryParse(txtCustomerID.Text, out check))
            {
                error++;
                txtCustomerID.Text = "";
                lblCustomerError.Text = "invalid ID";
            }
            else
            {
                string query = "select * from customer where CustomerID = @CustomerID";
                con.Open();
                SqlCommand cmdcheck = new SqlCommand(query, con);
                cmdcheck.Parameters.Add("@CustomerID", SqlDbType.Int);
                cmdcheck.Parameters["@CustomerID"].Value = Convert.ToInt32(CustomerID);
                SqlDataReader reader = cmdcheck.ExecuteReader();
                if (!reader.Read())
                {
                    error++;
                    lblCustomerError.Text = "ID doesn't exist";
                }
                else
                {
                    lblCustomerError.Text = "";
                }
                con.Close();
            }
            string BorrowDate = dtpBorrowDate.Text;
            if (BorrowDate.Equals(""))
            {
                error++;
                lblBorrowDateError.Text = "Borrow date can't be blank";
            }
            else
            {
                lblBorrowDateError.Text = "";
            }
            string ReturnDate = dtpReturnDate.Text;
            if (ReturnDate.Equals(""))
            {
                error++;
                lblReturnDateError.Text = "Return date can't be blank";
            }
            else
            {
                lblReturnDateError.Text = "";
            }
            if (error == 0)
            {
                string insert = "insert into Borrow_Form values (@BorrowAttemptID,@CustomerID,@BookID,@BorrowDate,@ReturnDate)";
                con.Open();
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.Parameters.Add("@BorrowAttemptID", SqlDbType.Int);
                cmd.Parameters["@BorrowAttemptID"].Value = BorrowID;
                cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                cmd.Parameters["@CustomerID"].Value = CustomerID;
                cmd.Parameters.Add("@BookID", SqlDbType.Int);
                cmd.Parameters["@BookID"].Value = BookID;
                cmd.Parameters.Add("@BorrowDate", SqlDbType.Date);
                cmd.Parameters["@BorrowDate"].Value = BorrowDate;
                cmd.Parameters.Add("@ReturnDate", SqlDbType.Date);
                cmd.Parameters["@ReturnDate"].Value = ReturnDate;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int error = 0;
            int check;
            string BorrowID = txtBorrowID.Text;
            if (BorrowID.Equals(""))
            {
                error++;
                lblBorrowError.Text = "Id can't be blank";
            }
            else if (!int.TryParse(txtBorrowID.Text, out check))
            {
                error++;
                txtBorrowID.Text = "";
                lblBorrowError.Text = "invalid ID";
            }
            else
            {
                string query = "select * from Borrow_Form where BorrowAttemptID = @BorrowID";
                con.Open();
                SqlCommand cmdcheck = new SqlCommand(query, con);
                cmdcheck.Parameters.Add("@BorrowID", SqlDbType.Int);
                cmdcheck.Parameters["@BorrowID"].Value = Convert.ToInt32(BorrowID);
                SqlDataReader reader = cmdcheck.ExecuteReader();
                if (!reader.Read())
                {
                    error++;
                    lblBorrowError.Text = "ID doesn't exist";
                }
                else
                {
                    lblBorrowError.Text = "";
                }
                con.Close();
            }
            string BookID = txtBookID.Text;
            if (BookID.Equals(""))
            {
                error++;
                lblBookError.Text = "Id can't be blank";
            }
            else if (!int.TryParse(txtBookID.Text, out check))
            {
                error++;
                txtBookID.Text = "";
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
                con.Close();
            }
            string CustomerID = txtCustomerID.Text;
            if (CustomerID.Equals(""))
            {
                error++;
                lblCustomerError.Text = "Id can't be blank";
            }
            else if (!int.TryParse(txtCustomerID.Text, out check))
            {
                error++;
                txtCustomerID.Text = "";
                lblCustomerError.Text = "invalid ID";
            }
            else
            {
                string query = "select * from customer where CustomerID = @CustomerID";
                con.Open();
                SqlCommand cmdcheck = new SqlCommand(query, con);
                cmdcheck.Parameters.Add("@CustomerID", SqlDbType.Int);
                cmdcheck.Parameters["@CustomerID"].Value = Convert.ToInt32(CustomerID);
                SqlDataReader reader = cmdcheck.ExecuteReader();
                if (!reader.Read())
                {
                    error++;
                    lblCustomerError.Text = "ID doesn't exist";
                }
                else
                {
                    lblCustomerError.Text = "";
                }
                con.Close();
            }
            string BorrowDate = dtpBorrowDate.Text;
            if (BorrowDate.Equals(""))
            {
                error++;
                lblBorrowDateError.Text = "Borrow date can't be blank";
            }
            else
            {
                lblBorrowDateError.Text = "";
            }
            string ReturnDate = dtpReturnDate.Text;
            if (ReturnDate.Equals(""))
            {
                error++;
                lblReturnDateError.Text = "Return date can't be blank";
            }
            else
            {
                lblReturnDateError.Text = "";
            }
            if (error == 0)
            {
                string update = "update Borrow_Form set CustomerID = @CustomerID, BookID = @BookID, BorrowDate = @BorrowDate, ReturnDate = @ReturnDate where BorrowAttemptID = @BorrowAttemptID";
                con.Open();
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.Parameters.Add("@BorrowAttemptID", SqlDbType.Int);
                cmd.Parameters["@BorrowAttemptID"].Value = BorrowID;
                cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                cmd.Parameters["@CustomerID"].Value = CustomerID;
                cmd.Parameters.Add("@BookID", SqlDbType.Int);
                cmd.Parameters["@BookID"].Value = BookID;
                cmd.Parameters.Add("@BorrowDate", SqlDbType.Date);
                cmd.Parameters["@BorrowDate"].Value = BorrowDate;
                cmd.Parameters.Add("@ReturnDate", SqlDbType.Date);
                cmd.Parameters["@ReturnDate"].Value = ReturnDate;
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.ShowDialog();
            this.Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int error = 0;
            int check;
            string ID = txtBorrowID.Text;
            if (ID.Equals(""))
            {
                error++;
                lblBorrowError.Text = "select a ID to Delete";
            }
            else if (!int.TryParse(txtBorrowID.Text, out check))
            {
                error++;
                txtBorrowID.Text = "";
                lblBorrowError.Text = "invalid ID";
            }
            else if (error == 0)
            {
                con.Open();
                string query2 = "delete from Borrow_Form where BorrowAttemptID = @BorrowAttemptID";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.Add("@BorrowAttemptID", SqlDbType.Int);
                cmd2.Parameters["@BorrowAttemptID"].Value = txtBorrowID.Text;
                cmd2.ExecuteNonQuery();
                MessageBox.Show("deleted successfully");
                con.Close();
                FillData();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtBorrowID.Text = "";
            txtCustomerID.Text = "";
            txtBookID.Text = "";
            dtpBorrowDate.Value = DateTime.Now;
            dtpReturnDate.Value = DateTime.Now;
        }

        private void dgvBorrow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvBorrow.Rows[e.RowIndex];
            txtBorrowID.Text = row.Cells["BorrowAttemptID"].Value.ToString();
            txtCustomerID.Text = row.Cells["CustomerID"].Value.ToString();
            txtBookID.Text = row.Cells["BookID"].Value.ToString();
            dtpBorrowDate.Text = row.Cells["BorrowDate"].Value.ToString();
            dtpReturnDate.Text = row.Cells["ReturnDate"].Value.ToString();
        }
    }
}
