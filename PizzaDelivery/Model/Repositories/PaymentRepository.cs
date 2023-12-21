using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Model.Data;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Model.Repositories.Base;
using System.Collections.ObjectModel;
using System.Linq;

namespace PizzaDelivery.Model.Repositories
{
    public class PaymentRepository : IRepository<PaymentMethod>
    {
        private PizzaContext context;

        public PaymentRepository(PizzaContext _context)
        {
            this.context = _context;
        }

        public ObservableCollection<PaymentMethod> GetList()
        {
            return new ObservableCollection<PaymentMethod>(context.PaymentMethods.ToList());
        }

        public PaymentMethod GetItem(int id)
        {
            return context.PaymentMethods.Find(id);
        }

        public void Create(PaymentMethod PaymentMethod)
        {
            context.PaymentMethods.Add(PaymentMethod);
        }

        public void Update(PaymentMethod PaymentMethod)
        {
            context.Entry(PaymentMethod).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            PaymentMethod PaymentMethod = context.PaymentMethods.Find(id);
            if (PaymentMethod != null)
                context.PaymentMethods.Remove(PaymentMethod);
        }
    }
}
