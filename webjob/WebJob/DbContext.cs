using Microsoft.EntityFrameworkCore;

namespace MyWebJob
{
    public class MyDbContext : DbContext
    {
        public DbSet<RowItem> RowItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"...not needed for error reproduction purposes since the app is not loading...");
        }
    }

    public class RowItem
    {
        public int Id { get; set; }
        public string Data { get; set; }
    }
}
