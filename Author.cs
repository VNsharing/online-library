using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Library_Test
{
    public partial class Author : Form
    {
        public SqlConnection con;
        public void FillData()
        {
            string query = "select * from Author";
            DataTable table = new DataTable();
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(table);
            dgvAuthor.DataSource = table;
            con.Close();
        }
        public Author()
        {
            InitializeComponent();
            con = new SqlConnection("Server=LAPTOP-CT7N310O\\SQLEXPRESS;Database=Online_Library;Integrated Security = true;");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int error = 0;
            int check;
            string AuthorID = txtID.Text;
            if (AuthorID.Equals(""))
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
                string query = "select * from Author where AuthorID = @AuthorID";
                con.Open();
                SqlCommand cmdcheck = new SqlCommand(query, con);
                cmdcheck.Parameters.Add("@AuthorID", SqlDbType.Int);
                cmdcheck.Parameters["@AuthorID"].Value = Convert.ToInt32(AuthorID);
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
            string AuthorName = txtName.Text;
            if (AuthorName.Equals(""))
            {
                error++;
                lblNameError.Text = "Author Name can't be blank";
            }
            else
            {
                lblNameError.Text = "";
            }
            string BirthDate = dtpBirthDate.Text;
            if (BirthDate.Equals(""))
            {
                error++;
                lblNameError.Text = "Birth Date can't be blank";
            }
            else
            {
                lblNameError.Text = "";
            }
            string Origin = txtOrigin.Text;
            if (Origin.Equals(""))
            {
                error++;
                lblOriginError.Text = "Origin can't be blank";
            }
            else
            {
                lblOriginError.Text = "";
            }
            string Biography = txtBiography.Text;
            if (Biography.Equals(""))
            {
                error++;
                lblBiographyError.Text = "Biography can't be blank";
            }
            else
            {
                lblBiographyError.Text = "";
            }
            if (error == 0)
            {
                string insert = "insert into Author values (@AuthorID,@AuthorName,@BirthDate,@Origin,@Biography)";
                con.Open();
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.Parameters.Add("@AuthorID", SqlDbType.Int);
                cmd.Parameters["@AuthorID"].Value = AuthorID;
                cmd.Parameters.Add("@AuthorName", SqlDbType.NVarChar);
                cmd.Parameters["@AuthorName"].Value = AuthorName;
                cmd.Parameters.Add("@BirthDate", SqlDbType.Date);
                cmd.Parameters["@BirthDate"].Value = BirthDate;
                cmd.Parameters.Add("@Origin", SqlDbType.NVarChar);
                cmd.Parameters["@Origin"].Value = Origin;
                cmd.Parameters.Add("@Biography", SqlDbType.NVarChar);
                cmd.Parameters["@Biography"].Value = Biography;
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
            string AuthorID = txtID.Text;
            if (AuthorID.Equals(""))
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
                string query = "select * from Author where AuthorID = @AuthorID";
                con.Open();
                SqlCommand cmdcheck = new SqlCommand(query, con);
                cmdcheck.Parameters.Add("@AuthorID", SqlDbType.Int);
                cmdcheck.Parameters["@BookID"].Value = Convert.ToInt32(AuthorID);
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
            string AuthorName = txtName.Text;
            if (AuthorName.Equals(""))
            {
                error++;
                lblNameError.Text = "Author Name can't be blank";
            }
            else
            {
                lblNameError.Text = "";
            }
            string BirthDate = dtpBirthDate.Text;
            if (BirthDate.Equals(""))
            {
                error++;
                lblNameError.Text = "Birth Date can't be blank";
            }
            else
            {
                lblNameError.Text = "";
            }
            string BookName = txtName.Text;
            string Origin = txtOrigin.Text;
            if (Origin.Equals(""))
            {
                error++;
                lblOriginError.Text = "Origin can't be blank";
            }
            else
            {
                lblOriginError.Text = "";
            }
            string Biography = txtBiography.Text;
            if (Biography.Equals(""))
            {
                error++;
                lblBiographyError.Text = "Biography can't be blank";
            }
            else
            {
                lblBiographyError.Text = "";
            }
            if (error == 0)
            {
                string update = "update Author set AuthorName = @AuthorName, BirthDate = @BirthDate, Origin = @Origin, Biography = @Biography where AuthorID = @AuthorID";
                con.Open();
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.Parameters.Add("@AuthorID", SqlDbType.Int);
                cmd.Parameters["@AuthorID"].Value = AuthorID;
                cmd.Parameters.Add("@AuthorName", SqlDbType.NVarChar);
                cmd.Parameters["@AuthorName"].Value = AuthorName;
                cmd.Parameters.Add("@BirthDate", SqlDbType.Date);
                cmd.Parameters["@BirthDate"].Value = BirthDate;
                cmd.Parameters.Add("@Origin", SqlDbType.NVarChar);
                cmd.Parameters["@Origin"].Value = Origin;
                cmd.Parameters.Add("@Biography", SqlDbType.NVarChar);
                cmd.Parameters["@Biography"].Value = Biography;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int error = 0;
            int check;
            string ID = txtID.Text;
            if (ID.Equals(""))
            {
                error++;
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
                string query = "select * from Book_Author where AuthorID = @AuthorID";
                con.Open();
                SqlCommand cmdcheck = new SqlCommand(query, con);
                cmdcheck.Parameters.Add("@AuthorID", SqlDbType.Int);
                cmdcheck.Parameters["@AuthorID"].Value = Convert.ToInt32(ID);
                SqlDataReader reader = cmdcheck.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    MessageBox.Show("you must delete every book author of this author");
                }
                
                con.Close();
            }
            if (error == 0)
            {
                con.Open();
                string query2 = "delete from Author where AuthorID = @AuthorID";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.Add("@AuthorID", SqlDbType.Int);
                cmd2.Parameters["@AuthorID"].Value = txtID.Text;
                cmd2.ExecuteNonQuery();
                MessageBox.Show("deleted successfully");
                con.Close();
                FillData();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            dtpBirthDate.Value = DateTime.Now;
            txtOrigin.Text = "";
            txtBiography.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.ShowDialog();
            this.Dispose();
        }

        private void Author_Load(object sender, EventArgs e)
        {
            dtpBirthDate.MaxDate = DateTime.Now;
            FillData();
        }

        private void dgvAuthor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvAuthor.Rows[e.RowIndex];
            txtID.Text = row.Cells["AuthorID"].Value.ToString();
            txtName.Text = row.Cells["AuthorName"].Value.ToString();
            dtpBirthDate.Text = row.Cells["BirthDate"].Value.ToString();
            txtOrigin.Text = row.Cells["Origin"].Value.ToString();
            txtBiography.Text = row.Cells["Biography"].Value.ToString();
        }
    }
}
