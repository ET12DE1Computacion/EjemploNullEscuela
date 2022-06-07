namespace Escuela.Core;
public class Alumno
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public uint Dni { get; set; }
    public Curso? Curso { get; set; }
    public List<Falta> Faltas { get; set; }

    public Alumno(string nombre, string apellido, uint dni)
    {
        Nombre = nombre;
        Apellido = apellido;
        Dni = dni;
        Faltas = new();
    }

    public string Saludar() => $"Hola, soy {Nombre} {Apellido} con dni: {Dni}";

    public void InscribiteEn(Curso curso)
    {
        //Pregunto si previamente había un curso
        if (Curso is not null)
            //Me salgo del curso anterior
            Curso.SacarAlumno(this);
        //Me agrego al curso nuevo
        curso.AgregarAlumno(this);
        //Guardo referencia del nuevo curso
        Curso = curso;
    }
    public void PonerAusente()
    {
        if (Curso is null)
            throw new InvalidOperationException("No posee curso");
        if (Faltas.Exists(f => f.EsDeHoy))
            throw new InvalidProgramException("Ya posee una falta");
        Faltas.Add(new Falta(this, Curso));
    }

    public Curso? ObtenerCurso() => Curso;
}