using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Base;
using WiredBrainCoffee.CustomersApp.DataProvider;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class MainViewModel : Observable
    {
        private readonly ICustomerDataProvider dataProvider;

        public MainViewModel(ICustomerDataProvider dataProvider)
        {
            Customers = new ObservableCollection<Customer>();
            this.dataProvider = dataProvider;
        }

        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsCustomerSelected));
                }
            }
        }

        public bool IsCustomerSelected
        {
            get
            {
                return SelectedCustomer != null;
            }
        }

        public ObservableCollection<Customer> Customers { get; }

        public async Task LoadAsync()
        {
            Customers.Clear();
            foreach (var cutomer in await dataProvider.LoadCustomersAsync())
            {
                Customers.Add(cutomer);
            }
        }


        public async Task SaveAsync()
        {
            await dataProvider.SaveCustomersAsync(Customers);
        }

        public void AddCustomer() 
        {
            var newCustomer = new Customer() { FirstName = "New" };
            Customers.Add(newCustomer);
            SelectedCustomer = newCustomer;
        }

        public void DeleteCustomer()  
        {
            var customer = SelectedCustomer;
            if (customer != null)
            {
                Customers.Remove(customer);               
            }
            SelectedCustomer = null;
        }

    }
}
