using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisiyonPanelAPI.Migration.Migrations
{
    /// <inheritdoc />
    public partial class FirstEntities : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aidat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplamArsaPayi = table.Column<int>(type: "int", nullable: true),
                    SabiteDahilMi = table.Column<bool>(type: "bit", nullable: false),
                    ToplamMesken = table.Column<int>(type: "int", nullable: true),
                    ArsaPayi = table.Column<int>(type: "int", nullable: true),
                    SabitTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ArsaPayiTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aidat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlokAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ToplamKatSayisi = table.Column<int>(type: "int", nullable: true),
                    KatBaslangicKati = table.Column<int>(type: "int", nullable: true),
                    Asansor = table.Column<bool>(type: "bit", nullable: false),
                    Otopark = table.Column<bool>(type: "bit", nullable: false),
                    BinaYasi = table.Column<int>(type: "int", nullable: true),
                    BlokOzellikleri = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blok", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gorevli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TcKimlikNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gorevli", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeskenTipi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeskenTipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UyeDurumTip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Durum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UyeDurumTip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mesken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlokId = table.Column<int>(type: "int", nullable: false),
                    MeskenTipId = table.Column<int>(type: "int", nullable: true),
                    Ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Kat = table.Column<int>(type: "int", nullable: true),
                    DaireNo = table.Column<int>(type: "int", nullable: true),
                    M2 = table.Column<int>(type: "int", nullable: true),
                    ArsaPayi = table.Column<int>(type: "int", nullable: false),
                    Oran1 = table.Column<int>(type: "int", nullable: false),
                    Oran2 = table.Column<int>(type: "int", nullable: false),
                    Oran3 = table.Column<int>(type: "int", nullable: false),
                    Oran4 = table.Column<int>(type: "int", nullable: false),
                    Oran5 = table.Column<int>(type: "int", nullable: false),
                    Oran6 = table.Column<int>(type: "int", nullable: false),
                    Oran7 = table.Column<int>(type: "int", nullable: false),
                    Oran8 = table.Column<int>(type: "int", nullable: false),
                    Oran9 = table.Column<int>(type: "int", nullable: false),
                    KisiSayisi = table.Column<int>(type: "int", nullable: true),
                    OturanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesken_Blok_BlokId",
                        column: x => x.BlokId,
                        principalTable: "Blok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mesken_MeskenTipi_MeskenTipId",
                        column: x => x.MeskenTipId,
                        principalTable: "MeskenTipi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Uye",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeskenId = table.Column<int>(type: "int", nullable: false),
                    UyeDurumTipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uye", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uye_Mesken_MeskenId",
                        column: x => x.MeskenId,
                        principalTable: "Mesken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uye_UyeDurumTip_UyeDurumTipId",
                        column: x => x.UyeDurumTipId,
                        principalTable: "UyeDurumTip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UyeHareket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UyeId = table.Column<int>(type: "int", nullable: false),
                    IslemTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HareketTipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UyeHareket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UyeHareket_Uye_UyeId",
                        column: x => x.UyeId,
                        principalTable: "Uye",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mesken_BlokId",
                table: "Mesken",
                column: "BlokId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesken_MeskenTipId",
                table: "Mesken",
                column: "MeskenTipId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesken_OturanId",
                table: "Mesken",
                column: "OturanId",
                unique: true,
                filter: "[OturanId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Uye_MeskenId",
                table: "Uye",
                column: "MeskenId");

            migrationBuilder.CreateIndex(
                name: "IX_Uye_UyeDurumTipId",
                table: "Uye",
                column: "UyeDurumTipId");

            migrationBuilder.CreateIndex(
                name: "IX_UyeHareket_UyeId",
                table: "UyeHareket",
                column: "UyeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mesken_Uye_OturanId",
                table: "Mesken",
                column: "OturanId",
                principalTable: "Uye",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mesken_Blok_BlokId",
                table: "Mesken");

            migrationBuilder.DropForeignKey(
                name: "FK_Mesken_MeskenTipi_MeskenTipId",
                table: "Mesken");

            migrationBuilder.DropForeignKey(
                name: "FK_Mesken_Uye_OturanId",
                table: "Mesken");

            migrationBuilder.DropTable(
                name: "Aidat");

            migrationBuilder.DropTable(
                name: "Gorevli");

            migrationBuilder.DropTable(
                name: "UyeHareket");

            migrationBuilder.DropTable(
                name: "Blok");

            migrationBuilder.DropTable(
                name: "MeskenTipi");

            migrationBuilder.DropTable(
                name: "Uye");

            migrationBuilder.DropTable(
                name: "Mesken");

            migrationBuilder.DropTable(
                name: "UyeDurumTip");
        }
    }
}
