using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PizzaDelivery.Model.CustomEntities
{
    public class Report1 : INotifyPropertyChanged
    {
        private ObservableCollection<OrdersByDate> _orders;
        public ObservableCollection<OrdersByDate> Orders { get => _orders; set { _orders = value; OnPropertyChanged(nameof(Orders)); } }
        public DateTime StartData { get; set; }
        public DateTime EndData { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class OrdersByDate
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public int CountOfPizzas { get; set; }
        public int Price { get; set; }
    }
}
