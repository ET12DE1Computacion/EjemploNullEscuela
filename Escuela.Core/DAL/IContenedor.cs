namespace Escuela.DAL;
public interface IContenedor
{
    public IRepoCurso RepoCursos { get; }
    public void Guardar();
}