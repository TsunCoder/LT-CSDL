using OnTap.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTap.Item
{
    public class QuanLySinhVIen
    {
        public IDataSource _dataSource;
        public List<Khoa> dsKhoa;
        public List<SinhVien> dssv;
        public QuanLySinhVIen(IDataSource dataSource)
        {
            this._dataSource = dataSource;
            dsKhoa = _dataSource.GetKhoas(); // lay ds file truyen vo ds ql
        }

        public Khoa this[int index]
        {
            get { return dsKhoa[index]; }
            set { dsKhoa[index] = value; }
        }

        public void SaveJson(List<SinhVien> sv, string _filePath)
        {
            IClass dataLop = new JsonDataSource();
            dataLop.Save(sv, _filePath);
           
        }

        public void ThemSV(SinhVien sv)
        {
            Khoa khoa = dsKhoa.Find(x => x.TenKhoa == sv.Khoa);
            if(khoa != null)
            {
                khoa.AddSV(sv);
            }
        }

        public void SuaSV(SinhVien sv)
        {
            Khoa khoa = dsKhoa.Find(x => x.TenKhoa == sv.Khoa);
            if (khoa != null)
            {
                khoa.SuaSV(sv);
            }
        }
    }
}
