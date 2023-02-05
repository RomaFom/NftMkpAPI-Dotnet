using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NftMkpAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nfts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nftid = table.Column<int>(name: "nft_id", type: "integer", nullable: false),
                    owner = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nfts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    itemid = table.Column<int>(name: "item_id", type: "integer", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    listingprice = table.Column<double>(name: "listing_price", type: "double precision", nullable: false),
                    seller = table.Column<string>(type: "text", nullable: false),
                    issold = table.Column<bool>(name: "is_sold", type: "boolean", nullable: false),
                    totalprice = table.Column<double>(name: "total_price", type: "double precision", nullable: false),
                    nftid = table.Column<int>(name: "nft_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_items_nfts_nft_id",
                        column: x => x.nftid,
                        principalTable: "nfts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_items_nft_id",
                table: "items",
                column: "nft_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "nfts");
        }
    }
}
