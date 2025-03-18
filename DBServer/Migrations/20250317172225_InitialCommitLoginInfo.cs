using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCommitLoginInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginInfo",
                columns: table => new
                {
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    DNAddress = table.Column<string>(type: "TEXT", nullable: false),
                    EmailId = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginInfo", x => x.Username);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginInfo");
        }
    }
}
