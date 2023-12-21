using System.Collections.ObjectModel;

namespace PizzaDelivery.Model.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        ObservableCollection<T> GetList();
        T GetItem(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
