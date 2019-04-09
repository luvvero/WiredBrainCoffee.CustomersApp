using System;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WiredBrainCoffee.CustomersApp.DataProvider;
using WiredBrainCoffee.CustomersApp.Model;
using WiredBrainCoffee.CustomersApp.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WiredBrainCoffee.CustomersApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; }

        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = new MainViewModel(new CustomerDataProvider());
            //DataContext = ViewModel;
            this.Loaded += MainPage_Loaded;
            App.Current.Suspending += App_Suspending;
          
            RequestedTheme = App.Current.RequestedTheme == ApplicationTheme.Light ?
                ElementTheme.Light : ElementTheme.Dark;
        }



        private async void MainPage_Loaded(object sender, RoutedEventArgs e) //sitas cia gali but
        {
            await ViewModel.LoadAsync();
        }

        private async void App_Suspending(object sender, Windows.ApplicationModel.SuspendingEventArgs e)  //sitas cia gali but
        {
            var deferal = e.SuspendingOperation.GetDeferral(); //uztikrinam kad bus baigtas isaugojimas cia suspendina

            await ViewModel.SaveAsync();
            
            deferal.Complete(); //cia jau zino kad galima baigti
        }

        //private void ButtonAddCustomer_Click(object sender, RoutedEventArgs e) //neyuretu buti cia
        //{
        //    var newCustomer = new Customer() { FirstName = "New" };
        //    customerListView.Items.Add(newCustomer);
        //    customerListView.SelectedItem = newCustomer;
        //}

        //private void ButtonDeleteCustomer_Click(object sender, RoutedEventArgs e)  //neyuretu buti cia
        //{
        //    var customer = customerListView.SelectedItem as Customer;
        //    if (customer != null)
        //    {
        //        customerListView.Items.Remove(customer);
        //        //customerListView.SelectedItem = customerListView.Items.FirstOrDefault();
        //    }

        //}

        private void ButtonMove_Click(object sender, RoutedEventArgs e) //sitas cia gali but susije su UI
        {
            var column = (int)customerListGrid.GetValue(Grid.ColumnProperty);
            var column2 = Grid.GetColumn(customerListGrid);

            var newColumn = column == 0 ? 2 : 0;

            Grid.SetColumn(customerListGrid, newColumn); //statinis budas
            //customerListGrid.SetValue(Grid.ColumnProperty, newColumn);

            moveSymbolIcon.Symbol = newColumn == 0 ? Symbol.Forward : Symbol.Back;

        }

        

        private void ThemeToggleButton_Click(object sender, RoutedEventArgs e)  //sitas cia gali but susije su UI
        {
            this.RequestedTheme = RequestedTheme == ElementTheme.Dark ?
                ElementTheme.Light : ElementTheme.Dark;
        }
    }
}
