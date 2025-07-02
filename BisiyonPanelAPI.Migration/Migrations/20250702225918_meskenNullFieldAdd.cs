using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisiyonPanelAPI.Migration.Migrations
{
    /// <inheritdoc />
    public partial class meskenNullFieldAdd : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mesken_AidatGrup_AidatGrupId",
                table: "Mesken");

            migrationBuilder.AlterColumn<int>(
                name: "AidatGrupId",
                table: "Mesken",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Mesken_AidatGrup_AidatGrupId",
                table: "Mesken",
                column: "AidatGrupId",
                principalTable: "AidatGrup",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mesken_AidatGrup_AidatGrupId",
                table: "Mesken");

            migrationBuilder.AlterColumn<int>(
                name: "AidatGrupId",
                table: "Mesken",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mesken_AidatGrup_AidatGrupId",
                table: "Mesken",
                column: "AidatGrupId",
                principalTable: "AidatGrup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
