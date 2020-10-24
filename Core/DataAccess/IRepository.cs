
////using Model.General;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T Get(long id);
        void Add(T entity);
      //  void Add(List<T> entity);
        void Update(T entity);
       
        void Delete(long id);
        void Remove(T entity);
        void SaveChanges();
        
    }
}
