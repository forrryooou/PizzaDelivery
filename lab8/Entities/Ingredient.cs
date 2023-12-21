using System.Collections.ObjectModel;

namespace lab8.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public List<Pizza> Pizzas { get; set; } = new();
    }
}
