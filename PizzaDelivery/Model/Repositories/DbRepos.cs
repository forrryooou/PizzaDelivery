using PizzaDelivery.Model.CustomEntities;
using PizzaDelivery.Model.Data;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Model.Repositories;
using PizzaDelivery.Model.Repositories.Base;

namespace LAB5.Repository
{
    public class DbRepos : IDbRepos
    {
        private PizzaContext context;
        private PizzaRepository pizzaRepository;
        private OrderRepository orderRepository;
        private UserRepository userRepository;
        private UserTypeRepository userTypeRepository;
        private TypeOfPizzaRepository typeOfPizzaRepository;
        private StatusRepository statusRepository;
        private IngredientRepository ingredientRepository;
        private ClientRepository clientRepository;
        private OrderLinesRepository detailRepository;
        private CategoryRepository categoryRepository;
        private PaymentRepository paymentRepository;
        private ReportRepository reportRepository;

        public DbRepos()
        {
            context = new PizzaContext();
        }

        public IReportsRepos Reports
        {
            get
            {
                if (reportRepository == null)
                    reportRepository = new ReportRepository(context);
                return reportRepository;
            }
        }

        public IRepository<PaymentMethod> PaymentMethods
        {
            get
            {
                if (paymentRepository == null)
                    paymentRepository = new PaymentRepository(context);
                return paymentRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(context);
                return userRepository;
            }
        }

        public IRepository<UserType> UserTypes
        {
            get
            {
                if (userTypeRepository == null)
                    userTypeRepository = new UserTypeRepository(context);
                return userTypeRepository;
            }
        }

        public IRepository<TypeOfPizza> PizzaTypes
        {
            get
            {
                if (typeOfPizzaRepository == null)
                    typeOfPizzaRepository = new TypeOfPizzaRepository(context);
                return typeOfPizzaRepository;
            }
        }

        public IRepository<Pizza> Pizzas
        {
            get
            {
                if (pizzaRepository == null)
                    pizzaRepository = new PizzaRepository(context);
                return pizzaRepository;
            }
        }

        public IRepository<IngredientCategory> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(context);
                return categoryRepository;
            }
        }

        public IRepository<Client> Clients
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepository(context);
                return clientRepository;
            }
        }

        public IRepository<OrderLine> OrderLines
        {
            get
            {
                if (detailRepository == null)
                    detailRepository = new OrderLinesRepository(context);
                return detailRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(context);
                return orderRepository;
            }
        }

        public IRepository<Ingredient> Ingredients
        {
            get
            {
                if (ingredientRepository == null)
                    ingredientRepository = new IngredientRepository(context);
                return ingredientRepository;
            }
        }

        public IRepository<OrderStatus> Statuses
        {
            get
            {
                if (statusRepository == null)
                    statusRepository = new StatusRepository(context);
                return statusRepository;
            }
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
