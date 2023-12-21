using PizzaDelivery.Model.Entities;
using PizzaDelivery.Utilities;
using PizzaDelivery.View.ClientWindows;
using PizzaDelivery.View.ViewForCRUD;
using PizzaDelivery.ViewModel.CustomEntities;
using PizzaDelivery.ViewModel.ForClientWindows;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PizzaDelivery.ViewModel.ForClientPages
{
    public class CartViewModel : ViewModelBase
    {
        private ObservableCollection<PizzaInCart> _pizzasInCart;
        private int _totalPrice;
        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }
        public int TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; OnPropertyChanged(nameof(TotalPrice)); }
        }
        public ObservableCollection<PizzaInCart> PizzasInCart
        {
            get { return _pizzasInCart; }
            set { _pizzasInCart = value; OnPropertyChanged(nameof(PizzasInCart)); }
        }

        public ICommand AddToQuantityCommand { get; set; }
        public ICommand SubtractFromQuantityCommand { get; set; }
        public ICommand MakeOrderCommand { get; set; }

        private Client curClient;
        public CartViewModel(ObservableCollection<PizzaInCart> pizzas, Client client)
        {
            curClient = client;
            AddToQuantityCommand = new RelayCommand(AddToQuantity);
            SubtractFromQuantityCommand = new RelayCommand(SubtractFromQuantity);
            MakeOrderCommand = new RelayCommand(MakeOrder);
            PizzasInCart = pizzas;
            TotalPrice = PizzasInCart.Select(p => p.Price).Sum();
        }

        MakeOrder window = null;
        private void MakeOrder(object obj)
        {
            if (PizzasInCart.Count > 0)
            {
                if (window != null) window.Close();
                window = new MakeOrder();
                MakeOrderViewModel viewModel = new MakeOrderViewModel(PizzasInCart, curClient);
                window.Closed += (s, e) =>
                {
                    TotalPrice = 0;
                    PizzasInCart.Clear();
                };
                window.DataContext = viewModel;
                window.Show();
            }
            else ErrorMessage = "Корзина пуста, вы не можете сделать заказ";
        }

        private void SubtractFromQuantity(object obj)
        {
            if (obj is PizzaInCart pizza)
            { 
                TotalPrice -= pizza.Price / pizza.Quantity;
                pizza.Price -= pizza.Price / pizza.Quantity;
                pizza.Quantity--;

                if (pizza.Quantity == 0)
                {
                    PizzasInCart.Remove(pizza);
                }
            }
        }

        private void AddToQuantity(object obj)
        {
            if (obj is PizzaInCart pizza)
            {
                TotalPrice+= pizza.Price / pizza.Quantity;
                pizza.Price += pizza.Price / pizza.Quantity;
                pizza.Quantity++;
                
            }
        }

    }
}
