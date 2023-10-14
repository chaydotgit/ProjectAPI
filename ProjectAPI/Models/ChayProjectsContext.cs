using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectAPI.Models
{
    public partial class ChayProjectsContext : DbContext
    {
        private readonly IConfiguration _config;

        public ChayProjectsContext(IConfiguration config, DbContextOptions<ChayProjectsContext> options)
            : base(options)
        {
            _config = config;
        }

        public virtual DbSet<Description> Descriptions { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config["Server"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Description>(entity =>
            {
                entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");

                entity.Property(e => e.Description1)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Description");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Descriptions)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__Descripti__Proje__3C69FB99");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProjectID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RepoLink)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Tech)
                    .HasMaxLength(50)
                    .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
