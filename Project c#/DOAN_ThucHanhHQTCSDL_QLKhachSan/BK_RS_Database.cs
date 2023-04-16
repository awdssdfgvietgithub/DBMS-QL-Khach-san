using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DOAN_ThucHanhHQTCSDL_QLKhachSan
{
    public partial class BK_RS_Database : Form
    {
        SqlConnection conn = new SqlConnection();
        public BK_RS_Database()
        {
            InitializeComponent();
            string cn = DangNhap.connect.ToString();
            conn = new SqlConnection(cn);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void BK_RS_Database_Load(object sender, EventArgs e)
        {
            btnBackup.Enabled = false;
            btnRestore.Enabled = false;
        }
        private void btnBrowseBackup_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog a = new FolderBrowserDialog();
            if (a.ShowDialog() == DialogResult.OK)
            {
                txtBrowseBackup.Text = a.SelectedPath;
                btnBackup.Enabled = true;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string ten_db = conn.Database.ToString();
            string duonglink = txtBrowseBackup.Text + "\\" + ten_db + "_Full.bak";
            if (txtBrowseBackup.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn đường dẫn lưu file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                conn.Open();
                try
                {
                    string str_use = "use " + ten_db + "";
                    SqlCommand cmd = new SqlCommand(str_use, conn);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Không có database này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (rdo_mahoa.Checked == false)
                {
                    string str_backup = "exec backup_Full N'" + duonglink + "', N'" + ten_db + "'";
                    SqlCommand cmd1 = new SqlCommand(str_backup, conn);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Backup database thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    btnBackup.Enabled = false;
                }
                else
                {
                    string str_backup = "exec backup_Full_ENCRYPTION N'" + duonglink + "', N'" + ten_db + "'";
                    SqlCommand cmd1 = new SqlCommand(str_backup, conn);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Backup database thành công (mã hóa)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    btnBackup.Enabled = false;
                }
            }
        }

        private void btnBrowseRestore_Click(object sender, EventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog();
            a.Filter = "bak files (*.bak)|*.bak|All files (*.*)|*.*";
            a.Title = "Database restore";
            if (a.ShowDialog() == DialogResult.OK)
            {
                txtBrowseRestore.Text = a.FileName;
                btnRestore.Enabled = true;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            string ten_db = conn.Database.ToString();

            string duonglink = txtBrowseRestore.Text;
            if (txtBrowseRestore.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn đường dẫn hồi phục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                conn.Open();
                string str_set_single = string.Format("Alter database [" + ten_db + "] set SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand cmd1 = new SqlCommand(str_set_single, conn);
                cmd1.ExecuteNonQuery();

                string str_backup = "use master exec restore_Full N'" + duonglink + "', N'" + ten_db + "'";
                SqlCommand cmd2 = new SqlCommand(str_backup, conn);
                cmd2.ExecuteNonQuery();

                string str_set_multi = string.Format("Alter database [" + ten_db + "] set MULTI_USER");
                SqlCommand cmd3 = new SqlCommand(str_set_multi, conn);
                cmd3.ExecuteNonQuery();

                timer1.Start();
                conn.Close();
                btnRestore.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var rand = new Random();
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 5;
                label1.Text = progressBar1.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Restore database thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
