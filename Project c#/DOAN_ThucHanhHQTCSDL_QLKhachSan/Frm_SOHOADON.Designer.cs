namespace DOAN_ThucHanhHQTCSDL_QLKhachSan
{
    partial class Frm_SOHOADON
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_TenKH = new System.Windows.Forms.TextBox();
            this.labeln = new System.Windows.Forms.Label();
            this.btn_loadDGV = new System.Windows.Forms.Button();
            this.btn_Tim = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_TenKH
            // 
            this.txt_TenKH.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenKH.Location = new System.Drawing.Point(157, 44);
            this.txt_TenKH.Margin = new System.Windows.Forms.Padding(2);
            this.txt_TenKH.Multiline = true;
            this.txt_TenKH.Name = "txt_TenKH";
            this.txt_TenKH.Size = new System.Drawing.Size(396, 36);
            this.txt_TenKH.TabIndex = 7;
            // 
            // labeln
            // 
            this.labeln.AutoSize = true;
            this.labeln.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeln.Location = new System.Drawing.Point(20, 50);
            this.labeln.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labeln.Name = "labeln";
            this.labeln.Size = new System.Drawing.Size(133, 17);
            this.labeln.TabIndex = 6;
            this.labeln.Text = "Họ tên khách hàng :";
            // 
            // btn_loadDGV
            // 
            this.btn_loadDGV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_loadDGV.Location = new System.Drawing.Point(681, 31);
            this.btn_loadDGV.Margin = new System.Windows.Forms.Padding(2);
            this.btn_loadDGV.Name = "btn_loadDGV";
            this.btn_loadDGV.Size = new System.Drawing.Size(98, 49);
            this.btn_loadDGV.TabIndex = 23;
            this.btn_loadDGV.Text = "Quay Lại";
            this.btn_loadDGV.UseVisualStyleBackColor = true;
            this.btn_loadDGV.Click += new System.EventHandler(this.btn_loadDGV_Click);
            // 
            // btn_Tim
            // 
            this.btn_Tim.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tim.Location = new System.Drawing.Point(576, 31);
            this.btn_Tim.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(88, 49);
            this.btn_Tim.TabIndex = 24;
            this.btn_Tim.Text = "Tìm";
            this.btn_Tim.UseVisualStyleBackColor = true;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(21, 95);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(118, 80);
            this.dataGridView.TabIndex = 25;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(145, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(644, 259);
            this.dataGridView1.TabIndex = 25;
            // 
            // Frm_SOHOADON
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 405);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btn_loadDGV);
            this.Controls.Add(this.btn_Tim);
            this.Controls.Add(this.txt_TenKH);
            this.Controls.Add(this.labeln);
            this.Name = "Frm_SOHOADON";
            this.Text = "Frm_SOHOADON";
            this.Load += new System.EventHandler(this.Frm_SOHOADON_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_TenKH;
        private System.Windows.Forms.Label labeln;
        private System.Windows.Forms.Button btn_loadDGV;
        private System.Windows.Forms.Button btn_Tim;
        public System.Windows.Forms.DataGridView dataGridView;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}