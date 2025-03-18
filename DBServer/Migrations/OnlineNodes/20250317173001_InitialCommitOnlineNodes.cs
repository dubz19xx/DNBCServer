using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBServer.Migrations.OnlineNodes
{
    /// <inheritdoc />
    public partial class InitialCommitOnlineNodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OnlineNodes",
                columns: table => new
                {
                    DNAddress = table.Column<string>(type: "TEXT", nullable: false),
                    IPAddress = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineNodes", x => x.DNAddress);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnlineNodes");
        }
    }
}
