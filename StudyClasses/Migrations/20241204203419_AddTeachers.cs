using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudyClasses.Migrations
{
    /// <inheritdoc />
    public partial class AddTeachers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ContractDateSerialized = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonGender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ContractDate", "ContractDateSerialized", "Name", "PersonGender", "Surname" },
                values: new object[,]
                {
                    { -5, new DateOnly(2020, 2, 1), "2020-02-01", "Hanter", 1, "Banter" },
                    { -4, new DateOnly(2023, 3, 4), "2023-03-04", "Jane", 2, "Done" },
                    { -3, new DateOnly(2019, 5, 6), "2019-05-06", "John", 1, "Doe" },
                    { -2, new DateOnly(2015, 8, 8), "2015-08-08", "Linda", 0, "Palinda" },
                    { -1, new DateOnly(2021, 10, 10), "2021-10-10", "Albert", 1, "Loop" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
