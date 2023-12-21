using System.Collections.ObjectModel;

namespace PizzaDelivery.Model.Entities
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int Price { get; set; }

        public ObservableCollection<OrderLine> OrderLines { get; set; }

        public int TypeId { get; set; }
        public TypeOfPizza Type { get; set; }

        public ObservableCollection<Ingredient> Ingredients { get; set; } = new();
    }
}
