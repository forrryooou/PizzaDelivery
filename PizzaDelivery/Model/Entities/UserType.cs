using System.Collections.ObjectModel;

namespace PizzaDelivery.Model.Entities
{
    public class UserType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ObservableCollection<User> Users { get; set; }
    }
}
