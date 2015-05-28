using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("ZZ", 1120020223, "网络2班");
            student.Show();
            student.ShowClass();
        }
    }
}
