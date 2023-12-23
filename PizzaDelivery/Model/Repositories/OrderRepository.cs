using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Model.Data;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Model.Repositories.Base;
using System.Collections.ObjectModel;
using System.Linq;

namespace LAB5.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        private PizzaContext context;

        public OrderRepository(PizzaContext _context)
        {
            this.context = _context;
        }

        public ObservableCollection<Order> GetList()
        {
            return new ObservableCollection<Order>(context.Orders.Include(o => o.Client).Include(o=>o.Payment).Include(o => o.Status)
                .Include(o => o.OrderLines).ThenInclude(ol => ol.Pizza).ToList());
        }

        public Order GetItem(int id)
        {
            return context.Orders.Find(id);
        }

        public void Create(Order Order)
        {
            context.Orders.Add(Order);
        }

        public void Update(Order Order)
        {
            context.Entry(Order).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Order Order = context.Orders.Find(id);
            if (Order != null)
                context.Orders.Remove(Order);
        }
    }
}
