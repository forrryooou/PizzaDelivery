using Moq;

namespace lab8.Mocks
{
    public static class MockDBRepos
    {
        public static Mock<IDBRepos> GetMock()
        {
            var mock = new Mock<IDBRepos>();
            var clientMock = MockClientRepository.GetMock();
            var pizzaMock = MockPizzaRepository.GetMock();
            var statusMock = MockStatusRepository.GetMock();
            var orderMock = MockOrderRepository.GetMock();
            var userMock = MockUserRepository.GetMock();

            mock.Setup(m => m.Clients).Returns(() => clientMock.Object);
            mock.Setup(m => m.Pizzas).Returns(() => pizzaMock.Object);
            mock.Setup(m => m.Statuses).Returns(() => statusMock.Object);
            mock.Setup(m => m.Orders).Returns(() => orderMock.Object);
            mock.Setup(m => m.Users).Returns(() => userMock.Object);
            // не тестируем запись в бд
            mock.Setup(m => m.Save()).Returns(() => { return 1; });
            return mock;
        }
    }
}
