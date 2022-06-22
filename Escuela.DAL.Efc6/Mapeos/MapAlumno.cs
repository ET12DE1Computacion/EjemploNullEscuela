using Escuela.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escuela.DAL.Efc6.Mapeos;
public class MapAlumno : IEntityTypeConfiguration<Alumno>
{
    public void Configure(EntityTypeBuilder<Alumno> builder)
    {
        builder.HasOne(a => a.Curso)
            .WithMany(c => c.Alumnos)
            .HasForeignKey("idCurso")
            .HasConstraintName("FK_Alumno_Curso");
    }
}