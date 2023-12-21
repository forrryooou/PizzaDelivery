using System.Windows;
using System.Windows.Input;

namespace PizzaDelivery.View
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow()
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

        private bool isMaximized = false;
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {

            if (isMaximized)
            {
                this.WindowState = WindowState.Normal;
                this.Width = 1080;
                this.Height = 720;
                isMaximized = false;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                isMaximized = true;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void rdExit_Click(object sender, RoutedEventArgs e)
        {
            LoginView login = new LoginView();
            login.Show();
            this.Close();
        }
    }
}
