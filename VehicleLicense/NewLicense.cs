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
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing.Imaging;

namespace VehicleLicense
{
    public partial class NewLicense : Form
    {
        PictureBox currentpic;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-LQ0GH05;Initial Catalog=VehicleLicense;Integrated Security=True");
        public NewLicense()
        {
            InitializeComponent();
            
            //this.SuspendLayout();
            //this.Invalidate();
        }

        public NewLicense(PictureBox pc)
        {
            InitializeComponent();
            this.currentpic = pc;
            pic_Box.Image = pc.Image;
            //this.SuspendLayout();
        }
        //public SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        //image.Save(stream, ImageFormat.Bmp);
        public bool DataManupulationOperationwithPic(string query, PictureBox pc)
        {
            try
            {
                cmd = new SqlCommand(query, con);
                MemoryStream ms = new MemoryStream();
                //pc.Image.Save(ms, pc.Image.RawFormat);
                pc.Image.Save(ms, ImageFormat.Bmp);
                //var image = new System.Drawing.Bitmap(500, 400);
                //var stream = new MemoryStream();
                //pc.Image.Save(ms, ImageFormat.Bmp);
                byte[] Photo = ms.GetBuffer();
                ms.Close();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@picture", Photo);
                con.Open();
                int count = cmd.ExecuteNonQuery();
                //pc.Image = null;
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


        public void datetime()
        {
            string dateInString = DateTime.Now.ToString();
            DOI.Text = dateInString;
            DateTime startDate = DateTime.Parse(dateInString);
            DateTime expiryDate = startDate.AddYears(5);
            DOE.Text = expiryDate.ToString();
        }
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
        private void NewLicense_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            int ID = autoID("Select Max(ID) from UserRecord", "UserRecord");
            //ID = Convert.ToInt32(ReturnValueFromDB("Select Max(ID) from UserRecord"));
            //ID = ID ++;
            ID_Label.Text = ID.ToString();
            datetime();        
            btnView.Enabled = false;
            btnQuiz.Enabled = false;
            
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DataManupulationOperation("Delete from RenewRecord where ID!='"+ID_Label.Text+"'");

            DataManupulationOperationwithPic("insert into UserRecord(ID,FirstName,MiddleName,LastName,F_HName,CNIC,DOB,POB,Address,Category,Picture,IssueDate,ExpiryDate) values ('"+ID_Label.Text+"','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + maskedTextBox1.Text + "','" + Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()) + "','" + textBox6.Text + "','" + textBox7.Text + "','" + comboBox1.Text + "',@picture,'" + DOI.Text + "','" + DOE.Text + "')", pic_Box);
            DataManupulationOperationwithPic("insert into RenewRecord(ID,FirstName,MiddleName,LastName,F_HName,CNIC,DOB,POB,Address,Category,Picture,IssueDate,ExpiryDate) values ('" + ID_Label.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + maskedTextBox1.Text + "','" + Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()) + "','" + textBox6.Text + "','" + textBox7.Text + "','" + comboBox1.Text + "',@picture,'" + DOI.Text + "','" + DOE.Text + "')", pic_Box);
            //try
            //    {
            //        con.Open();
            //        string query = "insert into UserRecord(FirstName,MiddleName,LastName,F_HName,CNIC,DOB,POB,Address,Category,Picture,IssueDate,ExpiryDate) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + maskedTextBox1.Text + "','" + dateTimePicker1.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + comboBox1.Text + "','" + DOI.Text + "','" + DOE.Text + "')";
            //        SqlCommand cmd = new SqlCommand(query, con);
            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //        MessageBox.Show("Registered Successfully!\nClick Quiz button to proceed for the Quiz!\nGOOD LUCK !");
            //    }

            //catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            MessageBox.Show("Record Inserted Successfully");
            //button1.Enabled = true;
            btnView.Enabled = true;
            btnSubmit.Enabled = false;
            btnQuiz.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        //private void btnQuiz_Click(object sender, EventArgs e)
        //{
        //    Quiz qz = new Quiz();
        //    qz.Show();
        //    this.Hide();
        //}

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewNewRecord vnr = new ViewNewRecord(this);
            vnr.Show();
            this.Hide();   
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
                
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only Letters are allowed");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only Letters are allowed");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only Letters are allowed");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32   )
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only Letters are allowed");
            }
        }

        
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
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

        private void btnQuiz_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Quiz qz = new Quiz();
            //qz.Show();
            //qz.BringToFront();
            qz.ShowDialog();
             
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            DateTime bday = DateTime.Parse(dateTimePicker1.Text);
            DateTime today = DateTime.Today;
            int age = today.Year - bday.Year;
            if (age < 18)
            {
                MessageBox.Show("You are not eligible for License yet\nEligibility age is 18");
                Application.Exit();
            }
        }
        //DateTime startDate;
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName.ToString();
                //pictureBox1.ImageLocation = path;
            }
        }

        public void getPictureBox(PictureBox pb)
        {
            this.pic_Box.Image = pb.Image;
        }
        private void btnPicture_Click(object sender, EventArgs e)
        {
            btnPicture.Enabled = false;
            btnSubmit.Enabled = true;
            AddPicture ap = new AddPicture(this);
            ap.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RenewAutofill ll = new RenewAutofill();
            ll.ShowDialog();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only Letters are allowed");
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)||char.IsNumber(e.KeyChar)||char.IsSymbol(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only Letters are allowed");
            }
        }



        //private bool IsValidCNIC(string cnic)
        //{
        //    Regex check = new Regex(@"^[0-9]{5}-[0-9]{7}-[0-9]{1}$");
        //    bool valid = false;
        //    valid = check.IsMatch(cnic);
        //    return valid;
        //}
        //private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //    if (char.IsNumber(e.KeyChar) || e.KeyChar == 8)
        //    {
        //        e.Handled = false;

        //    }
        //    else
        //    {
        //        e.Handled = true;
        //        MessageBox.Show("Only Numbers are allowed");
        //    }
        //}



        //pictureBox1.ImageLocation
    }
}
