using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

namespace TachoLibrary
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    /// 
    public partial class UserControl1 : UserControl
    {
        public double Radius { get; set; }
        public UserControl1()
        {
            InitializeComponent();
        }

        private void sld_Range_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            can_Tacho.Children.Clear();
            pbar_tacho.Value = (double)e.NewValue;
            lb_an.Content = "Analog Value: " + (double)e.NewValue;
            Radius = can_Tacho.ActualWidth / 2 > can_Tacho.ActualHeight * 0.9 ? can_Tacho.ActualHeight * 0.9 : can_Tacho.ActualWidth / 2;
            TachoDraw();
            NeedleDraw();
        }

        private void NeedleDraw()
        {
            if(sld_Range!=null)
            {
                Line Needle = new Line
                {
                    Stroke = new SolidColorBrush(Colors.Yellow),
                    StrokeThickness = 2,
                    X1 = can_Tacho.ActualWidth / 2,
                    Y1 = can_Tacho.ActualHeight * 0.9,
                    X2 = can_Tacho.ActualWidth / 2 - Radius * 0.75,
                    Y2 = can_Tacho.ActualHeight * 0.9

                };

                RotateTransform rotateNeedle = new RotateTransform(sld_Range.Value, Needle.X1, Needle.Y1);



                Needle.RenderTransform = rotateNeedle;

                can_Tacho.Children.Add(Needle);
            }
           
        }

        private void TachoDraw()
        {
            for (int angle = 0; angle <= 180; angle += 10)
            {
                //scalenstriche
                Line scaleLine = new Line
                {
                    Stroke = new SolidColorBrush(Colors.White),
                    StrokeThickness = 2,
                    X1 = can_Tacho.ActualWidth / 2 - Radius * 0.8,
                    Y1 = can_Tacho.ActualHeight * 0.9,
                    X2 = can_Tacho.ActualWidth / 2 - Radius * 0.85,
                    Y2 = can_Tacho.ActualHeight * 0.9


                };



                RotateTransform rotateScale = new RotateTransform(angle,can_Tacho.ActualWidth / 2, can_Tacho.ActualHeight*0.9);
                scaleLine.RenderTransform = rotateScale;
                can_Tacho.Children.Add(scaleLine);
            }
            }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            can_Tacho.Children.Clear();
            Radius = can_Tacho.ActualWidth / 2 > can_Tacho.ActualHeight * 0.9 ? can_Tacho.ActualHeight * 0.9 : can_Tacho.ActualWidth / 2;
            TachoDraw();
            NeedleDraw();
        }
    }
}