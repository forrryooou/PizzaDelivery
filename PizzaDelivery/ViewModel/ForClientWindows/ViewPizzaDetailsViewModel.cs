using PizzaDelivery.Model.Entities;
using PizzaDelivery.Utilities;
using System.Globalization;
using System.Linq;

namespace PizzaDelivery.ViewModel.ForClientWindows
{
    public class ViewPizzaDetailsViewModel : ViewModelBase
    {
        private string _name;
        private int _price;
        private string _ingredients;
        private byte[] _imageBytes;
        private Pizza _selectedPizza;

        public Pizza SelectedPizza
        {
            get { return _selectedPizza; }
            set { _selectedPizza = value; OnPropertyChanged(nameof(SelectedPizza)); }
        }

        public byte[] ImageBytes
        {
            get { return _imageBytes; }
            set { _imageBytes = value; OnPropertyChanged(nameof(ImageBytes)); }
        }
        public int Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(nameof(Price)); }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        public string Ingredients
        {
            get { return _ingredients; }
            set { _ingredients = value; OnPropertyChanged(nameof(Ingredients)); }
        }



        public ViewPizzaDetailsViewModel(Pizza pizza)
        {
            SelectedPizza = pizza;
            string ingredientArray = string.Join(",", SelectedPizza.Ingredients.Select(i => i.Name).ToList());
            Ingredients = FormatIngredientsList(ingredientArray);
        }

        private string FormatIngredientsList(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            var ingredients = input.Split(',');
            var ing = ingredients[0];
            ingredients[0] = char.ToUpper(ing[0]) + ing.Substring(1);
            for (int i = 1; i < ingredients.Length; i++)
            {
                ingredients[i] = CultureInfo.CurrentCulture.TextInfo.ToLower(ingredients[i].Trim());
            }
            return string.Join(", ", ingredients);
        }
    }
}
