using Microsoft.EntityFrameworkCore;
using MyDatePlanningData.Entities;

namespace MyDatePlanningData
{
    public class MyDatePlanningDBContext : DbContext  
    {
        public MyDatePlanningDBContext(DbContextOptions<MyDatePlanningDBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<PlaceType> PlaceTypes { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
    }
}
