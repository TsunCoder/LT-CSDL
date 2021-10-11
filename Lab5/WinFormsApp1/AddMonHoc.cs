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
    public partial class AddMonHoc : Form
    {
        public string monhoc;
        public AddMonHoc()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddMH_Click(object sender, EventArgs e)
        {
            monhoc = txtMonHoc.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
