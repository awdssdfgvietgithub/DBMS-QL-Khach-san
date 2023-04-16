using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class DoiMatKhau : Form
    {
        SqlConnection conn = new SqlConnection();
        public DoiMatKhau()
        {
            InitializeComponent();
            string cn = DangNhap.connect.ToString();
            conn = new SqlConnection(cn);
        }

        private void DoiMatKhau_Load(object sender, System.EventArgs e)
        {
            txt_manv.Text = DangNhap.tk.ToString();
        }

        private void btn_huy_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btn_doimk_Click(object sender, System.EventArgs e)
        {
            try
            {
                string ma = txt_manv.Text;
                string mkc = txt_mkc.Text;
                string mkm = txt_mkm.Text;
                conn.Open();
                SqlCommand c = new SqlCommand("exec SuaMatKhau '" + ma + "','" + mkc + "','" + mkm + "'", conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đổi thành công");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại");
            }
        }
    }
}
