using HelpMeFixIt.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HelpMeFixIt.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Fixer> Fixers { get; set; }
        public DbSet<Opinion> Opinions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Rating>()
                .HasKey(r => new { r.UserId, r.FixerId });

            base.OnModelCreating(builder);
        }

    }
}