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
    public partial class DangNhap : Form
    {
        SqlConnection conn = new SqlConnection();
        public static string connect = "";
        public static string sv = @"DESKTOP-TDAJUK1\VIETMSSQLSERVER";
        public static string tk = "";
        public static string mk = "";
        public static string dbn = "QL_KS_TUAN_1";
        public DangNhap()
        {
            InitializeComponent();
        }
        int dem;
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string stringconn = @"Data Source= " + sv + "; Initial Catalog = " + dbn + "; User ID = " + txt_taikhoan.Text + "; Password = " + txt_matkhau.Text;
            connect = stringconn;
            tk = txt_taikhoan.Text;
            mk = txt_matkhau.Text;
            try
            {
                SqlConnection conn = new SqlConnection(stringconn);
                conn.Open();
                MessageBox.Show("Đăng nhập thành công");
                conn.Close();
                FormQuanLy f = new FormQuanLy();
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại");
            }
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát chương trình không ? ", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void btn_thoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            txt_matkhau.PasswordChar = '*';
        }

        private void chk_show_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_show.Checked)
            {
                txt_matkhau.PasswordChar = (char)0;
            }
            else
            {
                txt_matkhau.PasswordChar = '*';
            }
        }

        private void txt_taikhoan_Leave(object sender, EventArgs e)
        {
            //Control ctr = (Control)sender;
            //if (ctr.Text.Trim().Length == 0)
            //{
            //    DialogResult r;
            //    r = MessageBox.Show("Bạn không được bỏ trống", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            //    if (r == DialogResult.OK)
            //    {
            //        txt_taikhoan.Focus();
            //    }
            //}
        }

        private void txt_matkhau_Leave(object sender, EventArgs e)
        {
            //Control ctr = (Control)sender;
            //if (ctr.Text.Trim().Length == 0)
            //{
            //    DialogResult r;
            //    r = MessageBox.Show("Bạn không được bỏ trống", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            //    if (r == DialogResult.OK)
            //    {
            //        txt_matkhau.Focus();
            //    }
            //}
        }

        private void DangNhap_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát chương trình không ? ", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_matkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_dangnhap_Click(sender, e);
            }
        }

        

    }
}
