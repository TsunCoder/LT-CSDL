using OnTap.Item;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTap.IO
{
    public class TextDataSource : IDataSource
    {
        public string _filePath;

        public TextDataSource(string filePath)
        {
            this._filePath = filePath;
        }

        public List<Khoa> GetKhoas()
        {
            List<Khoa> dsKhoa = new List<Khoa>();
            if (File.Exists(_filePath))
            {
                using (var stream = new FileStream(_filePath,FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var sinhViens = ParseSV(line);

                            int vtKhoa = dsKhoa.FindIndex(x => x.TenKhoa == sinhViens.Khoa); //Rìm vị trí của khoa trong ds khoas
                            if (vtKhoa == -1)
                            {
                                Khoa khoa = new Khoa(sinhViens.Khoa); //Tạo ds khoa
                                khoa.AddSV(sinhViens); //Thêm sv vào khoa và lớp
                                dsKhoa.Add(khoa); //Thêm khoa vào ds khoas
                            }
                            else
                            {
                                dsKhoa[vtKhoa].AddSV(sinhViens);
                            }
                        }
                    }
                }
            }
            return dsKhoa;
        }

        public void Save(List<Khoa> khoas)
        {
            throw new NotImplementedException();
        }

        private SinhVien ParseSV(string line)
        {
            var parts = line.Split('\t');
            SinhVien sv = new SinhVien();

            sv.Id = parts[0];
            sv.HoVaTenLot = parts[1];
            sv.Ten = parts[2];
            sv.Lop = parts[3];
            sv.Khoa = parts[4];
            if(parts.Length > 5)
            {
                sv.GioiTinh = parts[5] == "Nam" ? true : false;
                sv.NgaySinh = DateTime.Parse(parts[6]);
                sv.Sdt = parts[7];
                sv.DiaChi = parts[8];
            }
            return sv;
        }
    }
}
