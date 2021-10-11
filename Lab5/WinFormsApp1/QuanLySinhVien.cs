using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.IO;

namespace WinFormsApp1
{
    public class QuanLySinhVien
    {
        public List<SinhVien> list;

        private IDataSource _dataSource;
        public QuanLySinhVien()
        {
            list = new List<SinhVien>();
            _dataSource = new TextDataSource();
            //_dataSource = new JsonDataSource();
            list = _dataSource.GetSinhViens();
        }

        public void Them(SinhVien sv)
        {
            list.Add(sv);
        }

        public bool Tim(SinhVien sv)
        {
            var kq = list.Find(p => p.Id == sv.Id);
            if (kq == null)
            {
                return true;
            }
            return false;
        }

        public void Xoa(string id)
        {
            for (int i = this.list.Count - 1; i >= 0; i--)
            {
                if (list[i].Id == id)
                {
                    this.list.RemoveAt(i);
                }
            }
        }
        public void Sua(SinhVien sv)
        {
            var kq = list.Find(p => p.Id == sv.Id);
            if (kq == null)
            {
                return;
            }
            else
            {
                list.RemoveAll(p => p.Id == sv.Id);
                list.Add(sv);
            }
        }

        public List<SinhVien> GetSinhViens()
        {
            if (list == null)
            {
                list = _dataSource.GetSinhViens();

            }
            return list;
        }
        public void SaveSinhVien()
        {
            _dataSource.Save(list);
        }
    }
}
