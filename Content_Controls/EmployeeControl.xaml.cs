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
    /// Interaction logic for EmployeeControl.xaml
    /// </summary>
    public partial class EmployeeControl : UserControl
    {
        private List<Control> boxes = new List<Control>();

        

        public void FillEmployee(Employee employee)
        {
            
            this.EmployeeID.Text = employee.EmployeeID.ToString();
            this.LastName.Text=employee.LastName;
            this.FirstName.Text=employee.FirstName;
            this.Title.Text=employee.Title;
            this.BirthDate.Text=employee.BirthDate.ToString();
            this.Address.Text=employee.Address;
            this.City.Text=employee.City;
            this.Region.Text=employee.Region;
            this.PostalCode.Text=employee.PostalCode;
            this.Country.Text=employee.Country;
            this.HomePhone.Text = employee.HomePhone;
           
            
            this.Extension.Text=employee.Extension;
            this.Notes.Text = employee.Notes;
            //this.Photo.Text=employee.Photo;
            this.ReportsTo.Text = employee.ReportsTo.ToString();
            //this.PhotoPath.Text=employee.PhotoPath;
           

            
            
        }

         public EmployeeControl()
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
