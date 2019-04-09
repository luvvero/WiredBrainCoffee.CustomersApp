using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.Controls
{
    [ContentProperty(Name = nameof(Customer))]
    public sealed partial class CustomerDeatilControl : UserControl
    {
        // Using a DependencyProperty as the backing store for Customer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomerProperty =
            DependencyProperty.Register("Customer", typeof(Customer),
                typeof(CustomerDeatilControl), new PropertyMetadata(null));

        public CustomerDeatilControl()
        {
            this.InitializeComponent();
        }


        public Customer Customer
        {
            get { return (Customer)GetValue(CustomerProperty); }
            set { SetValue(CustomerProperty, value); }
        }
        
    }
}
