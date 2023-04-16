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
    public partial class QLNhanVien : Form
    {
        SqlConnection conn = new SqlConnection();
        public QLNhanVien()
        {
            InitializeComponent();
            cbo_table.Items.Add("KHACHHANG");
            cbo_table.Items.Add("NHANVIEN");
            cbo_table.Items.Add("PHONG");
            cbo_table.Items.Add("THUE");
            cbo_table.Items.Add("HOADON");
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
        public void load_cbo_cv()
        {
            SqlCommand c = new SqlCommand("select * from NHOMNGUOIDUNG", conn);
            SqlDataAdapter da = new SqlDataAdapter(c);
            DataSet ds = new DataSet();
            da.Fill(ds, "NHOMNGUOIDUNG");
            cbo_nhomquyen.DataSource = ds.Tables["NHOMNGUOIDUNG"];
            cbo_nhomquyen.DisplayMember = "Ten_NHOM";
            cbo_nhomquyen.ValueMember = "MA_NHOMNGUOIDUNG";
        }
        private void btn_xemHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[XuatHoaDon] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 
            }
            catch(Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_OxemHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[XuatHoaDon] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_themHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[ThemHoaDon] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_OthemHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[ThemHoaDon] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_xoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[XoaHoaDon] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_OxoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[XoaHoaDon] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_xemP_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[XuatPhong] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_OxemP_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[XuatPhong] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_themP_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[ThemPhong1] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_OthemP_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[ThemPhong1] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_xoaP_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[XoaPhong] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_OxoaP_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[XoaPhong] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_suaP_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[SuaPhong] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_OsuaP_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[SuaPhong] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_xemNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[XuatNhanVien] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_OxemNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[XuatNhanVien] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_themNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[ThemNhanVien] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_OthemNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[ThemNhanVien] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_xoaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[XoaNhanVien] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_OxoaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[XoaNhanVien] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_suaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[SuaNhanVien] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_OsuaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[SuaNhanVien] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_xemT_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[Xuat_ThongtinThue] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_OxemT_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[Xuat_ThongtinThue] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_themT_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[ThemThuePhong] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_OthemT_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[ThemThuePhong] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_xoaT_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[XoaThue] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_OxoaT_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[XoaThue] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_suaT_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[SuaThuePhong] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_OsuaT_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[SuaThuePhong] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_xemKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[XuatKH] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_OxemKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[XuatKH] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_themKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[ThemKhachHang] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_OthemKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[ThemKhachHang] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_xoaKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[XoaKhachHang] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_OxoaKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[XoaKhachHang] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_suaKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[SuaKhachHang] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_OsuaKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[SuaKhachHang] TO " + cbo_manv.Text, conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void QLNhanVien_Load(object sender, EventArgs e)
        {
            load_cbo_nv();
            load_cbo_cv();
        }

        private void btn_ThangChuc_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string nhomQ = "";
                if (cbo_nhomquyen.SelectedValue.ToString() == "NV")
                    nhomQ = "NhanVien";
                if (cbo_nhomquyen.SelectedValue.ToString() == "QL")
                    nhomQ = "QuanLy";
                SqlCommand a = new SqlCommand("exec ThemNQuyen '" + cbo_manv.Text + "', '" + nhomQ + "'", conn);
                a.ExecuteNonQuery();
                MessageBox.Show("Đã thêm vào nhóm quyền");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_GiangChuc_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string nhomQ = "";
                if (cbo_nhomquyen.SelectedValue.ToString() == "NV")
                    nhomQ = "NhanVien";
                if (cbo_nhomquyen.SelectedValue.ToString() == "QL")
                    nhomQ = "QuanLy";
                SqlCommand a = new SqlCommand("exec thuhoiThuHoiNQuyen '" + cbo_manv.Text + "', '" + nhomQ + "'", conn);
                a.ExecuteNonQuery();
                MessageBox.Show("Đã thu hồi khỏi nhóm quyền");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbo_table.SelectedItem.ToString() == "NHANVIEN")
            {
                if (ck_xem.Checked == true)
                    btn_xemNV_Click(sender, e);
                else
                    btn_OxemNV_Click(sender, e);
                if (ck_them.Checked == true)
                    btn_themNV_Click(sender, e);
                else
                    btn_OthemNV_Click(sender, e);
                if (ck_xoa.Checked == true)
                    btn_xoaNV_Click(sender, e);
                else
                    btn_OxoaNV_Click(sender, e);
                if (ck_sua.Checked == true)
                    btn_suaNV_Click(sender, e);
                else
                    btn_OsuaNV_Click(sender, e);
            }
            if (cbo_table.SelectedItem.ToString() == "KHACHHANG")
            {
                if (ck_xem.Checked == true)
                    btn_xemKH_Click(sender, e);
                else
                    btn_OxemKH_Click(sender, e);
                if (ck_them.Checked == true)
                    btn_themKH_Click(sender, e);
                else
                    btn_OthemKH_Click(sender, e);
                if (ck_xoa.Checked == true)
                    btn_xoaKH_Click(sender, e);
                else
                    btn_OxoaKH_Click(sender, e);
                if (ck_sua.Checked == true)
                    btn_suaKH_Click(sender, e);
                else
                    btn_OsuaKH_Click(sender, e);
            }
            if (cbo_table.SelectedItem.ToString() == "PHONG")
            {
                if (ck_xem.Checked == true)
                    btn_xemP_Click(sender, e);
                else
                    btn_OxemP_Click(sender, e);
                if (ck_them.Checked == true)
                    btn_themP_Click(sender, e);
                else
                    btn_OthemP_Click(sender, e);
                if (ck_xoa.Checked == true)
                    btn_xoaP_Click(sender, e);
                else
                    btn_OxoaP_Click(sender, e);
                if (ck_sua.Checked == true)
                    btn_suaP_Click(sender, e);
                else
                    btn_OsuaP_Click(sender, e);
            }
            if (cbo_table.SelectedItem.ToString() == "THUE")
            {
                if (ck_xem.Checked == true)
                    btn_xemT_Click(sender, e);
                else
                    btn_OxemT_Click(sender, e);
                if (ck_them.Checked == true)
                    btn_themT_Click(sender, e);
                else
                    btn_OthemT_Click(sender, e);
                if (ck_xoa.Checked == true)
                    btn_xoaT_Click(sender, e);
                else
                    btn_OxoaT_Click(sender, e);
                if (ck_sua.Checked == true)
                    btn_suaT_Click(sender, e);
                else
                    btn_OsuaT_Click(sender, e);
            }
            if (cbo_table.SelectedItem.ToString() == "HOADON")
            {
                if (ck_xem.Checked == true)
                    btn_xemHD_Click(sender, e);
                else
                    btn_OxemHD_Click(sender, e);
                if (ck_them.Checked == true)
                    btn_themHD_Click(sender, e);
                else
                    btn_OthemHD_Click(sender, e);
                if (ck_xoa.Checked == true)
                    btn_xoaHD_Click(sender, e);
                else
                    btn_OxoaHD_Click(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand a = new SqlCommand("exec ThemNQ '"+txt_manq.Text+"', N'"+txt_tennq.Text+"'", conn);
                a.ExecuteNonQuery();
                MessageBox.Show("Đã thêm nhóm quyền mới ");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand a = new SqlCommand("exec XoaNQ '" + txt_manq.Text + "'", conn);
                a.ExecuteNonQuery();
                MessageBox.Show("Đã xóa nhóm quyền");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        //quyền của nhóm quyền
        private void btn2_xemHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[XuatHoaDon] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_OxemHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[XuatHoaDon] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_themHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[ThemHoaDon] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_OthemHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[ThemHoaDon] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_xoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[XoaHoaDon] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_OxoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[XoaHoaDon] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_xemP_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[XuatPhong] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_OxemP_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[XuatPhong] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_themP_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[ThemPhong1] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_OthemP_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[ThemPhong1] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_xoaP_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[XoaPhong] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_OxoaP_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[XoaPhong] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_suaP_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[SuaPhong] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_OsuaP_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[SuaPhong] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_xemNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[XuatNhanVien] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_OxemNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[XuatNhanVien] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_themNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[ThemNhanVien] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_OthemNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[ThemNhanVien] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_xoaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[XoaNhanVien] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_OxoaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[XoaNhanVien] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_suaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[SuaNhanVien] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_OsuaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[SuaNhanVien] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_xemT_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[Xuat_ThongtinThue] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_OxemT_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[Xuat_ThongtinThue] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_themT_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[ThemThuePhong] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_OthemT_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[ThemThuePhong] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_xoaT_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[XoaThue] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_OxoaT_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[XoaThue] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_suaT_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[SuaThuePhong] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_OsuaT_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[SuaThuePhong] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_xemKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[XuatKH] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_OxemKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[XuatKH] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_themKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[ThemKhachHang] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_OthemKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[ThemKhachHang] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_xoaKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[XoaKhachHang] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_OxoaKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[XoaKhachHang] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_suaKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("grant EXECUTE ON [dbo].[SuaKhachHang] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cho phép");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }

        private void btn2_OsuaKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand c = new SqlCommand("deny EXECUTE ON [dbo].[SuaKhachHang] TO " + cbo_nhomquyen.SelectedValue.ToString(), conn);
                c.ExecuteNonQuery();
                MessageBox.Show("Đã cấm");
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi !!!");
            }
        }





        private void button4_Click(object sender, EventArgs e)
        {
            if (cbo_table.SelectedItem.ToString() == "NHANVIEN")
            {
                if (ck_xem.Checked == true)
                    btn2_xemNV_Click(sender, e);
                else
                    btn2_OxemNV_Click(sender, e);
                if (ck_them.Checked == true)
                    btn2_themNV_Click(sender, e);
                else
                    btn2_OthemNV_Click(sender, e);
                if (ck_xoa.Checked == true)
                    btn2_xoaNV_Click(sender, e);
                else
                    btn2_OxoaNV_Click(sender, e);
                if (ck_sua.Checked == true)
                    btn2_suaNV_Click(sender, e);
                else
                    btn2_OsuaNV_Click(sender, e);
            }
            if (cbo_table.SelectedItem.ToString() == "KHACHHANG")
            {
                if (ck_xem.Checked == true)
                    btn2_xemKH_Click(sender, e);
                else
                    btn2_OxemKH_Click(sender, e);
                if (ck_them.Checked == true)
                    btn2_themKH_Click(sender, e);
                else
                    btn2_OthemKH_Click(sender, e);
                if (ck_xoa.Checked == true)
                    btn2_xoaKH_Click(sender, e);
                else
                    btn2_OxoaKH_Click(sender, e);
                if (ck_sua.Checked == true)
                    btn2_suaKH_Click(sender, e);
                else
                    btn2_OsuaKH_Click(sender, e);
            }
            if (cbo_table.SelectedItem.ToString() == "PHONG")
            {
                if (ck_xem.Checked == true)
                    btn2_xemP_Click(sender, e);
                else
                    btn2_OxemP_Click(sender, e);
                if (ck_them.Checked == true)
                    btn2_themP_Click(sender, e);
                else
                    btn2_OthemP_Click(sender, e);
                if (ck_xoa.Checked == true)
                    btn2_xoaP_Click(sender, e);
                else
                    btn2_OxoaP_Click(sender, e);
                if (ck_sua.Checked == true)
                    btn2_suaP_Click(sender, e);
                else
                    btn2_OsuaP_Click(sender, e);
            }
            if (cbo_table.SelectedItem.ToString() == "THUE")
            {
                if (ck_xem.Checked == true)
                    btn2_xemT_Click(sender, e);
                else
                    btn2_OxemT_Click(sender, e);
                if (ck_them.Checked == true)
                    btn2_themT_Click(sender, e);
                else
                    btn2_OthemT_Click(sender, e);
                if (ck_xoa.Checked == true)
                    btn2_xoaT_Click(sender, e);
                else
                    btn2_OxoaT_Click(sender, e);
                if (ck_sua.Checked == true)
                    btn2_suaT_Click(sender, e);
                else
                    btn2_OsuaT_Click(sender, e);
            }
            if (cbo_table.SelectedItem.ToString() == "HOADON")
            {
                if (ck_xem.Checked == true)
                    btn2_xemHD_Click(sender, e);
                else
                    btn2_OxemHD_Click(sender, e);
                if (ck_them.Checked == true)
                    btn2_themHD_Click(sender, e);
                else
                    btn2_OthemHD_Click(sender, e);
                if (ck_xoa.Checked == true)
                    btn2_xoaHD_Click(sender, e);
                else
                    btn2_OxoaHD_Click(sender, e);
            }
        }
    }
}
