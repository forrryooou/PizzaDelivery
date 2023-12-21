using System.Collections.ObjectModel;

namespace PizzaDelivery.Model.Entities
{
    public class IngredientCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ObservableCollection<Ingredient> Ingredients { get; set; }
    }
}
