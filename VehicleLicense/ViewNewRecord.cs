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

namespace VehicleLicense
{
    public partial class ViewNewRecord : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-LQ0GH05;Initial Catalog=VehicleLicense;Integrated Security=True");
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        SqlCommand cmd;
        DataTable dt;
        NewLicense active;
        public ViewNewRecord()
        {
            InitializeComponent();
            btnUpdate.Enabled = false;
        }
        public ViewNewRecord(NewLicense nl)
        {
            this.active = nl;
            InitializeComponent();
            btnUpdate.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query1 = "select [ID],[FirstName],[MiddleName],[LastName],[F_HName],[CNIC],[DOB],[POB],[Address],[Category],[IssueDate],[ExpiryDate] from UserRecord";
                cmd = new SqlCommand(query1, con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                con.Close();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnUpdate.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            scb = new SqlCommandBuilder(sda);
            //scb.GetUpdateCommand();
            sda.Update(dt);
            MessageBox.Show("Record Updated Successfully");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            active.Show();
            this.Close();
        }
        #region RetrivalOfPicture
        public System.Drawing.Image ByteArrayToImage(byte[] bArray)
        {
            if (bArray == null)
                return null;
            Image x = (Bitmap)((new ImageConverter()).ConvertFrom(bArray));
            return x;
        }
        public Byte[] Ret_image(string q)
        {
            cmd = new SqlCommand(q, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Byte[] ar = new Byte[1];
            while (reader.Read())
            {
                ar = (Byte[])(reader[0]);
            }
            con.Close();
            return ar;
        }
        #endregion
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            picBoxUserPicture.Image = ByteArrayToImage(Ret_image("Select Picture from UserRecord where ID='" + ID + "'"));
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //private void btnUpdate_Click(object sender, EventArgs e)
        //{

        //}
    }
}
