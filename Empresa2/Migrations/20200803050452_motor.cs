using Microsoft.EntityFrameworkCore.Migrations;

namespace Empresa2.Migrations
{
    public partial class motor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
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
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Propietario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.IdEmpresa);
                });

            migrationBuilder.CreateTable(
                name: "Motor",
                columns: table => new
                {
                    IdMotor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(nullable: true),
                    TipoDeMotor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motor", x => x.IdMotor);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
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
                    table.PrimaryKey("PK_Vehiculo", x => x.IdVehiculo);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Empresa_EmpresaIdEmpresa",
                        column: x => x.EmpresaIdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Motor_MotorIdMotor",
                        column: x => x.MotorIdMotor,
                        principalTable: "Motor",
                        principalColumn: "IdMotor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente_vehiculo",
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
                    table.PrimaryKey("PK_Cliente_vehiculo", x => x.idClienteVehiculo);
                    table.ForeignKey(
                        name: "FK_Cliente_vehiculo_Cliente_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_vehiculo_Vehiculo_VehiculoIdVehiculo",
                        column: x => x.VehiculoIdVehiculo,
                        principalTable: "Vehiculo",
                        principalColumn: "IdVehiculo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_vehiculo_ClienteIdCliente",
                table: "Cliente_vehiculo",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_vehiculo_VehiculoIdVehiculo",
                table: "Cliente_vehiculo",
                column: "VehiculoIdVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_EmpresaIdEmpresa",
                table: "Vehiculo",
                column: "EmpresaIdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_MotorIdMotor",
                table: "Vehiculo",
                column: "MotorIdMotor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente_vehiculo");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Vehiculo");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Motor");
        }
    }
}
