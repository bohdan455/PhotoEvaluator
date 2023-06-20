using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AllowNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_TelegramUser_RaterId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_TelegramUser_TelegramUser_NextUserToRateId",
                table: "TelegramUser");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoId",
                table: "TelegramUser",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<long>(
                name: "NextUserToRateId",
                table: "TelegramUser",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TelegramUser",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "TelegramUser",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TelegramUser_TelegramUser_NextUserToRateId",
                table: "TelegramUser",
                column: "NextUserToRateId",
                principalTable: "TelegramUser",
                principalColumn: "TelegramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TelegramUser_TelegramUser_NextUserToRateId",
                table: "TelegramUser");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoId",
                table: "TelegramUser",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NextUserToRateId",
                table: "TelegramUser",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TelegramUser",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "TelegramUser",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_TelegramUser_RaterId",
                table: "Rating",
                column: "RaterId",
                principalTable: "TelegramUser",
                principalColumn: "TelegramId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TelegramUser_TelegramUser_NextUserToRateId",
                table: "TelegramUser",
                column: "NextUserToRateId",
                principalTable: "TelegramUser",
                principalColumn: "TelegramId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
