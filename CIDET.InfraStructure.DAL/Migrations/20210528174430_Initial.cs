using Microsoft.EntityFrameworkCore.Migrations;

namespace CIDET.InfraStructure.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    CodigoDANE = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    EsDistrito = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Antioquia" },
                    { 2, "Atlántico" },
                    { 3, "Bolívar" },
                    { 4, "Bogotá" },
                    { 5, "Chocó" },
                    { 6, "Cundinamarca" },
                    { 7, "La Guajira" },
                    { 8, "Nariño" },
                    { 9, "Norte de Santander" },
                    { 10, "Quindío" },
                    { 11, "San Andrés y Providencia" },
                    { 12, "Santander" },
                    { 13, "Sucre" },
                    { 14, "Tolima" },
                    { 15, "Valle del Cauca" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_Nombre",
                table: "Departamentos",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_CodigoDANE",
                table: "Municipios",
                column: "CodigoDANE");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_Nombre",
                table: "Municipios",
                column: "Nombre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Municipios");
        }
    }
}
