using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Student
    {
        public string Name;
        public int ID;
        public string Class;

        public Student(string name,int id,string cls) 
        {
            this.Name = name;
            this.ID = id;
            this.Class = cls;
        }

        public void Show() 
        {
            Console.WriteLine("我的名字叫:{0},我的学号是:{1}", Name, ID);
        }

        public void ShowClass() 
        {
            Console.WriteLine("我的班级是：{0}", Class);
        }
    }
}
