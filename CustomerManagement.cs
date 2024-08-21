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
    public partial class CustomerManagement : Form
    {
        public SqlConnection con;
        public CustomerManagement()
        {
            InitializeComponent();
            con = new SqlConnection("Server=LAPTOP-CT7N310O\\SQLEXPRESS;Database=Online_Library;Integrated Security = true;");
        }
        public void FillData()
        {
            string query = "select * from Customer";
            DataTable table = new DataTable();
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(table);
            dgvCustomerList.DataSource = table;
            con.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dtpBirthDate.MaxDate = DateTime.Now;
            FillData();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int error = 0;
            int check;
            string CustomerID = txtCustomerID.Text;
            if (CustomerID.Equals(""))
            {
                error++;
                lblIDError.Text = "Id can't be blank";
            }
            else if (!int.TryParse(txtCustomerID.Text, out check))
            {
                error++;
                txtCustomerID.Text = "";
                lblIDError.Text = "invalid ID";
            }
            else
            {
                string query = "select * from customer where CustomerID = @CustomerID";
                con.Open();
                SqlCommand cmdcheck = new SqlCommand(query, con);
                cmdcheck.Parameters.Add("@CustomerID", SqlDbType.Int);
                cmdcheck.Parameters["@CustomerID"].Value = Convert.ToInt32(CustomerID);
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
            string FirstName = txtFirstName.Text;
            if (FirstName.Equals(""))
            {
                error++;
                lblFNameError.Text = "First Name can't be blank";
            }
            else
            {
                lblFNameError.Text = "";
            }    
            string LastName = txtLastName.Text;
            if (LastName.Equals(""))
            {
                error++;
                lblLNameError.Text = "Last Name can't be blank";
            }
            else
            {
                lblLNameError.Text = "";
            }
            string BirthDate = dtpBirthDate.Text;
            if (BirthDate.Equals(""))
            {
                error++;
                lblBirthDateError.Text = "Birth date can't be blank";
            }
            else
            {
                lblBirthDateError.Text = "";
            }
            string BirthPlace = txtBirthPlace.Text;
            if (BirthPlace.Equals(""))
            {
                error++;
                lblBirthPlaceError.Text = "Birth Place can't be blank";
            }
            else
            {
                lblBirthPlaceError.Text = "";
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
            string PhoneNumber = txtPhoneNumber.Text;
            if (PhoneNumber.Equals(""))
            {
                error++;
                lblPhoneNumberError.Text = "Phone number can't be blank";
            }
            else if (!int.TryParse(txtPhoneNumber.Text, out check))
            {
                error++;
                txtPhoneNumber.Text = "";
                lblPhoneNumberError.Text = "invalid phone number";
            }
            else
            {
                lblPhoneNumberError.Text = "";
            }
            string Email = txtEmail.Text;
            if (Email.Equals(""))
            {
                error++;
                lblEmailError.Text = "Email can't be blank";
            }
            else
            {
                lblFNameError.Text = "";
            }
            if (error == 0)
            {
                string insert = "insert into Customer values (@CustomerID,@FirstName," +
                    "@LastName,@BirthDate,@BirthPlace,@Origin,@PhoneNumber,@Email)";
                con.Open();
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.Parameters.Add("@CustomerID",SqlDbType.Int);
                cmd.Parameters["@CustomerID"].Value = CustomerID;
                cmd.Parameters.Add("@Firstname",SqlDbType.NVarChar);
                cmd.Parameters["@Firstname"].Value = FirstName;
                cmd.Parameters.Add("@Lastname",SqlDbType.NVarChar);
                cmd.Parameters["@Lastname"].Value = LastName;
                cmd.Parameters.Add("@Birthdate", SqlDbType.Date);
                cmd.Parameters["@Birthdate"].Value = BirthDate;
                cmd.Parameters.Add("@Birthplace", SqlDbType.NVarChar);
                cmd.Parameters["@Birthplace"].Value = BirthPlace;
                cmd.Parameters.Add("@Origin", SqlDbType.NVarChar);
                cmd.Parameters["@Origin"].Value = Origin;
                cmd.Parameters.Add("@Phonenumber", SqlDbType.Int);
                cmd.Parameters["@Phonenumber"].Value = PhoneNumber;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                cmd.Parameters["@Email"].Value = Email;
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
            /*con.Open();
            SqlCommand cmd = new SqlCommand(insert, con);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result > 0)
            {
                MessageBox.Show("insert successfully");
            }
            else
            {
                MessageBox.Show("mission failed");
            }
            FillData();*/
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int error = 0;
            int check;
            string ID = txtCustomerID.Text;
            if (ID.Equals(""))
            {
                error++;
                lblIDError.Text = "select a ID to Delete";
            }
            else if (!int.TryParse(txtCustomerID.Text, out check))
            {
                error++;
                txtCustomerID.Text = "";
                lblIDError.Text = "invalid ID";
            }
            else
            {
                string query = "select * from Borrow_Form where CustomerID = @CustomerID";
                con.Open();
                SqlCommand cmdcheck = new SqlCommand(query, con);
                cmdcheck.Parameters.Add("@CustomerID", SqlDbType.Int);
                cmdcheck.Parameters["@CustomerID"].Value = Convert.ToInt32(ID);
                SqlDataReader reader = cmdcheck.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    MessageBox.Show("You must delete every borrow attempt of this customer");
                }
                con.Close();
            }
            if (error == 0)
            {
                con.Open();
                string query2 = "delete from customer where CustomerID = @CustomerID";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.Add("@CustomerID", SqlDbType.Int);
                cmd2.Parameters["@CustomerID"].Value = txtCustomerID.Text;
                cmd2.ExecuteNonQuery();
                MessageBox.Show("deleted successfully");
                con.Close();
                FillData();
            }    
        }
        private void ReLoad()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from customer", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "customer");
            dgvCustomerList.DataSource = ds.Tables["customer"].DefaultView;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int error = 0;
            int check;
            string CustomerID = txtCustomerID.Text;
            if (CustomerID.Equals(""))
            {
                error++;
                lblIDError.Text = "Id can't be blank";
            }
            else if(!int.TryParse(txtCustomerID.Text, out check))
            {
                error++;
                txtCustomerID.Text = "";
                lblIDError.Text = "invalid ID";
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
                    lblIDError.Text = "ID doesn't exist";
                }
                else
                {
                    lblIDError.Text = "";
                }
                con.Close();
            }
            string FirstName = txtFirstName.Text;
            if (FirstName.Equals(""))
            {
                error++;
                lblFNameError.Text = "First Name can't be blank";
            }
            else
            {
                lblFNameError.Text = "";
            }
            string LastName = txtLastName.Text;
            if (LastName.Equals(""))
            {
                error++;
                lblLNameError.Text = "Last Name can't be blank";
            }
            else
            {
                lblLNameError.Text = "";
            }
            string BirthDate = dtpBirthDate.Text;
            if (BirthDate.Equals(""))
            {
                error++;
                lblBirthDateError.Text = "Birth date can't be blank";
            }
            else
            {
                lblBirthDateError.Text = "";
            }
            string BirthPlace = txtBirthPlace.Text;
            if (BirthPlace.Equals(""))
            {
                error++;
                lblBirthPlaceError.Text = "Birth Place can't be blank";
            }
            else
            {
                lblBirthPlaceError.Text = "";
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
            string PhoneNumber = txtPhoneNumber.Text;
            if (PhoneNumber.Equals(""))
            {
                error++;
                lblPhoneNumberError.Text = "Phone number can't be blank";
            }
            else if (!int.TryParse(txtPhoneNumber.Text, out check))
            {
                error++;
                txtPhoneNumber.Text = "";
                lblPhoneNumberError.Text = "invalid Phone number";
            }
            else
            {
                lblPhoneNumberError.Text = "";
            }
            string Email = txtEmail.Text;
            if (Email.Equals(""))
            {
                error++;
                lblEmailError.Text = "Email can't be blank";
            }
            else
            {
                lblFNameError.Text = "";
            }
            if (error == 0)
            {
                string update = "update Customer set FirstName = @FirstName, Lastname = @LastName, " +
                    "BirthDate = @BirthDate, BirthPlace = @BirthPlace, Origin = @Origin, " +
                    "PhoneNumber = @PhoneNumber, Email = @Email"
                    + " where CustomerID = @CustomerID";
                con.Open();
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                cmd.Parameters["@CustomerID"].Value = CustomerID;
                cmd.Parameters.Add("@Firstname", SqlDbType.NVarChar);
                cmd.Parameters["@Firstname"].Value = FirstName;
                cmd.Parameters.Add("@Lastname", SqlDbType.NVarChar);
                cmd.Parameters["@Lastname"].Value = LastName;
                cmd.Parameters.Add("@Birthdate", SqlDbType.Date);
                cmd.Parameters["@Birthdate"].Value = BirthDate;
                cmd.Parameters.Add("@Birthplace", SqlDbType.NVarChar);
                cmd.Parameters["@Birthplace"].Value = BirthPlace;
                cmd.Parameters.Add("@Origin", SqlDbType.NVarChar);
                cmd.Parameters["@Origin"].Value = Origin;
                cmd.Parameters.Add("@Phonenumber", SqlDbType.Int);
                cmd.Parameters["@Phonenumber"].Value = PhoneNumber;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                cmd.Parameters["@Email"].Value = Email;
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
        private void dgvCustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomerList.Rows[e.RowIndex];
                txtCustomerID.Text = row.Cells["CustomerID"].Value.ToString();
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["Lastname"].Value.ToString();
                dtpBirthDate.Value = Convert.ToDateTime(row.Cells["BirthDate"].Value);
                txtBirthPlace.Text = row.Cells["BirthPlace"].Value.ToString();
                txtOrigin.Text = row.Cells["Origin"].Value.ToString();
                txtPhoneNumber.Text = row.Cells["PhoneNumber"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCustomerID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            dtpBirthDate.Text = "";
            txtBirthPlace.Text = "";
            txtOrigin.Text = "";
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.ShowDialog();
            this.Dispose();
        }
    }
}
