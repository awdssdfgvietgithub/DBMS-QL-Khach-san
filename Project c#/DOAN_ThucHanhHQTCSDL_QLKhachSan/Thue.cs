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
    public partial class Thue : Form
    {
        SqlConnection conn = new SqlConnection();
        public Thue()
        {
            InitializeComponent();
            string cn = DangNhap.connect.ToString();
            conn = new SqlConnection(cn);
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
            SqlCommand c = new SqlCommand("exec XuatTTPhongTrong", conn);
            SqlDataAdapter da = new SqlDataAdapter(c);
            DataSet ds = new DataSet();
            da.Fill(ds, "PHONG");
            cbo_phong.DataSource = ds.Tables["PHONG"];
            cbo_phong.DisplayMember = "MA_P";
            cbo_phong.ValueMember = "MA_P";
        }
        public void load_cbo_p2()
        {
            SqlCommand c = new SqlCommand("exec XuatTTPhongTrong", conn);
            SqlDataAdapter da = new SqlDataAdapter(c);
            DataSet ds = new DataSet();
            da.Fill(ds, "PHONG");
            cbo_mapsua.DataSource = ds.Tables["PHONG"];
            cbo_mapsua.DisplayMember = "MA_P";
            cbo_mapsua.ValueMember = "MA_P";
        }
        public void load_database_gridview()
        {
            try
            {
                SqlCommand c = new SqlCommand("exec Xuat_ThongtinThue", conn);
                SqlDataAdapter da = new SqlDataAdapter(c);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi !!! Hoặc bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }
        private void Thue_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            load_cbo_p();
            load_cbo_p2();
            load_cbo_kh();
            load_database_gridview();
        }
        public bool ktraCCCD()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CCCD";
            cmd.Parameters.AddWithValue("@cccd", txt_cccd.Text);
            cmd.Connection = conn;
            object kq = cmd.ExecuteScalar();
            int code = Convert.ToInt32(kq);
            if (code == 0)
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

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.Parse(txt_ngayden.Text) <= DateTime.Parse(txt_ngaydi.Text))
                {
                    string makh = cbo_makh.Text;
                    string map = cbo_phong.Text;
                    string ngayden = txt_ngayden.Text;
                    string ngaydi = txt_ngaydi.Text;
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    //------------------------------------------------------//
                    SqlCommand c = new SqlCommand("exec ThemThuePhong '" + makh + "',N'" + map + "','" + ngayden + "','" + ngaydi + "'", conn);
                    c.ExecuteNonQuery();
                    MessageBox.Show("Thêm thuê thành công");
                    load_cbo_p();
                    load_cbo_p2();
                    load_database_gridview();
                    //------------------------------------------------------//
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Ngày đến phải trước ngày đi");
                }
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
                string makh = cbo_makh.Text;
                string map = cbo_phong.Text;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                //------------------------------------------------------//
                SqlCommand c = new SqlCommand("exec XoaThue '" + makh + "',N'" + map + "'", conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Xóa thuê thành công");
                load_cbo_p();
                load_cbo_p2();
                load_database_gridview();
                //------------------------------------------------------//
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi !!! Hoặc bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_cccd.Text != "")
                {
                    if (ktraCCCD())
                    {
                        SqlCommand c = new SqlCommand("exec XuatKHtucccd '" + txt_cccd.Text + "'", conn);
                        SqlDataAdapter da = new SqlDataAdapter(c);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView2.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Chưa có thông tin khách hàng");
                        DM_KhachHang f = new DM_KhachHang();
                        f.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Nhập cccd khách hàng");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi !!! Hoặc bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cbo_makh.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cbo_phong.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbo_mapsua.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_ngayden.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_ngaydi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_soPhieuThue_Click(object sender, EventArgs e)
        {
            frm_SoPhieuThue frm = new frm_SoPhieuThue();
            frm.Show();
        }

        private void btn_sua_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.Parse(txt_ngayden.Text) <= DateTime.Parse(txt_ngaydi.Text))
                {
                    string makh = cbo_makh.Text;
                    string map = cbo_phong.Text;
                    string mapm = cbo_mapsua.Text;
                    string ngayden = txt_ngayden.Text;
                    string ngaydi = txt_ngaydi.Text;
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    //------------------------------------------------------//
                    SqlCommand c = new SqlCommand("set dateformat dmy exec SuaThuePhong '" + makh + "',N'" + map + "','" + mapm + "','" + ngayden + "','" + ngaydi + "'", conn);
                    c.ExecuteNonQuery();
                    MessageBox.Show("Sửa thuê thành công");
                    load_cbo_p();
                    load_cbo_p2();
                    load_database_gridview();
                    //------------------------------------------------------//
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Ngày đến phải trước ngày đi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi !!! Hoặc bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand c = new SqlCommand("exec CapNhatTTThue ", conn);
            c.ExecuteNonQuery();
            load_cbo_p();
            load_cbo_p2();
            load_cbo_kh();
            load_database_gridview();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void txt_cccd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập ký tự số", "Thông báo");
            }
        }

    }
}
