using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public class LinksContext : DbContext
    {
        public LinksContext(DbContextOptions<LinksContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Content> Contents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Profile>()
                .HasMany(c => c.Contents)
                .WithOne(e => e.Profile);
        }
    }
}
