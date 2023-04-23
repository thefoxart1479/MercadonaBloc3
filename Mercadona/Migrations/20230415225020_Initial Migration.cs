using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mercadona_V1.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    categorieID = table.Column<Guid>(type: "uuid", nullable: false),
                    libelle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categorieID);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    produitID = table.Column<Guid>(type: "uuid", nullable: false),
                    libelle = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    prix = table.Column<float>(type: "real", nullable: false),
                    enPromotion = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.produitID);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    promotionID = table.Column<Guid>(type: "uuid", nullable: false),
                    dateDebut = table.Column<string>(type: "text", nullable: false),
                    dateFin = table.Column<string>(type: "text", nullable: false),
                    remise = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.promotionID);
                });

            migrationBuilder.CreateTable(
                name: "CategorieProduit",
                columns: table => new
                {
                    CategoriescategorieID = table.Column<Guid>(type: "uuid", nullable: false),
                    produitsproduitID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieProduit", x => new { x.CategoriescategorieID, x.produitsproduitID });
                    table.ForeignKey(
                        name: "FK_CategorieProduit_Categories_CategoriescategorieID",
                        column: x => x.CategoriescategorieID,
                        principalTable: "Categories",
                        principalColumn: "categorieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieProduit_Produits_produitsproduitID",
                        column: x => x.produitsproduitID,
                        principalTable: "Produits",
                        principalColumn: "produitID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProduitPromotion",
                columns: table => new
                {
                    PromotionspromotionID = table.Column<Guid>(type: "uuid", nullable: false),
                    produitsproduitID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduitPromotion", x => new { x.PromotionspromotionID, x.produitsproduitID });
                    table.ForeignKey(
                        name: "FK_ProduitPromotion_Produits_produitsproduitID",
                        column: x => x.produitsproduitID,
                        principalTable: "Produits",
                        principalColumn: "produitID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProduitPromotion_Promotions_PromotionspromotionID",
                        column: x => x.PromotionspromotionID,
                        principalTable: "Promotions",
                        principalColumn: "promotionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieProduit_produitsproduitID",
                table: "CategorieProduit",
                column: "produitsproduitID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduitPromotion_produitsproduitID",
                table: "ProduitPromotion",
                column: "produitsproduitID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieProduit");

            migrationBuilder.DropTable(
                name: "ProduitPromotion");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Promotions");
        }
    }
}
