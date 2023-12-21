using LAB5.Repository;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Utilities;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PizzaDelivery.ViewModel.ForAdminPages
{
    public class ClientsViewModel : ViewModelBase
    {
        private DbRepos context;
        private ObservableCollection<Client> _allClients;
        private string _searchText;
        public ObservableCollection<Client> AllClients
        {
            get { return _allClients; }
            set { _allClients = value; OnPropertyChanged(nameof(AllClients)); }
        }
        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; OnPropertyChanged(nameof(SearchText)); }
        }

        public ICommand SearchClientCommand { get; set; }
        public ClientsViewModel()
        {
            SearchClientCommand = new RelayCommand(SearchClient);
            context = new DbRepos();
            AllClients = context.Clients.GetList();
        }

        private void SearchClient(object obj)
        {
            if (string.IsNullOrWhiteSpace(SearchText)) AllClients = context.Clients.GetList();
            else AllClients = new ObservableCollection<Client>(context.Clients.GetList().Where(c => c.Name.Contains(SearchText) ||
                                                                        c.Number.Contains(SearchText)).ToList());
        }
    }
}
