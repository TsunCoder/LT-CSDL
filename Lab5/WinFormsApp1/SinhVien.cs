using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class SinhVien
    {
        public string Id { get; set; }
        public bool GioiTinh { get; set; }
        public string HoVaTenLot { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Lop { get; set; }
        public string Cmnd { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
        public List<string> MonHoc { get; set; }

        public SinhVien()
        {
            MonHoc = new List<string>();
        }

        public SinhVien(string id, bool gioitinh, string hovatenlot, string ten, 
                        DateTime ngaysinh, string lop, string cmnd,
                           string sdt, string diachi, List<string> monhoc)
        {
            this.Id = id;
            this.GioiTinh = gioitinh;
            this.HoVaTenLot = hovatenlot;
            this.Ten = ten;
            this.NgaySinh = ngaysinh;
            this.Lop = lop;
            this.Cmnd = cmnd;
            this.Sdt = sdt;
            this.DiaChi = diachi;
            this.MonHoc = monhoc;
        }
    }
}
