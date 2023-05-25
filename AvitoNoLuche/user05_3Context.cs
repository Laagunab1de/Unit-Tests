using System;
using System.Collections.Generic;
using AvitoNoLuche.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AvitoNoLuche
{
    public partial class user05_3Context : DbContext
    {
        public user05_3Context()
        {
        }

        public user05_3Context(DbContextOptions<user05_3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AboutHouse> AboutHouses { get; set; } = null!;
        public virtual DbSet<Apartment> Apartments { get; set; } = null!;
        public virtual DbSet<BalconyType> BalconyTypes { get; set; } = null!;
        public virtual DbSet<Bathroom> Bathrooms { get; set; } = null!;
        public virtual DbSet<Parking> Parkings { get; set; } = null!;
        public virtual DbSet<Repair> Repairs { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<TransactionType> TransactionTypes { get; set; } = null!;
        public virtual DbSet<TypeHouse> TypeHouses { get; set; } = null!;
        public virtual DbSet<TypeWindow> TypeWindows { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost;database=database;user=sa;password=sa;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Cyrillic_General_100_CI_AI_SC_UTF8");

            modelBuilder.Entity<AboutHouse>(entity =>
            {
                entity.ToTable("AboutHouse");

                entity.Property(e => e.YearOfConsruction)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdParkingNavigation)
                    .WithMany(p => p.AboutHouses)
                    .HasForeignKey(d => d.IdParking)
                    .HasConstraintName("FK_AboutHouse_Parking");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.AboutHouses)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AboutHouse_Status");

                entity.HasOne(d => d.IdTypeHouseNavigation)
                    .WithMany(p => p.AboutHouses)
                    .HasForeignKey(d => d.IdTypeHouse)
                    .HasConstraintName("FK_AboutHouse_TypeHouse");
            });

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.ToTable("Apartment");

                entity.Property(e => e.Adress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("adress");

                entity.Property(e => e.CeilingHeight)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ceiling_height");

                entity.Property(e => e.Cost)
                    .HasColumnType("money")
                    .HasColumnName("cost");

                entity.Property(e => e.Discription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("discription");

                entity.Property(e => e.Furniture)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("furniture");

                entity.Property(e => e.IdBalconyType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdRepair).HasColumnName("idRepair");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Photo)
                    .HasMaxLength(10000)
                    .IsUnicode(false)
                    .HasColumnName("photo");

                entity.Property(e => e.Square).HasColumnName("square");

                entity.Property(e => e.Technique)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("technique");

                entity.HasOne(d => d.IdBathroomtypeNavigation)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.IdBathroomtype)
                    .HasConstraintName("FK_Apartment_BalconyType");

                entity.HasOne(d => d.IdBathroomtype1)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.IdBathroomtype)
                    .HasConstraintName("FK_Apartment_Bathroom");

                entity.HasOne(d => d.IdRepairNavigation)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.IdRepair)
                    .HasConstraintName("FK_Apartment_Repair");

                entity.HasOne(d => d.IdTransactionTypeNavigation)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.IdTransactionType)
                    .HasConstraintName("FK_Apartment_TransactionType");

                entity.HasOne(d => d.IdTypeWindowsNavigation)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.IdTypeWindows)
                    .HasConstraintName("FK_Apartment_TypeWindows");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Apartment_user");

                entity.HasOne(d => d.IdhouseNavigation)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.Idhouse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Apartment_AboutHouse");
            });

            modelBuilder.Entity<BalconyType>(entity =>
            {
                entity.ToTable("BalconyType");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bathroom>(entity =>
            {
                entity.ToTable("Bathroom");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BathroomType)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Parking>(entity =>
            {
                entity.ToTable("Parking");

                entity.Property(e => e.Parking1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Parking");
            });

            modelBuilder.Entity<Repair>(entity =>
            {
                entity.ToTable("Repair");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Repair1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Repair");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Status1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("TransactionType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TypeTransaction)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeHouse>(entity =>
            {
                entity.ToTable("TypeHouse");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeWindow>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Windows)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Number)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("number");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
