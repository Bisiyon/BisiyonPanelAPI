using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisiyonPanelAPI.Migration.Migrations
{
    /// <inheritdoc />
    public partial class DemirbasAndContextFix : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Demirbas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    Turu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Satici = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Serino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Faturano = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kdv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GarantiBaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GarantiBirisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "ROWVERSION", rowVersion: true, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demirbas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demirbas");
        }
    }
}
