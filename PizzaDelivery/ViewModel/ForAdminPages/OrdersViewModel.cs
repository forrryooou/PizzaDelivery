using LAB5.Repository;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Utilities;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PizzaDelivery.ViewModel.ForAdminPages
{
    public class OrdersViewModel : ViewModelBase
    {
        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders { get => _orders; set { _orders = value; OnPropertyChanged(nameof(Orders)); } }
        private ObservableCollection<OrderStatus> _statuses;
        public ObservableCollection<OrderStatus> Statuses { get => _statuses; set { _statuses = value; OnPropertyChanged(nameof(Statuses)); } }

        public ICommand UpdateOrdersCommand { get; set; }
        DbRepos context;
        public OrdersViewModel()
        {
            context = new DbRepos();
            Orders = new ObservableCollection<Order> (context.Orders.GetList().OrderBy(o=>o.Date).OrderBy(o=>o.StatusId).Where(o => o.StatusId != 4).ToList());
            Statuses = new ObservableCollection<OrderStatus>(context.Statuses.GetList());
            UpdateOrdersCommand = new RelayCommand(UpdateOrders);
        }

        private void UpdateOrders(object obj)
        {
            foreach (var order in Orders)
            {
                context.Orders.Update(order);
                Orders = new ObservableCollection<Order>(context.Orders.GetList().OrderBy(o => o.Date).OrderBy(o => o.StatusId).Where(o=>o.StatusId != 4).ToList());
            }
            context.Save();
        }
    }
}
