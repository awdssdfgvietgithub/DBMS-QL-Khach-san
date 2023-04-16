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
    public partial class Xuat_HoaDon : Form
    {
        SqlConnection conn = new SqlConnection();
        public Xuat_HoaDon()
        {
            InitializeComponent();
            string cn = DangNhap.connect.ToString();
            conn = new SqlConnection(cn);
        }
        public void load_cbo_nv()
        {
            SqlCommand c = new SqlCommand("select * from NhanVien", conn);
            SqlDataAdapter da = new SqlDataAdapter(c);
            DataSet ds = new DataSet();
            da.Fill(ds, "NHANVIEN");
            cbo_manv.DataSource = ds.Tables["NHANVIEN"];
            cbo_manv.DisplayMember = "MA_NV";
            cbo_manv.ValueMember = "MA_NV";
        }
        public void load_cbo_kh()
        {
            SqlCommand c = new SqlCommand("exec XuatKH", conn);
            SqlDataAdapter da = new SqlDataAdapter(c);
            DataSet ds = new DataSet();
            da.Fill(ds, "KHACHHANG");
            cbo_makh.DataSource = ds.Tables["KHACHHANG"];
            cbo_makh.DisplayMember = "MA_KH";
            cbo_makh.ValueMember = "MA_KH";
        }
        public void load_cbo_p()
        {
            SqlCommand c = new SqlCommand("exec XuatMPT'" + cbo_makh.Text + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(c);
            DataSet ds = new DataSet();
            da.Fill(ds, "PHONG");
            cbo_phong.DataSource = ds.Tables["PHONG"];
            cbo_phong.DisplayMember = "MA_P";
            cbo_phong.ValueMember = "MA_P";
        }
        public void load_database_gridview()
        {
            SqlCommand c = new SqlCommand("exec XuatHoaDon", conn);
            SqlDataAdapter da = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Xuat_HoaDon_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            load_database_gridview();
            load_cbo_nv();
            load_cbo_kh();
            load_cbo_p();
        }
        public bool ktramaHD()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KiemHoaDon";
            cmd.Parameters.AddWithValue("@Mahd", txt_ma.Text);
            cmd.Connection = conn;
            object kq = cmd.ExecuteScalar();
            int code = Convert.ToInt32(kq);
            if (code == 1)
            {
                conn.Close();
                return false;
            }
            else
            {
                conn.Close();
                return true;
            }
        }
        public string ktraThemHD(int so)
        {
            string ma = "HD";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KiemHoaDon";
            cmd.Parameters.AddWithValue("@Mahd", ma + so);
            cmd.Connection = conn;
            object kq = cmd.ExecuteScalar();
            int code = Convert.ToInt32(kq);
            if (code == 1)
            {
                conn.Close();
                return ktraThemHD(so + 1);
            }
            else
            {
                conn.Close();
                return ma + so;
            }
        }

        private void cbo_makh_MouseClick(object sender, MouseEventArgs e)
        {
            load_cbo_p();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                int so = 1;
                //------------------------------------------------------//
                string ma = ktraThemHD(so);
                string manv = cbo_manv.Text;
                string makh = cbo_makh.Text;
                string map = cbo_phong.Text;

                //------------------------------------------------------//
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                //------------------------------------------------------//
                SqlCommand c = new SqlCommand("set dateformat dmy exec ThemHoaDon '" + ma + "',N'" + manv + "','" + makh + "','" + map + "'", conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Thêm hóa đơn thành công");
                load_database_gridview();
                //------------------------------------------------------//
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                //------------------------------------------------------//
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi !!! Hoặc bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (ktramaHD())
                {
                    MessageBox.Show("Không tìm thấy mã hóa đơn");
                }
                else
                {
                    //------------------------------------------------------//
                    string ma;
                    // check txt ma is null
                    if (txt_ma.Text == "")
                    {
                        MessageBox.Show("Chưa nhập mã hóa đơn");
                        return;
                    }
                    else
                    {
                        ma = txt_ma.Text;
                    }

                    //------------------------------------------------------//
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    //------------------------------------------------------//
                    SqlCommand c = new SqlCommand("exec XoaHoaDon '" + ma + "'", conn);
                    c.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công");
                    load_database_gridview();
                    //------------------------------------------------------//
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    //------------------------------------------------------//
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi !!! Hoặc bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }

        private void cbo_phong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ma.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cbo_manv.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbo_makh.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbo_phong.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_ngay.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txt_tong.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec UPD_NG_TONG_HD", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            load_database_gridview();
            conn.Close();
        }
    }
}
