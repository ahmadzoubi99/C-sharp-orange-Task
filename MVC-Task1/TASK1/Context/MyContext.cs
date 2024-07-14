using Microsoft.EntityFrameworkCore;
using TASK1.Models;

namespace TASK1.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> myContext) : base(myContext)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Users> Users { get; set; }
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
