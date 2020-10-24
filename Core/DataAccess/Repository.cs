using Microsoft.EntityFrameworkCore;
using Model;

using System;
using System.Linq;
  

namespace DataAccess
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly Context _Context;
        private readonly DbSet<T> entities;
        public Repository(Context context)
        {
            _Context = context;
            entities = context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return entities;
        }

        public T Get(long id)
        {
            return entities.SingleOrDefault(s => s.ID == id);
        }
        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
           
        }
        

        public void Delete(long id)
        {
            var entity = entities.Find(id);
            entities.Remove(entity);
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            _Context.SaveChanges();
        }
         

    }
}
