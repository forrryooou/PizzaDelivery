using PizzaDelivery.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PizzaDelivery.View
{
    /// <summary>
    /// Логика взаимодействия для RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : Window
    {
        public RegistrationView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
                ((RegistrationViewModel)this.DataContext).Password = ((PasswordBox)sender).Password;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            LoginView login = new LoginView();
            login.Show();
            this.Close();
        }
    }
}
