using LAB5.Repository;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Utilities;
using PizzaDelivery.ViewModel.CustomEntities;
using PizzaDelivery.ViewModel.ForClientPages;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PizzaDelivery.ViewModel
{
    public class ClientViewModel : ViewModelBase
    {
        private ObservableCollection<PizzaInCart> _pizzasInCart;
        public ObservableCollection<PizzaInCart> PizzasInCart { get { return _pizzasInCart; } set { _pizzasInCart = value; OnPropertyChanged(nameof(PizzasInCart)); } }
        private object _currentView;
        public object CurrentView { get { return _currentView; } set { _currentView = value; OnPropertyChanged(nameof(CurrentView)); } }

        private Client _curClient;
        public Client CurClient { get { return _curClient; } set { _curClient = value;OnPropertyChanged(nameof(CurClient)); } }

        public ICommand ViewMenuCommand { get; set; }
        public ICommand ViewCartCommand { get; set; }
        public ICommand ViewOrdersCommand { get; set; }
        public ICommand ViewAccountCommand { get; set; }

        private void Menu(object obj) => CurrentView = new MenuViewModel(this);
        private void Cart(object obj) => CurrentView = new CartViewModel(PizzasInCart,CurClient);
        private void Orders(object obj) => CurrentView = new HistoryOfOrdersViewModel(CurClient);
        private void Account(object obj) => CurrentView = new AccountViewModel(CurClient);

        private DbRepos context;
        public ClientViewModel(User user)
        {
            context = new DbRepos();
            PizzasInCart = new ObservableCollection<PizzaInCart>();
            var client = context.Clients.GetList().FirstOrDefault(i => i.UserId == user.Id);
            if (client != null) CurClient = client;

            ViewAccountCommand = new RelayCommand(Account);
            ViewCartCommand = new RelayCommand(Cart);
            ViewMenuCommand = new RelayCommand(Menu);
            ViewOrdersCommand = new RelayCommand(Orders);

            CurrentView = new MenuViewModel(this);
        }
    }
}
