 
using Model;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

using System;
using DataAccess;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _Context;


        #region Default
       
        private IRepository<UserData> _UserDataRepository;
        public IRepository<UserData> UserDataRepository { get { return _UserDataRepository = _UserDataRepository ?? new Repository<UserData>(_Context); } }
         
        #endregion
 
        public UnitOfWork(Context Context)
        {
            _Context = Context;
            
        }
        public void Dispose()
        {
            _Context.Dispose();
        }
        public void SaveChanges()
        {
            _Context.SaveChanges();
        }

        public void SaveChanges(long userId, string source)
        {
            using (var dbContextTransaction = _Context.Database.BeginTransaction())
            {
                try
                {
                    
                    Dictionary<EntityEntry, int> objectList = new Dictionary<EntityEntry, int>();

                    List<EntityEntry> entityList =
                       _Context.ChangeTracker.Entries()
                            .Where(
                                p =>
                                    p.State == Microsoft.EntityFrameworkCore.EntityState.Added || p.State == Microsoft.EntityFrameworkCore.EntityState.Deleted ||
                                    p.State == Microsoft.EntityFrameworkCore.EntityState.Modified).ToList();




                    _Context.SaveChanges();

                   
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
