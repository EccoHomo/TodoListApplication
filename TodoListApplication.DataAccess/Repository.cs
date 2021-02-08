using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TodoListApplication.Core.Entities;
using TodoListApplication.Core.Interfaces;

namespace TodoListApplication.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly TodoAppContext _context;

        public Repository(TodoAppContext context)
        {
            _context = context;
        }
        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            Save();
        }

        public void Change(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            Save();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if(entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                Save();
            }
        }

        public void DeleteRange(List<TEntity> entities)
        {
            if (entities != null && entities.Any())
            {
                foreach (var item in entities)
                {
                    _context.Set<TEntity>().Remove(item);
                }
                Save();
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
