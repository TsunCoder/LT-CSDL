using Ex2.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex2
{
    public partial class FormTimKiem : Form
    {
		public List<GiaoVien> dsachGV;
		public GiaoVien gv;

		public FormTimKiem(QuanLyGiaoVien qlgv)
        {
			dsachGV = qlgv.dsGV;
			InitializeComponent();
        }

        private void rdMaSo_CheckedChanged(object sender, EventArgs e)
        {
			if (sender is RadioButton)
			{
				RadioButton radioButton = (RadioButton)sender;
				if (rdMaSo.Checked)
				{
					label1.Text = rdMaSo.Text;
				}
			}
		}

        private void rdHoTen_CheckedChanged(object sender, EventArgs e)
        {
			if (sender is RadioButton)
			{
				RadioButton radioButton = (RadioButton)sender;
				if (rdHoTen.Checked)
				{
					label1.Text = rdHoTen.Text;
				}
			}
		}

        private void rdSDT_CheckedChanged_1(object sender, EventArgs e)
        {
			if (sender is RadioButton)
			{
				RadioButton radioButton = (RadioButton)sender;
				if (rdSDT.Checked)
				{
					label1.Text = rdSDT.Text;
				}
			}
		}

        private void btnOK_Click(object sender, EventArgs e)
        {
			var timkiem = txtSearch.Text;
			if (rdMaSo.Checked == true)
			{
				GiaoVien kq = dsachGV.Find(x => x.MaSo.Trim() == timkiem.Trim());
				if (kq == null)
				{
					MessageBox.Show("Không tìm thấy giáo viên có mã số " + timkiem, "Lỗi");
				}
				else
				{
					frmTBGiaoVien frm = new frmTBGiaoVien();
					frm.SetText(kq.ToString());
					frm.ShowDialog();
				}
			}
			if (rdHoTen.Checked == true)
			{
				GiaoVien kq = dsachGV.Find(x => x.HoTen.ToLower().Trim() == timkiem.ToLower().Trim());
				if (kq == null)
				{
					MessageBox.Show("Không tìm thấy giáo viên có họ tên " + timkiem, "Lỗi");
				}
				else
				{
					frmTBGiaoVien frm = new frmTBGiaoVien();
					frm.SetText(kq.ToString());
					frm.ShowDialog();
				}
			}
			if (rdSDT.Checked == true)
			{
				GiaoVien kq = dsachGV.Find(x => x.SoDT.Trim() == timkiem.Trim());
				if (kq == null)
				{
					MessageBox.Show("Không tìm thấy giáo viên có số điện thoại " + timkiem, "Lỗi");
				}
				else
				{
					frmTBGiaoVien frm = new frmTBGiaoVien();
					frm.SetText(kq.ToString());
					frm.ShowDialog();
				}
			}
		}
    }
}
