using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ex1.info
{
    public delegate int SoSanh(object obj1, object obj2);
    public class QuanLySinhVien
    {
        public List<SinhVien> list;
        private const string _filePath = "SinhVien.txt";
        public QuanLySinhVien()
        {
            list = new List<SinhVien>();
        }

        public void Add(SinhVien sv)
        {
            this.list.Add(sv);
        }

        public SinhVien this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }

        public void Remove(object obj, SoSanh ss) {
            int i = list.Count - 1;
            for (;i >= 0; i--)
            {
                if(ss(obj, this[i]) == 0)
                {
                    this.list.RemoveAt(i);
                }
            }
        }

        public SinhVien Search(object obj, SoSanh ss)
        {
            SinhVien svKq = null;
            foreach (SinhVien students in list)
            {
                if (ss(obj, students) == 0)
                {
                    svKq = students;
                    break;
                }
            }
            return svKq;
        }

        public bool Update(SinhVien stUpdate, object obj,SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = this.list.Count;
            for (i = 0; i < count; i++)
            {
                if (ss(obj, this[i]) == 0)
                {
                    this[i] = stUpdate;
                    kq = true;
                    break;
                }
            }
            return kq;
        }

        public void DocTuFile()
        {
            string filename = "SinhVien.txt", t;
            string[] s;
            SinhVien sv;
            using (var stream = new FileStream(filename, FileMode.Open))
            {
                using (var reader = new StreamReader(stream))
                {
                    while ((t = reader.ReadLine()) != null)
                    {
                        s = t.Split('*');
                        sv = new SinhVien();
                        sv.Id = s[0];
                        sv.HoTen = s[1];
                        sv.GioiTinh = false;
                        if (s[2] == "1")
                            sv.GioiTinh = true;
                        sv.NgaySinh = DateTime.Parse(s[3]);
                        sv.Lop = s[4];
                        sv.Sdt = s[5];
                        sv.Email = s[6];
                        sv.DiaChi = s[7];
                        sv.Image = s[8];
                        this.Add(sv);
                    }
                }
            }
        }

        public void Save(List<SinhVien> dsSV)
        {
            using (var steam = new FileStream(_filePath, FileMode.Create, FileAccess.Write))
            {
                using (var write = new StreamWriter(steam))
                {
                    foreach (var sv in dsSV)
                    {
                        write.WriteLine("{0}*{1}*{2}*{3}*{4}*{5}*{6}*{7}*{8}*", sv.Id,
                             sv.HoTen, sv.GioiTinh == true ? "Nam" : "Nữ", sv.NgaySinh, sv.Lop, sv.Sdt,
                             sv.Email, sv.DiaChi, sv.Image);
                    }
                }
            }
        }
    }
}
