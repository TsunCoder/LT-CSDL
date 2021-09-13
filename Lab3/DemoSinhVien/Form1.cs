using DemoSinhVien.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoSinhVien
{
    public partial class frmSinhVien : Form
    {
        StudentsManagement qlsv;
        public frmSinhVien()
        {
            InitializeComponent();
        }
        private Students GetStudents()
        {
            Students sv = new Students();
            bool gt = true;
            List<string> cn = new List<string>();
            sv.Id = this.mtxt_id.Text;
            sv.Name = this.txtName.Text;
            sv.BirthDay = this.dtpDatebirth.Value;
            sv.Address = this.txtAdress.Text;
            sv.Class = this.cboClass.Text;
            sv.Image = this.txtImage.Text;
            if (rdFemale.Checked)
            {
                gt = false;
            }
            sv.Sex = gt;
            for (int i = 0; i < this.clbSpecialization.Items.Count; i++)
            {
                if (clbSpecialization.GetItemChecked(i))
                {
                    cn.Add(clbSpecialization.Items[i].ToString());
                }
            }
            sv.Specialized = cn;

            return sv;
        }

        private Students GetStudentsLV(ListViewItem lvitem)
        {
            Students sv = new Students();
            sv.Id = lvitem.SubItems[0].Text;
            sv.Name = lvitem.SubItems[1].Text;
            sv.BirthDay = DateTime.Parse(lvitem.SubItems[2].Text);
            sv.Address = lvitem.SubItems[3].Text;
            sv.Class = lvitem.SubItems[4].Text;
            sv.Sex = false;
            if (lvitem.SubItems[5].Text == "Nam")
            {
                sv.Sex = true;
            }

            List<string> cn = new List<string>();
            string[] s = lvitem.SubItems[6].Text.Split(',');
            foreach (string t in s)
            {
                cn.Add(t.Trim());
            }
            sv.Specialized = cn;
            sv.Image = lvitem.SubItems[7].Text;

            return sv;
        }

        private void SetInfo(Students sv)
        {
            this.mtxt_id.Text = sv.Id;
            this.txtName.Text = sv.Name;
            this.dtpDatebirth.Value = sv.BirthDay;
            this.txtAdress.Text = sv.Address;
            this.cboClass.Text = sv.Class;
            this.txtImage.Text = sv.Image;
            this.ptbImg.ImageLocation = sv.Image;

            if (sv.Sex)
            {
                this.rdMale.Checked = true;
            }
            else
            {
                this.rdFemale.Checked = true;
            }

            foreach (string s in sv.Specialized)
            {
                for (int i = 0; i < this.clbSpecialization.Items.Count; i++)
                {
                    if (s.CompareTo(this.clbSpecialization.Items[i]) == 0)
                    {
                        this.clbSpecialization.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void AddStudents(Students sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.Id);
            lvitem.SubItems.Add(sv.Name);
            lvitem.SubItems.Add(sv.BirthDay.ToShortDateString());
            lvitem.SubItems.Add(sv.Address);
            lvitem.SubItems.Add(sv.Class);
            string gt = "Nữ";
            if (sv.Sex)
            {
                gt = "Nam";
            }
            lvitem.SubItems.Add(gt);
            string cn = "";

            foreach (string s in sv.Specialized)
            {
                cn += s + ",";
            }

            cn = cn.Substring(0, cn.Length - 1);
            lvitem.SubItems.Add(cn);
            lvitem.SubItems.Add(sv.Image);
            this.lvStudents.Items.Add(lvitem);

        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            qlsv = new StudentsManagement();
            qlsv.DocTuFile();
            LoadListView();
        }

        private void LoadListView()
        {
            this.lvStudents.Items.Clear();
            foreach (Students sv in qlsv.List)
            {
                AddStudents(sv);
            }
            toolStripStatusLabel1.Text = "Tổng sinh viên: " + lvStudents.Items.Count;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Students sv = GetStudents();
            Students kq = qlsv.Search(sv.Id, delegate (object obj1, object obj2)
            {
                return (obj2 as Students).Id.CompareTo(obj1.ToString());
            });
            if (kq != null)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi thêm dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.qlsv.Add(sv);
                this.LoadListView();
            }
        }

        private int Compare_Id(object obj1, object obj2)
        {
            Students sv = obj2 as Students;
            return sv.Id.CompareTo(obj1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Students sv = GetStudents();
            bool kq;
            kq = qlsv.Update(sv, sv.Id, delegate (object obj1, object obj2)
            {
                return (obj2 as Students).Id.CompareTo(obj1.ToString());
            });
            LoadListView();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvitem;
            count = this.lvStudents.Items.Count - 1;

            for (i = count; i >= 0; i--)
            {
                lvitem = this.lvStudents.Items[i];
                if (lvitem.Checked)
                {
                    qlsv.Remove(lvitem.SubItems[0].Text, Compare_Id);

                }

            }
            this.LoadListView();
            this.btnDefault.PerformClick();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            this.mtxt_id.Text = "";
            this.txtName.Text = "";
            this.dtpDatebirth.Value = DateTime.Now;
            this.txtAdress.Text = "";
            this.cboClass.Text = this.cboClass.Items[0].ToString();
            this.txtImage.Text = "";
            this.ptbImg.ImageLocation = "";
            this.rdMale.Checked = true;
            for (int i = 0; i < this.clbSpecialization.Items.Count; i++)
                this.clbSpecialization.SetItemChecked(i, false);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Chọn hình món ăn";// "Add Photos";
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
                ptbImg.Load(fileName);
            }
        }

        private void lvStudents_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int count = this.lvStudents.CheckedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lvStudents.CheckedItems[0];
                Students sv = GetStudentsLV(lvitem);
                SetInfo(sv);
            }
        }

        private void ftsmiOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Chọn hình món ăn";// "Add Photos";
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
                ptbImg.Load(fileName);
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            Students sv = GetStudents();
            Students kq = qlsv.Search(sv.Id, delegate (object obj1, object obj2)
            {
                return (obj2 as Students).Id.CompareTo(obj1.ToString());
            });
            if (kq != null)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi thêm dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.qlsv.Add(sv);
                this.LoadListView();
            }
        }

        private void tsmiRemove_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvitem;
            count = this.lvStudents.Items.Count - 1;

            for (i = count; i >= 0; i--)
            {
                lvitem = this.lvStudents.Items[i];
                if (lvitem.Checked)
                {
                    qlsv.Remove(lvitem.SubItems[0].Text, Compare_Id);

                }

            }
            this.LoadListView();
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            Students sv = GetStudents();
            bool kq;
            kq = qlsv.Update(sv, sv.Id, delegate (object obj1, object obj2)
            {
                return (obj2 as Students).Id.CompareTo(obj1.ToString());
            });
            LoadListView();
        }


        private void LoadOptionsToListView(List<Students> dsSV)
        {
            this.lvStudents.Items.Clear();
            foreach (Students sv in dsSV)
            {
                AddStudents(sv);
            }
        }
        private void tsmiSort_Click(object sender, EventArgs e)
        {
            OptionsForm form = new OptionsForm(qlsv, 0);
            form.ShowDialog();
            LoadOptionsToListView(form.listSt);
        }

        private void tsmiSearch_Click(object sender, EventArgs e)
        {
            OptionsForm form = new OptionsForm(qlsv, 1);
            form.ShowDialog();
            LoadOptionsToListView(form.listSt);
        }

        private void tsmiFont_Click(object sender, EventArgs e)
        {
            lvStudents.Font = new Font(lvStudents.Font, lvStudents.Font.Style | FontStyle.Bold);
        } 

        private void tsmiColor_Click(object sender, EventArgs e)
        {
            lvStudents.ForeColor = Color.Green;
        }
    }
}
