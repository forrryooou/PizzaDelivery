
using lab8.Entities;
using PizzaDelivery.Model.Repositories.Base;

namespace lab8.Mocks
{
    public interface IDBRepos
    {
        IRepository<Pizza> Pizzas { get; }
        IRepository<Order> Orders { get; }
        IRepository<Ingredient> Ingredients { get; }
        IRepository<OrderStatus> Statuses { get; }
        IRepository<Client> Clients { get; }
        IRepository<OrderLine> OrderLines { get; }
        IRepository<User> Users { get; }
        int Save();
    }
}
