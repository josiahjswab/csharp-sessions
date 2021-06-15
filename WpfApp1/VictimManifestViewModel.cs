using ClassLibrary1;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1
{
    public class VictimManifestViewModel : INotifyPropertyChanged
    {
        public VictimManifestViewModel()
        {
            AddPersonCommand = new RelayCommand(AddPersonCommandExecute);
            RefreshCommand = new RelayCommand(RefreshCommandExecute);

        }
        public ObservableCollection<Person> VictimList { get; set; }
         = new ObservableCollection<Person>();

        private string firstNameInput; // Field
        public string FirstNameInput 
        {
            get 
            {
                return firstNameInput;
            }
            set
            {
                firstNameInput = value; // Value is a keyword all setters have them.
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("FirstNameInput"));
            }
        } //prop
        public string LastNameInput { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void OnNavigatedTo() {
            var service = new VictimService();
            var victims = await service.GetAll();

            foreach(var victim in victims) {
                VictimList.Add(victim);
            } 
        }
        public ICommand AddPersonCommand { get; set; }
        private  void AddPersonCommandExecute()
        {
            var person = new Person();
            person.FirstName = FirstNameInput;
            person.LastName = LastNameInput;
            person.BDay = DateTime.Now;
            
            VictimList.Add(person);
            FirstNameInput = null;
            LastNameInput = null;
        }

        public ICommand RefreshCommand { get; set; }
        private async void  RefreshCommandExecute()
        {
            try
            {
                //LoadingIndicator.Visibility = Visibility.Visible;
                var peoples = await new VictimService().GetAll();
                //LoadingIndicator.Visibility = Visibility.Collapsed;
             
                VictimList.Clear();
                foreach (var person in peoples)
                {
                    VictimList.Add(person);
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
    }
}
