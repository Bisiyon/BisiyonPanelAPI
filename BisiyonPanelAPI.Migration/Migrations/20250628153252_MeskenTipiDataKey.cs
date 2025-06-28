using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisiyonPanelAPI.Migration.Migrations
{
    /// <inheritdoc />
    public partial class MeskenTipiDataKey : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataKey",
                table: "MeskenTipi",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataKey",
                table: "MeskenTipi");
        }
    }
}
