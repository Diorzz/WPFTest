using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BindingTest.Pages
{
    /// <summary>
    /// Interaction logic for Binding_Third.xaml
    /// </summary>
    public partial class Binding_Third : UserControl
    {
        public Binding_Third()
        {
            InitializeComponent();
            List<StudentS> stulist = new List<StudentS>() 
            {
                new StudentS("ZZ","男",23)
            };
            tb1.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = stulist });
            tb2.SetBinding(TextBox.TextProperty, new Binding("Sex") { Source = stulist });
            tb3.SetBinding(TextBox.TextProperty, new Binding("Age") { Source = stulist });
        }
    }
    class StudentS
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Id { get; set; }

        public StudentS(string name,string sex,int id)
        {
            this.Name = name;
            this.Sex = sex;
            this.Id = id;
        }
    }
}
