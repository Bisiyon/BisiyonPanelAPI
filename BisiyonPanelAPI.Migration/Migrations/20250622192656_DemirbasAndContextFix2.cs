using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisiyonPanelAPI.Migration.Migrations
{
    /// <inheritdoc />
    public partial class DemirbasAndContextFix2 : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Faturano",
                table: "Demirbas",
                newName: "FaturaNo");

            migrationBuilder.RenameColumn(
                name: "GarantiBirisTarihi",
                table: "Demirbas",
                newName: "GarantiBitisTarihi");

            migrationBuilder.RenameColumn(
                name: "Fiyati",
                table: "Demirbas",
                newName: "Fiyat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FaturaNo",
                table: "Demirbas",
                newName: "Faturano");

            migrationBuilder.RenameColumn(
                name: "GarantiBitisTarihi",
                table: "Demirbas",
                newName: "GarantiBirisTarihi");

            migrationBuilder.RenameColumn(
                name: "Fiyat",
                table: "Demirbas",
                newName: "Fiyati");
        }
    }
}
