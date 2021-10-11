using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTap.Item
{
    public class Lop
    {
        public string TenLop { get; set; }
        public List<SinhVien> dssv;

        public Lop(string tenlop)
        {
            this.TenLop = tenlop;
            dssv = new List<SinhVien>();
        }

        public void XoaSvLop(string id)
        {
            dssv.RemoveAll(x => x.Id == id);
        }
    }
}
