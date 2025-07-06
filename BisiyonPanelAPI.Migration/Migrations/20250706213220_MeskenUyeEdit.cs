using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisiyonPanelAPI.Migration.Migrations
{
    /// <inheritdoc />
    public partial class MeskenUyeEdit : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uye_UyeDurumTip_UyeDurumTipId",
                table: "Uye");

            migrationBuilder.DropIndex(
                name: "IX_Uye_UyeDurumTipId",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "UyeDurumTipId",
                table: "Uye");

            migrationBuilder.AddColumn<int>(
                name: "UyeDurumTipId",
                table: "MeskenUye",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MeskenUye_UyeDurumTipId",
                table: "MeskenUye",
                column: "UyeDurumTipId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeskenUye_UyeDurumTip_UyeDurumTipId",
                table: "MeskenUye",
                column: "UyeDurumTipId",
                principalTable: "UyeDurumTip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeskenUye_UyeDurumTip_UyeDurumTipId",
                table: "MeskenUye");

            migrationBuilder.DropIndex(
                name: "IX_MeskenUye_UyeDurumTipId",
                table: "MeskenUye");

            migrationBuilder.DropColumn(
                name: "UyeDurumTipId",
                table: "MeskenUye");

            migrationBuilder.AddColumn<int>(
                name: "UyeDurumTipId",
                table: "Uye",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Uye_UyeDurumTipId",
                table: "Uye",
                column: "UyeDurumTipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uye_UyeDurumTip_UyeDurumTipId",
                table: "Uye",
                column: "UyeDurumTipId",
                principalTable: "UyeDurumTip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
