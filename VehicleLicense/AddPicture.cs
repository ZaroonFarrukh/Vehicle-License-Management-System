using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormCharpWebCam;
using System.IO;
using System.Data.SqlClient;
using System.Reflection;

namespace VehicleLicense
{
    public partial class AddPicture : Form
    {
        NewLicense active;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-LQ0GH05;Initial Catalog=VehicleLicense;Integrated Security=True");
        public AddPicture(NewLicense nl)
        {
            this.active = nl;
            InitializeComponent();
        }

        WebCam webcam;

        private void bntStart_Click(object sender, EventArgs e)
        {
            webcam.Start();
        }

        private void bntStop_Click(object sender, EventArgs e)
        {
            webcam.Stop();
        }

        private void bntContinue_Click(object sender, EventArgs e)
        {
            webcam.Continue();
        }

        private void bntCapture_Click(object sender, EventArgs e)
        {
            imgCapture.Image = imgCapture.Image;
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            Helper.SaveImageCapture(imgCapture.Image);
        }

        private void AddPicture_Load(object sender, EventArgs e)
        {
            webcam = new WebCam();
            webcam.InitializeWebCam(ref imgCapture);
        }

        public void convertingBinary()
        {
            //string filePath = Server.MapPath(imgCapture.Image);
            string path = Assembly.GetExecutingAssembly().CodeBase;

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);

            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            br.Close();
            fs.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ////convertingBinary();
            //try
            //{
            //    //insert the file into database
            //    con.Open();
            //    string query = "insert into UserRecord (Picture) values ('" + imgCapture.Image + "')";
            //    SqlCommand cmd = new SqlCommand(query, con);
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //    MessageBox.Show("Success");
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            active.getPictureBox(imgCapture);
            active.Show();
            //active.ActiveForm.Show();
            //NewLicense nl = new NewLicense(imgCapture);
            //nl.Show();
            this.Close();
        }

        private void imgCapture_Click(object sender, EventArgs e)
        {

        }

        private void imgVideo_Click(object sender, EventArgs e)
        {

        }
    }
}
