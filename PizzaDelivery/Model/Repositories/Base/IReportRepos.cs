using PizzaDelivery.Model.CustomEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Model.Repositories.Base
{
    public interface IReportsRepos
    {
        ObservableCollection<OrdersByDate> OrderByDate(DateTime startDate, DateTime endDate, int? statusId);
    }
}
