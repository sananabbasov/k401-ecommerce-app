using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace K401Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class BugFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Producs_ProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Producs_ProductId",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_ProducLanguages_Categories_CategoryId",
                table: "ProducLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_Producs_Categories_CategoryId",
                table: "Producs");

            migrationBuilder.DropForeignKey(
                name: "FK_Producs_Users_UserId",
                table: "Producs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producs",
                table: "Producs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProducLanguages",
                table: "ProducLanguages");

            migrationBuilder.RenameTable(
                name: "Producs",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "ProducLanguages",
                newName: "ProductLanguages");

            migrationBuilder.RenameIndex(
                name: "IX_Producs_UserId",
                table: "Products",
                newName: "IX_Products_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Producs_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "ProductLanguages",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProducLanguages_CategoryId",
                table: "ProductLanguages",
                newName: "IX_ProductLanguages_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductLanguages",
                table: "ProductLanguages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Products_ProductId",
                table: "Pictures",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLanguages_Products_ProductId",
                table: "ProductLanguages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Products_ProductId",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLanguages_Products_ProductId",
                table: "ProductLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductLanguages",
                table: "ProductLanguages");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Producs");

            migrationBuilder.RenameTable(
                name: "ProductLanguages",
                newName: "ProducLanguages");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserId",
                table: "Producs",
                newName: "IX_Producs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Producs",
                newName: "IX_Producs_CategoryId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProducLanguages",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductLanguages_ProductId",
                table: "ProducLanguages",
                newName: "IX_ProducLanguages_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producs",
                table: "Producs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProducLanguages",
                table: "ProducLanguages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Producs_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Producs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Producs_ProductId",
                table: "Pictures",
                column: "ProductId",
                principalTable: "Producs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProducLanguages_Categories_CategoryId",
                table: "ProducLanguages",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Producs_Categories_CategoryId",
                table: "Producs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Producs_Users_UserId",
                table: "Producs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
