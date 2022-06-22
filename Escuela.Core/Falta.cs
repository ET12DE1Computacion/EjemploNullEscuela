using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Core;
[Table("Falta")]
public class Falta
{
    public Alumno Alumno { get; set; } = null!;
    public Curso Curso { get; set; } = null!;

    [Column("fecha")]
    public DateOnly Fecha { get; set; }
    public static DateOnly Hoy 
        => DateOnly.FromDateTime(DateTime.Today);
    public Falta(Alumno alumno, Curso curso, DateOnly? fecha = null)
    {
        Alumno = alumno;
        Curso = curso;
        Fecha = fecha ?? Hoy;
    }
    public Falta() { }

    public bool EsDeHoy => Fecha.Equals(Hoy);
    
    public int Anio => Fecha.Year;
    public bool EsAnio(int anio) => Anio == anio;
}