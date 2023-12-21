using LAB5.Repository;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Utilities;
using PizzaDelivery.View.AdminPages;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PizzaDelivery.ViewModel.ForClientPages
{
    public class HistoryOfOrdersViewModel : ViewModelBase
    {
        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders { get => _orders; set { _orders = value; OnPropertyChanged(nameof(Orders)); } }

        DbRepos context;
        public HistoryOfOrdersViewModel()
        {
            context = new DbRepos();
            Orders = new ObservableCollection<Order>(context.Orders.GetList().Where(o => o.ClientId == 2).OrderByDescending(o => o.Date).ToList());
            
        }
    }
}
