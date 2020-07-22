using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace MyList.Services
{
    public interface IDataStore<T>
    {
        Task<int> SaveItemAsync(T item);
        Task<int> DeleteItemAsync(T item);
        Task<T> GetItemAsync(int ItemId);
        Task<List<T>> GetItemsAsync();
        Task<List<T>> GetItemsNotDoneAsync();
    }
}
