using Ex1.info;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex1
{
    public partial class Form1 : Form
    {
        QuanLySinhVien qlsv;
        public bool checkChange = true;
        public Form1()
        {
            qlsv = new QuanLySinhVien();
            InitializeComponent();
        }

        private SinhVien GetStudents()
        {
            SinhVien sv = new SinhVien();
            bool gt = true;
            sv.Id = this.mtxtId.Text;
            sv.HoTen = this.txtName.Text;
            sv.Email = this.txtEmail.Text;
            sv.DiaChi = this.txtAddress.Text;
            sv.Lop = this.cbbClass.Text;
            sv.NgaySinh = this.dtpBirthday.Value;
            sv.Sdt = this.mtxtPhone.Text;
            if (rdnFemale.Checked)
            {
                gt = false;
            }
            sv.GioiTinh = gt;
            sv.Image = this.txtImage.Text;

            return sv;
        }
        private void AddStudents(SinhVien sv)
        {
            string gt = "Nữ";
            ListViewItem lvitem = new ListViewItem(sv.Id);
            lvitem.SubItems.Add(sv.HoTen);
            if (sv.GioiTinh)
            {
                gt = "Nam";
            }
            lvitem.SubItems.Add(gt);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.Sdt);
            lvitem.SubItems.Add(sv.Email);
            lvitem.SubItems.Add(sv.DiaChi);
            lvitem.SubItems.Add(sv.Image);
            this.lvStudents.Items.Add(lvitem);

        }

        private SinhVien GetStudentsLv(ListViewItem lvitem)
        {
            
            SinhVien sv = new SinhVien();
            sv.Id = lvitem.SubItems[0].Text;
            sv.HoTen = lvitem.SubItems[1].Text;
            sv.GioiTinh = false;
            if (lvitem.SubItems[2].Text == "Nam")
            {
                sv.GioiTinh = true;
            }
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[3].Text);
            sv.Lop = lvitem.SubItems[4].Text;
            sv.Sdt = lvitem.SubItems[5].Text;
            sv.Email = lvitem.SubItems[6].Text;
            sv.DiaChi = lvitem.SubItems[7].Text;
            sv.Image = lvitem.SubItems[8].Text;

            return sv;

        }

        private void SetInfo(SinhVien sv)
        {
            this.mtxtId.Text = sv.Id;
            this.txtName.Text = sv.HoTen;
            if (sv.GioiTinh)
            {
                this.rdnMale.Checked = true;
            }
            else
            {
                this.rdnFemale.Checked = true;
            }
            this.dtpBirthday.Value = sv.NgaySinh;
            this.cbbClass.Text = sv.Lop;
            this.mtxtPhone.Text = sv.Sdt;
            this.txtEmail.Text = sv.Email;
            this.txtAddress.Text = sv.DiaChi;
            this.txtImage.Text = sv.Image;

        }

        private void Load_ListView()
        {
            this.lvStudents.Items.Clear();
            foreach (SinhVien sinhVien in qlsv.list)
            {
                AddStudents(sinhVien);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetStudents();
            SinhVien kq = qlsv.Search(sv.Id.Trim(),delegate(object obj1, object obj2) {
                return (obj2 as SinhVien).Id.CompareTo(obj1.ToString());
            });

            if(kq == null)
            {
                this.qlsv.Add(sv);
                this.Load_ListView();
            }
            else
            {
                bool kqsua;
                kqsua = qlsv.Update(sv, sv.Id.Trim(), delegate (object obj1, object obj2)
                {
                    return (obj2 as SinhVien).Id.CompareTo(obj1.ToString());
                });
                Load_ListView();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Chọn hình sinh viên";
            dlg.Multiselect = true;
            dlg.Filter = "Image Files (JPEG, GIF, BMP, etc.)|"
            + "*.jpg;*.jpeg;*.gif;*.bmp;"
            + "*.tif;*.tiff;*.png|"
            + "JPEG files (*.jpg;*.jpeg)|*.jpg;*.jpeg|"
            + "GIF files (*.gif)|*.gif|"
            + "BMP files (*.bmp)|*.bmp|"
            + "TIFF files (*.tif;*.tiff)|*.tif;*.tiff|"
            + "PNG files (*.png)|*.png|"
            + "All files (*.*)|*.*";
            dlg.InitialDirectory = Environment.CurrentDirectory;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var fileName = dlg.FileName;
                txtImage.Text = fileName;
                ptbImage.Load(fileName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien();
            qlsv.DocTuFile();
            Load_ListView();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            this.mtxtId.Text = "";
            this.txtName.Text = "";
            this.rdnMale.Checked = false;
            this.rdnFemale.Checked = false;
            this.dtpBirthday.Value = DateTime.Now;
            this.cbbClass.Text = this.cbbClass.Items[0].ToString();
            this.mtxtPhone.Text = "";
            this.txtEmail.Text = "";
            this.txtAddress.Text = "";
            this.txtImage.Text = "";
            this.ptbImage.ImageLocation = "";

        }

        private void lvStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvStudents.SelectedItems.Count;
            if(count > 0)
            {
                ListViewItem lvitem = this.lvStudents.SelectedItems[0];
                SinhVien sv = GetStudentsLv(lvitem);
                SetInfo(sv);
                
            }
        }

        private void lvStudents_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int count = this.lvStudents.CheckedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lvStudents.CheckedItems[0];
                SinhVien sv = GetStudentsLv(lvitem);
                SetInfo(sv);

            }
        }

        private int SoSanh_id(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.Id.CompareTo(obj1);
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvitem;
            count = this.lvStudents.Items.Count - 1;

            for (i = count; i >= 0; i--)
            {
                lvitem = this.lvStudents.Items[i];
                if (lvitem.Checked)
                {
                    qlsv.Remove(lvitem.SubItems[0].Text, SoSanh_id);

                }

            }
            this.Load_ListView();
        }

        private void loadListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qlsv.list.Clear();
            qlsv.DocTuFile();
            this.Load_ListView();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkChange)
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn lưu lại chỉnh sửa của mình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialog == DialogResult.Yes)
                {
                    this.qlsv.Save(qlsv.list);
                }
                else if(dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
