namespace DOAN_ThucHanhHQTCSDL_QLKhachSan
{
    partial class ImportDatabase
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Opendatasource = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtBrowse_Bulk = new System.Windows.Forms.TextBox();
            this.btnBrowse_Bulk = new System.Windows.Forms.Button();
            this.cboTable_Bulk = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport_Bulk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImport_OP = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTable_OP = new System.Windows.Forms.ComboBox();
            this.btnBrowse_OP = new System.Windows.Forms.Button();
            this.txtBrowse_OP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnKH = new System.Windows.Forms.Button();
            this.btnPH = new System.Windows.Forms.Button();
            this.btnTH = new System.Windows.Forms.Button();
            this.btnHD = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.Opendatasource.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnImport_Bulk);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboTable_Bulk);
            this.groupBox1.Controls.Add(this.btnBrowse_Bulk);
            this.groupBox1.Controls.Add(this.txtBrowse_Bulk);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 353);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bulk Insert";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(567, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(577, 511);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // Opendatasource
            // 
            this.Opendatasource.Controls.Add(this.label3);
            this.Opendatasource.Controls.Add(this.btnImport_OP);
            this.Opendatasource.Controls.Add(this.label4);
            this.Opendatasource.Controls.Add(this.cboTable_OP);
            this.Opendatasource.Controls.Add(this.btnBrowse_OP);
            this.Opendatasource.Controls.Add(this.groupBox4);
            this.Opendatasource.Controls.Add(this.txtBrowse_OP);
            this.Opendatasource.Location = new System.Drawing.Point(409, 12);
            this.Opendatasource.Name = "Opendatasource";
            this.Opendatasource.Size = new System.Drawing.Size(386, 353);
            this.Opendatasource.TabIndex = 2;
            this.Opendatasource.TabStop = false;
            this.Opendatasource.Text = "Opendatasource";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(567, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(577, 511);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // txtBrowse_Bulk
            // 
            this.txtBrowse_Bulk.Location = new System.Drawing.Point(7, 172);
            this.txtBrowse_Bulk.Name = "txtBrowse_Bulk";
            this.txtBrowse_Bulk.Size = new System.Drawing.Size(226, 29);
            this.txtBrowse_Bulk.TabIndex = 2;
            // 
            // btnBrowse_Bulk
            // 
            this.btnBrowse_Bulk.Location = new System.Drawing.Point(256, 169);
            this.btnBrowse_Bulk.Name = "btnBrowse_Bulk";
            this.btnBrowse_Bulk.Size = new System.Drawing.Size(116, 34);
            this.btnBrowse_Bulk.TabIndex = 3;
            this.btnBrowse_Bulk.Text = "Chọn file";
            this.btnBrowse_Bulk.UseVisualStyleBackColor = true;
            this.btnBrowse_Bulk.Click += new System.EventHandler(this.btnBrowse_Bulk_Click);
            // 
            // cboTable_Bulk
            // 
            this.cboTable_Bulk.FormattingEnabled = true;
            this.cboTable_Bulk.Location = new System.Drawing.Point(123, 88);
            this.cboTable_Bulk.Name = "cboTable_Bulk";
            this.cboTable_Bulk.Size = new System.Drawing.Size(170, 30);
            this.cboTable_Bulk.TabIndex = 4;
            this.cboTable_Bulk.SelectedIndexChanged += new System.EventHandler(this.cboTable_Bulk_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Chọn table";
            // 
            // btnImport_Bulk
            // 
            this.btnImport_Bulk.Location = new System.Drawing.Point(80, 270);
            this.btnImport_Bulk.Name = "btnImport_Bulk";
            this.btnImport_Bulk.Size = new System.Drawing.Size(220, 34);
            this.btnImport_Bulk.TabIndex = 6;
            this.btnImport_Bulk.Text = "Import";
            this.btnImport_Bulk.UseVisualStyleBackColor = true;
            this.btnImport_Bulk.Click += new System.EventHandler(this.btnImport_Bulk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(342, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "(Lỗi nếu sql không hỗ trợ code 65001 (csv UFT-8))";
            // 
            // btnImport_OP
            // 
            this.btnImport_OP.Location = new System.Drawing.Point(74, 270);
            this.btnImport_OP.Name = "btnImport_OP";
            this.btnImport_OP.Size = new System.Drawing.Size(220, 34);
            this.btnImport_OP.TabIndex = 12;
            this.btnImport_OP.Text = "Import";
            this.btnImport_OP.UseVisualStyleBackColor = true;
            this.btnImport_OP.Click += new System.EventHandler(this.btnImport_OP_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Chọn table";
            // 
            // cboTable_OP
            // 
            this.cboTable_OP.FormattingEnabled = true;
            this.cboTable_OP.Location = new System.Drawing.Point(137, 91);
            this.cboTable_OP.Name = "cboTable_OP";
            this.cboTable_OP.Size = new System.Drawing.Size(170, 30);
            this.cboTable_OP.TabIndex = 10;
            this.cboTable_OP.SelectedIndexChanged += new System.EventHandler(this.cboTable_OP_SelectedIndexChanged);
            // 
            // btnBrowse_OP
            // 
            this.btnBrowse_OP.Location = new System.Drawing.Point(257, 178);
            this.btnBrowse_OP.Name = "btnBrowse_OP";
            this.btnBrowse_OP.Size = new System.Drawing.Size(116, 34);
            this.btnBrowse_OP.TabIndex = 9;
            this.btnBrowse_OP.Text = "Chọn file";
            this.btnBrowse_OP.UseVisualStyleBackColor = true;
            this.btnBrowse_OP.Click += new System.EventHandler(this.btnBrowse_OP_Click);
            // 
            // txtBrowse_OP
            // 
            this.txtBrowse_OP.Location = new System.Drawing.Point(8, 181);
            this.txtBrowse_OP.Name = "txtBrowse_OP";
            this.txtBrowse_OP.Size = new System.Drawing.Size(226, 29);
            this.txtBrowse_OP.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "*Khuyến khích dùng*";
            // 
            // btnKH
            // 
            this.btnKH.Location = new System.Drawing.Point(10, 42);
            this.btnKH.Name = "btnKH";
            this.btnKH.Size = new System.Drawing.Size(186, 34);
            this.btnKH.TabIndex = 8;
            this.btnKH.Text = "Delete KHACHHANG";
            this.btnKH.UseVisualStyleBackColor = true;
            this.btnKH.Click += new System.EventHandler(this.btnKH_Click);
            // 
            // btnPH
            // 
            this.btnPH.Location = new System.Drawing.Point(202, 42);
            this.btnPH.Name = "btnPH";
            this.btnPH.Size = new System.Drawing.Size(186, 34);
            this.btnPH.TabIndex = 9;
            this.btnPH.Text = "Delete PHONG";
            this.btnPH.UseVisualStyleBackColor = true;
            this.btnPH.Click += new System.EventHandler(this.btnPH_Click);
            // 
            // btnTH
            // 
            this.btnTH.Location = new System.Drawing.Point(394, 42);
            this.btnTH.Name = "btnTH";
            this.btnTH.Size = new System.Drawing.Size(186, 34);
            this.btnTH.TabIndex = 10;
            this.btnTH.Text = "Delete THUE";
            this.btnTH.UseVisualStyleBackColor = true;
            this.btnTH.Click += new System.EventHandler(this.btnTH_Click);
            // 
            // btnHD
            // 
            this.btnHD.Location = new System.Drawing.Point(586, 42);
            this.btnHD.Name = "btnHD";
            this.btnHD.Size = new System.Drawing.Size(186, 34);
            this.btnHD.TabIndex = 11;
            this.btnHD.Text = "Delete HOADON";
            this.btnHD.UseVisualStyleBackColor = true;
            this.btnHD.Click += new System.EventHandler(this.btnHD_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnHD);
            this.groupBox3.Controls.Add(this.btnTH);
            this.groupBox3.Controls.Add(this.btnKH);
            this.groupBox3.Controls.Add(this.btnPH);
            this.groupBox3.Location = new System.Drawing.Point(12, 371);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(783, 100);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Test Delete";
            // 
            // ImportDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 726);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Opendatasource);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ImportDatabase";
            this.Text = "ImportDatabase";
            this.Load += new System.EventHandler(this.ImportDatabase_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Opendatasource.ResumeLayout(false);
            this.Opendatasource.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImport_Bulk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTable_Bulk;
        private System.Windows.Forms.Button btnBrowse_Bulk;
        private System.Windows.Forms.TextBox txtBrowse_Bulk;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox Opendatasource;
        private System.Windows.Forms.Button btnImport_OP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTable_OP;
        private System.Windows.Forms.Button btnBrowse_OP;
        private System.Windows.Forms.TextBox txtBrowse_OP;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnKH;
        private System.Windows.Forms.Button btnPH;
        private System.Windows.Forms.Button btnTH;
        private System.Windows.Forms.Button btnHD;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}