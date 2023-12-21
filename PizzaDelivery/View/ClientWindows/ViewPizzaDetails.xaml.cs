using System.Windows;
using System.Windows.Input;

namespace PizzaDelivery.View.ClientWindows
{
    /// <summary>
    /// Логика взаимодействия для ViewPizzaDetails.xaml
    /// </summary>
    public partial class ViewPizzaDetails : Window
    {
        public ViewPizzaDetails()
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
