using Microsoft.EntityFrameworkCore;

namespace Mountains_Forum.Entities
{
    public class ForumDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(25);
            modelBuilder.Entity<User>().Property(p => p.Email).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Description).HasDefaultValue("Hi, I'm new in forum!").HasMaxLength(300);

            modelBuilder.Entity<Role>().Property(p => p.Name).IsRequired();

            modelBuilder.Entity<Category>().Property(p => p.Name).IsRequired();

            modelBuilder.Entity<Topic>().Property(p => p.Title).IsRequired();
            modelBuilder.Entity<Topic>().Property(p => p.CreatedDate).IsRequired();

            modelBuilder.Entity<Post>().Property(p => p.Content).IsRequired();
            modelBuilder.Entity<Post>().Property(p => p.CreatedDate).IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MountainsForum;Trusted_Connection=True;");
        }
    }
}
