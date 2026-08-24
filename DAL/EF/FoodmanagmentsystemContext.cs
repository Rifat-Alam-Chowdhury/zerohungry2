using System;
using System.Collections.Generic;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public partial class FoodmanagmentsystemContext : DbContext
{
    public FoodmanagmentsystemContext()
    {
    }

    public FoodmanagmentsystemContext(DbContextOptions<FoodmanagmentsystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CollectionRequest> CollectionRequests { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DbConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CollectionRequest>(entity =>
        {
            entity.HasKey(e => e.CollectionReqId);

            entity.Property(e => e.CollectionReqId).HasColumnName("Collection_Req_Id");
            entity.Property(e => e.FreshTime).HasColumnType("datetime");
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.CollectionRequests)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_CollectionRequests_Employees");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.CollectionRequests)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CollectionRequests_Restaurants");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeId);

            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
