using PizzaDelivery.Utilities;
using PizzaDelivery.ViewModel.ForAdminPages;
using System.Windows.Input;

namespace PizzaDelivery.ViewModel
{
    public class AdminViewModel : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(nameof(CurrentView)); }
        }

        public ICommand OrdersCommand { get; set; }
        public ICommand PizzasCommand { get; set; }
        public ICommand IngredientsCommand { get; set; }
        public ICommand ClientsCommand { get; set; }
        public ICommand ReportsCommand { get; set; }

        private void Orders(object obj) => CurrentView = new OrdersViewModel();
        private void Pizzas(object obj) => CurrentView = new PizzasViewModel();
        private void Ingredients(object obj) => CurrentView = new IngredientsViewModel();
        private void Clients(object obj) => CurrentView = new ClientsViewModel();
        private void Reports(object obj) => CurrentView = new ReportsViewModel();

        public AdminViewModel()
        {
            OrdersCommand = new RelayCommand(Orders);
            PizzasCommand = new RelayCommand(Pizzas);
            IngredientsCommand = new RelayCommand(Ingredients);
            ClientsCommand = new RelayCommand(Clients);
            ReportsCommand = new RelayCommand(Reports);

            CurrentView = new PizzasViewModel();
        }
    }
}
