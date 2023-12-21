using LAB5.Repository;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Utilities;
using PizzaDelivery.View.ViewForCRUD;
using PizzaDelivery.ViewModel.ForCRUD;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PizzaDelivery.ViewModel.ForAdminPages
{
    public class IngredientsViewModel : ViewModelBase
    {
        private DbRepos context;
        private ObservableCollection<IngredientCategory> _categories;

        public ObservableCollection<IngredientCategory> Categories
        {
            get { return _categories; }
            set { _categories = value; OnPropertyChanged(nameof(Categories)); }
        }

        public ICommand AddIngredientCommand { get; set; }
        public ICommand EditIngredientCommand { get; set; }


        public IngredientsViewModel()
        {
            AddIngredientCommand = new RelayCommand(CreateIngredient);
            EditIngredientCommand = new RelayCommand(EditIngredient);
            context = new DbRepos();
            Categories = context.Categories.GetList();
        }

        private AddIngredient addIngredient = null;
        private void CreateIngredient(object obj)
        {
            if (addIngredient != null) addIngredient.Close();
            addIngredient = new AddIngredient();
            AddIngredientViewModel viewModel = new AddIngredientViewModel();
            addIngredient.DataContext = viewModel;
            addIngredient.Closed += (s, e) => Categories = context.Categories.GetList();
            addIngredient.Show();
        }

        private EditIngredient editIngredient = null;
        private void EditIngredient(object obj)
        {
            if (obj is Ingredient ingredient)
            {
                if (editIngredient != null) editIngredient.Close();
                editIngredient = new EditIngredient();
                EditIngredientViewModel viewModel = new EditIngredientViewModel(ingredient);
                editIngredient.DataContext = viewModel;
                editIngredient.Closed += (s, e) =>
                {
                    context = new DbRepos();
                    Categories = context.Categories.GetList();
                };
                editIngredient.Show();
                editIngredient.Focus();
            }
        }
    }
}
