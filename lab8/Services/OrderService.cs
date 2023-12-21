using lab8.Entities;
using lab8.Mocks;

namespace lab8.Services
{
    public class OrderService
    {
        private IDBRepos context;
        public OrderService(IDBRepos repos)
        {
            context = repos;
        }

        public Order MakeOrder(Order order)
        {
            if (order.OrderLines == null || order.OrderLines.Count == 0) throw new ArgumentNullException("В заказе нет пицц");
            var newOrder = new Order
            {
                Id= order.Id,
                Date = DateTime.Now,
                Payment = order.Payment,
                Client = order.Client,
                PaymentId = order.Payment.Id,
                ClientId = order.Client.Id,
                Price = order.Price,
                OrderLines = order.OrderLines,
                Status = order.Status,
                StatusId=order.Status.Id
            };
            context.Orders.Create(newOrder);
            if (context.Save() > 0)
            {
                var order1 = GetOrder(order.Id);
                return order1;
            }
                
            return null;

        }


        public List<Order> GetAllOrders()
        {
            return context.Orders.GetList().ToList();
        }
        public Order GetOrder(int Id)
        {
            return context.Orders.GetItem(Id);
        }
        public void DeleteOrder(int id)
        {
            if (context.Orders.GetItem(id) != null)
            {
                context.Orders.Delete(id);
                context.Save();
            }
        }

    }
}
