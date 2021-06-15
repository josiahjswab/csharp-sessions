using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WpfApp1
{
    public class VictimManifestViewModel
    {
        public ObservableCollection<Person> VictimList { get; set; }
         = new ObservableCollection<Person>();
        
       public async void OnNavigatedTo() {
            var service = new VictimService();
            var victims = await service.GetAll();

            foreach(var victim in victims) {
                VictimList.Add(victim);
            } 
        }
    }
}
