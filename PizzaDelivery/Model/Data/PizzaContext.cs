using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Model.Entities;

namespace PizzaDelivery.Model.Data
{
    public class PizzaContext : DbContext
    {
        public DbSet<Client> Clients { get; set; } //клиент
        public DbSet<Ingredient> Ingredients { get; set; } //ингредиент
        public DbSet<Pizza> Pizzas { get; set; } //пицца
        public DbSet<Order> Orders { get; set; } //заказ
        public DbSet<OrderStatus> Statuses { get; set; } //статус заказа
        public DbSet<OrderLine> OrderLines { get; set; } //строка заказа
        public DbSet<IngredientCategory> Categories { get; set; } //категория ингредиента
        public DbSet<User> Users { get; set; } //пользователь
        public DbSet<UserType> UserTypes { get; set; } //тип пользователя
        public DbSet<TypeOfPizza> TypeOfPizzas { get; set; } //тип пиццы
        public DbSet<PaymentMethod> PaymentMethods { get; set; } //cпособ оплаты

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-AS19UOEE\MSSQLSERVERR; Initial catalog=PizzaDelivery;Trusted_Connection=True; TrustServerCertificate=True;");
        }
    }
}
