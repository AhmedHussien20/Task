using Microsoft.EntityFrameworkCore;
using Model;
using System.Reflection;

namespace DataAccess
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
         

        
        #region MyRegion  
       
        public DbSet<UserData> UsersData { get; set; }
      
        #endregion
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }
    }
}