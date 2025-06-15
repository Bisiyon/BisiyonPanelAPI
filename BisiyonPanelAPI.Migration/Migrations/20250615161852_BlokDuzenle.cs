using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisiyonPanelAPI.Migration.Migrations
{
    /// <inheritdoc />
    public partial class BlokDuzenle : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlokAlanTipId",
                table: "Blok",
                newName: "BlokTipId");

            migrationBuilder.AddColumn<string>(
                name: "Kod",
                table: "MeskenTipi",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Renk",
                table: "MeskenTipi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ArsaPayi",
                table: "Mesken",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Blok_BlokTipId",
                table: "Blok",
                column: "BlokTipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blok_MeskenTipi_BlokTipId",
                table: "Blok",
                column: "BlokTipId",
                principalTable: "MeskenTipi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blok_MeskenTipi_BlokTipId",
                table: "Blok");

            migrationBuilder.DropIndex(
                name: "IX_Blok_BlokTipId",
                table: "Blok");

            migrationBuilder.DropColumn(
                name: "Kod",
                table: "MeskenTipi");

            migrationBuilder.DropColumn(
                name: "Renk",
                table: "MeskenTipi");

            migrationBuilder.RenameColumn(
                name: "BlokTipId",
                table: "Blok",
                newName: "BlokAlanTipId");

            migrationBuilder.AlterColumn<int>(
                name: "ArsaPayi",
                table: "Mesken",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
