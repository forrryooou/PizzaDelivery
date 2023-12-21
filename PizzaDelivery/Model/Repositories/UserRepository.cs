using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Model.Data;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Model.Repositories.Base;
using System.Collections.ObjectModel;
using System.Linq;

namespace PizzaDelivery.Model.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private PizzaContext context;

        public UserRepository(PizzaContext _context)
        {
            this.context = _context;
        }

        public ObservableCollection<User> GetList()
        {
            return new ObservableCollection<User>(context.Users.ToList());
        }

        public User GetItem(int id)
        {
            return context.Users.Find(id);
        }

        public void Create(User User)
        {
            context.Users.Add(User);
        }

        public void Update(User User)
        {
            context.Entry(User).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User User = context.Users.Find(id);
            if (User != null)
                context.Users.Remove(User);
        }
    }
}
