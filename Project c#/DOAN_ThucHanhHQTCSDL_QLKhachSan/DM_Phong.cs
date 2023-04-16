using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN_ThucHanhHQTCSDL_QLKhachSan
{
    public partial class DM_Phong : Form
    {
        SqlConnection conn = new SqlConnection();

        public DM_Phong()
        {
            InitializeComponent();
            string cn = DangNhap.connect.ToString();
            conn = new SqlConnection(cn);
        }

        //public void load_theo_loai(string a)
        //{
        //    SqlCommand c = new SqlCommand("exec XuatPhong2 N'" + a + "'", conn);
        //    SqlDataAdapter da = new SqlDataAdapter(c);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    dataGridView1.DataSource = dt;
        //}

        public void load_cbo_nv()
        {
            SqlCommand c = new SqlCommand("exec XuatMaNV", conn);
            SqlDataAdapter da = new SqlDataAdapter(c);
            DataSet ds = new DataSet();
            da.Fill(ds, "NHANVIEN");
            cbo_mnv.DataSource = ds.Tables["NHANVIEN"];
            cbo_mnv.DisplayMember = "HOTEN_NV";
            cbo_mnv.ValueMember = "MA_NV";
        }

        public void load_cbo_phong()
        {
            SqlCommand c = new SqlCommand("exec XuatLoaiPhong", conn);
            SqlDataAdapter da = new SqlDataAdapter(c);
            DataSet ds = new DataSet();
            da.Fill(ds, "PHONG");
            cbo_loaiphong.DataSource = ds.Tables["PHONG"];
            cbo_loaiphong.DisplayMember = "loaiphong";
            cbo_loaiphong.ValueMember = "loaiphong";
        }

        public void load_cbo_tt()
        {
            cbo_tinhtrang.Items.Add("Còn trống");
            cbo_tinhtrang.Items.Add("Đã được đặt");
        }

        public void load_cbo_tim()
        {
            cboTim.Items.Add("Khách hàng có số ngày ở cao nhất");
            cboTim.Items.Add("Khách hàng chưa thuê phòng");
            cboTim.Items.Add("Khách hàng đã đặt phòng");
        }

        public void load_database_gridview()
        {
            try
            {
                SqlCommand c = new SqlCommand("exec XuatPhong", conn);
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

        private void DM_Phong_Load(object sender, EventArgs e)
        {
            txt_ma.Enabled = false;
            dataGridView1.ReadOnly = true;
            load_cbo_tim();
            load_cbo_phong();
            load_cbo_nv();
            load_cbo_tt();
            load_database_gridview();
        }

        public bool ktramaP()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KiemPhong";
            cmd.Parameters.AddWithValue("@Map", txt_ma.Text);
            cmd.Connection = conn;
            object kq = cmd.ExecuteScalar();
            int code = Convert.ToInt32(kq);
            if (code == 1)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                return true;
            }
            else
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                return false;
            }
        }
        public string ktraThemPH(int so)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string ma = "PH";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KiemPhong";
            cmd.Parameters.AddWithValue("@Map", ma + so);
            cmd.Connection = conn;
            object kq = cmd.ExecuteScalar();
            int code = Convert.ToInt32(kq);
            if (code == 0)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                return ktraThemPH(so + 1);
            }
            else
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                return ma + so;
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (ktramaP())
                    MessageBox.Show("Mã phòng không để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    string ma = txt_ma.Text;
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    SqlCommand c = new SqlCommand("exec XoaPhong '" + ma + "'", conn);
                    c.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công");
                    load_database_gridview();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống !!! Hoặc bạn không có quyền này, hãy liên hệ quản lý để biết thêm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_gia.Text == "")
                    MessageBox.Show("Giá phòng không để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    if (txt_gia.Text.All(Char.IsNumber) == false)
                        MessageBox.Show("Giá phòng sai định dạng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        int so = 1;
                        string ma, manv, loai, ten;
                        string gia;
                        string tt = cbo_tinhtrang.Text;
                        ma = ktraThemPH(so);
                        ten = txt_ten.Text.Trim();
                        manv = cbo_mnv.SelectedValue.ToString().Trim();
                        gia = txt_gia.Text.Trim();
                        loai = cbo_loaiphong.Text.Trim();

                        if (conn.State == ConnectionState.Closed)
                            conn.Open();
                        SqlCommand cmd1 = new SqlCommand("SELECT [dbo].[CheckAllForInsert]('" + ma + "',N'" + ten + "','" + manv + "',N'" + loai + "'," + gia + ",N'" + tt + "')", conn);
                        cmd1.Connection = conn;

                        var result = cmd1.ExecuteScalar();
                        int i = cmd1.ExecuteNonQuery();
                        if (Convert.ToString(result) != "OK")
                            MessageBox.Show(Convert.ToString(result), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            if (string.IsNullOrEmpty(cbo_tinhtrang.Text))
                            {
                                SqlCommand c = new SqlCommand("exec ThemPhong2 '" + ma.ToUpper() + "',N'" + ten.ToUpper() + "','" + manv.ToUpper() + "',N'" + loai + "'," + gia + "", conn);
                                c.ExecuteNonQuery();
                                MessageBox.Show("Thêm thành công");
                            }
                            else
                            {
                                SqlCommand c = new SqlCommand("exec ThemPhong1 '" + ma.ToUpper() + "',N'" + ten.ToUpper() + "','" + manv.ToUpper() + "',N'" + loai + "'," + gia + ",N'" + tt + "'", conn);
                                c.ExecuteNonQuery();
                                MessageBox.Show("Thêm thành công");
                            }
                            load_database_gridview();
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống !!! Hoặc bạn không có quyền này, hãy liên hệ quản lý để biết thêm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_gia.Text == "")
                    MessageBox.Show("Giá phòng không để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    if (txt_gia.Text.All(Char.IsNumber) == false)
                        MessageBox.Show("Giá phòng sai định dạng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();
                        string ma, manv, loai, ten;
                        string gia;
                        string tt = cbo_tinhtrang.Text;
                        ma = txt_ma.Text.Trim();
                        ten = txt_ten.Text.Trim();
                        manv = cbo_mnv.Text.Trim();
                        gia = txt_gia.Text.Trim();
                        loai = cbo_loaiphong.Text.Trim();

                        SqlCommand cmd1 = new SqlCommand("SELECT [dbo].[CheckAllForUpdate]('" + ma + "',N'" + ten + "','" + manv + "',N'" + loai + "'," + gia + ",N'" + tt + "')", conn);
                        cmd1.Connection = conn;

                        var result = cmd1.ExecuteScalar();
                        int i = cmd1.ExecuteNonQuery();
                        if (Convert.ToString(result) != "OK")
                            MessageBox.Show(Convert.ToString(result), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            if (string.IsNullOrEmpty(cbo_tinhtrang.Text))
                            {
                                SqlCommand c = new SqlCommand("exec SuaPhong2 '" + ma + "',N'" + ten + "','" + manv + "',N'" + loai + "'," + gia + "", conn);
                                c.ExecuteNonQuery();
                                MessageBox.Show("Sửa thành công");
                            }
                            else
                            {
                                SqlCommand c = new SqlCommand("exec SuaPhong1 '" + ma + "',N'" + ten + "','" + manv + "',N'" + loai + "'," + gia + ",N'" + tt + "'", conn);
                                c.ExecuteNonQuery();
                                MessageBox.Show("Sửa thành công");
                            }
                            load_database_gridview();
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống !!! Hoặc bạn không có quyền này, hãy liên hệ quản lý để biết thêm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        //private void cbo_loaiphong_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    load_theo_loai(cbo_loaiphong.Text);
        //}
        public void load_database_gridview_MaxSoNgayO()
        {
            if (txt_ma.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("exec CheckMaxDate '" + txt_ma.Text + "'", conn);
                c.Parameters.Add("@map", txt_ma.Text);
                SqlDataAdapter da = new SqlDataAdapter(c);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        public void load_database_gridview_TimKiem_KH_ChuaThuePhong()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand c = new SqlCommand("exec CheckKHChuaThue", conn);
            SqlDataAdapter da = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        public void load_database_gridview_TimKiem_KH_THUE_PHONG()
        {
            try
            {
                if (txt_ma.Text == "")
                {
                    MessageBox.Show("Mã phòng chưa nhập");
                }
                else
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    // check phong do hien tai co khach hang dat thue khong
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "KiemTra_KH_Thue";
                    cmd.Parameters.AddWithValue("@map", txt_ma.Text);
                    cmd.Connection = conn;
                    object kq = cmd.ExecuteScalar();
                    int code = Convert.ToInt32(kq);
                    if (code == 1)
                    {
                        // load datagridview theo ma phong
                        string map = txt_ma.Text;
                        SqlCommand c = new SqlCommand("exec TimKiem_KH_THUE_PHONG '" + map + "'", conn);
                        SqlDataAdapter da = new SqlDataAdapter(c);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView2.DataSource = dt;

                        // Tra ve so luong khach hang dang thue theo ma phong
                        SqlCommand cmd1 = new SqlCommand("SELECT dbo.TinhSoLuongKHThuePhong('" + map + "')", conn);
                        cmd1.Connection = conn;
                        var result = cmd1.ExecuteScalar();
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }
                        int i = cmd1.ExecuteNonQuery();
                        MessageBox.Show("Có " + Convert.ToString(result) + " khách hàng đặt phòng này");
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Phòng chưa có khách hàng nào đặt thuê");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi !!! Hoặc bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboTim.Text == "Khách hàng có số ngày ở cao nhất")
            {
                load_database_gridview_MaxSoNgayO();
            }
            else if (cboTim.Text == "Khách hàng chưa thuê phòng")
            {
                load_database_gridview_TimKiem_KH_ChuaThuePhong();
            }
            else if (cboTim.Text == "Khách hàng đã đặt phòng")
            {
                load_database_gridview_TimKiem_KH_THUE_PHONG();
            }
        }

        private void btnCapNhatTT_Click_1(object sender, EventArgs e)
        {
            try
            {
                // update + dem so luong phong con trong
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Update_Tinh_Trang";
                cmd.Parameters.Add("@count", SqlDbType.Int);
                cmd.Parameters["@count"].Direction = ParameterDirection.Output;

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                int o = cmd.ExecuteNonQuery();
                MessageBox.Show("Có " + Convert.ToString(cmd.Parameters["@count"].Value) + " phòng còn trống");
                load_database_gridview();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi !!! Hoặc bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btn_dong_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbo_loaiphong_TextChanged(object sender, EventArgs e)
        {
            load_database_gridview();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txt_ma.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txt_ten.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                string ten = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                SqlCommand cmd = new SqlCommand("SELECT dbo.LayMaNV(N'" + ten + "')", conn);
                cmd.Connection = conn;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                var result = cmd.ExecuteScalar();
                int i = cmd.ExecuteNonQuery();
                cbo_mnv.Text = Convert.ToString(result);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                cbo_loaiphong.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txt_gia.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                cbo_tinhtrang.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void cbo_mnv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

