using LAB5.Repository;
using PizzaDelivery.Utilities;
using PizzaDelivery.View;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PizzaDelivery.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        DbRepos context;
        private string _username;
        private string _password;
        private string _errorMessage;

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand RegistrationCommand { get; set; }

        public LoginViewModel()
        {
            context = new DbRepos();
            LoginCommand = new RelayCommand(Login);
            RegistrationCommand = new RelayCommand(Registration);
        }

        private void Registration(object obj)
        {
            var regView = new RegistrationView();
            regView.Show();
            if (obj is Window window) window.Close();
        }

        private void Login(object obj)
        {
            var user = context.Users.GetList().Where(u => u.Password == Password && u.UserName == Username).FirstOrDefault();
            if (user != default)
            {
                if (user.UserTypeId == 2)
                {
                    var clientWindow = new ClientWindow();
                    var viewModel = new ClientViewModel(user);
                    clientWindow.DataContext = viewModel;
                    clientWindow.Show();
                }
                else if (user.UserTypeId == 1)
                {
                    var adminWindow = new AdminWindow();
                    adminWindow.Show();
                }
                if (obj is Window window) window.Close();
            }
            else ErrorMessage = "Данные введены некорректно";
        }
    }
}
