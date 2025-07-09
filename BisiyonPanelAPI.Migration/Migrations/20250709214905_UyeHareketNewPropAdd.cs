using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisiyonPanelAPI.Migration.Migrations
{
    /// <inheritdoc />
    public partial class UyeHareketNewPropAdd : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeskenId",
                table: "UyeHareket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UyeHareket_MeskenId",
                table: "UyeHareket",
                column: "MeskenId");

            migrationBuilder.AddForeignKey(
                name: "FK_UyeHareket_Mesken_MeskenId",
                table: "UyeHareket",
                column: "MeskenId",
                principalTable: "Mesken",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UyeHareket_Mesken_MeskenId",
                table: "UyeHareket");

            migrationBuilder.DropIndex(
                name: "IX_UyeHareket_MeskenId",
                table: "UyeHareket");

            migrationBuilder.DropColumn(
                name: "MeskenId",
                table: "UyeHareket");
        }
    }
}
