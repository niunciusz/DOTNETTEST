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
using System.Threading;

namespace dotnet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Customer> customers = new List<Customer>();
        List<Employee> employees = new List<Employee>();
        List<Product> products = new List<Product>();
        List<Order> orders = new List<Order>();
        List<CustomerControl> CustomerControls = new List<CustomerControl>();
        List<ProductControl> ProductControls = new List<ProductControl>();
        List<EmployeeControl> EmployeeControls = new List<EmployeeControl>();
        List<OrderControl> OrderControls = new List<OrderControl>();

        bool CustomersLoaded = false;
        bool ProductsLoaded = false;
        bool CustomerDataLoaded = false;
        bool ProductDataLoaded = false;
        bool EmployeesLoaded = false;
        bool EmployeeDataLoaded = false;
        bool OrdersLoaded = false;
        bool OrderDataLoaded = false;
        int loaded = 0;
             
        public MainWindow()
        {
        
            InitializeComponent();
            CenterWindowOnScreen();
            this.Show();

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                NORTHWNDEntities e = new NORTHWNDEntities();
                foreach (Employee employee in e.Employees)
                {
                    if (loaded > 100)
                        break;

                    employees.Add(employee);
                    loaded++;
                }
                EmployeeDataLoaded = true;
                loaded = 0;


            }).Start();

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                NORTHWNDEntities e = new NORTHWNDEntities();
                
                    foreach (Order order in e.Orders)
                    {
                        if (loaded > 100)
                            break;

                        orders.Add(order);
                        loaded++;
                        
                    }
                
                OrderDataLoaded = true;
                loaded = 0;


            }).Start(); 

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                NORTHWNDEntities e = new NORTHWNDEntities();

                foreach (Customer customer in e.Customers)
                    customers.Add(customer);
                CustomerDataLoaded = true;



            }).Start();

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                NORTHWNDEntities e = new NORTHWNDEntities();
                foreach (Product product in e.Products)
                    products.Add(product);
                ProductDataLoaded = true;


            }).Start();

           
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
            this.MainViewer.Visibility = Visibility.Visible;
            this.MainPanel.Visibility = Visibility.Visible;
            this.MainPanel.Children.Clear();

            if (ProductDataLoaded && !ProductsLoaded)
            {

                ProductControls.Clear();

                foreach (Product product in products)
                {
                    ProductControl c = new ProductControl();
                    c.FillProduct(product);
                    c.Visibility = Visibility.Visible;
                    ProductControls.Add(c);

                }
                ProductsLoaded = true;
            }



            foreach (ProductControl p in ProductControls)
            {
                p.Visibility = Visibility.Visible;
                this.MainPanel.Children.Add(p);
            }
            
            
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CustomersSelected(object sender, RoutedEventArgs e)
        {
            this.MainViewer.Visibility = Visibility.Visible;
            this.MainPanel.Visibility = Visibility.Visible;
            Loading.Visibility = Visibility.Visible;
            /* foreach (Control c in this.MainPanel.Children)
                c.Visibility = Visibility.Visible;*/
            CustomerFilter.Visibility = Visibility.Visible;
            
            this.MainPanel.Children.Clear();
           
            if (CustomerDataLoaded && !CustomersLoaded)
            {
             

                 foreach (Customer customer in customers)
                 {
                    CustomerControl c = new CustomerControl();
                    c.FillCustomer(customer);
                    c.Visibility = Visibility.Visible;
                    CustomerControls.Add(c);
                 }
                 CustomersLoaded = true;
             }

             foreach (CustomerControl p in CustomerControls)
             {
                 p.Visibility = Visibility.Visible;
                 this.MainPanel.Children.Add(p);
             }
             if (CustomerDataLoaded && CustomersLoaded)
                 Loading.Visibility = Visibility.Hidden;

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
            this.MainViewer.Visibility = Visibility.Visible;
            this.MainPanel.Visibility = Visibility.Visible;
           
            

            this.MainPanel.Children.Clear();

            if (OrderDataLoaded && !OrdersLoaded)
            {

                OrderControls.Clear();

                foreach (Order order in orders)
                {
                    OrderControl c = new OrderControl();
                    c.FillOrder(order);
                    c.Visibility = Visibility.Visible;
                    OrderControls.Add(c);

                }
                OrdersLoaded = true;
            }



            foreach (OrderControl p in OrderControls)
            {
                p.Visibility = Visibility.Visible;
                this.MainPanel.Children.Add(p);
            }
            
        }

        private void OrdersUnselected(object sender, RoutedEventArgs e)
        {
            OrderFilter.Visibility = Visibility.Hidden;
            
            
        }

        private void EmployeesSelected(object sender, RoutedEventArgs e)
        {
            {
                this.MainViewer.Visibility = Visibility.Visible;
                this.MainPanel.Visibility = Visibility.Visible;

                EmployeeFilter.Visibility = Visibility.Visible;
                
                this.MainPanel.Children.Clear();

                if (CustomerDataLoaded && !CustomersLoaded)
                {


                    foreach (Employee employee in employees)
                    {
                        EmployeeControl c = new EmployeeControl();
                        c.FillEmployee(employee);
                        c.Visibility = Visibility.Visible;
                        EmployeeControls.Add(c);
                    }
                    EmployeesLoaded = true;
                }

                foreach (EmployeeControl p in EmployeeControls)
                {
                    p.Visibility = Visibility.Visible;
                    this.MainPanel.Children.Add(p);
                }

            }
        }

        private void EmployeesUnselected(object sender, RoutedEventArgs e)
        {
            this.MainViewer.Visibility = Visibility.Hidden;
            this.MainPanel.Visibility = Visibility.Hidden;
            foreach (Control c in this.MainPanel.Children)
                c.Visibility = Visibility.Hidden;
            EmployeeFilter.Visibility = Visibility.Hidden;
            
        }

       
    }
}
