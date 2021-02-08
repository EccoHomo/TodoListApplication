using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TodoListApplication.Core.Interfaces
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void Change(TEntity entity);
        void Delete(int id);
        void DeleteRange(List<TEntity> entities);
        void Save();
    }
}
