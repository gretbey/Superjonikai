using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        List<TEntity> GetAll();
        TEntity Get(int id);
        TEntity Delete(int id);
        TEntity Update(TEntity entity);
    }
}
