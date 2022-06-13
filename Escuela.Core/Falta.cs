namespace Escuela.Core;
public class Falta
{
    public Alumno Alumno { get; set; }
    public Curso Curso { get; set; }
    public DateOnly Fecha { get; init; }
    private static DateOnly Hoy 
        => DateOnly.FromDateTime(DateTime.Today);
    public Falta(Alumno alumno, Curso curso, DateOnly? fecha = null)
    {
        Alumno = alumno;
        Curso = curso;
        Fecha = fecha ?? Hoy;
    }

    public bool EsDeHoy => Fecha.Equals(Hoy);
    public int Anio => Fecha.Year;
    public bool EsAnio(int anio) => Anio == anio;
}