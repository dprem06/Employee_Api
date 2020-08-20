using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Transport> Transport { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(30);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(13)
                    .IsFixedLength();

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.State).HasMaxLength(30);
            });

            modelBuilder.Entity<Transport>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.TripFrom).HasMaxLength(30);

                entity.Property(e => e.TripTo).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
