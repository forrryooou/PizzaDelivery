using lab8.Entities;
using Moq;
using PizzaDelivery.Model.Repositories.Base;
using System.Collections.ObjectModel;

namespace lab8.Mocks
{
    public static class MockClientRepository
    {
        public static ObservableCollection<Client> clients = new ObservableCollection<Client>()
        {
            new Client()
                {
                    Id = 1,
                    Name = "Клиент 1",
                    Address = "Адрес 1",
                    Number = "Номер телефона 1",
                    User = new User()
                    {
                        Id = 1,
                        Password = "1111",
                        UserName = "user1"
                    }

                },

                new Client()
                {
                    Id = 2,
                    Name = "Клиент 2",
                    Address = "Адрес 2",
                    Number = "Номер телефона 2",
                    User = new User()
                    {
                        Id = 2,
                        Password = "1111",
                        UserName = "user2"
                    }

                },
        };
        public static Mock<IRepository<Client>> GetMock()
        {
            var mock = new Mock<IRepository<Client>>();
            
            mock.Setup(m => m.GetList()).Returns(() => clients);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => clients.First());
            mock.Setup(m => m.Create(It.IsAny<Client>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<Client>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
