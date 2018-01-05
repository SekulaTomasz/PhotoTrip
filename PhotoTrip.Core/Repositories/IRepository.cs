using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTrip.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetList();
        Task<T> Post(T entity);
        Task<T> Put(T entity);
        void Delete(int id);
    }
}
