using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSuperMarket.Migrations
{
    /// <inheritdoc />
    public partial class modifyUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_Id",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad68dacb-9492-42a5-84cc-eb4e0cb22b25", "AQAAAAIAAYagAAAAED3jV/xvWVpDEXpbEy+H+NKnumwE2n7312CSUr2Rac70H0LATw19jrThhGndRr4G9Q==", "6b41fac5-b915-47e4-b96e-bcc540e8fcc3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "287a641a-d951-4456-880d-83e6b2c007ff", "AQAAAAIAAYagAAAAEA3k0hjunsracZEK9oa9KtkoxUYL8Oi9YsJWnccl0eie1L1KHq4zbP9nN+/RpwSIeA==", "2317c1a0-3480-483f-aaf4-63b9ef0fbc41" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a82b44d4-5f55-4a06-97f5-6b0722982676", "AQAAAAIAAYagAAAAEPXd+j6+e0JQoFfTwF4rbGNGwLqiPf8/3oiGt2x8l9EgBOWERFgpSsxo17oS3iIdGw==", "ccd6aa41-4ea4-404a-b4f5-8f8d91941538" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_userId",
                table: "Orders",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_userId",
                table: "Orders",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_userId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_userId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    billId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderId = table.Column<int>(type: "int", nullable: false),
                    billAmount = table.Column<double>(type: "float", nullable: false),
                    creditCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.billId);
                    table.ForeignKey(
                        name: "FK_Bills_Orders_orderId",
                        column: x => x.orderId,
                        principalTable: "Orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    creditCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    creditCardExpiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    creditCardNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.creditCardId);
                    table.ForeignKey(
                        name: "FK_CreditCards_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36b509f7-e9f7-4b81-b077-0416ef462383", "AQAAAAIAAYagAAAAEI2UrtxSRdGWb7Ap4Cs6DRvXzsG0WR9gCPeAd5DxQpcpvT928OJERWEipDy2JFIaaQ==", "efc9307c-bc95-499b-8042-4de01f2e0cab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46808066-2946-45e5-919d-1404b117a165", "AQAAAAIAAYagAAAAEF0ciMSUZUY8+H4Yp/g9OnVle9EEIukaO4QkpMyIaVAIgJb1sh0N/28U9pUxkGUkdA==", "2dfb83c3-2af0-4ba6-a7da-0518225a6f52" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f86bbe04-d9fa-43bd-8296-b58b95932f60", "AQAAAAIAAYagAAAAEBm9/K+gp144rZVq4r3nzGyYldn4fpIvZBDW7YNkQATl3Pf4my7mMa4XAJWCoqF/OA==", "880c3583-4c27-47e4-8db4-2d1fcca1c1f0" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id",
                table: "Orders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_orderId",
                table: "Bills",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_Id",
                table: "CreditCards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_Id",
                table: "Orders",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
