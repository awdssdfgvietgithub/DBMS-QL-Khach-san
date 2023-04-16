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
    public partial class FormQuanLy : Form
    {
        public FormQuanLy()
        {
            InitializeComponent();
        }

        private void FormQuanLy_Load(object sender, EventArgs e)
        {
            if (DangNhap.tk.ToString() == "sa")
                btn_hethong.Enabled = true;
            else
                btn_hethong.Enabled = false;
        }
        private Form currentFormChild;
        private void openChild(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }
        private void FormQuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult a = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (a == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            openChild(new DM_KhachHang());
        }

        private void btn_QLNV_Click(object sender, EventArgs e)
        {
            openChild(new DM_NhanVien());
        }

        private void btn_QLPhong_Click(object sender, EventArgs e)
        {
            openChild(new DM_Phong());
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            openChild(new Xuat_HoaDon());
        }

        private void btn_doanhthu_Click(object sender, EventArgs e)
        {
            openChild(new DoanhThu());
        }

        private void btn_thue_Click(object sender, EventArgs e)
        {
            openChild(new Thue());
        }

        private void btn_hethong_Click(object sender, EventArgs e)
        {
            openChild(new HeThong());
        }
    }
}
