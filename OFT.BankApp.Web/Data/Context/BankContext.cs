using Microsoft.EntityFrameworkCore;
using OFT.BankApp.Web.Data.Configurations;
using OFT.BankApp.Web.Data.Entitites;

namespace OFT.BankApp.Web.Data.Context
{
    public class BankContext : DbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Account> Accounts { get; set; }
       public BankContext (DbContextOptions<BankContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
