using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactMap1.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddPersonAsync(T person);
        Task<bool> UpdatePersonAsync(T person);
        Task<bool> DeletePersonAsync(string id);
        Task<T> GetPersonAsync(string id);
        Task<IEnumerable<T>> GetContactsAsync(bool forceRefresh = true);
    }
}
