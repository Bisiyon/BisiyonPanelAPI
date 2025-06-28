using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisiyonPanelAPI.Migration.Migrations
{
    /// <inheritdoc />
    public partial class PersonelTipAdd : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UyeDurumTipId",
                table: "Personel",
                newName: "PersonelTipId");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "Personel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PersonelTip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "ROWVERSION", rowVersion: true, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelTip", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personel_PersonelTipId",
                table: "Personel",
                column: "PersonelTipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personel_PersonelTip_PersonelTipId",
                table: "Personel",
                column: "PersonelTipId",
                principalTable: "PersonelTip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personel_PersonelTip_PersonelTipId",
                table: "Personel");

            migrationBuilder.DropTable(
                name: "PersonelTip");

            migrationBuilder.DropIndex(
                name: "IX_Personel_PersonelTipId",
                table: "Personel");

            migrationBuilder.DropColumn(
                name: "Adres",
                table: "Personel");

            migrationBuilder.RenameColumn(
                name: "PersonelTipId",
                table: "Personel",
                newName: "UyeDurumTipId");
        }
    }
}
