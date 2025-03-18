using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBServer.Migrations.OnlineNodes
{
    /// <inheritdoc />
    public partial class addedport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Port",
                table: "OnlineNodes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Port",
                table: "OnlineNodes");
        }
    }
}
