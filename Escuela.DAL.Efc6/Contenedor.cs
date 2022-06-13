namespace Escuela.DAL.Efc6;
public class Contenedor : IContenedor
{

    public IRepoCurso RepoCursos {get; init;}
    Contexto Contexto {get; set;}
    public Contenedor(Contexto contexto)
    {
        Contexto = contexto;
        RepoCursos = new RepoCurso(contexto);
    }

    public void Guardar() => Contexto.SaveChanges();

}
