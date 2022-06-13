using Escuela.Core;

namespace Escuela.DAL;
public interface IRepoCurso
{
    public IEnumerable<Curso> Traer();
    public void Alta(Curso curso);
}