using PizzaDelivery.View;
using System.Windows;

namespace PizzaDelivery
{
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {


            var loginView = new LoginView();
            loginView.Show();
        }
    }
}
