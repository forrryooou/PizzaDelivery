using PizzaDelivery.Model.Entities;

namespace PizzaDelivery.Model.Repositories.Base
{
    public interface IDbRepos
    {
        IRepository<Pizza> Pizzas { get; }
        IRepository<Order> Orders { get; }
        IRepository<Ingredient> Ingredients { get; }
        IRepository<OrderStatus> Statuses { get; }
        IRepository<Client> Clients { get; }
        IRepository<OrderLine> OrderLines { get; }
        IRepository<IngredientCategory> Categories { get; }
        int Save();
    }
}
