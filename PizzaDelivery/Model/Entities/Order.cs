using System;
using System.Collections.ObjectModel;

namespace PizzaDelivery.Model.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }

        public int StatusId { get; set; }
        public OrderStatus Status { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int PaymentId { get; set; }
        public PaymentMethod Payment { get; set; }

        public ObservableCollection<OrderLine> OrderLines { get; set; }

    }
}
