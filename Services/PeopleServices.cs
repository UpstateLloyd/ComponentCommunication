using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComponentCommunication.Data;
using ComponentCommunication.Models;
using Microsoft.Extensions.Configuration;

namespace ComponentCommunication.Services
{
    public class PeopleServices
    {
        public IDataAccess _data;
        public IConfiguration _config;
        public async Task<List<Person>> ListPeople()
        {
            string sql = "SELECT * FROM people";
            List<Person> people;

            people = await _data.LoadData<Person, dynamic>(sql, new { }, _config.GetConnectionString("default"));

            return people;
        }
        public async Task InsertData(Person person)
        {
            string sql = "INSERT INTO people (FirstName, LastName, Email) VALUES (@FirstName, @LastName, @Email);";

            await _data.SaveData(sql, new
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email
            }, _config.GetConnectionString("default"));


        }
    }
}
