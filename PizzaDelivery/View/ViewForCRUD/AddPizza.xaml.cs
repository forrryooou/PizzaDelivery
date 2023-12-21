using System.Windows;
using System.Windows.Input;

namespace PizzaDelivery.View.ViewForCRUD
{
    /// <summary>
    /// Логика взаимодействия для AddPizza.xaml
    /// </summary>
    public partial class AddPizza : Window
    {
        public AddPizza()
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
