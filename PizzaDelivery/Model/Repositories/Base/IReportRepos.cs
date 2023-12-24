using PizzaDelivery.Model.CustomEntities;
using System;
using System.Collections.ObjectModel;

namespace PizzaDelivery.Model.Repositories.Base
{
    public interface IReportsRepos
    {
        ObservableCollection<OrdersByDate> OrderByDate(DateTime startDate, DateTime endDate, int? statusId);
    }
}
