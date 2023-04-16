using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN_ThucHanhHQTCSDL_QLKhachSan
{
    public partial class DoanhThu : Form
    {
        public DoanhThu()
        {
            InitializeComponent();
        }

        private void In_Load(object sender, EventArgs e)
        {
          
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txt_ngay_ValueChanged(object sender, EventArgs e)
        {

        }

        //private void btn_in_Click(object sender, EventArgs e)
        //{
        //    MyReport rpt = new MyReport();
        //    crystalReportViewer1.ReportSource = rpt;
        //    rpt.SetDatabaseLogon("sa", "123", @"DESKTOP-TDAJUK1\VIETMSSQLSERVER", "QL_KS_TUAN_1");
        //    crystalReportViewer1.Refresh();
        //    this.crystalReportViewer1.RefreshReport();
        //}

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_in_Click(object sender, EventArgs e)
        {
            MyReport rpt = new MyReport();
            crystalReportViewer1.ReportSource = rpt;
            rpt.SetDatabaseLogon(DangNhap.tk.ToString(), DangNhap.mk.ToString(), DangNhap.sv.ToString(), DangNhap.dbn.ToString());
            rpt.SetParameterValue("ngay", txt_ngay.Text);
            crystalReportViewer1.Refresh();
        }
    }
}
