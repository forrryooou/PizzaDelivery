using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Model.Data;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Model.Repositories.Base;
using System.Collections.ObjectModel;
using System.Linq;

namespace PizzaDelivery.Model.Repositories
{
    public class CategoryRepository : IRepository<IngredientCategory>
    {
        private PizzaContext context;

        public CategoryRepository(PizzaContext _context)
        {
            this.context = _context;
        }

        public ObservableCollection<IngredientCategory> GetList()
        {
            return new ObservableCollection<IngredientCategory>(context.Categories.Include(i => i.Ingredients).ToList());
        }

        public IngredientCategory GetItem(int id)
        {
            return context.Categories.Find(id);
        }

        public void Create(IngredientCategory IngredientCategory)
        {
            context.Categories.Add(IngredientCategory);
        }

        public void Update(IngredientCategory IngredientCategory)
        {
            context.Entry(IngredientCategory).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            IngredientCategory IngredientCategory = context.Categories.Find(id);
            if (IngredientCategory != null)
                context.Categories.Remove(IngredientCategory);
        }
    }
}
