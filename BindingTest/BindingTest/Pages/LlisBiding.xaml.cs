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
    /// Interaction logic for IlisBiding.xaml
    /// </summary>
    public partial class IlisBiding : UserControl
    {
        public IlisBiding()
        {
            InitializeComponent();
            List<StudentX> stu = new List<StudentX>() 
            {
                new StudentX(){Name="ZZ",Sex="男",Id=1001},
                new StudentX(){Name="YY",Sex="女",Id=1002}
                //new StudentX("XX","男",1004)
            };

            this.lb11.ItemsSource = stu;

            FontFamily f = new System.Windows.Media.FontFamily(new Uri(""), "");


            Binding bd = new Binding("SelectedItem.Name") { Source = this.lb11};
            this.tb11.SetBinding(TextBox.TextProperty, bd);
        }
    }
    class StudentX
    {
        //public StudentX(string name, string sex, int id)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //    this.Sex = sex;
        //}
        public string Name { get; set; }
        public int Id { get; set; }

        public string Sex { get; set; }
    }
    
    
}
