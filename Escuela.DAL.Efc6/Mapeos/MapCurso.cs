using Escuela.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escuela.DAL.Efc6.Mapeos;

public class MapCurso : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.ToTable("Curso");

        builder.HasKey(c => c.IdCurso)
                .HasName("PK_Curso");
        builder.HasIndex(c => new { c.Anio, c.Division })
                .IsUnique()
                .HasDatabaseName("UQ_Curso_anio_division");

        builder.Property(c => c.IdCurso)
                .HasColumnName("idCurso");
        builder.Property(c => c.Turno).HasMaxLength(12);
        builder.Ignore(c => c.CantidadAlumnos);
    }
}