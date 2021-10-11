using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.IO
{
    public interface IDataSource
    {
        List<SinhVien> GetSinhViens();

        void Save(List<SinhVien> sv);
    }
}
