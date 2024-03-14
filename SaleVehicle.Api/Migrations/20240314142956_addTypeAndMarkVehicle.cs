using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleVehicle.Api.Migrations
{
    /// <inheritdoc />
    public partial class addTypeAndMarkVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleMarks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMark = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMarks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameVehicleType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleMarks_NameMark",
                table: "VehicleMarks",
                column: "NameMark",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_NameVehicleType",
                table: "VehicleTypes",
                column: "NameVehicleType",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleMarks");

            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}
