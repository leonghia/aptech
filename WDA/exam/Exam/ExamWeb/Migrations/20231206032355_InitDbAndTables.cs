using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitDbAndTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department_Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department_Tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Tbl_Department_Tbl_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department_Tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Tbl_DepartmentId",
                table: "Employee_Tbl",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee_Tbl");

            migrationBuilder.DropTable(
                name: "Department_Tbl");
        }
    }
}
