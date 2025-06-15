using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisiyonPanelAPI.Migration.Migrations
{
    /// <inheritdoc />
    public partial class AllTableEdit : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mesken_Uye_OturanId",
                table: "Mesken");

            migrationBuilder.DropForeignKey(
                name: "FK_Uye_Mesken_MeskenId",
                table: "Uye");

            migrationBuilder.DropTable(
                name: "Gorevli");

            migrationBuilder.DropIndex(
                name: "IX_Mesken_OturanId",
                table: "Mesken");

            migrationBuilder.DropColumn(
                name: "BlokOzellikleri",
                table: "Blok");

            migrationBuilder.RenameColumn(
                name: "MeskenId",
                table: "Uye",
                newName: "IlceId");

            migrationBuilder.RenameIndex(
                name: "IX_Uye_MeskenId",
                table: "Uye",
                newName: "IX_Uye_IlceId");

            migrationBuilder.RenameColumn(
                name: "OturanId",
                table: "Mesken",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Otopark",
                table: "Blok",
                newName: "MeskenOlusturuldu");

            migrationBuilder.RenameColumn(
                name: "BlokAdi",
                table: "Blok",
                newName: "Ad");

            migrationBuilder.RenameColumn(
                name: "BinaYasi",
                table: "Blok",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Asansor",
                table: "Blok",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Adi",
                table: "Aidat",
                newName: "DeletedNotes");

            // migrationBuilder.AddColumn<byte[]>(
            //     name: "ConcurrencyToken",
            //     table: "UyeHareket",
            //     type: "ROWVERSION",
            //     rowVersion: true,
            //     nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "UyeHareket",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "UyeHareket",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedNotes",
                table: "UyeHareket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UyeHareket",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UyeHareket",
                type: "bit",
                nullable: true);

            // migrationBuilder.AddColumn<byte[]>(
            //     name: "ConcurrencyToken",
            //     table: "UyeDurumTip",
            //     type: "ROWVERSION",
            //     rowVersion: true,
            //     nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "UyeDurumTip",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "UyeDurumTip",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedNotes",
                table: "UyeDurumTip",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UyeDurumTip",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UyeDurumTip",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Uye",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "AcilisBakiyesi",
                table: "Uye",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ad",
                table: "Uye",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CepTelefonu",
                table: "Uye",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CepTelefonu2",
                table: "Uye",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CepTelefonu3",
                table: "Uye",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CepTelefonu4",
                table: "Uye",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CinsiyetId",
                table: "Uye",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            // migrationBuilder.AddColumn<byte[]>(
            //     name: "ConcurrencyToken",
            //     table: "Uye",
            //     type: "ROWVERSION",
            //     rowVersion: true,
            //     nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Uye",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Uye",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedNotes",
                table: "Uye",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DogumTarihi",
                table: "Uye",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Uye",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email1",
                table: "Uye",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email2",
                table: "Uye",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email3",
                table: "Uye",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email4",
                table: "Uye",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IlId",
                table: "Uye",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Uye",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Uye",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Soyad",
                table: "Uye",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TCKimlikNo",
                table: "Uye",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TebligatAdres",
                table: "Uye",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            // migrationBuilder.AddColumn<byte[]>(
            //     name: "ConcurrencyToken",
            //     table: "MeskenTipi",
            //     type: "ROWVERSION",
            //     rowVersion: true,
            //     nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "MeskenTipi",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "MeskenTipi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedNotes",
                table: "MeskenTipi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MeskenTipi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MeskenTipi",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AidatGrupId",
                table: "Mesken",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // migrationBuilder.AddColumn<byte[]>(
            //     name: "ConcurrencyToken",
            //     table: "Mesken",
            //     type: "ROWVERSION",
            //     rowVersion: true,
            //     nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Mesken",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedNotes",
                table: "Mesken",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Mesken",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Mesken",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MalikHisse",
                table: "Mesken",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ToplamKatSayisi",
                table: "Blok",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KatBaslangicKati",
                table: "Blok",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Blok",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Apartman",
                table: "Blok",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BinaNo",
                table: "Blok",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BlokAlanTipId",
                table: "Blok",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CaddeSokak",
                table: "Blok",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            // migrationBuilder.AddColumn<byte[]>(
            //     name: "ConcurrencyToken",
            //     table: "Blok",
            //     type: "ROWVERSION",
            //     rowVersion: true,
            //     nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Blok",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedNotes",
                table: "Blok",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IlId",
                table: "Blok",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IlceId",
                table: "Blok",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Blok",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MahalleKoyMezraMevki",
                table: "Blok",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ToplamDaireSayisi",
                table: "Blok",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VarsayilanKattakiDaireSayisi",
                table: "Blok",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Ad",
                table: "Aidat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            // migrationBuilder.AddColumn<byte[]>(
            //     name: "ConcurrencyToken",
            //     table: "Aidat",
            //     type: "ROWVERSION",
            //     rowVersion: true,
            //     nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Aidat",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Aidat",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Aidat",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Aidat",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AidatGrup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "ROWVERSION", rowVersion: true, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedNotes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AidatGrup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Il",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "ROWVERSION", rowVersion: true, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedNotes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Il", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeskenUye",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UyeId = table.Column<int>(type: "int", nullable: false),
                    MeskenId = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "ROWVERSION", rowVersion: true, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedNotes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeskenUye", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeskenUye_Mesken_MeskenId",
                        column: x => x.MeskenId,
                        principalTable: "Mesken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeskenUye_Uye_UyeId",
                        column: x => x.UyeId,
                        principalTable: "Uye",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ilce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IlId = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "ROWVERSION", rowVersion: true, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedNotes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilce", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ilce_Il_IlId",
                        column: x => x.IlId,
                        principalTable: "Il",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uye_IlId",
                table: "Uye",
                column: "IlId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesken_AidatGrupId",
                table: "Mesken",
                column: "AidatGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_Blok_IlceId",
                table: "Blok",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_Blok_IlId",
                table: "Blok",
                column: "IlId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilce_IlId",
                table: "Ilce",
                column: "IlId");

            migrationBuilder.CreateIndex(
                name: "IX_MeskenUye_MeskenId",
                table: "MeskenUye",
                column: "MeskenId");

            migrationBuilder.CreateIndex(
                name: "IX_MeskenUye_UyeId",
                table: "MeskenUye",
                column: "UyeId");

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
                name: "FK_Mesken_AidatGrup_AidatGrupId",
                table: "Mesken",
                column: "AidatGrupId",
                principalTable: "AidatGrup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uye_Il_IlId",
                table: "Uye",
                column: "IlId",
                principalTable: "Il",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Uye_Ilce_IlceId",
                table: "Uye",
                column: "IlceId",
                principalTable: "Ilce",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.DropForeignKey(
                name: "FK_Mesken_AidatGrup_AidatGrupId",
                table: "Mesken");

            migrationBuilder.DropForeignKey(
                name: "FK_Uye_Il_IlId",
                table: "Uye");

            migrationBuilder.DropForeignKey(
                name: "FK_Uye_Ilce_IlceId",
                table: "Uye");

            migrationBuilder.DropTable(
                name: "AidatGrup");

            migrationBuilder.DropTable(
                name: "Ilce");

            migrationBuilder.DropTable(
                name: "MeskenUye");

            migrationBuilder.DropTable(
                name: "Il");

            migrationBuilder.DropIndex(
                name: "IX_Uye_IlId",
                table: "Uye");

            migrationBuilder.DropIndex(
                name: "IX_Mesken_AidatGrupId",
                table: "Mesken");

            migrationBuilder.DropIndex(
                name: "IX_Blok_IlceId",
                table: "Blok");

            migrationBuilder.DropIndex(
                name: "IX_Blok_IlId",
                table: "Blok");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "UyeHareket");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "UyeHareket");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "UyeHareket");

            migrationBuilder.DropColumn(
                name: "DeletedNotes",
                table: "UyeHareket");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UyeHareket");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UyeHareket");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "UyeDurumTip");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "UyeDurumTip");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "UyeDurumTip");

            migrationBuilder.DropColumn(
                name: "DeletedNotes",
                table: "UyeDurumTip");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UyeDurumTip");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UyeDurumTip");

            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "AcilisBakiyesi",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "Ad",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "CepTelefonu",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "CepTelefonu2",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "CepTelefonu3",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "CepTelefonu4",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "CinsiyetId",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "DeletedNotes",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "DogumTarihi",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "Email1",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "Email2",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "Email3",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "Email4",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "IlId",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "Soyad",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "TCKimlikNo",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "TebligatAdres",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "MeskenTipi");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "MeskenTipi");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "MeskenTipi");

            migrationBuilder.DropColumn(
                name: "DeletedNotes",
                table: "MeskenTipi");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MeskenTipi");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MeskenTipi");

            migrationBuilder.DropColumn(
                name: "AidatGrupId",
                table: "Mesken");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "Mesken");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Mesken");

            migrationBuilder.DropColumn(
                name: "DeletedNotes",
                table: "Mesken");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Mesken");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Mesken");

            migrationBuilder.DropColumn(
                name: "MalikHisse",
                table: "Mesken");

            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Blok");

            migrationBuilder.DropColumn(
                name: "Apartman",
                table: "Blok");

            migrationBuilder.DropColumn(
                name: "BinaNo",
                table: "Blok");

            migrationBuilder.DropColumn(
                name: "BlokAlanTipId",
                table: "Blok");

            migrationBuilder.DropColumn(
                name: "CaddeSokak",
                table: "Blok");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "Blok");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Blok");

            migrationBuilder.DropColumn(
                name: "DeletedNotes",
                table: "Blok");

            migrationBuilder.DropColumn(
                name: "IlId",
                table: "Blok");

            migrationBuilder.DropColumn(
                name: "IlceId",
                table: "Blok");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Blok");

            migrationBuilder.DropColumn(
                name: "MahalleKoyMezraMevki",
                table: "Blok");

            migrationBuilder.DropColumn(
                name: "ToplamDaireSayisi",
                table: "Blok");

            migrationBuilder.DropColumn(
                name: "VarsayilanKattakiDaireSayisi",
                table: "Blok");

            migrationBuilder.DropColumn(
                name: "Ad",
                table: "Aidat");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "Aidat");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Aidat");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Aidat");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Aidat");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Aidat");

            migrationBuilder.RenameColumn(
                name: "IlceId",
                table: "Uye",
                newName: "MeskenId");

            migrationBuilder.RenameIndex(
                name: "IX_Uye_IlceId",
                table: "Uye",
                newName: "IX_Uye_MeskenId");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Mesken",
                newName: "OturanId");

            migrationBuilder.RenameColumn(
                name: "MeskenOlusturuldu",
                table: "Blok",
                newName: "Otopark");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Blok",
                newName: "Asansor");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Blok",
                newName: "BinaYasi");

            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "Blok",
                newName: "BlokAdi");

            migrationBuilder.RenameColumn(
                name: "DeletedNotes",
                table: "Aidat",
                newName: "Adi");

            migrationBuilder.AlterColumn<int>(
                name: "ToplamKatSayisi",
                table: "Blok",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KatBaslangicKati",
                table: "Blok",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BlokOzellikleri",
                table: "Blok",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Gorevli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TcKimlikNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gorevli", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mesken_OturanId",
                table: "Mesken",
                column: "OturanId",
                unique: true,
                filter: "[OturanId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Mesken_Uye_OturanId",
                table: "Mesken",
                column: "OturanId",
                principalTable: "Uye",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Uye_Mesken_MeskenId",
                table: "Uye",
                column: "MeskenId",
                principalTable: "Mesken",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
