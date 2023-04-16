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
    public partial class SizeDatabase : Form
    {
        SqlConnection conn = new SqlConnection();
        public SizeDatabase()
        {
            InitializeComponent();
            string cn = DangNhap.connect.ToString();
            conn = new SqlConnection(cn);
        }

        public void load_database_gridview()
        {
            try
            {
                SqlCommand c = new SqlCommand("sp_spaceused", conn);
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

        public void load_database_gridview1()
        {
            try
            {
                SqlCommand c = new SqlCommand("SELECT name, size, size * 8/1024 'Size (MB)', max_size FROM sys.database_files;", conn);
                SqlDataAdapter da = new SqlDataAdapter(c);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }

        public void load_database_gridview3()
        {
            try
            {
                SqlCommand c = new SqlCommand("SELECT * FROM SYS.FILEGROUPS", conn);
                SqlDataAdapter da = new SqlDataAdapter(c);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView3.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }

        public void load_database_gridview4()
        {
            try
            {
                SqlCommand c = new SqlCommand("SELECT * FROM SYS.DATABASE_FILES", conn);
                SqlDataAdapter da = new SqlDataAdapter(c);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView4.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn không có quyền này, hãy liên hệ quản lý để biết thêm");
            }
        }

        private void HeThong_Load(object sender, EventArgs e)
        {
            load_database_gridview();
            load_database_gridview1();
            load_database_gridview3();
            load_database_gridview4();
        }

        private void btn_upsize_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txt_size.Text);
            string tenfile = txt_tenfile.Text;
            try
            {
                //------------------------------------------------------//
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (txt_size.Text == "" && txt_tenfile.Text =="")
                {
                    MessageBox.Show("Bạn Chưa Nhập Thông Tin Để tăng size");
                }
                else
                {
                    SqlCommand c = new SqlCommand("Alter database QL_KS_TUAN_1 Modify file (name ='" + tenfile + "',size = " + a + " MB)", conn);
                    c.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(c);
                    MessageBox.Show("Up size Thành Công ");
                    load_database_gridview();
                    load_database_gridview1();
                }
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

        private void btn_defside_Click(object sender, EventArgs e)
        {
           int a = int.Parse(txt_size.Text);
           try
           {
                //------------------------------------------------------//
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (txt_size.Text == "")
                {
                    MessageBox.Show("Bạn Chưa Nhập Thông Tin Để giảm size");
                }
                else
                {
                    SqlCommand c = new SqlCommand("DBCC SHRINKDATABASE (QL_KS_TUAN_1,"+a+")", conn);
                    c.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(c);
                    MessageBox.Show("Def size Thành Công ");
                    load_database_gridview();
                    load_database_gridview1();
                }
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

        private void txt_size_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập ký tự số", "Thông báo");
            }
        }

        private void btn_addfilegroup_Click(object sender, EventArgs e)
        {
            string tenfilegr = txt_namefilegroup.Text;
            try
            {
                //------------------------------------------------------//
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (txt_namefilegroup.Text == "")
                {
                    MessageBox.Show("Bạn Chưa Nhập Thông Tin Để Thêm  File Group");
                }
                else
                {
                    SqlCommand c = new SqlCommand("ALTER DATABASE QL_KS_TUAN_1 ADD FILEGROUP " + tenfilegr + " ", conn);
                    c.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(c);
                    MessageBox.Show("ADD Thành Công ");
                    load_database_gridview3();
                }
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

        private void btn_minusfilegroup_Click(object sender, EventArgs e)
        {
            string tenfilegr = txt_namefilegroup.Text;
            try
            {
                //------------------------------------------------------//
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (txt_namefilegroup.Text == "")
                {
                    MessageBox.Show("Bạn Chưa Nhập Thông Tin Để Thêm  File Group");
                }
                else
                {
                    SqlCommand c = new SqlCommand("ALTER DATABASE QL_KS_TUAN_1 REMOVE FILEGROUP " + tenfilegr + " ", conn);
                    c.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(c);
                    MessageBox.Show("Minus Thành Công ");
                    load_database_gridview3();
                }
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

        private void btn_addfiletothegroup_Click(object sender, EventArgs e)
        {
            string tenfile = txt_namefile.Text;
            string filename = txt_filename.Text;
            int size = int.Parse(txt_sizegr.Text);
            int maxsize = int.Parse(txt_maxsize.Text);
            int filegrowth = int.Parse(txt_filegrowth.Text);
            string group = txt_gr.Text;
            try
            {
                //------------------------------------------------------//
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (txt_namefile.Text == "" && txt_filename.Text == "" && txt_sizegr.Text == "" && txt_maxsize.Text == "" && txt_filegrowth.Text == "" && txt_gr.Text == "")
                {
                    MessageBox.Show("Bạn Chưa Nhập Thông Tin Để Thêm  File Vào Group");
                }
                else
                {
                    SqlCommand c = new SqlCommand("ALTER DATABASE QL_KS_TUAN_1 ADD FILE (name = "+tenfile+",Filename ='"+filename+"',Size = "+size+" MB ,MaxSize = "+maxsize+" MB,Filegrowth= "+filegrowth+"%) to filegroup "+group+" ", conn);
                    c.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(c);
                    MessageBox.Show("ADD Thành Công ");
                    load_database_gridview4();
                }
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

        private void btn_minusfiletothegroup_Click(object sender, EventArgs e)
        {
            string tenfile = txt_namefile.Text;
            try
            {
                //------------------------------------------------------//
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (txt_namefile.Text == "" )
                {
                    MessageBox.Show("Bạn Chưa Nhập Thông Tin Để Thêm  File Vào Group");
                }
                else
                {
                    SqlCommand c = new SqlCommand("ALTER DATABASE QL_KS_TUAN_1  REMOVE FILE "+tenfile+" ; ", conn);
                    c.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(c);
                    MessageBox.Show("Minus Thành Công ");
                    load_database_gridview4();
                }
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

    }
}
