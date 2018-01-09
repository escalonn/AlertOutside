using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LocationAlert.Data.Models
{
    public partial class LocationAlertDBContext : DbContext
    {
        public static string ConnectionString;

        public virtual DbSet<Client> Client { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client", "LA");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MiddleInit).HasColumnType("nchar(1)");

                entity.Property(e => e.PasswordHash).HasColumnType("char(64)");

                entity.Property(e => e.PasswordSalt).HasMaxLength(20);

                entity.Property(e => e.PhoneNumber).HasColumnType("char(10)");

                entity.Property(e => e.PreferenceId).HasColumnName("PreferenceID");
            });
        }
    }
}
