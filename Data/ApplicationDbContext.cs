using KnowledgeBase.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;

namespace KnowledgeBase.Data
{
    public class ApplicationDbContext : IdentityDbContext   //DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        /// Связываем сущности (модели) с таблицами в базе данных
        public DbSet<Law> Laws { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<Document> Documents { get; set; }

        // Настройки подключения к БД
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=KnowledgeBaseDb;Username=fasdbadmin;Password=admin");
            optionsBuilder.ConfigureWarnings(warnings => warnings.Throw(CoreEventId.InvalidIncludePathError));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => new { x.ProviderKey, x.LoginProvider });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<Document>().HasKey(d => new { d.Id });
        }

    




    }
}