using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Bir_Art_Calc
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Directory.Exists(@"C:\Calculator\save")) Directory.CreateDirectory(@"C:\Calculator\save");
            if (!File.Exists(@"C:\Calculator\save\save.txt")) File.Create(@"C:\Calculator\save\save.txt");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
