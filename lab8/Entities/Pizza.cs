using System.Collections.ObjectModel;

namespace lab8.Entities
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public List<OrderLine> OrderLines { get; set; }

        public List<Ingredient> Ingredients { get; set; } = new();
    }
}
