using OnTap.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTap.IO
{
    public interface IClass
    {
        void Save(List<SinhVien> sv, string _filePath);
    }
}
