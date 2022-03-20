using Microsoft.EntityFrameworkCore;

namespace adbNoob
{
    public class ActivityContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=device.db");
        }
        public DbSet<Activity> Activities { get; set; }
    }
}
