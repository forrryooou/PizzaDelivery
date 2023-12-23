using PizzaDelivery.Model.CustomEntities;
using PizzaDelivery.Model.Data;
using PizzaDelivery.Model.Repositories.Base;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PizzaDelivery.Model.Repositories
{
    public class ReportRepository : IReportsRepos
    {
        private PizzaContext context;

        public ReportRepository(PizzaContext _context)
        {
            this.context = _context;
        }

        public ObservableCollection<OrdersByDate> OrderByDate(DateTime startDate, DateTime endDate, int? statusId)
        {
            var ordersByMonth = new ObservableCollection<OrdersByDate>(context.Orders.OrderByDescending(o => o.Date)
            .Where(o => o.Date.Date >= startDate.Date && o.Date.Date <= endDate.Date && (statusId == 0 || o.StatusId == statusId))
            .Select(g => new OrdersByDate()
            {
                Date = g.Date.ToString("dd.MM.yyyy"),
                Time = g.Date.ToShortTimeString(),
                Status = g.Status.Name,
                CountOfPizzas = g.OrderLines.Count,
                Price = g.Price
            })
            .ToList());
            return ordersByMonth;
        }
    }
}
