using System.Windows;
using System.Windows.Input;

namespace PizzaDelivery.View.ClientWindows
{
    /// <summary>
    /// Логика взаимодействия для AddClientPizza.xaml
    /// </summary>
    public partial class AddClientPizza : Window
    {
        public AddClientPizza()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
