using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace orgSemasi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(nullable: true),
                    Gsm = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sirket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sirket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizasyon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SirketId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizasyon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizasyon_Sirket_SirketId",
                        column: x => x.SirketId,
                        principalTable: "Sirket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SirketLider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KullaniciId = table.Column<int>(nullable: false),
                    SirketId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SirketLider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SirketLider_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SirketLider_Sirket_SirketId",
                        column: x => x.SirketId,
                        principalTable: "Sirket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bolge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    OrganizasyonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bolge_Organizasyon_OrganizasyonId",
                        column: x => x.OrganizasyonId,
                        principalTable: "Organizasyon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizasyonLider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KullaniciId = table.Column<int>(nullable: false),
                    OrganizasyonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizasyonLider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizasyonLider_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizasyonLider_Organizasyon_OrganizasyonId",
                        column: x => x.OrganizasyonId,
                        principalTable: "Organizasyon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BolgeLider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KullaniciId = table.Column<int>(nullable: false),
                    BolgeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BolgeLider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BolgeLider_Bolge_BolgeId",
                        column: x => x.BolgeId,
                        principalTable: "Bolge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BolgeLider_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ofis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BolgeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ofis_Bolge_BolgeId",
                        column: x => x.BolgeId,
                        principalTable: "Bolge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfisLider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KullaniciId = table.Column<int>(nullable: false),
                    OfisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfisLider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfisLider_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfisLider_Ofis_OfisId",
                        column: x => x.OfisId,
                        principalTable: "Ofis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Takim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    OfisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Takim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Takim_Ofis_OfisId",
                        column: x => x.OfisId,
                        principalTable: "Ofis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TakimLider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KullaniciId = table.Column<int>(nullable: false),
                    TakimId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakimLider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TakimLider_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TakimLider_Takim_TakimId",
                        column: x => x.TakimId,
                        principalTable: "Takim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uye",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    TakimId = table.Column<int>(nullable: false),
                    KullaniciId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uye", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uye_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uye_Takim_TakimId",
                        column: x => x.TakimId,
                        principalTable: "Takim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bolge_OrganizasyonId",
                table: "Bolge",
                column: "OrganizasyonId");

            migrationBuilder.CreateIndex(
                name: "IX_BolgeLider_BolgeId",
                table: "BolgeLider",
                column: "BolgeId");

            migrationBuilder.CreateIndex(
                name: "IX_BolgeLider_KullaniciId",
                table: "BolgeLider",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Ofis_BolgeId",
                table: "Ofis",
                column: "BolgeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfisLider_KullaniciId",
                table: "OfisLider",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_OfisLider_OfisId",
                table: "OfisLider",
                column: "OfisId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizasyon_SirketId",
                table: "Organizasyon",
                column: "SirketId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizasyonLider_KullaniciId",
                table: "OrganizasyonLider",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizasyonLider_OrganizasyonId",
                table: "OrganizasyonLider",
                column: "OrganizasyonId");

            migrationBuilder.CreateIndex(
                name: "IX_SirketLider_KullaniciId",
                table: "SirketLider",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_SirketLider_SirketId",
                table: "SirketLider",
                column: "SirketId");

            migrationBuilder.CreateIndex(
                name: "IX_Takim_OfisId",
                table: "Takim",
                column: "OfisId");

            migrationBuilder.CreateIndex(
                name: "IX_TakimLider_KullaniciId",
                table: "TakimLider",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_TakimLider_TakimId",
                table: "TakimLider",
                column: "TakimId");

            migrationBuilder.CreateIndex(
                name: "IX_Uye_KullaniciId",
                table: "Uye",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Uye_TakimId",
                table: "Uye",
                column: "TakimId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BolgeLider");

            migrationBuilder.DropTable(
                name: "OfisLider");

            migrationBuilder.DropTable(
                name: "OrganizasyonLider");

            migrationBuilder.DropTable(
                name: "SirketLider");

            migrationBuilder.DropTable(
                name: "TakimLider");

            migrationBuilder.DropTable(
                name: "Uye");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "Takim");

            migrationBuilder.DropTable(
                name: "Ofis");

            migrationBuilder.DropTable(
                name: "Bolge");

            migrationBuilder.DropTable(
                name: "Organizasyon");

            migrationBuilder.DropTable(
                name: "Sirket");
        }
    }
}
