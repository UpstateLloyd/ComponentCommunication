using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComponentCommunication.Data;
using ComponentCommunication.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;

namespace ComponentCommunication.Services
{
    public class PeopleServices
    {
        public IDataAccess _data = new DataAccess();
        public IConfiguration _config { get; }
        public async Task<List<Person>> ListPeople()
        {
            string sql = "SELECT * FROM people";

            //List<Person> people = new List<Person>();

            return await _data.LoadData<Person, dynamic>(sql, new { }, "Server=localhost;Port=3306;database=ytdemo;user id=upstatedashadmin;password=LH85upst4t3d4sh!");// Startup.Configuration.GetConnectionString("default"));

        }
        public async Task InsertData(Person person)
        {
            string sql = "INSERT INTO people (FirstName, LastName, Email) VALUES (@FirstName, @LastName, @Email);";

            await _data.SaveData(sql, new
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email
            }, "Server=localhost;Port=3306;database=ytdemo;user id=upstatedashadmin;password=LH85upst4t3d4sh!");// _config.GetConnectionString("default"));


        }
    }
}
