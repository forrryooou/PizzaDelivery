﻿using LAB5.Repository;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Utilities;
using PizzaDelivery.View.ClientWindows;
using PizzaDelivery.View.ViewForCRUD;
using PizzaDelivery.ViewModel.CustomEntities;
using PizzaDelivery.ViewModel.ForClientWindows;
using PizzaDelivery.ViewModel.ForCRUD;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PizzaDelivery.ViewModel.ForClientPages
{
    public class MenuViewModel : ViewModelBase
    {
        private DbRepos context;

        private ObservableCollection<Pizza> _pizzas;
        public ObservableCollection<Pizza> Pizzas
        {
            get { return _pizzas; }
            set { _pizzas = value; OnPropertyChanged(nameof(Pizzas)); }
        }

        public ICommand ViewPizzaCommand { get; set; }
        public ICommand EditPizzaCommand { get; set; }


        private ClientViewModel clientViewModel;
        public ICommand AddPizzaToCartCommand { get; set; }
        public MenuViewModel(ClientViewModel _clientViewModel)
        {
            AddPizzaToCartCommand = new RelayCommand(AddPizza);
            clientViewModel = _clientViewModel;
            ViewPizzaCommand = new RelayCommand(ViewPizza);
            context = new DbRepos();
            Pizzas = context.Pizzas.GetList();

        }

        private void AddPizza(object obj)
        {
            if (obj is Pizza pizza)
            {
                var existingPizza = clientViewModel.PizzasInCart.FirstOrDefault(p => p.Id == pizza.Id);
                if (existingPizza != null)
                {
                    existingPizza.Quantity++;
                    existingPizza.Price += pizza.Price;
                }
                else clientViewModel.PizzasInCart.Add(new PizzaInCart(pizza));
            }

        }

        private ViewPizzaDetails pizzaDetails = null;
        private void ViewPizza(object obj)
        {
            if (obj is Pizza pizza)
            {
                if (pizzaDetails != null) pizzaDetails.Close();
                pizzaDetails = new ViewPizzaDetails();
                ViewPizzaDetailsViewModel viewModel = new ViewPizzaDetailsViewModel(context.Pizzas.GetItem(pizza.Id));
                pizzaDetails.DataContext = viewModel;
                pizzaDetails.Show();
            }
        }

        private void CreatePizza(object obj)
        {
            AddPizza addPizza = new AddPizza();
            AddPizzaViewModel viewModel = new AddPizzaViewModel();
            addPizza.DataContext = viewModel;
            addPizza.Closed += (s, e) => Pizzas = context.Pizzas.GetList();
            addPizza.Show();
        }
    }
}