using ExtraTask.Models;
using Microsoft.EntityFrameworkCore;

namespace ExtraTask.Context
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> mycontext) : base(mycontext)
        {
        }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Assessment> Assessments { get; set; }

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
