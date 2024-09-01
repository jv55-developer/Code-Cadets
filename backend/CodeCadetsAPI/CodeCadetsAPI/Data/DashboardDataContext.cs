using CodeCadetsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CodeCadetsAPI.Data
{
    public class DashboardDataContext : DbContext
    {
        public DashboardDataContext(DbContextOptions<DashboardDataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectManagement> ProjectManagement { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<User>()
                .HasIndex(e => e.Email)
                .IsUnique();

            builder.Entity<User>()
               .HasIndex(e => e.PhoneNumber)
               .IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=CodeCadets.db");
        }
    }
}
