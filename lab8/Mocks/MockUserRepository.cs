using lab8.Entities;
using Moq;
using PizzaDelivery.Model.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8.Mocks
{
    public class MockUserRepository
    {
        public static ObservableCollection<User> users = new ObservableCollection<User>();
        public static Mock<IRepository<User>> GetMock()
        {
            var mock = new Mock<IRepository<User>>();
            mock.Setup(m => m.GetList()).Returns(() => users);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => users.FirstOrDefault(o => o.Id == id));
            mock.Setup(m => m.Create(It.IsAny<User>()))
                .Callback((User User) => {
                    users.Add(User);
                });
            mock.Setup(m => m.Update(It.IsAny<User>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
