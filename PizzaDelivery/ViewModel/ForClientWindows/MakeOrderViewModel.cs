using LAB5.Repository;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Utilities;
using PizzaDelivery.View.ClientWindows;
using PizzaDelivery.ViewModel.CustomEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PizzaDelivery.ViewModel.ForClientWindows
{
    public class MakeOrderViewModel : ViewModelBase
    {
        private DbRepos context;
        private ObservableCollection<PaymentMethod> _paymentMethods;
        private int _paymentId;
        private string _address;
        private string _orderedPizzas;
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
        public string OrderedPizzas
        {
            get { return _orderedPizzas; }
            set { _orderedPizzas = value; OnPropertyChanged(nameof(OrderedPizzas)); }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChanged(nameof(Address)); }
        }
        public ObservableCollection<PaymentMethod> PaymentMethods
        {
            get { return _paymentMethods; }
            set { _paymentMethods = value; OnPropertyChanged(nameof(PaymentMethods)); }
        }
        public int PaymentId
        {
            get { return _paymentId; }
            set { _paymentId = value; OnPropertyChanged(nameof(PaymentId)); }
        }

        public ICommand MakeOrderCommand { get; set; }

        private Client curClient;
        private ObservableCollection<PizzaInCart> pizzas;
        public MakeOrderViewModel(ObservableCollection<PizzaInCart> _pizzas, Client client)
        {
            curClient = client;
            pizzas = _pizzas;
            OrderedPizzas = string.Join(Environment.NewLine, pizzas.Select(p => $"{p.Quantity} x {p.Name}"));
            context = new DbRepos();
            TotalPrice = pizzas.Select(p => p.Price).Sum();
            PaymentMethods = context.PaymentMethods.GetList();
            if (curClient.Address != null) Address = curClient.Address;

            MakeOrderCommand = new RelayCommand(MakeOrder);
        }

        private void MakeOrder(object obj)
        {
            if (string.IsNullOrWhiteSpace(Address) || PaymentId == 0) ErrorMessage = "Не все поля заполнены";
            else
            {
                var orderLines = new ObservableCollection<OrderLine>();
                foreach (PizzaInCart p in pizzas)
                {
                    if (p.TypeId == 2)
                    {
                        Pizza clientPizza = new Pizza()
                        {
                            Name = p.Name,
                            TypeId = p.TypeId
                        };
                        foreach (var ing in p.Ingredients) clientPizza.Ingredients.Add(context.Ingredients.GetItem(ing.Id));
                        clientPizza.Price = clientPizza.Ingredients.Select(x => x.Price).Sum();
                        context.Pizzas.Create(clientPizza);
                        context.Save();
                        p.Id = clientPizza.Id;
                    }
                    var pizza = context.Pizzas.GetItem(p.Id);
                    var line = new OrderLine();
                    line.PizzaId = pizza.Id;
                    line.Quantity = p.Quantity;
                    orderLines.Add(line);
                }
                var newOrder = new Order
                {
                    Date = DateTime.Now,
                    PaymentId = PaymentId,
                    ClientId = curClient.Id,
                    Price = TotalPrice,
                    OrderLines = orderLines,
                    StatusId = 1
                };
                context.Orders.Create(newOrder);
                context.Save();
                if (obj is Window window) window.Close();
            }
            
        }
    }
}
