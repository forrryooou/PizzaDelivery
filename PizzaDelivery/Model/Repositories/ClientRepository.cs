using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Model.Data;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Model.Repositories.Base;
using System.Collections.ObjectModel;
using System.Linq;

namespace PizzaDelivery.Model.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        private PizzaContext context;

        public ClientRepository(PizzaContext _context)
        {
            this.context = _context;
        }

        public ObservableCollection<Client> GetList()
        {
            return new ObservableCollection<Client>(context.Clients.Include(u => u.User).ToList());
        }

        public Client GetItem(int id)
        {
            return context.Clients.Find(id);
        }

        public void Create(Client Client)
        {
            context.Clients.Add(Client);
        }

        public void Update(Client Client)
        {
            context.Entry(Client).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Client Client = context.Clients.Find(id);
            if (Client != null)
                context.Clients.Remove(Client);
        }
    }
}
