using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        Student stu;
        public Home()
        {
            InitializeComponent();

            //Binding
            stu = new Student();
            Binding binding = new Binding();
            binding.Path = new PropertyPath("Name");
            binding.Source = stu;
            binding.Mode = BindingMode.TwoWay;

            BindingOperations.SetBinding(this.tb, TextBox.TextProperty, binding);
        }

        private void bt_Click(object sender, RoutedEventArgs e)
        {
            stu.Name += "你好,";
        }
    }
    class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

    }
}
