using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormNhapSV : Form
    {
        QuanLySinhVien qlsv;
        List<SinhVien> dsSv;
        private bool checkChange = true;
        public FormNhapSV()
        {
            InitializeComponent();
        }

        private void FormNhapSV_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien();
            LoadListView(qlsv.GetSinhViens());
            dsSv = qlsv.list;
        }

        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            bool gt = true;
            List<string> MonHoc = new List<string>();

            sv.Id = this.mtbID.Text;
            if (rdnNu.Checked == true)
            {
                gt = false;
            }
            sv.GioiTinh = gt;
            sv.HoVaTenLot = this.txtHoTenLot.Text;
            sv.Ten = this.txtTen.Text;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.Lop = this.cbbLop.Text;
            sv.Cmnd = this.mtbCMND.Text;
            sv.Sdt = this.mtbSDT.Text;
            sv.DiaChi = this.txtDiaChi.Text;

            for (int i = 0; i < this.clbMonHoc.Items.Count; i++)
            {
                if (clbMonHoc.GetItemChecked(i))
                {
                    MonHoc.Add(clbMonHoc.Items[i].ToString());
                }
            }
            sv.MonHoc = MonHoc;

            return sv;
        }

        private SinhVien GetSinhVienLv(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.Id = lvitem.SubItems[0].Text;
            sv.GioiTinh = false;
            if(lvitem.SubItems[1].Text == "Nam")
            {
                sv.GioiTinh = true;
            }
            sv.HoVaTenLot = lvitem.SubItems[2].Text;
            sv.Ten = lvitem.SubItems[3].Text;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[4].Text);
            sv.Lop = lvitem.SubItems[5].Text;
            sv.Cmnd = lvitem.SubItems[6].Text;
            sv.Sdt = lvitem.SubItems[7].Text;
            sv.DiaChi = lvitem.SubItems[8].Text;

            List<string> monhoc = new List<string>();
            string[] s = lvitem.SubItems[9].Text.Split(',');
            for (int i = 0; i < this.clbMonHoc.Items.Count; i++)
            {
                this.clbMonHoc.SetItemChecked(i, false);
            }
            foreach (string t in s)
            {
                monhoc.Add(t.Trim());
            }
            sv.MonHoc = monhoc;

            return sv;
        }

        private void LoadListView(List<SinhVien> list)
        {
            this.lvSinhVien.Items.Clear();
            foreach (SinhVien sinhVien in list)
            {
                AddSinhVien(sinhVien);
            }
        }

        private void LoadListView()
        {
            foreach (SinhVien sinhVien in qlsv.list)
            {
                AddSinhVien(sinhVien);
            }
        }

        private void LoadCheckListBox(SinhVien sv)
        {
            this.clbMonHoc.Items.Clear();
            foreach (var item in sv.MonHoc)
            {
                clbMonHoc.Items.Add(item);  
            }
        }

        private void AddSinhVien(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.Id);
            string gt = "Nữ";
            if (sv.GioiTinh)
            {
                gt = "Nam";
            }
            lvitem.SubItems.Add(gt);
            lvitem.SubItems.Add(sv.HoVaTenLot);
            lvitem.SubItems.Add(sv.Ten);
            lvitem.SubItems.Add(sv.NgaySinh.ToString());
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.Cmnd);
            lvitem.SubItems.Add(sv.Sdt);
            lvitem.SubItems.Add(sv.DiaChi);
            string mh = "";
            foreach (string s in sv.MonHoc)
            {
                mh += s + ",";
            }
            mh = mh.Substring(0, mh.Length - 1);
            lvitem.SubItems.Add(mh);

            this.lvSinhVien.Items.Add(lvitem);
        }

        private void ThietLapSinhVien(SinhVien sv)
        {
            this.mtbID.Text = sv.Id;
            this.rdnNam.Checked = true;
            if (sv.GioiTinh)
            {
                this.rdnNam.Checked = true;
            }
            else
            {
                this.rdnNu.Checked = true;
            }
            this.txtHoTenLot.Text = sv.HoVaTenLot;
            this.txtTen.Text = sv.Ten;
            this.dtpNgaySinh.Value = sv.NgaySinh;

            this.cbbLop.Text = sv.Lop;
            this.mtbSDT.Text = sv.Sdt;
            this.mtbCMND.Text = sv.Cmnd;
            this.txtDiaChi.Text = sv.DiaChi;
            foreach (var item in sv.MonHoc)
            {
                for (int i = 0; i < this.clbMonHoc.Items.Count; i++)
                {
                    if (item.CompareTo(this.clbMonHoc.Items[i]) == 0)
                    {
                        this.clbMonHoc.SetItemChecked(i, true);
                    }
                }
            }
        }
            // Kiểm tra môn học 
            private bool checkMonHoc()
            {
                int monHoc = 0;
                for (int i = 0; i < this.clbMonHoc.Items.Count; i++)
                {
                    monHoc += 1;
                }

                if(monHoc > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        // Thêm mới sinh viên
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (this.mtbID.Text == "" || this.txtHoTenLot.Text == "" || this.txtTen.Text == "" || this.cbbLop.Text == "" || this.mtbCMND.Text == ""
                || this.mtbSDT.Text == "" || this.txtDiaChi.Text == "" || checkMonHoc() == false)
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin sinh viên trước khi thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                for (int i = 0; i < dsSv.Count; i++)
                {
                    if(dsSv[i].Id == this.mtbID.Text)
                    {
                        MessageBox.Show("Trùng ID sinh viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                SinhVien sv = GetSinhVien();
                this.qlsv.Them(sv);
                MessageBox.Show("Lưu thành công", "Thông báo");
                qlsv.SaveSinhVien();
                LoadListView(qlsv.list); ;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (this.mtbID.Text == "" || this.txtHoTenLot.Text == "" || this.txtTen.Text == "" || this.cbbLop.Text == "" || this.mtbCMND.Text == ""
                || this.mtbSDT.Text == "" || this.txtDiaChi.Text == "" || checkMonHoc() == false)
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin sinh viên trước khi thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SinhVien sv = GetSinhVien();
                qlsv.Sua(sv);
                qlsv.SaveSinhVien();
                LoadListView(qlsv.list);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            TimKiem tim = new TimKiem(qlsv);
            tim.ShowDialog();    
            LoadListView(tim.dssv);
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = lvSinhVien.SelectedItems.Count;
            if(count > 0)
            {
                ListViewItem lvitem = this.lvSinhVien.SelectedItems[0];
                SinhVien sv = GetSinhVienLv(lvitem);
                ThietLapSinhVien(sv);
            }
        }

        private void tsmiXoa_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvitem;

            count = this.lvSinhVien.Items.Count - 1;

            for (i = count - 1; i >= 0; i--)
            {
                lvitem = this.lvSinhVien.Items[i];
                if (lvitem.Checked)
                {
                    qlsv.Xoa(lvitem.SubItems[0].Text);
                }
            }
            LoadListView(qlsv.list);
        }

        private void FormNhapSV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkChange)
            {
                DialogResult dialog = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialog == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void tsmiThemMH_Click(object sender, EventArgs e)
        {
            AddMonHoc add = new AddMonHoc();
            var dialog = add.ShowDialog();

            if(dialog == DialogResult.OK)
            {
                string mh = add.monhoc;
                clbMonHoc.Items.Add(mh);
            }
        }

        private void tsmiXoaMH_Click(object sender, EventArgs e)
        {
            for (int i = this.clbMonHoc.Items.Count - 1; i >= 0; i--)
            {
                if (clbMonHoc.GetItemChecked(i))
                {
                    clbMonHoc.Items.Remove(clbMonHoc.Items[i]);
                }
            }
            LoadListView(qlsv.list);
        }
    }
}
