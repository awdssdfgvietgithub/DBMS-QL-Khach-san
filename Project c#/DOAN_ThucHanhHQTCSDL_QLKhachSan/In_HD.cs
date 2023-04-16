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

namespace DOAN_ThucHanhHQTCSDL_QLKhachSan
{
    public partial class In_HD : Form
    {
        SqlConnection conn = new SqlConnection();
        public In_HD()
        {
            InitializeComponent();
            string cn = DangNhap.connect.ToString();
            conn = new SqlConnection(cn);
        }
        public void In_HDKH(In_HD f ,string makh)
        {
            HDKH r = new HDKH();
            f.crystalReportViewer1.ReportSource = r;
            r.SetDatabaseLogon(DangNhap.tk.ToString(), DangNhap.mk.ToString(), DangNhap.sv.ToString(), DangNhap.dbn.ToString());
            r.SetParameterValue("@makh", makh);
            r.SetParameterValue("makh", makh);
            f.crystalReportViewer1.Refresh();
            f.ShowDialog();
        }
        private void In_HD_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
