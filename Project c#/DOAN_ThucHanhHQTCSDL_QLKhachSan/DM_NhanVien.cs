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
    public partial class DM_NhanVien : Form
    {
        SqlConnection conn = new SqlConnection();
        public DM_NhanVien()
        {
            InitializeComponent();
            cbo_gioitinh.Items.Add("Nữ");
            cbo_gioitinh.Items.Add("Nam");
            string cn = DangNhap.connect.ToString();
            conn = new SqlConnection(cn);
        }
        public void load_database_gridview()
        {
            try
            {
                SqlCommand c = new SqlCommand("exec XuatNhanVien", conn);
                SqlDataAdapter da = new SqlDataAdapter(c);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("bạn không có quyền xem danh sách thông tin ");

            }
        }
        public void load_cbo_cv()
        {
            SqlCommand c = new SqlCommand("select * from NHOMNGUOIDUNG", conn);
            SqlDataAdapter da = new SqlDataAdapter(c);
            DataSet ds = new DataSet();
            da.Fill(ds, "NHOMNGUOIDUNG");
            cbo_chucvu.DataSource = ds.Tables["NHOMNGUOIDUNG"];
            cbo_chucvu.DisplayMember = "Ten_NHOM";
            cbo_chucvu.ValueMember = "MA_NHOMNGUOIDUNG";
        }
        private void DM_NhanVien_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            load_database_gridview();
            load_cbo_cv();
            if (DangNhap.tk.ToString() == "sa")
                btn_QLquyen.Enabled = true;
            else
                if (ktraMaQL() == true)
                    btn_QLquyen.Enabled = true;
                else
                    btn_QLquyen.Enabled = false;
        }
        public bool ktramaNV()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KiemTraMaNV";
            cmd.Parameters.AddWithValue("@Manv", txt_ma.Text);
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
        public bool ktracccdNV()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KiemTratheoCCCDNV";
            cmd.Parameters.AddWithValue("@Cccd", txt_cccd.Text);
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
        public string ktraThemNV(int so)
        {
            string ma = "NV";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KiemTraMaNV";
            cmd.Parameters.AddWithValue("@Manv", ma + so);
            cmd.Connection = conn;
            object kq = cmd.ExecuteScalar();
            int code = Convert.ToInt32(kq);
            if (code == 1)
            {
                conn.Close();
                return ktraThemNV(so + 1);
            }
            else
            {
                conn.Close();
                return ma + so;
            }
        }
        public bool ktratenNV()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KiemTratheoTenNV";
            cmd.Parameters.AddWithValue("@ten", txt_cccd.Text);
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

        public bool ktraMaQL()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KiemTraMaQL";
            cmd.Parameters.AddWithValue("@ma", DangNhap.tk.ToString());
            cmd.Connection = conn;
            object kq = cmd.ExecuteScalar();
            int code = Convert.ToInt32(kq);
            if (code == 1)
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }

        private void btn_them_Click_1(object sender, EventArgs e)
        {
            if (txt_cccd.Text.Length != 9 && txt_cccd.Text.Length != 12)
            {
                MessageBox.Show("Số CCCD Nhập Chưa Đúng ");
                return;
            }
            try
            {
                if (ktracccdNV())
                {
                    int so = 1;
                    string ma = ktraThemNV(so);
                    string ten = txt_ten.Text;
                    string gitinh = cbo_gioitinh.Text;
                    string diachi = txt_diachi.Text;
                    string cccd = txt_cccd.Text;
                    string chucvu = cbo_chucvu.Text;
                    string mk = txt_mk.Text;
                    conn.Open();
                    SqlCommand c = new SqlCommand("exec ThemNhanVien '" + ma + "',N'" + ten + "',N'" + gitinh + "',N'" + diachi + "','" + cccd + "',N'" + chucvu + "','" + mk + "'", conn);
                    c.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm nhân viên");
                    load_database_gridview();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Trùng CCCD, vui lòng nhập lại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (ktramaNV())
                {
                    MessageBox.Show("Không tìm thấy mã nhân viên");
                }
                else
                {
                    string ma = txt_ma.Text;
                    conn.Open();
                    SqlCommand c = new SqlCommand("exec XoaNhanVien '" + ma + "'", conn);
                    c.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công");
                    load_database_gridview();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (ktramaNV())
                {
                    MessageBox.Show("Không tìm thấy mã nhân viên");
                }
                else
                {
                    string ma = txt_ma.Text;
                    string ten = txt_ten.Text;
                    string gitinh = cbo_gioitinh.Text;
                    string diachi = txt_diachi.Text;
                    string cccd = txt_cccd.Text;
                    string chucvu = cbo_chucvu.Text;
                    string mk = txt_mk.Text;
                    conn.Open();
                    SqlCommand c = new SqlCommand("exec SuaNhanVien '" + ma + "',N'" + ten + "',N'" + gitinh + "',N'" + diachi + "','" + cccd + "',N'" + chucvu + "'", conn);
                    c.ExecuteNonQuery();
                    MessageBox.Show("Đã sửa thông tin nhân viên");
                    load_database_gridview();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ma.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_ten.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbo_gioitinh.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_diachi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_cccd.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            cbo_chucvu.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btn_doimk_Click(object sender, EventArgs e)
        {
            DoiMatKhau mk = new DoiMatKhau();
            mk.ShowDialog();
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_QLquyen_Click(object sender, EventArgs e)
        {
            QLNhanVien ql = new QLNhanVien();
            ql.ShowDialog();
        }

        private void btn_tracuucccd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ktracccdNV())
                {
                    MessageBox.Show("Không có số CCCD này!");
                }
                else
                {
                    string cccd = txt_cccd.Text;

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    if (txt_cccd.Text == "")
                    {
                        MessageBox.Show("Bạn Chưa Nhập Thông Tin Để Tìm Kiếm");
                    }
                    else
                    {
                        SqlCommand c = new SqlCommand("exec XuatNhanVientucccd '" + cccd + "'", conn);
                        c.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(c);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        MessageBox.Show("Tìm Thành Công ");
                    }
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    } 

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi !!! Hoặc bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
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

        private void btn_ten_Click(object sender, EventArgs e)
        {
            try
            {
                if (ktratenNV())
                {
                    MessageBox.Show("Không có tên nhân viên này!");
                }
                else
                {
                    string ten = txt_ten.Text;

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    if (txt_ten.Text == "")
                    {
                        MessageBox.Show("Bạn Chưa Nhập Thông Tin Để Tìm Kiếm");
                    }
                    else
                    {
                        SqlCommand c = new SqlCommand("exec XuatNVTheoTen N'" + ten + "'", conn);
                        c.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(c);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        MessageBox.Show("Tìm Thành Công ");
                    }
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Lỗi !!! Hoặc bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }

        private void btn_xuatfileexcel_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand c = new SqlCommand(@"execute sp_CONFIGURE 'show advanced options',1
                                            RECONFIGURE with override", conn);
                c.ExecuteNonQuery();
                SqlCommand a = new SqlCommand(@"EXEC master.dbo.sp_configure 'xp_cmdshell', 1
                                            RECONFIGURE WITH OVERRIDE", conn);
                a.ExecuteNonQuery();
                SqlCommand b = new SqlCommand(@"exec xp_cmdshell 'bcp QL_KS_TUAN_1.dbo.NHANVIEN out D:\DanhsachNhanVien.txt -SLAPTOP-IRLS8GIA\SQLEXPRESS -T -c'", conn);
                b.ExecuteNonQuery();
                MessageBox.Show("Xuất file thành công");
                load_database_gridview();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xuất file thất bại");
            }
        }
        

        private void btn_load_Click(object sender, EventArgs e)
        {
            load_database_gridview();
        }

        private void txt_ten_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txt_ten.Text, "^[a-zA-Z ]"))
            {
                e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            }
        }


    }
}
