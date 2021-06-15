using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibrary1;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var Vm = (VictimManifestViewModel)this.DataContext;
            Vm.OnNavigatedTo();
        }
        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            // System.Diagnostics.Debug.Print("Button Click");
            var person = new Person();
            person.FirstName = FirstNameTextBox.Text;
            person.LastName = LastNameTextBox.Text;
            person.BDay = DateTime.Now;
            var list = (ObservableCollection<Person>)PeopleListControl.ItemsSource;
            list.Add(person);
        }

        private async void Refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadingIndicator.Visibility = Visibility.Visible;
                var peoples = await new VictimService().GetAll();
                LoadingIndicator.Visibility = Visibility.Collapsed;
                var collection = (ObservableCollection<Person>)PeopleListControl.ItemsSource;
                collection.Clear();

                foreach (var person in peoples)
                {
                    collection.Add(person);
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class VictimService //Service performs an action outside of the scope of ui usually.
    {
        public async Task<List<Person>> GetAll()
        {
            await Task.Delay(2000);
            //throw new InvalidOperationException("Foo");
            return new List<Person>() {
                new Person()
                {
                    FirstName = "Kaya",
                    LastName = "S",
                    BDay = DateTime.Now
                }
            };
        }
    }

}
