using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSuperMarket.Migrations
{
    /// <inheritdoc />
    public partial class modifyDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Products",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ProductColors",
                columns: table => new
                {
                    productColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColors", x => x.productColorId);
                    table.ForeignKey(
                        name: "FK_ProductColors_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSizes",
                columns: table => new
                {
                    productSizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizes", x => x.productSizeId);
                    table.ForeignKey(
                        name: "FK_ProductSizes_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee9c7dfc-d041-43d8-81f5-815571c201da", "AQAAAAIAAYagAAAAEAKYGKzi3/Tz0W7FvJWPVlB23sdJHkPNE9BvynKI06+DUqLwZHXd1owQ4d8jjxlu7Q==", "64cca403-b817-443b-8c79-5e3a97c8b5c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aec33d6e-f3de-4716-8539-9a4b3aa418e3", "AQAAAAIAAYagAAAAEA7Y90a6BGTtuZyrI52lPyNH9OHc/9gbaTNba/+2yJQvbIwwmTtA9Mf4ijnvQ3kr9Q==", "4a5e7b9f-d4ff-47ab-bbc7-bf5d9331cc92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2dd4827-ea6c-4703-b65c-1bbeb7f50838", "AQAAAAIAAYagAAAAEKT3PhWjclYmupTPpdjbSMOa249SofzJyPNha6tjoziH+GZZTl+ICrFCojBoC6890A==", "afc65fa2-a76e-407a-a42c-4f3951ad6330" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_productId",
                table: "ProductColors",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_productId",
                table: "ProductSizes",
                column: "productId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductColors");

            migrationBuilder.DropTable(
                name: "ProductSizes");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    productDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.productDetailId);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88d34924-1b46-41f1-a37e-42d8674cf68f", "AQAAAAIAAYagAAAAEPfyEXbHblrBP8fSl1zIYTptbehcxoLk6P43PoyNjISQzbXQ2W8kkkmG51krT9Vwlg==", "bef6438b-5c5a-41f5-8198-f89b99b41271" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a642087-7346-4b85-b254-1b570bf34bf4", "AQAAAAIAAYagAAAAEGtpeUAvihv5I6Xv0Xtd96jqVA/VG5Y6D3HEueeyB2RasNmnS4arNugXBoYZGkaW1g==", "3ba1c9a0-40a8-4201-aa71-8d8479c6dc26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cebd30af-0012-4015-bca9-a21b518121d2", "AQAAAAIAAYagAAAAEN45uTBJ6/nZO/jad8gpW+cn3c6vgXyd3z+xk+VQtDP0i6x81LQajeZmdTLIEJcXfQ==", "8d48282c-30cf-472f-b319-a9e1de4283d8" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_productId",
                table: "ProductDetails",
                column: "productId");
        }
    }
}
