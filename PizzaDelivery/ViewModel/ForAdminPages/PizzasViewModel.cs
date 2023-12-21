using LAB5.Repository;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Utilities;
using PizzaDelivery.View.ViewForCRUD;
using PizzaDelivery.ViewModel.ForCRUD;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PizzaDelivery.ViewModel.ForAdminPages
{
    public class PizzasViewModel : ViewModelBase
    {
        private DbRepos context;

        private ObservableCollection<Pizza> _pizzas;
        public ObservableCollection<Pizza> Pizzas
        {
            get { return _pizzas; }
            set { _pizzas = value; OnPropertyChanged(nameof(Pizzas)); }
        }

        public ICommand AddPizzaCommand { get; set; }
        public ICommand EditPizzaCommand { get; set; }
        public PizzasViewModel()
        {
            AddPizzaCommand = new RelayCommand(CreatePizza);
            EditPizzaCommand = new RelayCommand(EditPizza);
            context = new DbRepos();
            Pizzas = context.Pizzas.GetList();

        }

        private EditPizza editPizza = null;
        private void EditPizza(object obj)
        {
            if (obj is Pizza pizza)
            {
                if (editPizza != null) editPizza.Close();
                editPizza = new EditPizza();
                EditPizzaViewModel viewModel = new EditPizzaViewModel(context.Pizzas.GetItem(pizza.Id));
                editPizza.DataContext = viewModel;
                editPizza.Closed += (s, e) =>
                {
                    context = new DbRepos();
                    Pizzas = context.Pizzas.GetList();
                };
                editPizza.Show();
            }
        }

        private AddPizza addPizza = null;
        private void CreatePizza(object obj)
        {
            if (addPizza != null) addPizza.Close();
            addPizza = new AddPizza();
            AddPizzaViewModel viewModel = new AddPizzaViewModel();
            addPizza.DataContext = viewModel;
            addPizza.Closed += (s, e) => Pizzas = context.Pizzas.GetList();
            addPizza.Show();
        }
    }
}
