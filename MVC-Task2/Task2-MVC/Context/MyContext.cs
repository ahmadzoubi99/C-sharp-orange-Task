using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Task2_MVC.Models;

namespace Task2_MVC.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> myContext) : base(myContext)
        {
        }

        public DbSet<Product>  product{get;set ;}
        public DbSet<Categories> Category { get;set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            var conString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(conString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
