using System.Collections.ObjectModel;

namespace PizzaDelivery.Model.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public int CategoryId { get; set; }
        public IngredientCategory Category { get; set; }

        public ObservableCollection<Pizza> Pizzas { get; set; } = new();
    }
}
