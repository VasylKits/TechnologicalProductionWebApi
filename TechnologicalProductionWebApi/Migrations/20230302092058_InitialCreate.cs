using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechnologicalProductionWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionBuildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Square = table.Column<double>(type: "float", nullable: false),
                    FreeSquare = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionBuildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfEquipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Square = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfEquipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => new { x.TypeId, x.BuildingId });
                    table.ForeignKey(
                        name: "FK_Contracts_ProductionBuildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "ProductionBuildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_TypeOfEquipments_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TypeOfEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductionBuildings",
                columns: new[] { "Id", "FreeSquare", "Name", "Square" },
                values: new object[,]
                {
                    { 1, 100.0, "Building 1", 100.0 },
                    { 2, 125.0, "Building 2", 125.0 },
                    { 3, 88.0, "Building 3", 88.0 },
                    { 4, 200.0, "Building 4", 200.0 },
                    { 5, 165.0, "Building 5", 165.0 },
                    { 6, 346.0, "Building 6", 346.0 }
                });

            migrationBuilder.InsertData(
                table: "TypeOfEquipments",
                columns: new[] { "Id", "Name", "Square" },
                values: new object[,]
                {
                    { 1, "Type 1", 10.0 },
                    { 2, "Type 2", 25.0 },
                    { 3, "Type 3", 18.0 },
                    { 4, "Type 4", 37.0 },
                    { 5, "Type 5", 60.0 },
                    { 6, "Type 6", 5.0 }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "BuildingId", "TypeId", "Count", "Name" },
                values: new object[,]
                {
                    { 1, 5, 1, "Contract15" },
                    { 6, 5, 3, "Contract65" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_BuildingId",
                table: "Contracts",
                column: "BuildingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "ProductionBuildings");

            migrationBuilder.DropTable(
                name: "TypeOfEquipments");
        }
    }
}
