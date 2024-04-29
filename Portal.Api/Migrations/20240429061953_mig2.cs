using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _20201132039_SinavPortali.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82d895b0-cd76-496b-98ee-756fb9f5aba9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c98cf5eb-8dac-4aae-adda-563684d1dc47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecba2892-f4dc-4ab4-9842-ca2d3b83e1cf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5bd4008c-efaf-46ae-92ce-8fd75f05dcbf", "2", "Student", "STUDENT" },
                    { "6b92e5af-bb9b-4586-8b9c-3ead6d1350d8", "3", "Teacher", "TEACHER" },
                    { "be37a6de-d8e9-4839-a23e-faf43083a237", "1", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bd4008c-efaf-46ae-92ce-8fd75f05dcbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b92e5af-bb9b-4586-8b9c-3ead6d1350d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be37a6de-d8e9-4839-a23e-faf43083a237");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "82d895b0-cd76-496b-98ee-756fb9f5aba9", "3", "Teacher", "TEACHER" },
                    { "c98cf5eb-8dac-4aae-adda-563684d1dc47", "2", "Student", "STUDENT" },
                    { "ecba2892-f4dc-4ab4-9842-ca2d3b83e1cf", "1", "Admin", "ADMIN" }
                });
        }
    }
}
