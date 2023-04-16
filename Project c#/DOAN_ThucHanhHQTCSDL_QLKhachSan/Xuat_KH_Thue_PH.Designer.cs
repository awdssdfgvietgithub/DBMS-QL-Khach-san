namespace DOAN_ThucHanhHQTCSDL_QLKhachSan
{
    partial class Xuat_KH_Thue_PH
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.txt_TenKH = new System.Windows.Forms.TextBox();
            this.labeln = new System.Windows.Forms.Label();
            this.btn_Tim = new System.Windows.Forms.Button();
            this.btn_loadDGV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(39, 101);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(496, 301);
            this.dataGridView2.TabIndex = 0;
            // 
            // txt_TenKH
            // 
            this.txt_TenKH.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenKH.Location = new System.Drawing.Point(173, 29);
            this.txt_TenKH.Margin = new System.Windows.Forms.Padding(2);
            this.txt_TenKH.Multiline = true;
            this.txt_TenKH.Name = "txt_TenKH";
            this.txt_TenKH.Size = new System.Drawing.Size(153, 36);
            this.txt_TenKH.TabIndex = 5;
            // 
            // labeln
            // 
            this.labeln.AutoSize = true;
            this.labeln.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeln.Location = new System.Drawing.Point(36, 32);
            this.labeln.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labeln.Name = "labeln";
            this.labeln.Size = new System.Drawing.Size(133, 17);
            this.labeln.TabIndex = 4;
            this.labeln.Text = "Họ tên khách hàng :";
            // 
            // btn_Tim
            // 
            this.btn_Tim.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tim.Location = new System.Drawing.Point(330, 27);
            this.btn_Tim.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(88, 38);
            this.btn_Tim.TabIndex = 22;
            this.btn_Tim.Text = "Tìm";
            this.btn_Tim.UseVisualStyleBackColor = true;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // btn_loadDGV
            // 
            this.btn_loadDGV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_loadDGV.Location = new System.Drawing.Point(422, 29);
            this.btn_loadDGV.Margin = new System.Windows.Forms.Padding(2);
            this.btn_loadDGV.Name = "btn_loadDGV";
            this.btn_loadDGV.Size = new System.Drawing.Size(98, 36);
            this.btn_loadDGV.TabIndex = 22;
            this.btn_loadDGV.Text = "Quay Lại";
            this.btn_loadDGV.UseVisualStyleBackColor = true;
            this.btn_loadDGV.Click += new System.EventHandler(this.btn_loadDGV_Click);
            // 
            // Xuat_KH_Thue_PH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 414);
            this.Controls.Add(this.btn_loadDGV);
            this.Controls.Add(this.btn_Tim);
            this.Controls.Add(this.txt_TenKH);
            this.Controls.Add(this.labeln);
            this.Controls.Add(this.dataGridView2);
            this.Name = "Xuat_KH_Thue_PH";
            this.Text = "Xuat_KH_Thue_PH";
            this.Load += new System.EventHandler(this.Xuat_KH_Thue_PH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txt_TenKH;
        private System.Windows.Forms.Label labeln;
        private System.Windows.Forms.Button btn_Tim;
        private System.Windows.Forms.Button btn_loadDGV;

    }
}