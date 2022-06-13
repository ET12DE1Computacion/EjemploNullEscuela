using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escuela.DAL.Efc6.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    idCurso = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Anio = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Division = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Turno = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.idCurso);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    dni = table.Column<uint>(type: "int unsigned", nullable: false),
                    nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellido = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CursoIdCurso = table.Column<byte>(type: "tinyint unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.dni);
                    table.ForeignKey(
                        name: "FK_Alumno_Curso_CursoIdCurso",
                        column: x => x.CursoIdCurso,
                        principalTable: "Curso",
                        principalColumn: "idCurso");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_CursoIdCurso",
                table: "Alumno",
                column: "CursoIdCurso");

            migrationBuilder.CreateIndex(
                name: "UQ_Curso_anio_division",
                table: "Curso",
                columns: new[] { "Anio", "Division" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumno");

            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}
