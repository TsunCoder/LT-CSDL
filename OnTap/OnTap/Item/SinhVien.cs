using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTap.Item
{
    public class SinhVien
    {
        public string Id { get; set; }
        public string HoVaTenLot { get; set; }
        public string Ten { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Lop { get; set; }
        public string Sdt { get; set; }
        public string Khoa { get; set; }
        public string DiaChi { get; set; }

        public SinhVien(string Id, string HoVaTenLot, string Ten, bool GioiTinh, DateTime NgaySinh, string Lop, string Sdt, string Khoa, string DiaChi)
        {
            this.Id = Id;
            this.HoVaTenLot = HoVaTenLot;
            this.Ten = Ten;
            this.GioiTinh = GioiTinh;
            this.NgaySinh = NgaySinh;
            this.Lop = Lop;
            this.Sdt = Sdt;
            this.Khoa = Khoa;
            this.DiaChi = DiaChi;
        }

        public SinhVien()
        {

        }
    }
}
