using System.Collections.ObjectModel;

namespace lab8.Entities
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

        public List<OrderLine> OrderLines { get; set; }

    }
}
