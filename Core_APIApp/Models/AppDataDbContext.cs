using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_APIApp.Models
{
    public class AppDataDbContext : DbContext
    {
        /// <summary>
        /// Read the DbContext from DI Container
        /// and instantiate the Current DbContext based on Comnnection string
        /// passed to Db Context by DI Container
        /// DbContextOptions: Class that will read DbContext from DI Container
        /// by auto resolving the DbContextOptions from DI Container
        /// </summary>
        /// <param name="options"></param>
        public AppDataDbContext(DbContextOptions<AppDataDbContext> options):base(options)
        {

        }

        // IQueryable Cursors

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Map the CLR object to Db Tables taht is defined
        /// using DbSet<T> class properties
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           //  modelBuilder.Entity<Category>().HasMany<Product>("Products");
           // apply constraints on Table after generating table from CR Objects
        }
    }
}
