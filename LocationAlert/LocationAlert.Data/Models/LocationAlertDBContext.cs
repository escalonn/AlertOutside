using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LocationAlert.Data.Models
{
    public partial class LocationAlertDBContext : DbContext
    {
        private static Action<DbContextOptionsBuilder> s_configureConnection = options => { };

        public static Action<DbContextOptionsBuilder> ConfigureConnection
        {
            get => s_configureConnection;
            set => s_configureConnection = value ?? throw new ArgumentNullException(nameof(value));
        }

        public virtual DbSet<Alert> Alert { get; set; }
        public virtual DbSet<BaseAlert> BaseAlert { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<NewsPreference> NewsPreference { get; set; }
        public virtual DbSet<Preference> Preference { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<SubAlert> SubAlert { get; set; }
        public virtual DbSet<TrafficPreference> TrafficPreference { get; set; }
        public virtual DbSet<WeatherPreference> WeatherPreference { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                ConfigureConnection(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alert>(entity =>
            {
                entity.ToTable("Alert", "LA");

                entity.Property(e => e.AlertId).HasColumnName("AlertID");

                entity.Property(e => e.AlertMessage).HasMaxLength(512);

                entity.Property(e => e.AlertTypeId).HasColumnName("AlertTypeID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Alert)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Alert_Client");
            });

            modelBuilder.Entity<BaseAlert>(entity =>
            {
                entity.ToTable("BaseAlert", "LA");

                entity.Property(e => e.BaseAlertId).HasColumnName("BaseAlertID");

                entity.Property(e => e.BaseAlertType).HasMaxLength(50);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client", "LA");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MiddleInit).HasColumnType("nchar(1)");

                entity.Property(e => e.PasswordHash).HasColumnType("char(64)");

                entity.Property(e => e.PasswordSalt).HasMaxLength(20);

                entity.Property(e => e.PhoneNumber).HasColumnType("char(10)");

                entity.Property(e => e.PreferenceId).HasColumnName("PreferenceID");

                entity.HasOne(d => d.Preference)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.PreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Preference");
            });

            modelBuilder.Entity<NewsPreference>(entity =>
            {
                entity.ToTable("NewsPreference", "LA");

                entity.Property(e => e.NewsPreferenceId)
                    .HasColumnName("NewsPreferenceID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Preference>(entity =>
            {
                entity.ToTable("Preference", "LA");

                entity.Property(e => e.PreferenceId).HasColumnName("PreferenceID");

                entity.Property(e => e.NewsPreferenceId).HasColumnName("NewsPreferenceID");

                entity.Property(e => e.TrafficPreferenceId).HasColumnName("TrafficPreferenceID");

                entity.Property(e => e.WeatherPreferenceId).HasColumnName("WeatherPreferenceID");

                entity.HasOne(d => d.NewsPreference)
                    .WithMany(p => p.Preference)
                    .HasForeignKey(d => d.NewsPreferenceId)
                    .HasConstraintName("FK_Preference_NewsPreference");

                entity.HasOne(d => d.TrafficPreference)
                    .WithMany(p => p.Preference)
                    .HasForeignKey(d => d.TrafficPreferenceId)
                    .HasConstraintName("FK_Preference_TrafficPreference");

                entity.HasOne(d => d.WeatherPreference)
                    .WithMany(p => p.Preference)
                    .HasForeignKey(d => d.WeatherPreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Preference_WeatherPreference");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region", "LA");

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Latitude).HasColumnType("decimal(8, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.RegionName).HasMaxLength(50);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Region)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Region_Client");
            });

            modelBuilder.Entity<SubAlert>(entity =>
            {
                entity.ToTable("SubAlert", "LA");

                entity.Property(e => e.SubAlertId).HasColumnName("SubAlertID");

                entity.Property(e => e.BaseAlertId).HasColumnName("BaseAlertID");

                entity.Property(e => e.SubAlertType).HasMaxLength(50);

                entity.HasOne(d => d.BaseAlert)
                    .WithMany(p => p.SubAlert)
                    .HasForeignKey(d => d.BaseAlertId)
                    .HasConstraintName("FK_SubAlert_BaseAlert");
            });

            modelBuilder.Entity<TrafficPreference>(entity =>
            {
                entity.ToTable("TrafficPreference", "LA");

                entity.Property(e => e.TrafficPreferenceId)
                    .HasColumnName("TrafficPreferenceID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<WeatherPreference>(entity =>
            {
                entity.ToTable("WeatherPreference", "LA");

                entity.Property(e => e.WeatherPreferenceId).HasColumnName("WeatherPreferenceID");

                entity.Property(e => e.CloudMax).HasDefaultValueSql("((10))");

                entity.Property(e => e.CloudMin).HasDefaultValueSql("((0))");

                entity.Property(e => e.HumidityMax).HasDefaultValueSql("((10))");

                entity.Property(e => e.HumidityMin).HasDefaultValueSql("((0))");

                entity.Property(e => e.PushHours).HasDefaultValueSql("((1))");

                entity.Property(e => e.PushMinutes).HasDefaultValueSql("((0))");

                entity.Property(e => e.RainMax).HasDefaultValueSql("((10))");

                entity.Property(e => e.RainMin).HasDefaultValueSql("((0))");

                entity.Property(e => e.SnowMax).HasDefaultValueSql("((10))");

                entity.Property(e => e.SnowMin).HasDefaultValueSql("((0))");

                entity.Property(e => e.TempMax).HasDefaultValueSql("((10))");

                entity.Property(e => e.TempMin).HasDefaultValueSql("((0))");

                entity.Property(e => e.WindMax).HasDefaultValueSql("((10))");

                entity.Property(e => e.WindMin).HasDefaultValueSql("((0))");
            });
        }
    }
}
