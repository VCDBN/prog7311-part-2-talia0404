using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Farm_Central_2.Models
{
    public partial class PROG_2023Context : DbContext
    {
        public PROG_2023Context()
        {
        }

        public PROG_2023Context(DbContextOptions<PROG_2023Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Farmer> Farmer { get; set; }
        public virtual DbSet<FarmerProducts> FarmerProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=lab000000\\SQLEXPRESS;Database=PROG_2023;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmployeePassword)
                    .HasColumnName("Employee_Password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeUsername)
                    .HasColumnName("Employee_Username")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Farmer>(entity =>
            {
                entity.Property(e => e.FarmerId)
                    .HasColumnName("FarmerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FarmerPassword)
                    .HasColumnName("Farmer_Password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FarmerUsername)
                    .HasColumnName("Farmer_Username")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FarmerProducts>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__FarmerPr__B40CC6EDCD1CD63D");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FarmerId).HasColumnName("FarmerID");

                entity.Property(e => e.ProductName)
                    .HasColumnName("Product_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Farmer)
                    .WithMany(p => p.FarmerProducts)
                    .HasForeignKey(d => d.FarmerId)
                    .HasConstraintName("FK__FarmerPro__Farme__4F7CD00D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
