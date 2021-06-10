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
            //var sp = new StackPanel();
            //Content = sp;
            //var button = new Button();
            //button.Content = "I am in the code behind!";
            //button.HorizontalAlignment = HorizontalAlignment.Left;
            //button.VerticalAlignment = VerticalAlignment.Center;
            //sp.Children.Add(button);
            var foo = new Person()
            {
                FirstName = "Ben",
                LastName = "Z",
                BDay = DateTime.Now
            };

            var list = new ObservableCollection<Person>()
            {
                foo
            };

            var person = new Person();
            person.FirstName = "Josiah";
            person.LastName = "S";
            person.BDay = DateTime.Now;

            list.Add(person);

            PeopleListControl.ItemsSource = list; // ctrl R R renames all references
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(MySecondClass.MakeInteger(2.22).ToString());
            //MessageBox.Show(new MessageProvider().GetMessage());
            //MessageBox.Show(MySecondClass.GetMessage("Hello"));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.Print("Button Click");
            var person = new Person();
            person.FirstName = FirstNameTextBox.Text;
            person.LastName = "S";
            person.BDay = DateTime.Now;
            var list = (ObservableCollection<Person>)PeopleListControl.ItemsSource;
            list.Add(person);
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadingIndicator.Visibility = Visibility.Visible;
                var peoples = await new GetPeople().MakeFakeApiCall();
                LoadingIndicator.Visibility = Visibility.Collapsed;
                var collection = (ObservableCollection<Person>)PeopleListControl.ItemsSource;

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

    public class GetPeople
    {
        public async Task<List<Person>> MakeFakeApiCall()
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
