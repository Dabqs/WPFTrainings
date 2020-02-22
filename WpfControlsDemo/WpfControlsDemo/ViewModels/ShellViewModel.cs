using Caliburn.Micro;
using DemoLibrary;
using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfControlsDemo.ViewModels
{
    public class ShellViewModel : Screen
    {
        public BindableCollection<PersonModel> People { get; set; }

        public ShellViewModel()
        {
            DataAccess da = new DataAccess();
            People = new BindableCollection<PersonModel>(da.GetPeople());
        }
        public void AddPerson()
        {
            int lastId;
            DataAccess dataAccess = new DataAccess();
            if (People.Count > 0)
            {
            lastId = People.Max(x => x.PersonId);
            }
            else
            {
                lastId = 0;
            }
            People.Add(dataAccess.GetPerson(lastId +1));

        }
        public void RemovePerson() 
        {
            if (People.Count > 0)
            {
 DataAccess dataAccess = new DataAccess();
            People.Remove(dataAccess.GetRandomItem<PersonModel>(People.ToArray()));
            }
           
        }
    }
}
