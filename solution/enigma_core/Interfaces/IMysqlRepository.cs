using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace enigma_core.Interfaces
{
    public interface IMysqlRepository<T>
    {
        T Add(T item);
        Task<T> AddAsync(T item);
        T Update(int id, T item);
        Task<T> UpdateAsync(int id,T item);
        void Detelete(int id);
        Task DeleteAsync(int id);
        List<T> GetAll(int limitRecords);
        Task<List<T>> GetAllAsync(int limitRecors);
        T GetItemById(int id);
        Task<T> GetItemByIdAsync(string id);
        List<T> Find(List<Object> paremeters);
        Task<List<T>> FindAsync(List<Object> paremeters);
    }
}
