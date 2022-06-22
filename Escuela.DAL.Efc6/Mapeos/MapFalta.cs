using Escuela.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escuela.DAL.Efc6.Mapeos;
public class MapFalta : IEntityTypeConfiguration<Falta>
{
    public void Configure(EntityTypeBuilder<Falta> builder)
    {
        builder.Property<uint>("dni");
        builder.Property<byte>("idCurso");

        builder.HasKey("dni", "idCurso")
            .HasName("PK_Falta");

        builder.HasOne(f => f.Alumno)
            .WithMany(a => a.Faltas)
            .HasConstraintName("FK_Falta_Alumno");

        builder.HasOne(f => f.Curso)
            .WithMany()
            .HasConstraintName("FK_Falta_Curso");
    }
}