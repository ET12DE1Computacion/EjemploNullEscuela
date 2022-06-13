using Escuela.Core;
using Escuela.DAL.Efc6.Mapeos;
using Microsoft.EntityFrameworkCore;

namespace Escuela.DAL.Efc6
{
    public class Contexto : DbContext
    {

        public DbSet<Curso> Cursos { get; set; } = null!;
        public DbSet<Alumno> Alumnos { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));

            optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=efc6", serverVersion);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            

            // modelBuilder.Entity<Curso>(curso =>
            // {
            //     curso.HasKey(e => e.IdCurso);
            //     curso.Ignore(c => c.Alumnos);
            //     curso.Ignore(c => c.CantidadAlumnos);
            //     curso.Property(c => c.Turno).HasMaxLength(12);
            //     curso.HasIndex(c => new { c.Anio, c.Division }).IsUnique();

            // });
            new MapCurso().Configure(modelBuilder.Entity<Curso>());
        }
    }
}