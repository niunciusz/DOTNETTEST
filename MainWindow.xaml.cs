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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
        
            InitializeComponent();
            CenterWindowOnScreen();
            NORTHWNDEntities e = new NORTHWNDEntities();
            List<Customer> customers = new List<Customer>();
          
            foreach (Customer customer in e.Customers)
                customers.Add(customer);
          

          
            foreach(Customer customer in customers)
            {
                CustomerControl c = new CustomerControl();
                c.FillCustomer(customer);
                c.Visibility = Visibility.Visible;
                this.MainPanel.Children.Add(c);
            }
            this.Show();
         
     
        }

        
        private void LogOut(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();

        }
        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void ProductsUnselected(object sender, RoutedEventArgs e)
        {
            ProductFilter.Visibility = Visibility.Hidden;
        }

        private void ProductsSelected(object sender, RoutedEventArgs e)
        {
            ProductFilter.Visibility = Visibility.Visible;
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CustomersSelected(object sender, RoutedEventArgs e)
        {
           this.MainViewer.Visibility = Visibility.Visible;
           this.MainPanel.Visibility = Visibility.Visible;
           foreach (Control c in this.MainPanel.Children)
                c.Visibility = Visibility.Visible;
           CustomerFilter.Visibility = Visibility.Visible;
        }

        private void CustomersUnselected(object sender, RoutedEventArgs e)
        {
            this.MainViewer.Visibility = Visibility.Hidden;
           this.MainPanel.Visibility = Visibility.Hidden;
           foreach (Control c in this.MainPanel.Children)
                c.Visibility = Visibility.Hidden;
           CustomerFilter.Visibility = Visibility.Hidden;
        }

        private void OrdersSelected(object sender, RoutedEventArgs e)
        {
            OrderFilter.Visibility = Visibility.Visible;
        }

        private void OrdersUnselected(object sender, RoutedEventArgs e)
        {
            OrderFilter.Visibility = Visibility.Hidden;
        }

        private void EmployeesSelected(object sender, RoutedEventArgs e)
        {
            EmployeeFilter.Visibility = Visibility.Visible;
        }

        private void EmployeesUnselected(object sender, RoutedEventArgs e)
        {
            EmployeeFilter.Visibility = Visibility.Hidden;
        }

       
    }
}
