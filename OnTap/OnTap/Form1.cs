using ClosedXML.Excel;
using Microsoft.Office.Interop.Excel;
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
    public partial class FormQuanLy : Form
    {
        QuanLySinhVIen qlsv;
        List<SinhVien> ds;
        TreeNode node;
        public FormQuanLy(QuanLySinhVIen qlsv)
        {
            InitializeComponent();
            this.qlsv = qlsv;
        }

        private void AddSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.Id);


            lvitem.SubItems.Add(sv.HoVaTenLot);
            lvitem.SubItems.Add(sv.Ten);
            string gt = "Nữ";
            if (sv.GioiTinh)
            {
                gt = "Nam";
            }
            lvitem.SubItems.Add(gt);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.Sdt);
            lvitem.SubItems.Add(sv.Lop);

            this.lvSinhvien.Items.Add(lvitem);

        }

        private void LoadListView(List<SinhVien> sinhViens)
        {
            this.lvSinhvien.Items.Clear();
            foreach (SinhVien sinhVien in sinhViens)
            {
                AddSV(sinhVien);
            }
        }

        private void LoadTreeView(List<Khoa> dsKhoa)
        {
            foreach (Khoa khoa in dsKhoa)
            {
                var node = this.treeView1.Nodes.Add(khoa.TenKhoa);
                foreach (Lop lop in khoa.dsLop)
                {
                    node.Nodes.Add(lop.TenLop); 
                }
            }
            treeView1.ExpandAll();
        }

        private void FormQuanLy_Load(object sender, EventArgs e)
        {
            LoadListView(qlsv.dsKhoa[0].dssv);
            LoadTreeView(qlsv.dsKhoa);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.lvSinhvien.Items.Clear();
            node = e.Node;
            LoadListView(LoadListParent());
            
        }

        private List<SinhVien> LoadListParent()
        {
            if(node.Level == 0)
            {
                int x = qlsv.dsKhoa.FindIndex(p => p.TenKhoa == node.Text);
                ds = qlsv.dsKhoa[x].dssv;
            }
            else
            {
                int x = qlsv.dsKhoa.FindIndex(p => p.TenKhoa == node.Parent.Text);
                int y = qlsv.dsKhoa[x].dsLop.FindIndex(p => p.TenLop == node.Text);
                ds = qlsv.dsKhoa[x].dsLop[y].dssv;
            }
            return ds;
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            if(txtTimkiem.Text == "")
            {
                LoadListView(qlsv.dsKhoa[ViTriKhoa()].dssv);
            }

            if(rdnMssv.Checked)
            {
                var sv = LoadListParent().FindAll(x => x.Id.Trim().ToLower().Contains(txtTimkiem.Text));
                LoadListView(sv);
            }
            else if (rdnHoten.Checked)
            {
                var sv = LoadListParent().FindAll(x => x.Ten.Trim().ToLower().Contains(txtTimkiem.Text));
                LoadListView(sv);
            }
            else if (rdnSdt.Checked)
            {
                var sv = LoadListParent().FindAll(x => x.Sdt.Trim().ToLower().Contains(txtTimkiem.Text));
                LoadListView(sv);
            }
         
        }

        private void txtTimkiem_Click(object sender, EventArgs e)
        {
            txtTimkiem.Clear();
        }

        private void tsmi_Them_Click(object sender, EventArgs e)
        {
            FormAdd form = new FormAdd(qlsv);
            form.ShowDialog();
            if(form.DialogResult == DialogResult.OK)
            {
                LoadListView(form.qlsv.dsKhoa[ViTriKhoa()].dssv);
            }
        }
        
        public int ViTriKhoa()
        {
            if(node.Level == 0)
            {
                return qlsv.dsKhoa.FindIndex(x => x.TenKhoa == node.Text);
            }
            else
            {
                return qlsv.dsKhoa.FindIndex(x => x.TenKhoa == node.Parent.Text);
            }
        }
        
        public void tsmi_Xoa_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvitem;

            count = lvSinhvien.Items.Count - 1;
            for (i = count; i >= 0; i--)
            {
                lvitem = lvSinhvien.Items[i];
                if (lvitem.Selected)
                {
                    qlsv.dsKhoa[ViTriKhoa()].XoaSV(lvitem.SubItems[0].Text);
                }
            }
            MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            LoadListView(LoadListParent());
        }
        
        private void tsmi_ExportExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel WorkBook (.xls) (.xlsx)|*.xls||*.xlsx", ValidateNames = true, InitialDirectory = "D:\\", FileName = node.Text })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;
                    app.Visible = false;
                    int i = 1, j = 1;

                    foreach (ListViewItem item in lvSinhvien.Items)
                    {
                        ws.Cells[1, 1] = "ID";
                        ws.Cells[1, 2] = "Họ và tên lót";
                        ws.Cells[1, 3] = "Tên";
                        ws.Cells[1, 4] = "Giới tính";
                        ws.Cells[1, 5] = "Ngày sinh";
                        ws.Cells[1, 6] = "SDT";
                        ws.Cells[1, 7] = "Lớp";
                        ws.Cells[i, j] = item.Text.ToString();
                        foreach (ListViewItem.ListViewSubItem item1 in item.SubItems)
                        {
                            ws.Cells[i, j] = item1.Text.ToString();
                            j++;
                        }
                        j = 1;
                        i++;
                    }
                    wb.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange,
                        Type.Missing, Type.Missing);
                    MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private SinhVien GetSinhVienLv(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.Id = lvitem.SubItems[0].Text;
            sv.HoVaTenLot = lvitem.SubItems[1].Text;
            sv.Ten = lvitem.SubItems[2].Text;
            sv.GioiTinh = false;
            if (lvitem.SubItems[3].Text == "Nam")
            {
                sv.GioiTinh = true;
            }
            
            
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[4].Text);
            sv.Sdt = lvitem.SubItems[6].Text;
            sv.Lop = lvitem.SubItems[5].Text;
            return sv;
        }

        private void lvSinhvien_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string item = lvSinhvien.SelectedItems[0].Text;
            SinhVien sinhVien = qlsv.dsKhoa[ViTriKhoa()].TimSV(item);
            FormAdd form = new FormAdd(qlsv);
            form.ThietLapSinhVien(sinhVien);
            form.sua = true;
            form.ShowDialog();
            LoadListView(qlsv.dsKhoa[ViTriKhoa()].dssv);
            
        }

        private void tsmi_JsonExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Json File (.json)|*.json", InitialDirectory = "D:\\", FileName = node.Text })
            {
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    qlsv.SaveJson(LoadListParent(), sfd.FileName);
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
