using LAB5.Repository;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Utilities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PizzaDelivery.ViewModel.ForCRUD
{
    public class EditIngredientViewModel : ViewModelBase
    {
        private DbRepos context;
        private string _name;
        private int _price;
        private int _category;
        private ObservableCollection<IngredientCategory> _allCategories;

        public ObservableCollection<IngredientCategory> AllCategories
        {
            get { return _allCategories; }
            set { _allCategories = value; OnPropertyChanged(nameof(AllCategories)); }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        public int Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(nameof(Price)); }
        }
        public int Category
        {
            get { return _category; }
            set { _category = value; OnPropertyChanged(nameof(Category)); }
        }

        public ICommand EditIngredientCommand { get; set; }
        public ICommand DeleteIngredientCommand { get; set; }

        private Ingredient ingredient;
        public EditIngredientViewModel(Ingredient _ingredient)
        {
            context = new DbRepos();
            EditIngredientCommand = new RelayCommand(UpdateIngredient);
            DeleteIngredientCommand = new RelayCommand(DeleteIngredient);
            AllCategories = context.Categories.GetList();
            ingredient = context.Ingredients.GetItem(_ingredient.Id);

            Name = ingredient.Name;
            Price = ingredient.Price;
            Category = ingredient.CategoryId;
        }

        private void UpdateIngredient(object obj)
        {
            ingredient.Name = Name;
            ingredient.Price = Price;
            ingredient.CategoryId = Category;
            context.Ingredients.Update(ingredient);
            context.Save();
            if (obj is Window window) window.Close();
        }
        private void DeleteIngredient(object obj)
        {
            context.Ingredients.Delete(ingredient.Id);
            context.Save();
            if (obj is Window window) window.Close();
        }
    }
}
