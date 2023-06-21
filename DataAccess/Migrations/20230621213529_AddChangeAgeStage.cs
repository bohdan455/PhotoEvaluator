using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddChangeAgeStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ChatState",
                keyColumn: "Id",
                keyValue: 8,
                column: "State",
                value: "Change age");

            migrationBuilder.InsertData(
                table: "ChatState",
                columns: new[] { "Id", "State" },
                values: new object[] { 9, "Change photo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatState",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "ChatState",
                keyColumn: "Id",
                keyValue: 8,
                column: "State",
                value: "Change photo");
        }
    }
}
