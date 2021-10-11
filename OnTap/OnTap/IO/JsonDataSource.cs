using Newtonsoft.Json;
using OnTap.Item;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTap.IO
{
    class JsonDataSource : IClass
    {
        public void Save(List<SinhVien> sv, string _filePath)
        {
            var data = JsonConvert.SerializeObject(sv);
            File.WriteAllText(_filePath, data);
            
        }
    }
}
