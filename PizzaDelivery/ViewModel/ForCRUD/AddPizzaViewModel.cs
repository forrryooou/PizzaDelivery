using LAB5.Repository;
using Microsoft.Win32;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Utilities;
using PizzaDelivery.ViewModel.CustomEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PizzaDelivery.ViewModel.ForCRUD
{
    public class AddPizzaViewModel : ViewModelBase
    {
        private string _name;
        private int _price;
        private List<CategoryWithSelection> _allIngredients;
        private ObservableCollection<Ingredient> _selectedIngredients;
        private ImageSource _pizzaImage;
        private byte[] _imageBytes;
        private string _errorMessage;

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
        public ImageSource PizzaImage
        {
            get { return _pizzaImage; }
            set { _pizzaImage = value; OnPropertyChanged(nameof(PizzaImage)); }
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
        public ICommand SelectSizesCommand { get; set; }
        public ICommand AddPizzaCommand { get; set; }

        private DbRepos context;

        public AddPizzaViewModel()
        {
            AddImageCommand = new RelayCommand(AddImage);
            AddPizzaCommand = new RelayCommand(CreatePizza);
            SelectIngredientCommand = new RelayCommand(SelectIngredient);



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

        private void AddImage(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                //BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                //PizzaImage = bitmap;
                ImageBytes = File.ReadAllBytes(openFileDialog.FileName);
            }
        }

        private void CreatePizza(object obj)
        {
            if (SelectedIngredients.Count() == 0 ||
                Name == null ||
                ImageBytes == null) ErrorMessage = "Заполнены не все поля";
            else
            {
                Pizza newPizza = new Pizza();
                newPizza.Name = Name;
                newPizza.Ingredients = SelectedIngredients;
                newPizza.Image = ImageBytes;
                newPizza.Price = Price;
                newPizza.TypeId = 1;

                context.Pizzas.Create(newPizza);
                context.Save();

                if (obj is Window window) window.Close();
            }
        }
    }
}
