using Escuela.Core;
using Microsoft.EntityFrameworkCore;

namespace Escuela.DAL.Efc6;
public class RepoCurso : IRepoCurso
{
    public DbSet<Curso> Cursos { get; set; }
    public RepoCurso(Contexto contexto) => Cursos = contexto.Cursos;
    public void Alta(Curso curso) => Cursos.Add(curso);
    public IEnumerable<Curso> Traer() => Cursos.ToList();
}