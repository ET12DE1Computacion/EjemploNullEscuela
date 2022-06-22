using Escuela.Core;
using Escuela.DAL.Efc6.Mapeos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Escuela.DAL.Efc6
{
    public class Contexto : DbContext
    {

        public DbSet<Curso> Cursos => Set<Curso>();
        public DbSet<Alumno> Alumnos => Set<Alumno>();
        public DbSet<Falta> Faltas => Set<Falta>();
        public DbSet<FaltaPasada> FaltasPasadas => Set<FaltaPasada>();
        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            if (!ob.IsConfigured)
        {
            IConfiguration myConfig = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appSettings.json")
                .Build();

            string strConexion = myConfig.GetConnectionString("dev");
            var serverVersion = new MySqlServerVersion(versionString: myConfig["SerVersion"]);
            ob.UseMySql(strConexion, serverVersion);
        }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new MapCurso().Configure(modelBuilder.Entity<Curso>());
            new MapAlumno().Configure(modelBuilder.Entity<Alumno>());
            new MapFalta().Configure(modelBuilder.Entity<Falta>());
            new MapFaltaPasada().Configure(modelBuilder.Entity<FaltaPasada>());
        }
    }
}