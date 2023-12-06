using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExamWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDepartmentsAndEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Department_Tbl",
                columns: new[] { "Id", "DepartmentCode", "DepartmentName", "Location" },
                values: new object[,]
                {
                    { 1, "ACC", "Accounting", "Vietnam" },
                    { 2, "PMGT", "Production Management", "Vietnam" },
                    { 3, "HR", "Human Resources", "Vietnam" },
                    { 4, "IT", "Information Technology", "Vietnam" }
                });

            migrationBuilder.InsertData(
                table: "Employee_Tbl",
                columns: new[] { "Id", "DepartmentId", "EmployeeCode", "EmployeeName", "Rank" },
                values: new object[] { 1, 4, "E01", "La Trong Nghia", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department_Tbl",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Department_Tbl",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Department_Tbl",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employee_Tbl",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Department_Tbl",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
