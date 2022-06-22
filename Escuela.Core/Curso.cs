namespace Escuela.Core;
public class Curso
{
    //Atributo de clase, se comparte para todas las instancias
    private static byte _cantidadMaxima = 30;

    public List<FaltaPasada> FaltasPasadas { get; set; }

    //Definición clasica de atributo
    private byte anio;
    public byte IdCurso { get; set; }

    //Propiedad que usa para encapsular el atributo y verificar las asignaciones
    public byte Anio
    {
        get => anio;
        set
        {
            //Cuando hablamos de value, hablamos de la pseudo-variable del valor que se pretende asignar
            if (value > 6)
            {
                throw new ArgumentException("Solo son validos años de 1 al 6");
            }
            anio = value;
        }
    }
    public byte Division { get; set; }
    public string Turno { get; set; }
    public List<Alumno> Alumnos { get; set; }

    public Curso(byte anio, byte division, string turno)
    {
        Anio = anio;
        Division = division;
        Turno = turno;
        Alumnos = new();
        FaltasPasadas = new();
    }

    public void AgregarAlumno(Alumno alumno)
    {
        if (CantidadAlumnos == _cantidadMaxima)
            throw new InvalidOperationException("Cantidad de alumnos máxima alcanzada");
        if (Alumnos.Contains(alumno))
            throw new InvalidOperationException("Alumnos repetido");
        Alumnos.Add(alumno);
    }

    public void SacarAlumno(Alumno alumno)
        => Alumnos.Remove(alumno);

    public int CantidadAlumnos => Alumnos.Count;
    public override string ToString() => $"{anio}° - {CantidadAlumnos} alumnos";
    public void PasarFalta(DateOnly fecha)
    {
        if (FaltasPasadas.Exists(fp => fp.EsFecha(fecha)))
            throw new InvalidOperationException("Ya existe una falta para esa fecha");

        FaltasPasadas.Add(new FaltaPasada(this, fecha));
    }

    public void PasarFalta() => PasarFalta(Falta.Hoy);
}