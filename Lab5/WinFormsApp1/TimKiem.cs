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
    public partial class TimKiem : Form
    {
        public List<SinhVien> dssv;
        public QuanLySinhVien qlsv;
        public SinhVien sv;

        public TimKiem()
        {
        }

        public TimKiem(QuanLySinhVien qlsv)
        {
            dssv = qlsv.list;
            qlsv = new QuanLySinhVien();
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string timkiem = txtNhap.Text;
            List<SinhVien> dskq = new List<SinhVien>();
            if (rdnID.Checked == true)
            {
                dskq = dssv.FindAll(x => x.Id == timkiem);
                if(dskq == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên có mã là" + timkiem, "Lỗi");
                }
                else if(timkiem == "")
                {
                    MessageBox.Show("Vui lòng nhập thông tin cần tìm");
                }
                else
                {
                    dssv = dskq;
                    Close();
                }
            }
            else if(rdnTen.Checked == true)
            {
                dskq = dssv.FindAll(x => x.Ten == timkiem);
                if(dskq == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên có tên là" + timkiem, "Lỗi");
                }
                else if (timkiem == "")
                {
                    MessageBox.Show("Vui lòng nhập thông tin cần tìm");
                }
                else
                {
                    dssv = dskq;
                    Close();
                }
            }
            else if (rdnLop.Checked == true)
            {
                dskq = dssv.FindAll(x => x.Lop == timkiem);
                if (dskq == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên có lớp là" + timkiem, "Lỗi");
                }
                else if (timkiem == "")
                {
                    MessageBox.Show("Vui lòng nhập thông tin cần tìm");
                }
                else
                {
                    dssv = dskq;
                    Close();
                }
            }
        }
    }
}
