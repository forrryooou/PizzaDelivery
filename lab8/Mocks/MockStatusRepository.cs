using lab8.Entities;
using Moq;
using PizzaDelivery.Model.Repositories.Base;
using System.Collections.ObjectModel;

namespace lab8.Mocks
{
    public static class MockStatusRepository
    {
        public static ObservableCollection<OrderStatus> statuses = new ObservableCollection<OrderStatus>()
        {
            new OrderStatus()
                {
                    Id = 1,
                    Name = "Статус 1"
                },

                new OrderStatus()
                {
                    Id = 2,
                    Name = "Статус 2"
                }
        };
        public static Mock<IRepository<OrderStatus>> GetMock()
        {
            var mock = new Mock<IRepository<OrderStatus>>();
            mock.Setup(m => m.GetList()).Returns(() => statuses);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => statuses.First());
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
