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
    public partial class Xuat_KH_Thue_PH : Form
    {
        SqlConnection conn = new SqlConnection();
        public Xuat_KH_Thue_PH()
        {
            InitializeComponent();
            string cn = DangNhap.connect.ToString();
            conn = new SqlConnection(cn);
        }

        public void load_database_gridview1()
        {
            try
            {
                SqlCommand c1 = new SqlCommand("exec Xuat_TenHK_MAKH_MAP_LOAIP", conn);
                SqlDataAdapter da1 = new SqlDataAdapter(c1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dataGridView2.DataSource = dt1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }

        public bool ktratenKH()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TEN";
            cmd.Parameters.AddWithValue("@ten", txt_TenKH.Text);
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

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string ten = txt_TenKH.Text;
            //try
            //{
                if (txt_TenKH.Text == "")
                {
                    MessageBox.Show("Bạn Chưa Nhập Thông Tin Để Tìm Kiếm");
                }
                if (ktratenKH()==false)
                {
                    //------------------------------------------------------//
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlCommand c = new SqlCommand("exec IN_KH_THUE_PH N'" + ten + "'", conn);
                    c.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(c);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    MessageBox.Show("Tìm Thành Công ");
                    dataGridView2.DataSource = dt;
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    //------------------------------------------------------//
                }
                else
                {
                    MessageBox.Show("Không có  khách hàng này!");
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi !!! Hoặc bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            //}
        }

        private void Xuat_KH_Thue_PH_Load(object sender, EventArgs e)
        {
            dataGridView2.ReadOnly = true;
            load_database_gridview1();
        }

        private void btn_loadDGV_Click(object sender, EventArgs e)
        {
            load_database_gridview1();
        }
    }
}
