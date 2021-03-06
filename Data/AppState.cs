using ComponentCommunication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ComponentCommunication.Services;

namespace ComponentCommunication.Data
{
    public class AppState
    {
        public AppState(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string SelectedColour { get; private set; }
        public IConfiguration Configuration { get; }

        public event Action OnChange;

        public IDataAccess _data;
        public IConfiguration _config;
        public void SetColour(string colour)
        {
            SelectedColour = colour;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        public List<Person> peoples = new List<Person>();        

        public PeopleServices _peopleservices = new PeopleServices();

        public void GetPersonList()
        {
            peoples = _peopleservices.ListPeople().Result;
            NotifyStateChanged();
        }

        public async void AddToPersonList(Person newperson)
        {
            await _peopleservices.InsertData(newperson);
            peoples = _peopleservices.ListPeople().Result;
            NotifyStateChanged();
        }

    }
}
