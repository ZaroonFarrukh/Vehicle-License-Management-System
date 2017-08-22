using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleLicense
{
    public partial class Form1 : Form
    {
        NewLicense nl = new NewLicense();
        RenewAutofill rnl = new RenewAutofill();

        public Form1()
        {
            InitializeComponent();
            //btnProceed.Enabled = false;
        }
        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (rbNewLicense.Checked == false && rbRenewLicense.Checked == false)
            {
                MessageBox.Show("Please Select an option");
            }
            if (rbNewLicense.Checked == true)
            {
                btnProceed.Enabled = true;
                if (nl.IsDisposed == true)
                {
                    nl = new NewLicense();
                }
                nl.Show();
                this.Hide();
            }

            else if (rbRenewLicense.Checked == true)
            {
                if (rnl.IsDisposed == true)
                {
                    rnl = new RenewAutofill();
                }
                rnl.Show();
                this.Hide();    
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnProceed.Enabled = true;
            rbNewLicense.Checked = false;
            rbRenewLicense.Checked = false;
            //comboBox1.Items.Clear();
            //DataTable kk = nl.DataNavigationOperations("Select CNIC from UserRecord");
            //foreach (DataRow item in kk.Rows)
            //{
            //    comboBox1.Items.Add(item[0]);
            //}
        }

        private void rbNewLicense_CausesValidationChanged(object sender, EventArgs e)
        {
            if (rbNewLicense.Checked == true)
            {
                btnProceed.Enabled = true;
            }
            else
            {
                btnProceed.Enabled = false;
            }
        }

        //private void rbRenewLicense_CausesValidationChanged(object sender, EventArgs e)
        //{
            
        //}

        //private void rbRenewLicense_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rbNewLicense.Checked == true)
        //    {
        //        btnProceed.Enabled = true;
        //    }
        //    else
        //    {
        //        btnProceed.Enabled = false;
        //    }
        //}

        //private void comboBox1_Validating(object sender, CancelEventArgs e)
        //{
        //    bool loaditems = true;
        //    DataTable dt = nl.DataNavigationOperations("Select CNIC from UserRecord");
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (comboBox1.Text == item[0].ToString())
        //        {
        //            loaditems = true;
        //            break;
        //        }
        //        else
        //        {
        //            loaditems = false;
        //        }
        //    }
        //    if (loaditems == true)
        //    {
        //        btnProceed.Enabled = true;
        //    }
        //    else
        //    {
        //        MessageBox.Show("CNIC doesnot exist in the database");
        //    }
        //}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
