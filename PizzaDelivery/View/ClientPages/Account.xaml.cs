using PizzaDelivery.ViewModel.ForClientPages;
using System.Windows;
using System.Windows.Controls;

namespace PizzaDelivery.View.ClientPages
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : UserControl
    {
        public Account()
        {
            InitializeComponent();
        }
        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
                ((AccountViewModel)this.DataContext).Password = ((PasswordBox)sender).Password;
        }

        private void txtNewPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
                ((AccountViewModel)this.DataContext).NewPassword = ((PasswordBox)sender).Password;
        }
    }
}
