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
using System.Configuration;

namespace DOAN_ThucHanhHQTCSDL_QLKhachSan
{
    public partial class DM_KhachHang : Form
    {
        SqlConnection conn = new SqlConnection();
        public DM_KhachHang()
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
                SqlCommand c = new SqlCommand("exec XuatKH", conn);
                SqlDataAdapter da = new SqlDataAdapter(c);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }

        public void DM_KhachHang_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            load_database_gridview();
        }
        public bool ktramaKH()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KiemTraMaKH";
            cmd.Parameters.AddWithValue("@Makh", txt_ma.Text);
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
        public string ktraThemKH(int so)
        {
            string ma = "KH";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KiemTraMaKH";
            cmd.Parameters.AddWithValue("@Makh", ma + so);
            cmd.Connection = conn;
            object kq = cmd.ExecuteScalar();
            int code = Convert.ToInt32(kq);
            if (code == 1)
            {
                conn.Close();
                return ktraThemKH(so + 1);
            }
            else
            {
                conn.Close();
                return ma + so;
            }
        }

        public bool ktratenKH()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TEN";
            cmd.Parameters.AddWithValue("@ten", txt_ten.Text);
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

        public bool ktracccd()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CCCD";
            cmd.Parameters.AddWithValue("@cccd", txt_cccd.Text);
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

        public bool ktrasdt()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SDT";
            cmd.Parameters.AddWithValue("@sdt", txt_sdt.Text);
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

        public bool ktramaemail()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "EMAIL";
            cmd.Parameters.AddWithValue("@email", txt_mail.Text);
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
        public void ThemKH()
        {
            int so = 1;
            string ma = ktraThemKH(so);
            string ten = txt_ten.Text;
            string gitinh = cbo_gioitinh.Text;
            string cccd = txt_cccd.Text;
            string mail = txt_mail.Text;
            string sdt = txt_sdt.Text;
            //------------------------------------------------------//
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            //------------------------------------------------------//
            SqlCommand c = new SqlCommand("exec ThemKhachHang '" + ma + "',N'" + ten + "',N'" + gitinh + "','" + cccd + "','" + mail + "','" + sdt + "'", conn);
            c.ExecuteNonQuery();
            MessageBox.Show("Thêm khách hàng thành công");
            load_database_gridview();
            //------------------------------------------------------//
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            //------------------------------------------------------//
        }

        public void btn_them_Click(object sender, EventArgs e)
        {
            if (txt_ten.Text == "" || cbo_gioitinh.Text == "" || txt_cccd.Text == "" || txt_mail.Text == "" || txt_sdt.Text == "")
            {
                MessageBox.Show("Chưa nhập đầy đủ thông tin bắt buộc!!");
                return;
            }

            if (txt_cccd.Text.Length != 9 && txt_cccd.Text.Length != 12)
            {
                MessageBox.Show("Số Căn Cước Công Dân Bạn Nhập Chưa Đúng ");
                return;
            }

            if (txt_sdt.Text.Length != 9 && txt_sdt.Text.Length != 10 && txt_sdt.Text.Length != 11)
            {
                MessageBox.Show("Số Điện Thoại Bạn Nhập Chưa Đúng ");
                return;
            }
            try
            {
                if (ktracccd())
                {
                    if (ktramaemail() == true)
                    {
                        if (ktrasdt() == false)
                        {
                            DialogResult x = MessageBox.Show("Đồng ý", "Số Điện Thoại Đã Có Bạn Có muốn Thêm Không ?", MessageBoxButtons.YesNo);
                            if (x == DialogResult.Yes)
                            {
                                ThemKH();
                            }
                            else if (x == DialogResult.No)
                            {
                                MessageBox.Show("Trùng Số Điện Thoại, Mời Nhập Lại");
                            }
                        }
                        else
                        {
                            ThemKH();
                        }
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Đồng ý ", "Email Đã Có Bạn Có muốn Thêm Không ?", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            ThemKH();
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            MessageBox.Show("Trùng Email, Mời Nhập Lại");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Trùng Căn Cước Công Dân, Mời Nhập Lại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi !!! Hoặc bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }

        public void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (ktramaKH())
                {
                    MessageBox.Show("Không tìm thấy mã khách hàng");
                }
                else
                {
                    string ma = txt_ma.Text;
                    conn.Open();
                    SqlCommand c = new SqlCommand("exec XoaKhachHang '" + ma + "'", conn);
                    c.ExecuteNonQuery();
                    MessageBox.Show("Xóa khách hàng thành công");
                    load_database_gridview();
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
            string ma = txt_ma.Text;
            string ten = txt_ten.Text;
            string gitinh = cbo_gioitinh.Text;
            string cccd = txt_cccd.Text;
            string mail = txt_mail.Text;
            string sdt = txt_sdt.Text;
            try
            {
                if (ktramaKH())
                {
                    MessageBox.Show("Không tìm thấy mã khách hàng");
                }
                else
                {
                    conn.Open();
                    SqlCommand c = new SqlCommand("exec SuaKhachHang '" + ma + "',N'" + ten + "',N'" + gitinh + "','" + cccd + "','" + mail + "','" + sdt + "'", conn);
                    c.ExecuteNonQuery();
                    MessageBox.Show("Sửa thông tin khách hàng thành công");
                    load_database_gridview();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi !!! Hoặc bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            if (ktramaKH())
            {
                MessageBox.Show("Không tìm thấy khách hàng!");
            }
            else
            {
                In_HD f = new In_HD();
                f.In_HDKH(f, txt_ma.Text);
            }

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ma.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_ten.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbo_gioitinh.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_cccd.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_mail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_sdt.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            load_database_gridview();
        }

        private void txt_ten_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!(Char.IsLetter(e.KeyChar) || (e.KeyChar == 8) || Char.IsWhiteSpace(e.KeyChar) || (e.KeyChar >= 48) && (e.KeyChar <= 57)))
            //    e.Handled = true;
        }

        private void txt_cccd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập ký tự số", "Thông báo");
            }
        }

        private void txt_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
               if(!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
               {
                   e.Handled = true;
                   MessageBox.Show("Chỉ được nhập ký tự số", "Thông báo");
               }
        }

        private void btn_SearchTen_Click(object sender, EventArgs e)
        {
            try
            {
                if (ktratenKH())
                {
                    MessageBox.Show("Không có tên khách hàng này!");
                }
                else
                {
                    string ten = txt_ten.Text;
                    //------------------------------------------------------//
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
                        SqlCommand c = new SqlCommand("exec XuatKHTheoTen N'" + ten + "'", conn);
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
                    //------------------------------------------------------//
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi !!! Hoặc bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }
        private void btnSearchSDT_Click(object sender, EventArgs e)
        {
            try
            {
                if (ktrasdt())
                {
                    MessageBox.Show("Không có Số Điện Thoại khách hàng này!");
                }
                else
                {
                    string sdt = txt_sdt.Text;
                    //------------------------------------------------------//
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    if (txt_sdt.Text == "")
                    {
                        MessageBox.Show("Bạn Chưa Nhập Thông Tin Để Tìm Kiếm");
                    }
                    else
                    {
                        SqlCommand c = new SqlCommand("exec XuatKhachHangtuSdt '" + sdt + "'", conn);
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
                    //------------------------------------------------------//
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi !!! Hoặc bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }

        private void btnSearchMa_Click(object sender, EventArgs e)
        {
            try
            {
                if (ktramaKH())
                {
                    MessageBox.Show("Không có Mã khách hàng này!");
                }
                else
                {
                    string ma = txt_ma.Text;
                    //------------------------------------------------------//
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    if (txt_ma.Text == "")
                    {
                        MessageBox.Show("Bạn Chưa Nhập Thông Tin Để Tìm Kiếm");
                    }
                    else
                    {
                        SqlCommand c = new SqlCommand("exec XuatKHtheoma '" + ma + "'", conn);
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
                    //------------------------------------------------------//
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi !!! Hoặc bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }

        private void btn_KH_THUE_PH_Click(object sender, EventArgs e)
        {
            Xuat_KH_Thue_PH frm = new Xuat_KH_Thue_PH();
            frm.Show();
        }

        private void btn_Sohoadon_Click(object sender, EventArgs e)
        {
            Frm_SOHOADON frm1= new Frm_SOHOADON();
            frm1.Show();
        } 

    }
}

