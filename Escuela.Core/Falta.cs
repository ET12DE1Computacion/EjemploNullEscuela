namespace Escuela.Core;
public class Falta
{
    public Alumno Alumno { get; set; }
    public Curso Curso { get; set; }
    public DateOnly Fecha { get; set; }
    private static DateOnly Hoy 
        => DateOnly.FromDateTime(DateTime.Today);
    public Falta(Alumno alumno, Curso curso)
    {
        Alumno = alumno;
        Curso = curso;
        Fecha = Hoy;
    }

    public bool EsDeHoy => Fecha.Equals(Hoy);
    public int Anio => Fecha.Year;
    public bool EsAnio(int anio) => Anio == anio;
}