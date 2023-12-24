using LAB5.Repository;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Utilities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PizzaDelivery.ViewModel.ForCRUD
{
    public class AddIngredientViewModel : ViewModelBase
    {
        private DbRepos context;
        private string _name;
        private int _price;
        private int _category;
        private ObservableCollection<IngredientCategory> _allCategories;
        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }
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

        public ICommand CreateIngredientCommand { get; set; }

        public AddIngredientViewModel()
        {
            context = new DbRepos();
            CreateIngredientCommand = new RelayCommand(CreateIngredient);
            AllCategories = context.Categories.GetList();
        }

        private void CreateIngredient(object obj)
        {
            if (string.IsNullOrWhiteSpace(Name) ||
                Price == 0 || Category == null) ErrorMessage = "Заполнены не все поля";
            else
            {
                Ingredient newIngredient = new Ingredient();
                newIngredient.Name = Name;
                newIngredient.Price = Price;
                newIngredient.CategoryId = Category;

                context.Ingredients.Create(newIngredient);
                context.Save();

                if (obj is Window window) window.Close();
            }
        }
    }
}
