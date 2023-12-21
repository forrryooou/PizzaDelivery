using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Model.Data;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Model.Repositories.Base;
using System.Collections.ObjectModel;
using System.Linq;

namespace PizzaDelivery.Model.Repositories
{
    public class IngredientRepository : IRepository<Ingredient>
    {
        private PizzaContext context;

        public IngredientRepository(PizzaContext _context)
        {
            this.context = _context;
        }

        public ObservableCollection<Ingredient> GetList()
        {
            return new ObservableCollection<Ingredient>(context.Ingredients.Include(c => c.Category).ToList());
        }

        public Ingredient GetItem(int id)
        {
            return context.Ingredients.Find(id);
        }

        public void Create(Ingredient Ingredient)
        {
            context.Ingredients.Add(Ingredient);
        }

        public void Update(Ingredient Ingredient)
        {
            context.Entry(Ingredient).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Ingredient Ingredient = context.Ingredients.Find(id);
            if (Ingredient != null)
                context.Ingredients.Remove(Ingredient);
        }
    }
}
