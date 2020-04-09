using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactMap3.Data
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemAsync(bool forceRefresh = true);
    }
}