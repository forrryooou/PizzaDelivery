using PizzaDelivery.Model.Entities;

namespace PizzaDelivery.ViewModel.CustomEntities
{
    public class SelectedIngredient : Ingredient
    {
        public bool IsSelected { get; set; }
        public SelectedIngredient(Ingredient ingredient)
        {
            Id = ingredient.Id;
            Name = ingredient.Name;
            Price = ingredient.Price;
            IsSelected = false;
        }
    }
}
