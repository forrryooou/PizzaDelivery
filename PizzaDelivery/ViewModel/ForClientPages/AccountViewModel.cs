using LAB5.Repository;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Utilities;
using System.Linq;
using System.Windows.Input;

namespace PizzaDelivery.ViewModel.ForClientPages
{
    public class AccountViewModel : ViewModelBase
    {
        private string _name;
        private string _number;
        private string _address;
        private string _username;
        private string _password;
        private string _newPassword;
        private string _errorMessage;

        public string Name { get => _name; set { _name = value; OnPropertyChanged(nameof(Name)); } }
        public string Number { get => _number; set { _number = value; OnPropertyChanged(nameof(Number)); } }
        public string Address { get => _address; set { _address = value; OnPropertyChanged(nameof(Address)); } }
        public string Username { get => _username; set { _username = value; OnPropertyChanged(nameof(Username)); } }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string NewPassword { get => _newPassword; set { _newPassword = value; OnPropertyChanged(nameof(NewPassword)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }

        public ICommand SaveChangesCommand { get; set; }

        private Client curClient;
        private DbRepos context;
        public AccountViewModel(Client client)
        {
            context = new DbRepos();
            curClient = context.Clients.GetList().First(c => c.Id == client.Id);
            Name = curClient.Name;
            Number = curClient.Number;
            if (curClient.Address != null) Address = curClient.Address;
            Username = curClient.User.UserName;

            SaveChangesCommand = new RelayCommand(SaveChanges);
        }

        private void SaveChanges(object obj)
        {
            bool canSave = true;
            if (string.IsNullOrWhiteSpace(Name))
            {
                ErrorMessage = "Не все поля заполнены";
                canSave = false;
            }
            else curClient.Name = Name;
            if (string.IsNullOrWhiteSpace(Number))
            {
                ErrorMessage = "Не все поля заполнены";
                canSave = false;
            }
            else curClient.Number = Number;
            curClient.Address = Address;
            if (string.IsNullOrWhiteSpace(Username))
            {
                ErrorMessage = "Не все поля заполнены";
                canSave = false;
            }
            else if (Username != curClient.User.UserName)
            {
                var exist = context.Users.GetList().FirstOrDefault(u => u.UserName == Username);
                if (exist == null) curClient.User.UserName = Username;
                else
                {
                    ErrorMessage = "Имя пользователя занято";
                    canSave = false;
                }
            }
            if (curClient.User.Password != Password && !string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Неверный пароль";
                canSave = false;
            }
            if (!string.IsNullOrWhiteSpace(NewPassword)) curClient.User.Password = NewPassword;

            if (canSave)
            {
                ErrorMessage = string.Empty;
                context.Clients.Update(curClient);
                context.Save();
                context.Users.Update(curClient.User);
                context.Save();
            }
        }
    }
}
