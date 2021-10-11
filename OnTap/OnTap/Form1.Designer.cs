
namespace OnTap
{
    partial class FormQuanLy
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
            this.components = new System.ComponentModel.Container();
            this.tsmiIn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Nhap = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiLuu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_JsonExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.rdnSdt = new System.Windows.Forms.RadioButton();
            this.rdnHoten = new System.Windows.Forms.RadioButton();
            this.rdnMssv = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSinhvien = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_Them = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Xoa = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsmiIn
            // 
            this.tsmiIn.Name = "tsmiIn";
            this.tsmiIn.Size = new System.Drawing.Size(35, 24);
            this.tsmiIn.Text = "In";
            // 
            // tsmi_Nhap
            // 
            this.tsmi_Nhap.Name = "tsmi_Nhap";
            this.tsmi_Nhap.Size = new System.Drawing.Size(59, 24);
            this.tsmi_Nhap.Text = "Nhập";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Nhap,
            this.tsmiLuu,
            this.tsmiIn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1176, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiLuu
            // 
            this.tsmiLuu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_JsonExport,
            this.tsmi_ExportExcel});
            this.tsmiLuu.Name = "tsmiLuu";
            this.tsmiLuu.Size = new System.Drawing.Size(47, 24);
            this.tsmiLuu.Text = "Lưu";
            // 
            // tsmi_JsonExport
            // 
            this.tsmi_JsonExport.Name = "tsmi_JsonExport";
            this.tsmi_JsonExport.Size = new System.Drawing.Size(224, 26);
            this.tsmi_JsonExport.Text = "Json";
            this.tsmi_JsonExport.Click += new System.EventHandler(this.tsmi_JsonExport_Click);
            // 
            // tsmi_ExportExcel
            // 
            this.tsmi_ExportExcel.Name = "tsmi_ExportExcel";
            this.tsmi_ExportExcel.Size = new System.Drawing.Size(224, 26);
            this.tsmi_ExportExcel.Text = "Excel";
            this.tsmi_ExportExcel.Click += new System.EventHandler(this.tsmi_ExportExcel_Click);
            // 
            // rdnSdt
            // 
            this.rdnSdt.AutoSize = true;
            this.rdnSdt.Location = new System.Drawing.Point(424, 21);
            this.rdnSdt.Name = "rdnSdt";
            this.rdnSdt.Size = new System.Drawing.Size(112, 21);
            this.rdnSdt.TabIndex = 1;
            this.rdnSdt.TabStop = true;
            this.rdnSdt.Text = "Số điện thoại";
            this.rdnSdt.UseVisualStyleBackColor = true;
            // 
            // rdnHoten
            // 
            this.rdnHoten.AutoSize = true;
            this.rdnHoten.Location = new System.Drawing.Point(310, 21);
            this.rdnHoten.Name = "rdnHoten";
            this.rdnHoten.Size = new System.Drawing.Size(71, 21);
            this.rdnHoten.TabIndex = 1;
            this.rdnHoten.TabStop = true;
            this.rdnHoten.Text = "Họ tên";
            this.rdnHoten.UseVisualStyleBackColor = true;
            // 
            // rdnMssv
            // 
            this.rdnMssv.AutoSize = true;
            this.rdnMssv.Location = new System.Drawing.Point(190, 21);
            this.rdnMssv.Name = "rdnMssv";
            this.rdnMssv.Size = new System.Drawing.Size(67, 21);
            this.rdnMssv.TabIndex = 1;
            this.rdnMssv.TabStop = true;
            this.rdnMssv.Text = "MSSV";
            this.rdnMssv.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tìm theo:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTimkiem);
            this.groupBox1.Controls.Add(this.rdnSdt);
            this.groupBox1.Controls.Add(this.rdnHoten);
            this.groupBox1.Controls.Add(this.rdnMssv);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(293, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(869, 80);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.Location = new System.Drawing.Point(190, 52);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(346, 22);
            this.txtTimkiem.TabIndex = 2;
            this.txtTimkiem.Text = "Nhập thông tin cần tìm!!!";
            this.txtTimkiem.Click += new System.EventHandler(this.txtTimkiem_Click);
            this.txtTimkiem.TextChanged += new System.EventHandler(this.txtTimkiem_TextChanged);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Lớp";
            this.columnHeader7.Width = 111;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Số điện thoại";
            this.columnHeader6.Width = 124;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ngày sinh";
            this.columnHeader5.Width = 115;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Giới tính";
            this.columnHeader4.Width = 86;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên";
            this.columnHeader3.Width = 69;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Họ và tên lót";
            this.columnHeader2.Width = 164;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "MSSV";
            this.columnHeader1.Width = 69;
            // 
            // lvSinhvien
            // 
            this.lvSinhvien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvSinhvien.ContextMenuStrip = this.contextMenuStrip1;
            this.lvSinhvien.FullRowSelect = true;
            this.lvSinhvien.GridLines = true;
            this.lvSinhvien.HideSelection = false;
            this.lvSinhvien.Location = new System.Drawing.Point(293, 90);
            this.lvSinhvien.Name = "lvSinhvien";
            this.lvSinhvien.Size = new System.Drawing.Size(869, 520);
            this.lvSinhvien.TabIndex = 7;
            this.lvSinhvien.UseCompatibleStateImageBehavior = false;
            this.lvSinhvien.View = System.Windows.Forms.View.Details;
            this.lvSinhvien.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvSinhvien_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Them,
            this.tsmi_Xoa});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(116, 52);
            // 
            // tsmi_Them
            // 
            this.tsmi_Them.Name = "tsmi_Them";
            this.tsmi_Them.Size = new System.Drawing.Size(115, 24);
            this.tsmi_Them.Text = "Thêm";
            this.tsmi_Them.Click += new System.EventHandler(this.tsmi_Them_Click);
            // 
            // tsmi_Xoa
            // 
            this.tsmi_Xoa.Name = "tsmi_Xoa";
            this.tsmi_Xoa.Size = new System.Drawing.Size(115, 24);
            this.tsmi_Xoa.Text = "Xóa";
            this.tsmi_Xoa.Click += new System.EventHandler(this.tsmi_Xoa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Chọn lớp để hiển thị danh sách sinh viên";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 90);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(275, 520);
            this.treeView1.TabIndex = 5;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // FormQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 621);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lvSinhvien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.Name = "FormQuanLy";
            this.Text = "Quản lý sinh viên";
            this.Load += new System.EventHandler(this.FormQuanLy_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmiIn;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Nhap;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiLuu;
        private System.Windows.Forms.RadioButton rdnSdt;
        private System.Windows.Forms.RadioButton rdnHoten;
        private System.Windows.Forms.RadioButton rdnMssv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTimkiem;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lvSinhvien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Them;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Xoa;
        private System.Windows.Forms.ToolStripMenuItem tsmi_JsonExport;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ExportExcel;
    }
}

