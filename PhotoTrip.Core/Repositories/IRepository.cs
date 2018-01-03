using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoTrip.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetList();
        void Post(T entity);
        void Put(T entity);
        void Delete(T entity);
    }
}
