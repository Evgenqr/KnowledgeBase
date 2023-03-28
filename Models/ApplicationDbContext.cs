using KnowledgeBase.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace KnowledgeBase.Data
{
    public class ApplicationDbContext : DbContext  //IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Law> Laws { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=KnowledgeBaseDb;Username=fasdbadmin;Password=admin");
            optionsBuilder.ConfigureWarnings(warnings => warnings.Throw(CoreEventId.InvalidIncludePathError));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => new { x.ProviderKey, x.LoginProvider });
            modelBuilder.Entity<Document>()
                .HasKey(d => new { d.Id });
        }
    }
}