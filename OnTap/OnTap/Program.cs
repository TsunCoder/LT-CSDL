using OnTap.IO;
using OnTap.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnTap
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IDataSource dataSource = new TextDataSource(@"D:\Study\Lập trình cơ sở dữ liệu\OnTap\OnTap\Data\Data.txt");
            QuanLySinhVIen qlsv = new QuanLySinhVIen(dataSource);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormQuanLy(qlsv));
        }
    }
}
