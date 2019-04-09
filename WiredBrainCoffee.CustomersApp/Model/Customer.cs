using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using WiredBrainCoffee.CustomersApp.Base;

namespace WiredBrainCoffee.CustomersApp.Model
{
    [CreateFromString(MethodName = "WiredBrainCoffee.CustomersApp.Model.CustomerConverter.CreateCustomerFromString")]
    public class Customer : Observable
    {
        private string firstName;
        private string _lastName;
        private bool _isDeveloper;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => _lastName; set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public bool IsDeveloper
        {
            get => _isDeveloper; set
            {
                _isDeveloper = value;
                OnPropertyChanged();
            }
        }
    }
}
