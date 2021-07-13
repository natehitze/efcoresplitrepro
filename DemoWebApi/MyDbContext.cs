using DemoWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApi
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }
        
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Calendars> Calendars { get; set; }
        public virtual DbSet<CalendarSubscriptions> CalendarSubscriptions { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
        }
    }
}