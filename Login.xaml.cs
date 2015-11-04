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
using System.Windows.Shapes;

namespace dotnet
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            this.MaxHeight = this.MinHeight = this.Height;
            this.MinWidth = this.MaxWidth = this.Width;
            this.login_button.IsEnabled = false;
            X x = new X();
            this.grid.Children.Add(x);
            Grid.SetColumn(x, 2);
            Grid.SetRow(x, 0);
            this.login_box.Focus();
            CenterWindowOnScreen();
        }

        private void login_button_Click(object sender, RoutedEventArgs e)
        {
            if (!(this.login_box.Text == "" || this.password_box.Password == ""))
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
        }


        private void login_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(this.login_box.Text == "" || this.password_box.Password == ""))
            {
                this.login_button.Background = Brushes.DeepSkyBlue;
                this.login_button.IsEnabled = true;
            }
            else
            {
                this.login_button.ClearValue(Button.BackgroundProperty);
                this.login_button.IsEnabled = false;
            }
        }

        private void password_box_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!(this.login_box.Text == "" || this.password_box.Password == ""))
            {
                this.login_button.Background = Brushes.DeepSkyBlue;
                this.login_button.IsEnabled = true;
            }
            else
            {
                this.login_button.ClearValue(Button.BackgroundProperty);
                this.login_button.IsEnabled = false;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                if (this.login_button.IsEnabled == true)
                    login_button_Click(null, null);
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource == this)
                this.login_box.Focus();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            this.login_box.Focus();
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
    }
}
