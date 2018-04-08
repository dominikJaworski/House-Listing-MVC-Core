using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HousesForSale.Models
{
    public partial class HousesForSaleContext : DbContext
    {
        public virtual DbSet<BuildingTypes> BuildingTypes { get; set; }
        public virtual DbSet<Houses> Houses { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<ParkingTypes> ParkingTypes { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }

        public HousesForSaleContext(DbContextOptions<HousesForSaleContext> options)
        : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-OQ47PMS\SQLEXPRESS;Database=HousesForSale;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuildingTypes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Houses>(entity =>
            {
                entity.HasKey(e => e.HouseId);

                entity.Property(e => e.HouseId).ValueGeneratedNever();

                entity.Property(e => e.Bathrooms).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Mlsnumber)
                    .IsRequired()
                    .HasColumnName("MLSnumber")
                    .HasMaxLength(20);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.StreetAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.BuildingType)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.BuildingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BuildingTypeId_FK");

                entity.HasOne(d => d.ParkingType)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.ParkingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ParkingTypeId_FK");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RegionId_FK");
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ParkingTypes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}
