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
    public partial class OptionsForm : Form
    {
        public List<Students> listSt;
        int i;
        public OptionsForm(StudentsManagement qlsv, int num)
        {
            listSt = qlsv.List;
            i = num;
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            if (i == 0)
            {
                pnSearch.Enabled = false;
            }
            else
            {
                btnSort.Enabled = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (rdID.Checked == true)
            {
                listSt = listSt.OrderBy(x => x.Id).ToList();
                Close();
            }
            if (rdname.Checked == true)
            {
                listSt = listSt.OrderBy(x => x.Name).ToList();
                Close();
            }
            if (rdBirthday.Checked == true)
            {
                listSt = listSt.OrderBy(x => x.BirthDay).ToList();
                Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string tim = txtInfo.Text;
            List<Students> listKq = new List<Students>();
            if (string.IsNullOrEmpty(tim))
            {
                MessageBox.Show("Hãy nhập thông tin cần tìm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (rdID.Checked == true)
                {
                    foreach (var st in listSt)
                    {
                        if (st.Id == tim)
                        {
                            listKq.Add(st);
                        }
                    }
                    listSt.Clear();
                    if (listKq.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy sinh viên có mã số là: " + tim, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        listSt = listKq;
                        MessageBox.Show("Số sinh viên tìm thấy: " + listSt.Count);
                        Close();
                    }
                }
                if (rdname.Checked == true)
                {
                    foreach (var st in listSt)
                    {
                        if (st.Name.Trim().ToLower() == tim.Trim().ToLower())
                        {
                            listKq.Add(st);
                        }

                    }
                    listSt.Clear();
                    if (listKq.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy sinh viên có tên là: " + tim, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        listSt = listKq;
                        MessageBox.Show("Số sinh viên tìm thấy: " + listSt.Count);
                        Close();
                    }

                    if (rdBirthday.Checked == true)
                    {
                        foreach (var st in listSt)
                        {
                            if (st.BirthDay == DateTime.Parse(tim))
                            {
                                listKq.Add(st);
                            }
                        }
                        listSt.Clear();
                        if (listKq.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy sinh viên có ngày sinh là: " + tim, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            listSt = listKq;
                            MessageBox.Show("Số sinh viên tìm thấy: " + listSt.Count);
                            Close();
                        }
                    }
                }
            }
        }
    }
}
