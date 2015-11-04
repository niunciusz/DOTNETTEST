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

namespace dotnet
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class X : UserControl
    {
   Line l1 = new Line();
        Line l2 = new Line();

        public X()
        {
            InitializeComponent();
            draw_cross();
            
        }

        private void draw_cross() 
        {
            l1.X1 = 0;
            l1.X2 = 10;
            l1.Y1 = 0;
            l1.Y2 = 10;
            l2.X1 = 10;
            l2.X2 = 0;
            l2.Y1 = 0;
            l2.Y2 = 10;
            l1.Stroke = Brushes.DeepSkyBlue;
            l2.Stroke = Brushes.DeepSkyBlue;
            this.c.Children.Add(l1);
            this.c.Children.Add(l2);
        }

        private void c_MouseEnter(object sender, MouseEventArgs e)
        {
            l1.Stroke = Brushes.Red;
            l2.Stroke = Brushes.Red;
            this.Cursor = Cursors.Hand;
        }

        private void c_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            l1.Stroke = Brushes.DeepSkyBlue;
            l2.Stroke = Brushes.DeepSkyBlue;
        }

        private void c_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
    }
    }
