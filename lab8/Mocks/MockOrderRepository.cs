using lab8.Entities;
using Moq;
using PizzaDelivery.Model.Repositories.Base;
using PizzaDelivery.View.AdminPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8.Mocks
{
    public static class MockOrderRepository
    {
        public static ObservableCollection<Order> orders = new ObservableCollection<Order>()
        {
            new Order
                {
                    Id=1,
                    Client = MockClientRepository.clients[0],
                    Date = DateTime.Now,
                    Price=1332,
                    Status = MockStatusRepository.statuses[0],
                    Payment = MockPaymentRepository.payments[0],
                    OrderLines = new List<OrderLine>
                    {
                        new OrderLine()
                        {
                            Id = 1,
                            Pizza = MockPizzaRepository.pizzas[0],
                            Quantity = 2
                        }
                    }
                },
            new Order
                {
                    Id=2,
                    Client = MockClientRepository.clients[0],
                    Date = DateTime.Now,
                    Price=1332,
                    Status = MockStatusRepository.statuses[0],
                    Payment = MockPaymentRepository.payments[0],
                    OrderLines = new List<OrderLine>
                    {
                        new OrderLine()
                        {
                            Id = 1,
                            Pizza = MockPizzaRepository.pizzas[0],
                            Quantity = 2
                        }
                    }
                }
        };
        public static Mock<IRepository<Order>> GetMock()
        {
            var mock = new Mock<IRepository<Order>>();
            mock.Setup(m => m.GetList()).Returns(() => orders);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => orders.FirstOrDefault(o => o.Id == id) ?? orders[0]);
            mock.Setup(m => m.Create(It.IsAny<Order>()))
                .Callback((Order order) => {
                orders.Add(order);
                });
            mock.Setup(m => m.Update(It.IsAny<Order>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
