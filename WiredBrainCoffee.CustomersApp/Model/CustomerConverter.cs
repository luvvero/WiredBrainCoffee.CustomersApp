using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WiredBrainCoffee.CustomersApp.Model
{
    public static class CustomerConverter
    {
        public static Customer CreateCustomerFromString(string input)
        {
            var values = Regex.Replace(input, @"\s", "").Split(",");
            return new Customer
            {
                FirstName = values[0],
                LastName=values[1],
                IsDeveloper=bool.Parse(values[2])
            };
        }
    }
}
