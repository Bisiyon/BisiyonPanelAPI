using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisiyonPanelAPI.Migration.Migrations
{
    /// <inheritdoc />
    public partial class MeskenUyeEditv2 : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VarsayilanKattakiDaireSayisi",
                table: "Blok");

            migrationBuilder.RenameColumn(
                name: "MalikHisse",
                table: "Mesken",
                newName: "TahsisOran");

            migrationBuilder.AddColumn<int>(
                name: "MalikHisse",
                table: "MeskenUye",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GiderGrupId",
                table: "Mesken",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GiderId",
                table: "Mesken",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GiderGrup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiderGrupAd = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiderGrup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiderGrupAd = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    GiderGrupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gider_GiderGrup_GiderGrupId",
                        column: x => x.GiderGrupId,
                        principalTable: "GiderGrup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mesken_GiderGrupId",
                table: "Mesken",
                column: "GiderGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesken_GiderId",
                table: "Mesken",
                column: "GiderId");

            migrationBuilder.CreateIndex(
                name: "IX_Gider_GiderGrupId",
                table: "Gider",
                column: "GiderGrupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mesken_GiderGrup_GiderGrupId",
                table: "Mesken",
                column: "GiderGrupId",
                principalTable: "GiderGrup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mesken_Gider_GiderId",
                table: "Mesken",
                column: "GiderId",
                principalTable: "Gider",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mesken_GiderGrup_GiderGrupId",
                table: "Mesken");

            migrationBuilder.DropForeignKey(
                name: "FK_Mesken_Gider_GiderId",
                table: "Mesken");

            migrationBuilder.DropTable(
                name: "Gider");

            migrationBuilder.DropTable(
                name: "GiderGrup");

            migrationBuilder.DropIndex(
                name: "IX_Mesken_GiderGrupId",
                table: "Mesken");

            migrationBuilder.DropIndex(
                name: "IX_Mesken_GiderId",
                table: "Mesken");

            migrationBuilder.DropColumn(
                name: "MalikHisse",
                table: "MeskenUye");

            migrationBuilder.DropColumn(
                name: "GiderGrupId",
                table: "Mesken");

            migrationBuilder.DropColumn(
                name: "GiderId",
                table: "Mesken");

            migrationBuilder.RenameColumn(
                name: "TahsisOran",
                table: "Mesken",
                newName: "MalikHisse");

            migrationBuilder.AddColumn<int>(
                name: "VarsayilanKattakiDaireSayisi",
                table: "Blok",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
