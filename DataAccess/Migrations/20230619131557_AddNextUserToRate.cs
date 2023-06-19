using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddNextUserToRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_TelegramUser_TelegramUserId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_Id_TelegramUserId",
                table: "Rating");

            migrationBuilder.RenameColumn(
                name: "TelegramUserId",
                table: "Rating",
                newName: "UserToRateId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_TelegramUserId",
                table: "Rating",
                newName: "IX_Rating_UserToRateId");

            migrationBuilder.AddColumn<long>(
                name: "NextUserToRateId",
                table: "TelegramUser",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "Rating",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "RaterId",
                table: "Rating",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TelegramUser_NextUserToRateId",
                table: "TelegramUser",
                column: "NextUserToRateId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_RaterId_UserToRateId",
                table: "Rating",
                columns: new[] { "RaterId", "UserToRateId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_TelegramUser_RaterId",
                table: "Rating",
                column: "RaterId",
                principalTable: "TelegramUser",
                principalColumn: "TelegramId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_TelegramUser_UserToRateId",
                table: "Rating",
                column: "UserToRateId",
                principalTable: "TelegramUser",
                principalColumn: "TelegramId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TelegramUser_TelegramUser_NextUserToRateId",
                table: "TelegramUser",
                column: "NextUserToRateId",
                principalTable: "TelegramUser",
                principalColumn: "TelegramId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_TelegramUser_RaterId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_TelegramUser_UserToRateId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_TelegramUser_TelegramUser_NextUserToRateId",
                table: "TelegramUser");

            migrationBuilder.DropIndex(
                name: "IX_TelegramUser_NextUserToRateId",
                table: "TelegramUser");

            migrationBuilder.DropIndex(
                name: "IX_Rating_RaterId_UserToRateId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "NextUserToRateId",
                table: "TelegramUser");

            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "RaterId",
                table: "Rating");

            migrationBuilder.RenameColumn(
                name: "UserToRateId",
                table: "Rating",
                newName: "TelegramUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_UserToRateId",
                table: "Rating",
                newName: "IX_Rating_TelegramUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_Id_TelegramUserId",
                table: "Rating",
                columns: new[] { "Id", "TelegramUserId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_TelegramUser_TelegramUserId",
                table: "Rating",
                column: "TelegramUserId",
                principalTable: "TelegramUser",
                principalColumn: "TelegramId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
