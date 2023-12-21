using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Model.Data;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Model.Repositories.Base;
using System.Collections.ObjectModel;
using System.Linq;

namespace PizzaDelivery.Model.Repositories
{
    class UserTypeRepository : IRepository<UserType>
    {
        private PizzaContext context;

        public UserTypeRepository(PizzaContext _context)
        {
            this.context = _context;
        }

        public ObservableCollection<UserType> GetList()
        {
            return new ObservableCollection<UserType>(context.UserTypes.ToList());
        }

        public UserType GetItem(int id)
        {
            return context.UserTypes.Find(id);
        }

        public void Create(UserType UserType)
        {
            context.UserTypes.Add(UserType);
        }

        public void Update(UserType UserType)
        {
            context.Entry(UserType).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            UserType UserType = context.UserTypes.Find(id);
            if (UserType != null)
                context.UserTypes.Remove(UserType);
        }
    }
}
