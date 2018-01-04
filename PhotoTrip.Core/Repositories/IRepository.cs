using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTrip.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetListAsync();
        Task PostAsync(T entity);
        Task PutAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
