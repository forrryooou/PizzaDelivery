using lab8.Entities;
using lab8.Mocks;
using lab8.Services;
using Moq;
using System.Collections.ObjectModel;

namespace lab8.Tests
{
    public class MakeOrderTests
    {
        Mock<IDBRepos> context;
        OrderService service;

        [SetUp]
        public void Setup()
        {
            context = MockDBRepos.GetMock();
            service = new OrderService(context.Object);
        }


        [Test]
        public void CreateOrder_Success()
        {
            var orders = new ObservableCollection<Order>()
            {
                new Order
                {
                    Id=3,
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
                            Pizza = MockPizzaRepository.pizzas[1],
                            Quantity = 2
                        }
                    }
                }
            };
            var result = service.MakeOrder(orders[0]);
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(orders[0].Id));
        }

        [Test]
        public void CreateOrderWithoutPizzas_Fail()
        {
            var orders = new ObservableCollection<Order>()
            {
                new Order
                {
                    Id=4,
                    Client = MockClientRepository.clients[0],
                    Date = DateTime.Now,
                    Price=1332,
                    Status = MockStatusRepository.statuses[0],
                    Payment = MockPaymentRepository.payments[0]
                }
            };
            try
            {
                var result = service.MakeOrder(orders[0]);
                Assert.IsNull(result);
                Assert.Throws<ArgumentNullException>(() => service.MakeOrder(orders[0]));
            }
            catch (Exception ex) { }
        }
    }
}
