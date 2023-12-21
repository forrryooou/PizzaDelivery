using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Model.Data;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Model.Repositories.Base;
using System.Collections.ObjectModel;
using System.Linq;

namespace LAB5.Repository
{
    public class StatusRepository : IRepository<OrderStatus>
    {
        private PizzaContext context;

        public StatusRepository(PizzaContext _context)
        {
            this.context = _context;
        }

        public ObservableCollection<OrderStatus> GetList()
        {
            return new ObservableCollection<OrderStatus>(context.Statuses.ToList());
        }

        public OrderStatus GetItem(int id)
        {
            return context.Statuses.Find(id);
        }

        public void Create(OrderStatus Status)
        {
            context.Statuses.Add(Status);
        }

        public void Update(OrderStatus Status)
        {
            context.Entry(Status).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            OrderStatus Status = context.Statuses.Find(id);
            if (Status != null)
                context.Statuses.Remove(Status);
        }
    }
}
