using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace VizsgaremekAPI.BurgerAdatbazisEFCore
{
    public partial class burgeretteremContext : DbContext
    {
        public burgeretteremContext()
        {
        }

        public burgeretteremContext(DbContextOptions<burgeretteremContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Burger> Burgers { get; set; }
        public virtual DbSet<Desszert> Desszerts { get; set; }
        public virtual DbSet<Felhasznalo> Felhasznalos { get; set; }
        public virtual DbSet<Foglala> Foglalas { get; set; }
        public virtual DbSet<Ital> Itals { get; set; }
        public virtual DbSet<Koret> Korets { get; set; }
        public virtual DbSet<Rendele> Rendeles { get; set; }
        public virtual DbSet<Tetel> Tetels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;database=burgeretterem;username=root;pwd=;sslmode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Burger>(entity =>
            {
                entity.HasKey(e => e.Bazon)
                    .HasName("PRIMARY");

                entity.ToTable("burger");

                entity.Property(e => e.Bazon)
                    .HasColumnType("int(1)")
                    .HasColumnName("bazon");

                entity.Property(e => e.Aktiv)
                    .IsRequired()
                    .HasColumnName("aktiv")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Bar)
                    .HasColumnType("int(4)")
                    .HasColumnName("bar");

                entity.Property(e => e.Bleir)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("bleir");

                entity.Property(e => e.Bnev)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("bnev");
            });

            modelBuilder.Entity<Desszert>(entity =>
            {
                entity.HasKey(e => e.Dazon)
                    .HasName("PRIMARY");

                entity.ToTable("desszert");

                entity.Property(e => e.Dazon)
                    .HasColumnType("int(1)")
                    .HasColumnName("dazon");

                entity.Property(e => e.Aktiv)
                    .IsRequired()
                    .HasColumnName("aktiv")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Dar)
                    .HasColumnType("int(4)")
                    .HasColumnName("dar");

                entity.Property(e => e.Dleir)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("dleir");

                entity.Property(e => e.Dnev)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dnev");
            });

            modelBuilder.Entity<Felhasznalo>(entity =>
            {
                entity.HasKey(e => e.Azon)
                    .HasName("PRIMARY");

                entity.ToTable("felhasznalo");

                entity.Property(e => e.Azon)
                    .HasColumnType("int(6) unsigned")
                    .HasColumnName("azon");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Jog)
                    .HasColumnType("int(1)")
                    .HasColumnName("jog");

                entity.Property(e => e.Lak)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("lak");

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nev");

                entity.Property(e => e.Pw)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("pw");

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("tel");
            });

            modelBuilder.Entity<Foglala>(entity =>
            {
                entity.HasKey(e => e.Fazon)
                    .HasName("PRIMARY");

                entity.ToTable("foglalas");

                entity.HasIndex(e => e.Azon, "fk_foglalas_felhasznalo");

                entity.Property(e => e.Fazon)
                    .HasColumnType("int(4) unsigned")
                    .HasColumnName("fazon");

                entity.Property(e => e.Azon)
                    .HasColumnType("int(6) unsigned")
                    .HasColumnName("azon")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Foglalasido).HasColumnName("foglalasido");

                entity.Property(e => e.Leadva).HasColumnName("leadva");

                entity.Property(e => e.Megjelent).HasColumnName("megjelent");

                entity.Property(e => e.Szemelydb)
                    .HasColumnType("int(1)")
                    .HasColumnName("szemelydb");

                entity.HasOne(d => d.AzonNavigation)
                    .WithMany(p => p.Foglalas)
                    .HasForeignKey(d => d.Azon)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_foglalas_felhasznalo");
            });

            modelBuilder.Entity<Ital>(entity =>
            {
                entity.HasKey(e => e.Iazon)
                    .HasName("PRIMARY");

                entity.ToTable("ital");

                entity.Property(e => e.Iazon)
                    .HasColumnType("int(1)")
                    .HasColumnName("iazon");

                entity.Property(e => e.Aktiv)
                    .IsRequired()
                    .HasColumnName("aktiv")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Iar)
                    .HasColumnType("int(4)")
                    .HasColumnName("iar");

                entity.Property(e => e.Ileir)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ileir");

                entity.Property(e => e.Inev)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("inev");
            });

            modelBuilder.Entity<Koret>(entity =>
            {
                entity.HasKey(e => e.Kazon)
                    .HasName("PRIMARY");

                entity.ToTable("koret");

                entity.Property(e => e.Kazon)
                    .HasColumnType("int(1)")
                    .HasColumnName("kazon");

                entity.Property(e => e.Aktiv)
                    .IsRequired()
                    .HasColumnName("aktiv")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Kar)
                    .HasColumnType("int(4)")
                    .HasColumnName("kar");

                entity.Property(e => e.Kleir)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("kleir");

                entity.Property(e => e.Knev)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("knev");
            });

            modelBuilder.Entity<Rendele>(entity =>
            {
                entity.HasKey(e => e.Razon)
                    .HasName("PRIMARY");

                entity.ToTable("rendeles");

                entity.HasIndex(e => e.Fazon, "fk_rendeles_foglalas");

                entity.Property(e => e.Razon)
                    .HasColumnType("int(4) unsigned")
                    .HasColumnName("razon");

                entity.Property(e => e.Asztal)
                    .HasColumnType("int(1)")
                    .HasColumnName("asztal");

                entity.Property(e => e.Etelstatus)
                    .HasColumnType("int(1)")
                    .HasColumnName("etelstatus");

                entity.Property(e => e.Fazon)
                    .HasColumnType("int(4) unsigned")
                    .HasColumnName("fazon")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Ido).HasColumnName("ido");

                entity.Property(e => e.Italstatus)
                    .HasColumnType("int(1)")
                    .HasColumnName("italstatus");

                entity.HasOne(d => d.FazonNavigation)
                    .WithMany(p => p.Rendeles)
                    .HasForeignKey(d => d.Fazon)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_rendeles_foglalas");
            });

            modelBuilder.Entity<Tetel>(entity =>
            {
                entity.HasKey(e => e.Tazon)
                    .HasName("PRIMARY");

                entity.ToTable("tetel");

                entity.HasIndex(e => e.Bazon, "fk_tetel_burger");

                entity.HasIndex(e => e.Dazon, "fk_tetel_desszert");

                entity.HasIndex(e => e.Iazon, "fk_tetel_ital");

                entity.HasIndex(e => e.Kazon, "fk_tetel_koret");

                entity.HasIndex(e => e.Razon, "fk_tetel_rendeles");

                entity.Property(e => e.Tazon)
                    .HasColumnType("int(4) unsigned")
                    .HasColumnName("tazon");

                entity.Property(e => e.Bazon)
                    .HasColumnType("int(1)")
                    .HasColumnName("bazon");

                entity.Property(e => e.Bdb)
                    .HasColumnType("int(1)")
                    .HasColumnName("bdb")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dazon)
                    .HasColumnType("int(1)")
                    .HasColumnName("dazon");

                entity.Property(e => e.Ddb)
                    .HasColumnType("int(1)")
                    .HasColumnName("ddb")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Etelstatus)
                    .HasColumnType("int(1)")
                    .HasColumnName("etelstatus");

                entity.Property(e => e.Iazon)
                    .HasColumnType("int(1)")
                    .HasColumnName("iazon");

                entity.Property(e => e.Idb)
                    .HasColumnType("int(1)")
                    .HasColumnName("idb")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Italstatus)
                    .HasColumnType("int(1)")
                    .HasColumnName("italstatus");

                entity.Property(e => e.Kazon)
                    .HasColumnType("int(1)")
                    .HasColumnName("kazon");

                entity.Property(e => e.Kdb)
                    .HasColumnType("int(1)")
                    .HasColumnName("kdb")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Megjegyzes)
                    .HasMaxLength(255)
                    .HasColumnName("megjegyzes")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Razon)
                    .HasColumnType("int(4) unsigned")
                    .HasColumnName("razon")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.BazonNavigation)
                    .WithMany(p => p.Tetels)
                    .HasForeignKey(d => d.Bazon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tetel_burger");

                entity.HasOne(d => d.DazonNavigation)
                    .WithMany(p => p.Tetels)
                    .HasForeignKey(d => d.Dazon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tetel_desszert");

                entity.HasOne(d => d.IazonNavigation)
                    .WithMany(p => p.Tetels)
                    .HasForeignKey(d => d.Iazon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tetel_ital");

                entity.HasOne(d => d.KazonNavigation)
                    .WithMany(p => p.Tetels)
                    .HasForeignKey(d => d.Kazon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tetel_koret");

                entity.HasOne(d => d.RazonNavigation)
                    .WithMany(p => p.Tetels)
                    .HasForeignKey(d => d.Razon)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_tetel_rendeles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
