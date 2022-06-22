namespace Escuela.Core
{
    public class FaltaPasada
    {
        public FaltaPasada(Curso curso, DateOnly fecha)
        {
            Curso = curso;
            Fecha = fecha;
        }
        public FaltaPasada() { }
        public Curso Curso { get; set; } = null!;
        public DateOnly Fecha { get; set; }
        public bool EsFecha(DateOnly fecha) => Fecha.Equals(fecha);
    }
}