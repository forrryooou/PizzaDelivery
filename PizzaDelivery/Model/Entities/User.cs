namespace PizzaDelivery.Model.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }
    }
}
