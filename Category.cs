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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Online_Library_Test
{
    public partial class Category : Form
    {
        public SqlConnection con;
        public Category()
        {
            InitializeComponent();
            con = new SqlConnection("Server=LAPTOP-CT7N310O\\SQLEXPRESS;Database=Online_Library;Integrated Security = true;");
        }
        public void FillData()
        {
            string query = "select * from Category";
            DataTable table = new DataTable();
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(table);
            dgvCategory.DataSource = table;
            con.Close();
        }
        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int error = 0;
            int check;
            string CategoryID = txtID.Text;
            if (CategoryID.Equals(""))
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
                string query = "select * from Category where CategoryID = @CategoryID";
                con.Open();
                SqlCommand cmdcheck = new SqlCommand(query, con);
                cmdcheck.Parameters.Add("@CategoryID", SqlDbType.Int);
                cmdcheck.Parameters["@CategoryID"].Value = Convert.ToInt32(CategoryID);
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
            string CategoryName = txtName.Text;
            if (CategoryName.Equals(""))
            {
                error++;
                lblNameError.Text = "Category Name can't be blank";
            }
            else
            {
                lblNameError.Text = "";
            }
            string CategoryDesc = txtDescription.Text;
            if (CategoryDesc.Equals(""))
            {
                error++;
                lblDescriptionError.Text = "Category Description can't be blank";
            }
            else
            {
                lblDescriptionError.Text = "";
            }
            if (error == 0)
            {
                string insert = "insert into Category values (@CategoryID,@CategoryName,@CategoryDesc)";
                con.Open();
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int);
                cmd.Parameters["@BookID"].Value = CategoryID;
                cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar);
                cmd.Parameters["@CategoryName"].Value = CategoryName;
                cmd.Parameters.Add("@CategoryDesc", SqlDbType.NVarChar);
                cmd.Parameters["@CategoryDesc"].Value = CategoryDesc;
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
            string CategoryID = txtID.Text;
            if (CategoryID.Equals(""))
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
                string query = "select * from Category where CategoryID = @CategoryID";
                con.Open();
                SqlCommand cmdcheck = new SqlCommand(query, con);
                cmdcheck.Parameters.Add("@CategoryID", SqlDbType.Int);
                cmdcheck.Parameters["@CategoryID"].Value = Convert.ToInt32(CategoryID);
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
            string CategoryName = txtName.Text;
            if (CategoryName.Equals(""))
            {
                error++;
                lblNameError.Text = "Category Name can't be blank";
            }
            else
            {
                lblNameError.Text = "";
            }
            string CategoryDesc = txtDescription.Text;
            if (CategoryDesc.Equals(""))
            {
                error++;
                lblDescriptionError.Text = "Category Description can't be blank";
            }
            else
            {
                lblDescriptionError.Text = "";
            }
            if (error == 0)
            {
                string update = "update Category set CategoryName = @CategoryName, CategoryDesc = @CategoryDesc where CategoryID = @CategoryID";
                con.Open();
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int);
                cmd.Parameters["@BookID"].Value = CategoryID;
                cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar);
                cmd.Parameters["@CategoryName"].Value = CategoryName;
                cmd.Parameters.Add("@CategoryDesc", SqlDbType.NVarChar);
                cmd.Parameters["@CategoryDesc"].Value = CategoryDesc;
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
                string query = "select * from Book_Category where CategoryID = @CategoryID";
                con.Open();
                SqlCommand cmdcheck = new SqlCommand(query, con);
                cmdcheck.Parameters.Add("@CategoryID", SqlDbType.Int);
                cmdcheck.Parameters["@CategoryID"].Value = Convert.ToInt32(ID);
                SqlDataReader reader = cmdcheck.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    MessageBox.Show("you must delete every book category of this category");
                }
                con.Close();
            }
            if (error == 0)
            {
                con.Open();
                string query2 = "delete from Category where CategoryID = @CategoryID";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.Add("@CategoryID", SqlDbType.Int);
                cmd2.Parameters["@CategoryID"].Value = txtID.Text;
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
            txtDescription.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.ShowDialog();
            this.Dispose();
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvCategory.Rows[e.RowIndex];
            txtID.Text = row.Cells["CategoryID"].Value.ToString();
            txtName.Text = row.Cells["CategoryName"].Value.ToString();
            txtDescription.Text = row.Cells["CategoryDesc"].Value.ToString();
        }

        private void Category_Load(object sender, EventArgs e)
        {
            FillData();
        }
    }
}
