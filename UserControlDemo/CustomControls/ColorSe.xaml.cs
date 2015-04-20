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
using System.Windows.Markup;

namespace CustomControls
{
    /// <summary>
    /// ColorSe.xaml 的交互逻辑
    /// </summary>
    public partial class ColorSe : UserControl
    {
        public ColorSe()
        {
            InitializeComponent();
        }

        public static DependencyProperty ColorProperty;
        public static DependencyProperty RedProperty;
        public static DependencyProperty GreenProperty;
        public static DependencyProperty BlueProperty;

        static ColorSe() 
        {
            ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(ColorSe),new FrameworkPropertyMetadata(Colors.Black,new PropertyChangedCallback(OnColorChanged)));
            RedProperty = DependencyProperty.Register("Red", typeof(byte), typeof(ColorSe), new FrameworkPropertyMetadata((byte)0, new PropertyChangedCallback(OnColorRGBChanged)));
            GreenProperty = DependencyProperty.Register("Green", typeof(byte), typeof(ColorSe), new FrameworkPropertyMetadata((byte)0, new PropertyChangedCallback(OnColorRGBChanged)));
            BlueProperty = DependencyProperty.Register("Blue", typeof(byte), typeof(ColorSe), new FrameworkPropertyMetadata((byte)0, new PropertyChangedCallback(OnColorRGBChanged)));

            ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorSe));
        }

        public Color Color 
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }
        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }
        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }
        private static void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) 
        {

            ColorSe ColorSe = (ColorSe)sender;
            Color oldColor = (Color)e.OldValue;
            Color newColor = (Color)e.NewValue;
            ColorSe.Red = newColor.R;
            ColorSe.Green = newColor.G;
            ColorSe.Blue = newColor.B;

            ColorSe.OnColorChanged(oldColor,newColor);


        }
        private static void OnColorRGBChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            

            ColorSe ColorSe = (ColorSe)sender;
            Color color = ColorSe.Color;

            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;

            ColorSe.Color = color;


            
        }

        public static readonly RoutedEvent ColorChangedEvent;

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { this.AddHandler(ColorChangedEvent, value); }

            remove { this.RemoveHandler(ColorChangedEvent, value); }
            
        }

        private void OnColorChanged(Color oldValue, Color newValue) 
        {
            RoutedPropertyChangedEventArgs<Color> args = new RoutedPropertyChangedEventArgs<Color>(oldValue, newValue);
            args.RoutedEvent = ColorSe.ColorChangedEvent;
            RaiseEvent(args);
        }
    }
}
