using lab8.Entities;
using lab8.Mocks;
using lab8.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8.Tests
{
    public class UserServiceTests
    {
        Mock<IDBRepos> context;
        UserService service;

        [SetUp]
        public void Setup()
        {
            context = MockDBRepos.GetMock();
            service = new UserService(context.Object);
        }


        [Test]
        public void Authenticate_ValidData_ReturnTrue()
        {
            var users = new ObservableCollection<User>()
            {
                new User
                {
                    Password = "password",
                    UserName = "name",
                }
            };
            context.Setup(repo => repo.Users.GetList()).Returns(users);
            var result = service.Authenticate(users[0].UserName, users[0].Password);
            Assert.IsTrue(result);
        }

        [Test]
        public void Authenticate_InvalidUsername_ReturnFalse()
        {
            var users = new ObservableCollection<User>()
            {
                new User
                {
                    Password = "password",
                    UserName = "name",
                }
            };
            context.Setup(repo => repo.Users.GetList()).Returns(users);
            var result = service.Authenticate("invalidUser", users[0].Password);
            Assert.IsFalse(result);
        }

        [Test]
        public void Authenticate_InvalidPassword_ReturnFalse()
        {
            var users = new ObservableCollection<User>()
            {
                new User
                {
                    Password = "password",
                    UserName = "name",
                }
            };
            context.Setup(repo => repo.Users.GetList()).Returns(users);
            var result = service.Authenticate(users[0].UserName, "InvalidPassword");
            Assert.IsFalse(result);
        }
    }
}
