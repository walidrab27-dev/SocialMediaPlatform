using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaPlatform.Data.Models
{
    public class SocialMediaPlatformDbContext : DbContext
    {
        private string _connection = @"Server=walidrab27\SQLEXPRESS;Database=SocialMediaPlatformDb;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
        }
        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries().Where(e=>e.Entity!=null && (e.State == EntityState.Added || e.State==EntityState.Modified));
            foreach(var entity in entities)
            {
                var context = new ValidationContext(entity);
                Validator.ValidateObject(entity.Entity,context,true);
            }
            var models = ChangeTracker.Entries<BaseEntity>();
            foreach(var model in models)
            {
                if (model.State == EntityState.Added)
                    model.Entity.CreatedAt = DateTime.UtcNow;
                else if (model.State == EntityState.Modified)
                    model.Entity.UpdatedAt = DateTime.UtcNow;
            }
            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex("Username").IsUnique();
                entity.HasIndex("Email").IsUnique();
            });
        }
        public DbSet<User> Users { get; set; }
    }
}
