using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.IO
{
    public class TextDataSource : IDataSource
    {
        private const string _filepath = "D:\\Study\\Lập trình cơ sở dữ liệu\\Lab\\Lab5\\WinFormsApp1\\Data\\SinhVien.txt";

        public List<SinhVien> GetSinhViens()
        {
            List<SinhVien> sinhViens = new List<SinhVien>();
            SinhVien sv;
            string[] s;
            if (File.Exists(_filepath))
            {
                using (var stream = new FileStream(_filepath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            s = line.Split('*');
                            sv = new SinhVien();
                            sv.Id = s[0];
                            sv.GioiTinh = false;
                            if (s[1] == "1")
                            {
                                sv.GioiTinh = true;
                            }
                            sv.HoVaTenLot = s[2];
                            sv.Ten = s[3];
                            sv.NgaySinh = DateTime.Parse(s[4]);
                            sv.Lop = s[5];
                            sv.Cmnd = s[6];
                            sv.Sdt = s[7];
                            sv.DiaChi = s[8];
                            string[] mh = s[9].Split(',');
                            foreach (var item in mh)
                            {
                                sv.MonHoc.Add(item);
                            }
                            sinhViens.Add(sv);
                        }
                    }
                }
            }
            
            return sinhViens;
        }

        public void Save(List<SinhVien> sinhViens)
        {
            using (var stream = new FileStream(_filepath, FileMode.Create, FileAccess.ReadWrite))
            {
                using (var writer = new StreamWriter(stream))
                {
                    foreach (var sv in sinhViens)
                    {
                        writer.WriteLine("{0}*{1}*{2}*{3}*{4}*{5}*{6}*{7}*{8}*{9}",
                        sv.Id, sv.GioiTinh ? 1 : 0, sv.HoVaTenLot, sv.Ten, sv.NgaySinh, sv.Lop, sv.Cmnd, sv.Sdt, sv.DiaChi, ParseMonHoc(sv.MonHoc));
                    }
                }
            }
        }

        private string ParseMonHoc(List<string> monhoc)
        {
            string dsmh = "";
            foreach (var item in monhoc)
            {
                dsmh += item + ",";
            }

            return dsmh;
        }
    }
}
