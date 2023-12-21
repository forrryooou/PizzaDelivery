using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Model.Data;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Model.Repositories.Base;
using System.Collections.ObjectModel;
using System.Linq;

namespace LAB5.Repository
{
    public class OrderLinesRepository : IRepository<OrderLine>
    {
        private PizzaContext context;

        public OrderLinesRepository(PizzaContext _context)
        {
            this.context = _context;
        }

        public ObservableCollection<OrderLine> GetList()
        {
            return new ObservableCollection<OrderLine>(context.OrderLines.ToList());
        }

        public OrderLine GetItem(int id)
        {
            return context.OrderLines.Find(id);
        }

        public void Create(OrderLine OrderLine)
        {
            context.OrderLines.Add(OrderLine);
        }

        public void Update(OrderLine OrderLine)
        {
            context.Entry(OrderLine).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            OrderLine OrderLine = context.OrderLines.Find(id);
            if (OrderLine != null)
                context.OrderLines.Remove(OrderLine);
        }
    }
}
