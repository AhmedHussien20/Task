
using Model;
using System;

namespace DataAccess
{
    public interface IUnitOfWork : IDisposable
    {

        #region Default
       
        IRepository<UserData> UserDataRepository { get; }

        #endregion
 
        void SaveChanges();
        void SaveChanges(long userId, string source);
    }
}
