using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Model.Data;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Model.Repositories.Base;
using System.Collections.ObjectModel;
using System.Linq;

namespace PizzaDelivery.Model.Repositories
{
    public class TypeOfPizzaRepository : IRepository<TypeOfPizza>
    {
        private PizzaContext context;

        public TypeOfPizzaRepository(PizzaContext _context)
        {
            this.context = _context;
        }

        public ObservableCollection<TypeOfPizza> GetList()
        {
            return new ObservableCollection<TypeOfPizza>(context.TypeOfPizzas.ToList());
        }

        public TypeOfPizza GetItem(int id)
        {
            return context.TypeOfPizzas.Find(id);
        }

        public void Create(TypeOfPizza TypeOfPizza)
        {
            context.TypeOfPizzas.Add(TypeOfPizza);
        }

        public void Update(TypeOfPizza TypeOfPizza)
        {
            context.Entry(TypeOfPizza).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TypeOfPizza TypeOfPizza = context.TypeOfPizzas.Find(id);
            if (TypeOfPizza != null)
                context.TypeOfPizzas.Remove(TypeOfPizza);
        }
    }
}
