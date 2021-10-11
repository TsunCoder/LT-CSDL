using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTap.Item
{
    public class Khoa
    {
        public string TenKhoa { get; set; }
        public List<Lop> dsLop;
        public List<SinhVien> dssv;

        public Khoa(string tenKhoa)
        {
            this.TenKhoa = tenKhoa;
            dsLop = new List<Lop>();
            dssv = new List<SinhVien>();
        }

        public void AddSV(SinhVien sv)
        {
            int vtLop = dsLop.FindIndex(x => x.TenLop == sv.Lop);
            if(vtLop == -1)
            {
                Lop lop = new Lop(sv.Lop);
                lop.dssv.Add(sv);
                dsLop.Add(lop);
            }
            else
            {
                dsLop[vtLop].dssv.Add(sv);
            }
            dssv.Add(sv);
        }

        public int TimViTriLop(string tenLop)
        {
            return dsLop.FindIndex(x => x.TenLop == tenLop);
        }
        public SinhVien TimSV(string id)
        {
            return dssv.Find(x => x.Id == id);

        }
        public void XoaSV(string id)
        {
            SinhVien sv = dssv.Find(x => x.Id == id);
            dssv.Remove(sv);
            dsLop[TimViTriLop(sv.Lop)].XoaSvLop(id);
        }

        public void SuaSV(SinhVien sv)
        {
            int sinhvien = dssv.FindIndex(x => x.Id == sv.Id);
            if(sinhvien >= 0)
            {
                dssv[sinhvien] = sv;
            }
        }
    }
}
