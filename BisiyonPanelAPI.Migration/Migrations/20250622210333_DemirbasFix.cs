using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisiyonPanelAPI.Migration.Migrations
{
    /// <inheritdoc />
    public partial class DemirbasFix : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Serino",
                table: "Demirbas",
                newName: "SeriNo");

            migrationBuilder.RenameColumn(
                name: "Adi",
                table: "Demirbas",
                newName: "Ad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeriNo",
                table: "Demirbas",
                newName: "Serino");

            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "Demirbas",
                newName: "Adi");
        }
    }
}
