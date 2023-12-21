using lab8.Entities;
using Moq;
using PizzaDelivery.Model.Repositories.Base;
using System.Collections.ObjectModel;

namespace lab8.Mocks
{
    public static class MockPizzaRepository
    {
        public static ObservableCollection<Pizza> pizzas = new ObservableCollection<Pizza>()
        {
             new Pizza()
                {
                    Id = 1,
                    Name = "Пицца 1",
                    Price = 300,
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient()
                        {
                            Id = 1,
                            Name = "Ингредиент 1",
                            Price = 77
                        }
                    }
                },

                new Pizza()
                {
                    Id = 2,
                    Name = "Пицца 2",
                    Price = 345,
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient()
                        {
                            Id = 2,
                            Name = "Ингредиент 2",
                            Price = 21
                        }
                    }
                }
        };
        public static Mock<IRepository<Pizza>> GetMock()
        {
            var mock = new Mock<IRepository<Pizza>>();

            mock.Setup(m => m.GetList()).Returns(() => pizzas);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => pizzas.First());
            mock.Setup(m => m.Create(It.IsAny<Pizza>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<Pizza>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
