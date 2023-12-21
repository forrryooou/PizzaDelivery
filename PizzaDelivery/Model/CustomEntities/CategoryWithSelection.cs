using PizzaDelivery.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PizzaDelivery.ViewModel.CustomEntities
{
    public class CategoryWithSelection
    {
        public string Name { get; set; }
        public List<SelectedIngredient> Ingredients { get; set; }
        public CategoryWithSelection(IngredientCategory category)
        {
            Name = category.Name;
            Ingredients = category.Ingredients.Select(i => new SelectedIngredient(i)).ToList();
        }
    }
}
