using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Model.Data;
using PizzaDelivery.Model.Entities;
using System.Collections.ObjectModel;
using System.Linq;

namespace PizzaDelivery.Model.Repositories.Base
{
    public class PizzaRepository : IRepository<Pizza>
    {
        private PizzaContext context;

        public PizzaRepository(PizzaContext _context)
        {
            this.context = _context;
        }

        public ObservableCollection<Pizza> GetList()
        {
            return new ObservableCollection<Pizza>(context.Pizzas.Include(i => i.Ingredients).ToList());
        }

        public Pizza GetItem(int id)
        {
            return context.Pizzas.Include(i => i.Ingredients).Where(p => p.Id == id).First();
        }

        public void Create(Pizza pizza)
        {
            context.Pizzas.Add(pizza);
        }

        public void Update(Pizza pizza)
        {
            context.Entry(pizza).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Pizza pizza = context.Pizzas.Find(id);
            if (pizza != null)
                context.Pizzas.Remove(pizza);
        }

    }
}
