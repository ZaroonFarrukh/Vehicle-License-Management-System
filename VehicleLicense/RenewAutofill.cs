using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;

namespace VehicleLicense
{
    public partial class RenewAutofill : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-LQ0GH05;Initial Catalog=VehicleLicense;Integrated Security=True");
        SqlCommand cmd;
        public RenewAutofill()
        {
            InitializeComponent();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool loaditems = true;
            DataTable dt = nl.DataNavigationOperations("Select CNIC from UserRecord");
            foreach (DataRow item in dt.Rows)
            {
                if (comboBox1.Text == item[0].ToString())
                {
                    loaditems = true;
                    break;
                }
                else
                {
                    loaditems = false;
                }
            }
            string query = "select * from UserRecord where CNIC='" + comboBox1.Text + "'";
            cmd = new SqlCommand(query, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string fname = reader.GetString(reader.GetOrdinal("FirstName"));
                    string mname = reader.GetString(reader.GetOrdinal("MiddleName"));
                    string lname = reader.GetString(reader.GetOrdinal("LastName"));
                    string f_hname = reader.GetString(reader.GetOrdinal("F_HName"));
                    string address = reader.GetString(reader.GetOrdinal("Address"));
                    txtFirstName.Text = fname;
                    txtMiddleName.Text = mname;
                    txtLastName.Text = lname;
                    txtF_HName.Text = f_hname;
                    txtAddress.Text = address;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        public DataTable DataNavigationOperations(string query)
        {
            try
            {
                cmd = new SqlCommand(query, con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows != null)
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        public string ReturnValueFromDB(string q)
        {
            DataTable dt = DataNavigationOperations(q);
            string Val = "";
            foreach (DataRow item in dt.Rows)
            {
                Val = item[0].ToString();
            }
            return Val;
        }

        public int valueexist(string q)
        {
            con.Close();
            int s;
            con.Open();
            cmd = new SqlCommand(q, con);
            s = (Int32)cmd.ExecuteScalar();
            con.Close();
            return s;
        }
        public int autoID(string query, string tableName)
        {
            string q = "Select count(*) as IsExists from " + tableName;
            int chk = valueexist(q);
            if (chk >= 1)
            {
                int a = Convert.ToInt32(ReturnValueFromDB(query));
                return a + 1;
            }
            else
            {
                return 1;
            }
        }
            NewLicense nl = new NewLicense();
        private void RenewAutofill_Load(object sender, EventArgs e)
        {
            DataTable kk = nl.DataNavigationOperations("Select CNIC from UserRecord");
            foreach (DataRow item in kk.Rows)
            {
                comboBox1.Items.Add(item[0]);
            }
            //int ID = autoID("Select Max(ID) from UserRecord", "UserRecord");
            ////ID = Convert.ToInt32(ReturnValueFromDB("Select Max(ID) from UserRecord"));
            ////ID = ID ++;
            //ID_Label.Text = ID.ToString();
        }
        public bool DataManupulationOperation(string query)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    con.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
            return false;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //DataManupulationOperation("Delete from RenewRecord where ID!='" + ID_Label.Text + "'");
            DataManupulationOperation("update UserRecord set FirstName='" + this.txtFirstName.Text + "',MiddleName='" + this.txtMiddleName.Text + "',LastName='" + this.txtLastName.Text + "',F_HName='" + this.txtF_HName.Text + "',Address='" + this.txtAddress.Text + "' where FirstName='" + this.txtFirstName.Text + "'");
            //DataManupulationOperation("update RenewRecord set FirstName='" + this.txtFirstName.Text + "',MiddleName='" + this.txtMiddleName.Text + "',LastName='" + this.txtLastName.Text + "',F_HName='" + this.txtF_HName.Text + "',Address='" + this.txtAddress.Text + "' where FirstName='" + this.txtFirstName.Text + "'");
            //string query = "update UserRecord set FirstName='" + this.txtFirstName.Text + "',MiddleName='" + this.txtMiddleName.Text + "',LastName='" + this.txtLastName.Text + "',F_HName='" + this.txtF_HName.Text + "',Address='" + this.txtAddress.Text + "' where FirstName='"+this.txtFirstName.Text+"'";
            //string query = "update UserRecord set FirstName='" + this.txtFirstName.Text + "',MiddleName='" + this.txtMiddleName.Text + "',LastName='" + this.txtLastName.Text + "',F_HName='" + this.txtF_HName.Text + "',Address='" + this.txtAddress.Text + "' where FirstName='" + this.txtFirstName.Text + "'";
            //cmd = new SqlCommand(query, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                MessageBox.Show("Updated in Database");
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.ShowDialog();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to exit", "EXIT", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                //Dont do anything.
                //Stay on the same form.
            }
        }
    }
}
