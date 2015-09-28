using System.Data.Entity;

namespace FinalProject.Models
{
    public class SiteContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
    
    }
}