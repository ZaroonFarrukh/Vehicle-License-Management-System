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
    public partial class ReportViewer : Form
    {
        public ReportViewer()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            FinalLicense fl = new FinalLicense();
            crystalReportViewer1.ReportSource = fl;
            crystalReportViewer1.Refresh();
            crystalReportViewer1.RefreshReport();
        }
    }
}
