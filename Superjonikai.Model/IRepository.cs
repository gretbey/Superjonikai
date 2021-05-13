using System.Collections.Generic;

namespace Superjonikai.Model
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        List<T> Get();
        T Get(int id);
        T Delete(int id);
        T Update(T entity);
    }
}