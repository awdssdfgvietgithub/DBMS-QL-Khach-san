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
    public partial class ImportDatabase : Form
    {
        SqlConnection conn = new SqlConnection();
        public ImportDatabase()
        {
            InitializeComponent();
            string cn = DangNhap.connect.ToString();
            conn = new SqlConnection(cn);
        }

        public void load_cbo_table()
        {
            cboTable_Bulk.Items.Add("KHACHHANG");

            cboTable_OP.Items.Add("KHACHHANG");
            cboTable_OP.Items.Add("NHANVIEN");
            cboTable_OP.Items.Add("PHONG");
            cboTable_OP.Items.Add("THUE");
            cboTable_OP.Items.Add("HOADON");
        }

        private void ImportDatabase_Load(object sender, EventArgs e)
        {
            load_cbo_table();
            btnImport_Bulk.Enabled = false;
            btnImport_OP.Enabled = false;
        }

        private void cboTable_Bulk_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Bulk_Click(object sender, EventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog();
            a.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            a.Title = "Import data";
            if (a.ShowDialog() == DialogResult.OK)
            {
                txtBrowse_Bulk.Text = a.FileName;
                btnImport_Bulk.Enabled = true;
            }
        }

        private void btnImport_Bulk_Click(object sender, EventArgs e)
        {
            conn.Open();
            string ten_table = cboTable_Bulk.Text;
            string duonglink = txtBrowse_Bulk.Text;
            if (ten_table == "THUE")
            {
                SqlCommand cmd_dis = new SqlCommand("ALTER TABLE THUE DISABLE TRIGGER ALL", conn);
                cmd_dis.ExecuteNonQuery();
            }
            if (ten_table == "HOADON")
            {
                SqlCommand cmd_dis = new SqlCommand("ALTER TABLE HOADON DISABLE TRIGGER ALL", conn);
                cmd_dis.ExecuteNonQuery();
            }


            if (txtBrowse_Bulk.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string str_Imp = @"BULK INSERT " + ten_table + " FROM N'" + @duonglink + "' with (CHECK_CONSTRAINTS, CODEPAGE=65001, fieldterminator=';', ROWTERMINATOR = '\n', firstrow=2)";
                SqlCommand cmd = new SqlCommand(str_Imp, conn);
                cmd.ExecuteNonQuery();
                SqlCommand cmd5 = new SqlCommand("ALTER TABLE HOADON ENABLE TRIGGER ALL", conn);
                cmd5.ExecuteNonQuery();
                SqlCommand cmd6 = new SqlCommand("ALTER TABLE THUE ENABLE TRIGGER ALL", conn);
                cmd6.ExecuteNonQuery();

                MessageBox.Show("Import thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                btnImport_Bulk.Enabled = false;
            }
        }

        private void cboTable_OP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowse_OP_Click(object sender, EventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog();
            a.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            a.Title = "Import data";
            if (a.ShowDialog() == DialogResult.OK)
            {
                txtBrowse_OP.Text = a.FileName;
                btnImport_OP.Enabled = true;
            }
        }

        private void btnImport_OP_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string ten_table = cboTable_OP.Text;
                string sheet = cboTable_OP.Text;
                string duonglink = txtBrowse_OP.Text;
                if (ten_table == "THUE")
                {
                    ten_table = "THUE(MA_KH, MA_P, NGAY_DEN, NGAY_DI)";
                    SqlCommand cmd_dis = new SqlCommand("ALTER TABLE THUE DISABLE TRIGGER ALL", conn);
                    cmd_dis.ExecuteNonQuery();
                }
                if (ten_table == "HOADON")
                {
                    ten_table = "HOADON(MA_HD, MA_NV, MA_KH, MA_P)";
                    SqlCommand cmd_dis = new SqlCommand("ALTER TABLE HOADON DISABLE TRIGGER ALL", conn);
                    cmd_dis.ExecuteNonQuery();
                }
                if (ten_table == "PHONG")
                    ten_table = "PHONG(MA_P, TEN_P, MA_NV, LOAI_P, GIA_P)";

                if (txtBrowse_OP.Text == string.Empty)
                {
                    MessageBox.Show("Bạn chưa chọn file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SqlCommand cmd1 = new SqlCommand("sp_configure 'show advanced options', 1;RECONFIGURE;", conn);
                    cmd1.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand("sp_configure 'Ad Hoc Distributed Queries', 1;RECONFIGURE;", conn);
                    cmd2.ExecuteNonQuery();
                    SqlCommand cmd3 = new SqlCommand("EXEC master.dbo.sp_MSset_oledb_prop N'Microsoft.ACE.OLEDB.12.0', N'AllowInProcess', 1 ", conn);
                    cmd3.ExecuteNonQuery();
                    SqlCommand cmd4 = new SqlCommand("EXEC master.dbo.sp_MSset_oledb_prop N'Microsoft.ACE.OLEDB.12.0', N'DynamicParameters', 1 ", conn);
                    cmd4.ExecuteNonQuery();

                    string str_Imp = @"INSERT INTO " + ten_table + " SELECT * FROM OPENDATASOURCE('Microsoft.ACE.OLEDB.12.0', N'Data Source=" + duonglink + ";Extended Properties=Excel 12.0')...[" + sheet + "$]";
                    SqlCommand cmd = new SqlCommand(str_Imp, conn);
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd5 = new SqlCommand("ALTER TABLE HOADON ENABLE TRIGGER ALL", conn);
                    cmd5.ExecuteNonQuery();
                    SqlCommand cmd6 = new SqlCommand("ALTER TABLE THUE ENABLE TRIGGER ALL", conn);
                    cmd6.ExecuteNonQuery();

                    MessageBox.Show("Import thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Trùng dữ liệu unique hoặc số cột không tương thích!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                btnImport_OP.Enabled = false;
            }
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete KHACHHANG", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }

        private void btnPH_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete PHONG", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }

        private void btnTH_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete THUE", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }

        private void btnHD_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete HOADON", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }
    }
}
