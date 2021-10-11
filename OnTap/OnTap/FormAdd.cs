using OnTap.Item;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnTap
{
    public partial class FormAdd : Form
    {
        public QuanLySinhVIen qlsv;
        public SinhVien sv;
        public bool sua;
        public FormAdd(QuanLySinhVIen qlsv)
        {
            InitializeComponent();
            this.qlsv = qlsv;
            sua = false;
        }
        
        private void LoadCbbKhoa()
        {
            foreach (var item in qlsv.dsKhoa)
            {
                cbbKhoa.Items.Add(item.TenKhoa);
            }
        }

        private void LoadCbbLop(int vt)
        {
            cbbLop.Items.Clear();
            foreach (var item in qlsv.dsKhoa[vt].dsLop)
            {
                cbbLop.Items.Add(item.TenLop);
            }
        }

        private SinhVien GetSinhVien()
        {
            SinhVien sinhvien = new SinhVien();
            bool gt = true; 
            sinhvien.Id = this.mtbID.Text;
            if (rdnNu.Checked == true)
            {
                gt = false;
            }
            sinhvien.GioiTinh = gt;
            sinhvien.HoVaTenLot = this.txtHoVaTenLot.Text;
            sinhvien.Ten = this.txtTen.Text;
            sinhvien.NgaySinh = this.dtpNgaySinh.Value;
            sinhvien.Lop = this.cbbLop.Text;
            sinhvien.Sdt = this.mtbSDT.Text;
            sinhvien.Khoa = this.cbbKhoa.Text;
            sinhvien.DiaChi = this.txtDiaChi.Text;
            return sinhvien;
        }

        private SinhVien GetSinhVienUpdate()
        {
            bool gt = true;
            sv.Id = this.mtbID.Text;
            if (rdnNu.Checked == true)
            {
                gt = false;
            }
            sv.GioiTinh = gt;
            sv.HoVaTenLot = this.txtHoVaTenLot.Text;
            sv.Ten = this.txtTen.Text;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.Lop = this.cbbLop.Text;
            sv.Sdt = this.mtbSDT.Text;
            sv.Khoa = this.cbbKhoa.Text;
            sv.DiaChi = this.txtDiaChi.Text;
            return sv;
        }

        public void ThietLapSinhVien(SinhVien sinhvien)
        {
            this.mtbID.Text = sinhvien.Id;
            this.rdnNam.Checked = true;
            if (sinhvien.GioiTinh)
            {
                this.rdnNam.Checked = true;
            }
            else
            {
                this.rdnNu.Checked = true;
            }
            this.txtHoVaTenLot.Text = sinhvien.HoVaTenLot;
            this.txtTen.Text = sinhvien.Ten;
            this.dtpNgaySinh.Text = DateTime.Now.ToShortDateString();
            this.cbbLop.Text = sinhvien.Lop;
            this.mtbSDT.Text = sinhvien.Sdt;
            this.cbbKhoa.Text = sinhvien.Khoa;
            this.txtDiaChi.Text = sinhvien.DiaChi;

            this.mtbID.ReadOnly = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (mtbID.Text == "" || txtHoVaTenLot.Text == "" || txtTen.Text == "" || cbbKhoa.Text == "" || cbbLop.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!sua)
            {
                SinhVien sinhVienThem = GetSinhVien();
                this.qlsv.ThemSV(sinhVienThem);
                Close();     
            }
            else
            {
                sv = GetSinhVien();
                this.qlsv.SuaSV(sv);
                Close();
            }
            
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            LoadCbbKhoa();
        }

        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cbbKhoa.SelectedIndex;
            LoadCbbLop(i);
        }
    }
}
