using PizzaDelivery.Model.Entities;
using System.ComponentModel;

namespace PizzaDelivery.ViewModel.CustomEntities
{
    public class PizzaInCart : Pizza, INotifyPropertyChanged
    {
        private int _quantity;
        public int Quantity { get => _quantity; set { _quantity = value; OnPropertyChanged(nameof(Quantity)); } }
        private int _price;
        public new int Price { get => _price; set { _price = value; OnPropertyChanged(nameof(Price)); } }

        public PizzaInCart(Pizza pizza)
        {
            Id = pizza.Id;
            Name = pizza.Name;
            Price = pizza.Price;
            Image = pizza.Image;
            Quantity = 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
