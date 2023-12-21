using lab8.Entities;
using Moq;
using PizzaDelivery.Model.Repositories.Base;
using System.Collections.ObjectModel;

namespace lab8.Mocks
{
    public static class MockPaymentRepository
    {
        public static ObservableCollection<PaymentMethod> payments = new ObservableCollection<PaymentMethod>()
        {
            new PaymentMethod()
                {
                    Id = 1,
                    Name = "Способ 1"
                },

                new PaymentMethod()
                {
                    Id = 2,
                    Name = "Способ 2"
                }
        };
        public static Mock<IRepository<OrderStatus>> GetMock()
        {
            var mock = new Mock<IRepository<OrderStatus>>();
            mock.Setup(m => m.GetList()).Returns(() => payments);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => payments.First());
            mock.Setup(m => m.Create(It.IsAny<OrderStatus>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<OrderStatus>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
