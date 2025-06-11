using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;


namespace AccountManagement.Infrastructure.EFCore
{
    public class AccountContextFactory : IDesignTimeDbContextFactory<AccountContext>
    {
        public AccountContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AccountContext>();

            // Use your actual connection string here
           // optionsBuilder.UseSqlServer("Server=.;Database=HoldenHarvest;Integrated Security=True;");

            return new AccountContext(optionsBuilder.Options);
        }
    }
}
