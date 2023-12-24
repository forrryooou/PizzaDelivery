using LAB5.Repository;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Utilities;
using PizzaDelivery.ViewModel.CustomEntities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PizzaDelivery.ViewModel.ForClientWindows
{
    public class AddClientPizzaViewModel : ViewModelBase
    {
        private int _price;
        private List<CategoryWithSelection> _allIngredients;
        private ObservableCollection<Ingredient> _selectedIngredients;
        private string _errorMessage;

        public int Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(nameof(Price)); }
        }
        public List<CategoryWithSelection> AllIngredients
        {
            get { return _allIngredients; }
            set { _allIngredients = value; OnPropertyChanged(nameof(AllIngredients)); }
        }
        public ObservableCollection<Ingredient> SelectedIngredients
        {
            get { return _selectedIngredients; }
            set { _selectedIngredients = value; OnPropertyChanged(nameof(SelectedIngredients)); }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }

        public ICommand SelectIngredientCommand { get; set; }
        public ICommand AddPizzaCommand { get; set; }

        private DbRepos context;

        private ClientViewModel clientViewModel;
        public AddClientPizzaViewModel(ClientViewModel _clientViewModel)
        {
            AddPizzaCommand = new RelayCommand(CreatePizza);
            SelectIngredientCommand = new RelayCommand(SelectIngredient);
            clientViewModel = _clientViewModel;
            context = new DbRepos();

            AllIngredients = context.Categories.GetList().Select(c => new CategoryWithSelection(c)).ToList();
            SelectedIngredients = new ObservableCollection<Ingredient>();
        }

        private void SelectIngredient(object obj)
        {
            if (obj is SelectedIngredient ingredient)
            {
                var ing = context.Ingredients.GetItem(ingredient.Id);
                if (ingredient.IsSelected)
                {
                    Price += ing.Price;
                    SelectedIngredients.Add(ing);
                }
                else
                {
                    Price -= ing.Price;
                    SelectedIngredients.Remove(ing);
                }
            }
        }

        private void CreatePizza(object obj)
        {
            if (SelectedIngredients.Count() == 0) ErrorMessage = "Не выбран ни один ингредиент";
            else
            {
                Pizza newPizza = new Pizza();
                string ingredientArray = string.Join(",", SelectedIngredients.Select(i => i.Name).ToList());
                newPizza.Name = FormatIngredientsList(ingredientArray);
                newPizza.Ingredients = SelectedIngredients;
                newPizza.Price = Price;
                newPizza.TypeId = 2;

                clientViewModel.PizzasInCart.Add(new PizzaInCart(newPizza));

                if (obj is Window window) window.Close();
            }
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
