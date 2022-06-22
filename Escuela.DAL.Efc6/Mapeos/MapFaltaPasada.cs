using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Escuela.Core;

namespace Escuela.DAL.Efc6.Mapeos
{
    public class MapFaltaPasada : IEntityTypeConfiguration<FaltaPasada>
    {
        public void Configure(EntityTypeBuilder<FaltaPasada> builder)
        {
            builder.ToTable("FaltaPasada");

            builder.Property<byte>("idCurso").HasColumnOrder(1);
            builder.Property(pf=>pf.Fecha).HasColumnName("fecha");

            builder.HasKey("idCurso", "Fecha")
                .HasName("PK_FaltaPasada");
            
            builder.HasOne(pf=>pf.Curso)
                .WithMany(c=>c.FaltasPasadas)
                .HasConstraintName("FK_FaltaPasada_Curso");
        }
    }
}