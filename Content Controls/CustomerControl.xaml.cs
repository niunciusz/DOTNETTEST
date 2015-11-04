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
    /// Interaction logic for CustomerControl.xaml
    /// </summary>
    public partial class CustomerControl : UserControl
    {
        private List<Control> boxes = new List<Control>();

        public void FillCustomer (Customer customer)
        {
            this.City.Text = customer.City;
            this.Name.Text=customer.ContactName;
            this.Phone.Text=customer.Phone;
            this.Fax.Text=customer.Fax;
            this.Address.Text=customer.Address;
            this.Company.Text=customer.CompanyName;
            this.Code.Text=customer.PostalCode;
            this.Country.Text=customer.Country;
            this.Title.Text=customer.ContactTitle;
            this.Id.Text=customer.CustomerID;
            this.Region.Text = customer.Region;
        }
        public CustomerControl()
        {
           
            InitializeComponent();
            var controls = this.grid.Children;
            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    control.IsEnabled = false;
                    control.BorderBrush = Brushes.Transparent;
                    control.Background = Brushes.Transparent;
                    control.Foreground = Brushes.Black;
                }
            }
        
        }

        private void block_input() 
        {
        
        
        }
        private void EditContent(object sender, RoutedEventArgs e)
        {
           
            
            var controls = this.grid.Children;
            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    control.IsEnabled = true;
                    boxes.Add(control);
                }

            }
            this.Edit.Visibility = Visibility.Hidden;
            this.Cancel.Visibility = Visibility.Visible;
            this.Save.Visibility = Visibility.Visible;

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

            this.Save.Visibility = Visibility.Hidden;
        }

        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            var controls = this.grid.Children;
            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    control.IsEnabled = false;
                    control.Foreground = Brushes.Black;
                }

            }

            this.Edit.Visibility = Visibility.Visible;
            this.Cancel.Visibility = Visibility.Hidden ;
            this.Save.Visibility = Visibility.Hidden;
        }

        private void CancelChanges(object sender, RoutedEventArgs e)
        {
            //TODO DOESNT CANCEL ANYTHING 
            var controls = this.grid.Children;
            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    control.IsEnabled = false;
                    control.Foreground = Brushes.Black;
                }

            }

            this.Edit.Visibility = Visibility.Visible;
            this.Cancel.Visibility = Visibility.Hidden;
            this.Save.Visibility = Visibility.Hidden;
        }


    }
}
