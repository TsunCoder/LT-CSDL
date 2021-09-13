using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSinhVien.Info
{
    public delegate int Compare(object obj1, object obj2);
    public class StudentsManagement
    {
        public List<Students> List;
        public StudentsManagement()
        {
            List = new List<Students>();
        }

        public void Add(Students st)
        {
            this.List.Add(st);
        }

        public Students this[int index]
        {
            get { return List[index]; }
            set { List[index] = value; }
        }

        public void Remove(object obj, Compare cp)
        {
            int i = List.Count - 1;
            for (;  i >= 0; i--)
            {
                if(cp(obj, this[i]) == 0)
                {
                    this.List.RemoveAt(i);
                }
            }
        }

        public Students Search(object obj, Compare cp)
        {
            Students studentsResult = null;
            foreach (Students students in List)
            {
                if(cp(obj,students) == 0)
                {
                    studentsResult = students;
                    break;
                }
            }
            return studentsResult;
        }

        public bool Update(Students stUpdate, object obj, Compare cp)
        {
            int i, count;
            bool kq = false;
            count = this.List.Count - 1;
            for (i = 0; i < count; i++)
            {
                if (cp(obj, this[i]) == 0)
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
            string filename = "DanhSachSV.txt", t;
            string[] s;
            Students sv;
            using (var stream = new FileStream(filename, FileMode.Open))
            {
                using (var reader = new StreamReader(stream))
                {
                    while ((t = reader.ReadLine()) != null)
                    {
                        s = t.Split('\t');
                        sv = new Students();
                        sv.Id = s[0];
                        sv.Name = s[1];
                        sv.BirthDay = DateTime.Parse(s[2]);
                        sv.Address = s[3];
                        sv.Class = s[4];
                        sv.Image = s[5];

                        sv.Sex = false;
                        if (s[6] == "1")
                            sv.Sex = true;
                        string[] cn = s[7].Split(',');
                        foreach (string c in cn)
                        {
                            sv.Specialized.Add(c);
                        }
                        this.Add(sv);
                    }
                }
            }
        }
    }
}
