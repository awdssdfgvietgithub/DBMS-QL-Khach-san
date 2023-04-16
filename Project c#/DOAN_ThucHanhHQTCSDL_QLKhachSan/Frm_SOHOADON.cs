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
    public partial class Frm_SOHOADON : Form
    {
        SqlConnection conn = new SqlConnection();
        public Frm_SOHOADON()
        {
            InitializeComponent();
            string cn = DangNhap.connect.ToString();
            conn = new SqlConnection(cn);
        }
        public void load_database_gridview()
        {
                string ten = txt_TenKH.Text;
                SqlCommand c3 = new SqlCommand("exec InSoHoaDon_KH N'" + ten + "'", conn);
                SqlDataAdapter da3 = new SqlDataAdapter(c3);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                dataGridView.DataSource = dt3;
        }

        public void load_database_gridview1()
        {

                SqlCommand c = new SqlCommand("exec XuatHoaDon", conn);
                SqlDataAdapter da = new SqlDataAdapter(c);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
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

        private void Frm_SOHOADON_Load(object sender, EventArgs e)
        {
            load_database_gridview();
            load_database_gridview1();
        }

        private void btn_loadDGV_Click(object sender, EventArgs e)
        {
            load_database_gridview();
            load_database_gridview1();
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string ten = txt_TenKH.Text;
            try
            {
                SqlCommand c3 = new SqlCommand("exec InSoHoaDon_KH N'" + ten + "'", conn);
                SqlDataAdapter da3 = new SqlDataAdapter(c3);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                dataGridView.DataSource = dt3;

                SqlCommand c4 = new SqlCommand("exec InHoaDon_KH N'" + ten + "'", conn);
                SqlDataAdapter da4 = new SqlDataAdapter(c4);
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                dataGridView1.DataSource = dt4;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }
    }
}
