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
        private PersonModel selectedPerson;
        private AddressModel selectedAddress;

        public AddressModel SelectedAddress
        {
            get { return selectedAddress; }
            set
            {
                selectedAddress = value;
                SelectedPerson.PrimaryAddress = value;
                NotifyOfPropertyChange(() => SelectedAddress);
            }
        }

        public PersonModel SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                selectedPerson = value;
                SelectedAddress = value.PrimaryAddress;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public ShellViewModel()
        {
            DataAccess da = new DataAccess();
            People = new BindableCollection<PersonModel>(da.GetPeople());
        }
    }
}
