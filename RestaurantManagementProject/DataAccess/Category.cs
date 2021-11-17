using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Category
    {
        // ID của bảng, Tự tăng
        public int ID { get; set; }
        // Tên loại thức ăn
        public string Name { get; set; }
        // Kiểu: 0(Đồ uống), 1(Thức ăn)
        public int Type { get; set; }

    }
}
