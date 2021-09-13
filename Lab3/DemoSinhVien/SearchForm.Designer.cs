
namespace DemoSinhVien
{
    partial class OptionsForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdBirthday = new System.Windows.Forms.RadioButton();
            this.rdname = new System.Windows.Forms.RadioButton();
            this.rdID = new System.Windows.Forms.RadioButton();
            this.pnSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdBirthday);
            this.panel1.Controls.Add(this.rdname);
            this.panel1.Controls.Add(this.rdID);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 81);
            this.panel1.TabIndex = 0;
            // 
            // rdBirthday
            // 
            this.rdBirthday.AutoSize = true;
            this.rdBirthday.Location = new System.Drawing.Point(265, 23);
            this.rdBirthday.Name = "rdBirthday";
            this.rdBirthday.Size = new System.Drawing.Size(95, 24);
            this.rdBirthday.TabIndex = 2;
            this.rdBirthday.Text = "Ngày sinh";
            this.rdBirthday.UseVisualStyleBackColor = true;
            // 
            // rdname
            // 
            this.rdname.AutoSize = true;
            this.rdname.Location = new System.Drawing.Point(148, 23);
            this.rdname.Name = "rdname";
            this.rdname.Size = new System.Drawing.Size(75, 24);
            this.rdname.TabIndex = 1;
            this.rdname.Text = "Họ tên";
            this.rdname.UseVisualStyleBackColor = true;
            // 
            // rdID
            // 
            this.rdID.AutoSize = true;
            this.rdID.Checked = true;
            this.rdID.Location = new System.Drawing.Point(26, 23);
            this.rdID.Name = "rdID";
            this.rdID.Size = new System.Drawing.Size(72, 24);
            this.rdID.TabIndex = 0;
            this.rdID.TabStop = true;
            this.rdID.Text = "Mã SV";
            this.rdID.UseVisualStyleBackColor = true;
            // 
            // pnSearch
            // 
            this.pnSearch.Controls.Add(this.btnSearch);
            this.pnSearch.Controls.Add(this.txtInfo);
            this.pnSearch.Controls.Add(this.label1);
            this.pnSearch.Location = new System.Drawing.Point(12, 99);
            this.pnSearch.Name = "pnSearch";
            this.pnSearch.Size = new System.Drawing.Size(394, 68);
            this.pnSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.Coral;
            this.btnSearch.Location = new System.Drawing.Point(323, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 29);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(144, 25);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(173, 27);
            this.txtInfo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập thông tin:";
            // 
            // btnSort
            // 
            this.btnSort.ForeColor = System.Drawing.Color.Coral;
            this.btnSort.Location = new System.Drawing.Point(82, 173);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(91, 29);
            this.btnSort.TabIndex = 3;
            this.btnSort.Text = "Sắp xếp";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnExit
            // 
            this.btnExit.ForeColor = System.Drawing.Color.Coral;
            this.btnExit.Location = new System.Drawing.Point(246, 173);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(68, 29);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 228);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.pnSearch);
            this.Controls.Add(this.panel1);
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnSearch.ResumeLayout(false);
            this.pnSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdBirthday;
        private System.Windows.Forms.RadioButton rdname;
        private System.Windows.Forms.RadioButton rdID;
        private System.Windows.Forms.Panel pnSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnExit;
    }
}