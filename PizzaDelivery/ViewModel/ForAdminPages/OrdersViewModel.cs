using LAB5.Repository;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Utilities;
using System.Collections.ObjectModel;
using System.Linq;

namespace PizzaDelivery.ViewModel.ForAdminPages
{
    public class OrdersViewModel : ViewModelBase
    {
        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders { get => _orders; set { _orders = value; OnPropertyChanged(nameof(Orders)); } }

        DbRepos context;
        public OrdersViewModel()
        {
            context = new DbRepos();
            Orders = new ObservableCollection<Order> (context.Orders.GetList().OrderBy(o=>o.Date).ToList()); 
        }
    }
}
