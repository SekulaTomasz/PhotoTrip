using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTrip.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetList();
        T Post(T entity);
        T Put(T entity);
        void Delete(int id);
    }
}
