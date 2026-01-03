using Film.Models;
using Microsoft.EntityFrameworkCore;

namespace Film.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u=>u.Email).IsUnique();
            modelBuilder.Entity<MovieCast>().HasIndex(mc=>new { mc.MovieId, mc.CastId}).IsUnique();
            modelBuilder.Entity<User>().HasOne(u=>u.Progress).WithOne(p=>p.User).HasForeignKey<UserProgress>(p=>p.UserId).OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<UserProgress> UsersProgress { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
    }
}