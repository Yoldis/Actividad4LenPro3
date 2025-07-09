using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Actividad4LenPro3.Models;

public partial class Actividad4LenPro3Context : DbContext
{
    public Actividad4LenPro3Context()
    {
    }

    public Actividad4LenPro3Context(DbContextOptions<Actividad4LenPro3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Calificacione> Calificaciones { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LOCALHOST;Database=Actividad4LenPro3;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calificacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Califica__3214EC07576CC1F0");

            entity.Property(e => e.CodigoMateria).HasMaxLength(15);
            entity.Property(e => e.MatriculaEstudiante).HasMaxLength(15);
            entity.Property(e => e.Periodo).HasMaxLength(20);

            entity.HasOne(d => d.CodigoMateriaNavigation).WithMany(p => p.Calificaciones)
                .HasPrincipalKey(p => p.Codigo)
                .HasForeignKey(d => d.CodigoMateria)
                .HasConstraintName("FK_Calificaciones_Materias");

            entity.HasOne(d => d.MatriculaEstudianteNavigation).WithMany(p => p.Calificaciones)
                .HasPrincipalKey(p => p.Matricula)
                .HasForeignKey(d => d.MatriculaEstudiante)
                .HasConstraintName("FK_Calificaciones_Estudiantes");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estudian__3214EC07711C68F3");

            entity.HasIndex(e => e.Matricula, "UQ__Estudian__0FB9FB4F0A39EEA2").IsUnique();

            entity.Property(e => e.Carrera).HasMaxLength(100);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(255);
            entity.Property(e => e.Genero).HasMaxLength(50);
            entity.Property(e => e.Matricula).HasMaxLength(15);
            entity.Property(e => e.NombreCompleto).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.TipoIngreso).HasMaxLength(50);
            entity.Property(e => e.Turno).HasMaxLength(50);
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Materias__3214EC07DA0B266C");

            entity.HasIndex(e => e.Codigo, "UQ__Materias__06370DAC9C7AA0B1").IsUnique();

            entity.Property(e => e.Carrera).HasMaxLength(50);
            entity.Property(e => e.Codigo).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
