using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace adbNoob.Factory
{
    public class ActivityContextFactory : IDesignTimeDbContextFactory<ActivityContext>
    {
            public ActivityContext CreateDbContext(string[]? args = null)
            {
                var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var optionsBuilder = new DbContextOptionsBuilder<ActivityContext>();
                optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
                return new ActivityContext();
            }
    }

}
