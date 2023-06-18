using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelegramUser",
                columns: table => new
                {
                    TelegramId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PhotoId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramUser", x => x.TelegramId);
                    table.ForeignKey(
                        name: "FK_TelegramUser_ChatState_StateId",
                        column: x => x.StateId,
                        principalTable: "ChatState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelegramUserId = table.Column<long>(type: "bigint", nullable: false),
                    RatingNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_TelegramUser_TelegramUserId",
                        column: x => x.TelegramUserId,
                        principalTable: "TelegramUser",
                        principalColumn: "TelegramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ChatState",
                columns: new[] { "Id", "State" },
                values: new object[,]
                {
                    { 1, "Set name" },
                    { 2, "Set age" },
                    { 3, "Set photo" },
                    { 4, "Menu" },
                    { 5, "Rate" },
                    { 6, "Settings" },
                    { 7, "Change name" },
                    { 8, "Change photo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rating_Id_TelegramUserId",
                table: "Rating",
                columns: new[] { "Id", "TelegramUserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rating_TelegramUserId",
                table: "Rating",
                column: "TelegramUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TelegramUser_StateId",
                table: "TelegramUser",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "TelegramUser");

            migrationBuilder.DropTable(
                name: "ChatState");
        }
    }
}
