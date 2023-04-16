namespace DOAN_ThucHanhHQTCSDL_QLKhachSan
{
    partial class HeThong
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
            this.btnBR = new System.Windows.Forms.Button();
            this.btnRS = new System.Windows.Forms.Button();
            this.panel_Body_2 = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBR
            // 
            this.btnBR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBR.Location = new System.Drawing.Point(12, 12);
            this.btnBR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBR.Name = "btnBR";
            this.btnBR.Size = new System.Drawing.Size(197, 63);
            this.btnBR.TabIndex = 0;
            this.btnBR.Text = "Backup && Restore";
            this.btnBR.UseVisualStyleBackColor = true;
            this.btnBR.Click += new System.EventHandler(this.btnBR_Click);
            // 
            // btnRS
            // 
            this.btnRS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRS.Location = new System.Drawing.Point(216, 12);
            this.btnRS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRS.Name = "btnRS";
            this.btnRS.Size = new System.Drawing.Size(197, 63);
            this.btnRS.TabIndex = 2;
            this.btnRS.Text = "Resize Database";
            this.btnRS.UseVisualStyleBackColor = true;
            this.btnRS.Click += new System.EventHandler(this.btnRS_Click);
            // 
            // panel_Body_2
            // 
            this.panel_Body_2.Location = new System.Drawing.Point(12, 81);
            this.panel_Body_2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Body_2.Name = "panel_Body_2";
            this.panel_Body_2.Size = new System.Drawing.Size(1123, 651);
            this.panel_Body_2.TabIndex = 3;
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(419, 14);
            this.btnImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(197, 63);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // HeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 770);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.panel_Body_2);
            this.Controls.Add(this.btnRS);
            this.Controls.Add(this.btnBR);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HeThong";
            this.Text = "HeThong";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBR;
        private System.Windows.Forms.Button btnRS;
        private System.Windows.Forms.Panel panel_Body_2;
        private System.Windows.Forms.Button btnImport;
    }
}