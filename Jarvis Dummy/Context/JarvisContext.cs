using Jarvis_Dummy.Model;
using Microsoft.EntityFrameworkCore;

namespace Jarvis_Dummy.Context
{
    public class JarvisContext : DbContext
    {
        public JarvisContext(DbContextOptions<JarvisContext> options) :base(options)
        {
            
        }

        public JarvisContext()
        {
        }

        protected override void OnConfiguring
      (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "JarvisDb");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<GetJarvisInfo>(
        //            eb =>
        //            {                                               
        //                eb.HasNoKey();                        
        //                eb.Property(v => v.UEN);
        //            });
        //}
        public DbSet<GetJarvisInfo> getJarvisInfos { get; set; }        

    }
}
