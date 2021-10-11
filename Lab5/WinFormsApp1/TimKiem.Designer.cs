
namespace WinFormsApp1
{
    partial class TimKiem
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
            this.txtNhap = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.rdnID = new System.Windows.Forms.RadioButton();
            this.rdnTen = new System.Windows.Forms.RadioButton();
            this.rdnLop = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdnLop);
            this.groupBox1.Controls.Add(this.rdnTen);
            this.groupBox1.Controls.Add(this.rdnID);
            this.groupBox1.Controls.Add(this.btnTim);
            this.groupBox1.Controls.Add(this.txtNhap);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 130);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // txtNhap
            // 
            this.txtNhap.Location = new System.Drawing.Point(9, 71);
            this.txtNhap.Name = "txtNhap";
            this.txtNhap.Size = new System.Drawing.Size(298, 27);
            this.txtNhap.TabIndex = 2;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(313, 70);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(94, 29);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // rdnID
            // 
            this.rdnID.AutoSize = true;
            this.rdnID.Location = new System.Drawing.Point(9, 31);
            this.rdnID.Name = "rdnID";
            this.rdnID.Size = new System.Drawing.Size(68, 24);
            this.rdnID.TabIndex = 3;
            this.rdnID.TabStop = true;
            this.rdnID.Text = "MSSV";
            this.rdnID.UseVisualStyleBackColor = true;
            // 
            // rdnTen
            // 
            this.rdnTen.AutoSize = true;
            this.rdnTen.Location = new System.Drawing.Point(133, 31);
            this.rdnTen.Name = "rdnTen";
            this.rdnTen.Size = new System.Drawing.Size(53, 24);
            this.rdnTen.TabIndex = 3;
            this.rdnTen.TabStop = true;
            this.rdnTen.Text = "Tên";
            this.rdnTen.UseVisualStyleBackColor = true;
            // 
            // rdnLop
            // 
            this.rdnLop.AutoSize = true;
            this.rdnLop.Location = new System.Drawing.Point(252, 31);
            this.rdnLop.Name = "rdnLop";
            this.rdnLop.Size = new System.Drawing.Size(55, 24);
            this.rdnLop.TabIndex = 3;
            this.rdnLop.TabStop = true;
            this.rdnLop.Text = "Lớp";
            this.rdnLop.UseVisualStyleBackColor = true;
            // 
            // TimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 166);
            this.Controls.Add(this.groupBox1);
            this.Name = "TimKiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TimKiem";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdnLop;
        private System.Windows.Forms.RadioButton rdnTen;
        private System.Windows.Forms.RadioButton rdnID;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtNhap;
    }
}