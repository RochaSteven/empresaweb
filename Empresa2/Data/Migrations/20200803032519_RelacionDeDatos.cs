
using Microsoft.EntityFrameworkCore.Migrations;

namespace Empresa2.Data.Migrations
{
    public partial class RelacionDeDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Propietario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.IdEmpresa);
                });

            migrationBuilder.CreateTable(
                name: "Motors",
                columns: table => new
                {
                    IdMotor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(nullable: true),
                    TipoDeMotor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motors", x => x.IdMotor);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    IdVehiculo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    IdMotor = table.Column<int>(nullable: false),
                    MotorIdMotor = table.Column<int>(nullable: true),
                    IdEmpresa = table.Column<int>(nullable: false),
                    EmpresaIdEmpresa = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.IdVehiculo);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Empresas_EmpresaIdEmpresa",
                        column: x => x.EmpresaIdEmpresa,
                        principalTable: "Empresas",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Motors_MotorIdMotor",
                        column: x => x.MotorIdMotor,
                        principalTable: "Motors",
                        principalColumn: "IdMotor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente_Vehiculos",
                columns: table => new
                {
                    idClienteVehiculo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(nullable: false),
                    IdVehiculo = table.Column<int>(nullable: false),
                    ClienteIdCliente = table.Column<int>(nullable: true),
                    VehiculoIdVehiculo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente_Vehiculos", x => x.idClienteVehiculo);
                    table.ForeignKey(
                        name: "FK_Cliente_Vehiculos_Clientes_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_Vehiculos_Vehiculos_VehiculoIdVehiculo",
                        column: x => x.VehiculoIdVehiculo,
                        principalTable: "Vehiculos",
                        principalColumn: "IdVehiculo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Vehiculos_ClienteIdCliente",
                table: "Cliente_Vehiculos",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Vehiculos_VehiculoIdVehiculo",
                table: "Cliente_Vehiculos",
                column: "VehiculoIdVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_EmpresaIdEmpresa",
                table: "Vehiculos",
                column: "EmpresaIdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_MotorIdMotor",
                table: "Vehiculos",
                column: "MotorIdMotor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente_Vehiculos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Motors");
        }
    }
}
