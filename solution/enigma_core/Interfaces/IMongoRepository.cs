using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace enigma_core.Interfaces
{
    public interface IMongoRepository<T>
    {
        
        Task add(T item);
        Task update(T item);
        Task delete(string id);
        Task<List<T>> getAll();
        Task<T> getItemById(string id);
        Task<List<T>> find(FilterDefinition<T> filter);

    }
}
