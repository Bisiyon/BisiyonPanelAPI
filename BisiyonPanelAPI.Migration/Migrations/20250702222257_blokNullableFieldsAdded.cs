using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisiyonPanelAPI.Migration.Migrations
{
    /// <inheritdoc />
    public partial class blokNullableFieldsAdded : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blok_Il_IlId",
                table: "Blok");

            migrationBuilder.DropForeignKey(
                name: "FK_Blok_Ilce_IlceId",
                table: "Blok");

            migrationBuilder.DropForeignKey(
                name: "FK_Blok_MeskenTipi_BlokTipId",
                table: "Blok");

            migrationBuilder.DropIndex(
                name: "IX_Blok_BlokTipId",
                table: "Blok");

            migrationBuilder.DropColumn(
                name: "MeskenOlusturuldu",
                table: "Blok");

            migrationBuilder.AlterColumn<string>(
                name: "MahalleKoyMezraMevki",
                table: "Blok",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "IlceId",
                table: "Blok",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IlId",
                table: "Blok",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CaddeSokak",
                table: "Blok",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BinaNo",
                table: "Blok",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Apartman",
                table: "Blok",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Blok",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Blok_Il_IlId",
                table: "Blok",
                column: "IlId",
                principalTable: "Il",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blok_Ilce_IlceId",
                table: "Blok",
                column: "IlceId",
                principalTable: "Ilce",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blok_Il_IlId",
                table: "Blok");

            migrationBuilder.DropForeignKey(
                name: "FK_Blok_Ilce_IlceId",
                table: "Blok");

            migrationBuilder.AlterColumn<string>(
                name: "MahalleKoyMezraMevki",
                table: "Blok",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IlceId",
                table: "Blok",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IlId",
                table: "Blok",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CaddeSokak",
                table: "Blok",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BinaNo",
                table: "Blok",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Apartman",
                table: "Blok",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Blok",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MeskenOlusturuldu",
                table: "Blok",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Blok_BlokTipId",
                table: "Blok",
                column: "BlokTipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blok_Il_IlId",
                table: "Blok",
                column: "IlId",
                principalTable: "Il",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blok_Ilce_IlceId",
                table: "Blok",
                column: "IlceId",
                principalTable: "Ilce",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blok_MeskenTipi_BlokTipId",
                table: "Blok",
                column: "BlokTipId",
                principalTable: "MeskenTipi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
