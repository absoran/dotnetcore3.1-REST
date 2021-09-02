using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SehirlerAPI.Models
{
    public partial class SehirlerContext : DbContext
    {
        public SehirlerContext()
        {
        }

        public SehirlerContext(DbContextOptions<SehirlerContext> options) : base(options)
        {
        }

        public virtual DbSet<Sehir> Sehirs { get; set; }
        public virtual DbSet<Ilceler> Ilcelers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //                optionsBuilder.UseSqlServer("Server=N107551\\SQLEXPRESS; Database=Sehirler; User ID=testuser;Password=testuser;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Sehir>(entity =>
            {
                entity.ToTable("sehir");
                entity.Property(e => e.Isim)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("isim");

                entity.Property(e => e.Plaka).HasColumnName("plaka");
            });

            modelBuilder.Entity<Ilceler>(entity =>
            {
                entity.ToTable("Ilceler");

                entity.Property(e => e.id)
                .HasColumnName("ID");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).
                ValueGeneratedOnAdd();


                entity.Property(e => e.ilce)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ilce");

                
                entity.Property(e => e.Plaka)
                .HasColumnName("Plaka");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
