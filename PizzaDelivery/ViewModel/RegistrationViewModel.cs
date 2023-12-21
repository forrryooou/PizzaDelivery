using LAB5.Repository;
using PizzaDelivery.Model.Data;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Model.Repositories.Base;
using PizzaDelivery.Utilities;
using PizzaDelivery.View;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PizzaDelivery.ViewModel
{
    class RegistrationViewModel : ViewModelBase
    {
        private string _name;
        private string _number;
        private string _username;
        private string _password;
        private string _errorMessage;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                OnPropertyChanged(nameof(Number));
            }
        }
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

        public ICommand RegistrCommand { get; set; }

        DbRepos context;
        public RegistrationViewModel()
        {
            context = new DbRepos();
            RegistrCommand = new RelayCommand(Registration);
        }

        private void Registration(object obj)
        {
            if (Number == null || Name == null || Password == null || Username == null)
                ErrorMessage = "Не все поля заполнены";
            else
            {
                if (Username == context.Users.GetList().Where(i => i.UserName == Username).Select(i => i.UserName).FirstOrDefault())
                    ErrorMessage = "Имя пользователя занято";
                else
                {
                    User user = new User();
                    user.UserName = Username;
                    user.Password = Password;
                    user.UserTypeId = 2;
                    context.Users.Create(user);
                    context.Save();

                    Client client = new Client();
                    client.Name = Name;
                    client.Number = Number;
                    client.UserId = context.Users.GetList().Where(i => i.UserName == user.UserName).Select(i => i.Id).First();
                    context.Clients.Create(client);
                    context.Save();
                    var clientWindow = new ClientWindow();
                    var viewModel = new ClientViewModel(user);
                    clientWindow.DataContext = viewModel;
                    clientWindow.Show();
                    if (obj is Window window) window.Close();
                }
            }
        }

    }
}
