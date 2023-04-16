using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN_ThucHanhHQTCSDL_QLKhachSan
{
    public partial class HeThong : Form
    {
        public HeThong()
        {
            InitializeComponent();
        }

        private Form currentFormChild;
        private void openChild(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body_2.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnBR_Click(object sender, EventArgs e)
        {
            openChild(new BK_RS_Database());
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            openChild(new SizeDatabase());
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            openChild(new ImportDatabase());
        }

    }
}
