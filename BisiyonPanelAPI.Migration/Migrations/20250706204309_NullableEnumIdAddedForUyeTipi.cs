using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisiyonPanelAPI.Migration.Migrations
{
    /// <inheritdoc />
    public partial class NullableEnumIdAddedForUyeTipi : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnumId",
                table: "UyeDurumTip",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnumId",
                table: "UyeDurumTip");
        }
    }
}
