using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSinhVien.Info
{
    public class Students
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string Class { get; set; }
        public string Image { get; set; }
        public bool Sex { get; set; }
        public List<string> Specialized { get; set; }

        public Students()
        {
            Specialized = new List<string>();
        }

        public Students(string id, string name, DateTime birth, string address, string _class, string image, bool sex, List<string> specialized)
        {
            this.Id = id;
            this.Name = name;
            this.BirthDay = birth;
            this.Address = address;
            this.Class = _class;
            this.Image = image;
            this.Sex = sex;
            this.Specialized = specialized;
        }
    }
}
