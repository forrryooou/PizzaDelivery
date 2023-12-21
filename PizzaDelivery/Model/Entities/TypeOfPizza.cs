using System.Collections.ObjectModel;

namespace PizzaDelivery.Model.Entities
{
    public class TypeOfPizza
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ObservableCollection<Pizza> Pizzas { get; set; }
    }
}
