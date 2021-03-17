using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentCommunication.Data
{
    public interface IDataAccess
    {
        Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString);
        Task SaveData<T>(string sql, T parameters, string connectionString);
    }
}
