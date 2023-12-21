using System.Collections.ObjectModel;

namespace PizzaDelivery.Model.Entities
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ObservableCollection<Order> Orders { get; set; }
    }
}
