using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Ex1.info
{
    public class SinhVien
    {
        public string Id { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string Lop { get; set; }
        public string Sdt { get; set; }
        public string Image { get; set; }
        public SinhVien()
        {
            
        }

        public SinhVien(string id, string hoten, string email, string diachi, DateTime ngaysinh, bool gioitinh, string lop, string sdt)
        {
            this.Id = id;
            this.HoTen = hoten;
            this.Email = email;
            this.DiaChi = diachi;
            this.NgaySinh = ngaysinh;
            this.GioiTinh = gioitinh;
            this.Lop = lop;
            this.Sdt = sdt;
        }
    }
}
