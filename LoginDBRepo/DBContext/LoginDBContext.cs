using LoginDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LoginDBRepo.DBContext
{
    public class LoginDBContext : DbContext
    {
        public LoginDBContext()
        {
        }
        public LoginDBContext(DbContextOptions<LoginDBContext> options)
            : base(options)
        {
        }


        public DbSet<Rol> Rol { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountRol> AccountRol { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<RolModule> RolModule { get; set; }

        // Override names
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().ToTable("Rol");
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<AccountRol>().ToTable("AccountRol");
            modelBuilder.Entity<Module>().ToTable("Module");
            modelBuilder.Entity<RolModule>().ToTable("RolModule");
        }

        // DB Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("LoginDB");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


    }
}
