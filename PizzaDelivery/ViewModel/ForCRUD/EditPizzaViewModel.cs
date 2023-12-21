using LAB5.Repository;
using Microsoft.Win32;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Utilities;
using PizzaDelivery.ViewModel.CustomEntities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PizzaDelivery.ViewModel.ForCRUD
{
    public class EditPizzaViewModel : ViewModelBase
    {
        private string _name;
        private int _price;
        private List<CategoryWithSelection> _allIngredients;
        private ObservableCollection<Ingredient> _selectedIngredients;
        private byte[] _imageBytes;
        private string _errorMessage;

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
        public byte[] ImageBytes
        {
            get { return _imageBytes; }
            set { _imageBytes = value; OnPropertyChanged(nameof(ImageBytes)); }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }
        public ICommand AddImageCommand { get; set; }
        public ICommand SelectIngredientCommand { get; set; }
        public ICommand EditPizzaCommand { get; set; }
        public ICommand DeletePizzaCommand { get; set; }

        private DbRepos context;

        private Pizza pizza;
        public EditPizzaViewModel(Pizza _pizza)
        {
            context = new DbRepos();

            pizza = context.Pizzas.GetItem(_pizza.Id);
            Name = pizza.Name;
            SelectedIngredients = new ObservableCollection<Ingredient>(pizza.Ingredients);
            pizza.Ingredients.Clear();
            ImageBytes = pizza.Image;
            Price = pizza.Price;

            DeletePizzaCommand = new RelayCommand(DeletePizza);
            AddImageCommand = new RelayCommand(AddImage);
            EditPizzaCommand = new RelayCommand(EditPizza);
            SelectIngredientCommand = new RelayCommand(SelectIngredient);

            AllIngredients = context.Categories.GetList().Select(c => new CategoryWithSelection(c)).ToList();
            foreach (var category in AllIngredients)
            {
                foreach (var ingredient in category.Ingredients)
                {
                    foreach (var selected in SelectedIngredients)
                    {
                        if (ingredient.Id == selected.Id) ingredient.IsSelected = true;
                    }
                }
            }

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

        private void AddImage(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                //BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                ImageBytes = File.ReadAllBytes(openFileDialog.FileName);
            }
        }

        private void EditPizza(object obj)
        {
            if (SelectedIngredients.Count() == 0 ||
                Name == null ||
                ImageBytes == null) ErrorMessage = "Заполнены не все поля";
            else
            {
                pizza.Name = Name;
                pizza.Price = Price;
                pizza.Ingredients = SelectedIngredients;
                pizza.Image = ImageBytes;

                context.Pizzas.Update(pizza);
                context.Save();

                if (obj is Window window) window.Close();
            }
        }

        private void DeletePizza(object obj)
        {
            context.Pizzas.Delete(pizza.Id);
            context.Save();

            if (obj is Window window) window.Close();
        }
    }
}
