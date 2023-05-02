using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSuperMarket.Migrations
{
    /// <inheritdoc />
    public partial class initCreateBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_productId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_productId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "total",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "TotalMoney",
                table: "OrderDetails",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "OrderDetails",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0ab064d-ba38-4fc9-b59f-3952b83762bf", "AQAAAAIAAYagAAAAENS33dI3opvrr5JaW2zTGdu/yZfgyH5IKVlpQAAH1LLeJOX38lhx4p1EldPUEeTPUw==", "9063e96a-574c-4981-bfd0-ec7ed00aa108" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c98a1a9-00cb-463b-81ae-415b58f4e389", "AQAAAAIAAYagAAAAEBW6XPHPYZv5pVfy5qm03PmTuj44GM9PfgXbXnPDaXt3yH10qA188Kssn4P9/naNKA==", "4fc2cd3a-4d7e-4bd3-a9f9-0d31dfb54632" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05aa9fd6-e379-4cea-acd0-425328d76328", "AQAAAAIAAYagAAAAEBdWqKt2McxrNxDo7TfuFbJxYS+5JylWRvvbrDb4F5c9q2fQBDWYuBGvd6zy5Jxcvw==", "cc33a13d-0520-4c68-815b-ac6b7638a879" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "total",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "amount",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TotalMoney",
                table: "OrderDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "OrderDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bd911cf-9f4f-43cb-8c1f-9a79ec4720c3", "AQAAAAIAAYagAAAAEFN5nFpizOtu9JyAPzQL/w/paWcNGZAFifXJ89Nqq4uTnpfh6wIc65VRIhAQ124mMA==", "b36afbc8-3fdb-4984-8e2f-7e2b2b801b3f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90a16aed-27b8-4055-a57a-9f5f10c3f1db", "AQAAAAIAAYagAAAAEC/OP7hUpCri75/tD1GfmTjOAXQtQj2yVjVyV4mkcQvvy4tRpYng5iQWTFw0p7jqqQ==", "e3dd2bf9-80b7-4dda-a6a3-d7b94423b959" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "705856f7-5302-4313-84e7-dca205307811", "AQAAAAIAAYagAAAAENRfXpuivOtF3ZAsD7p1+Br8mjuzYlatuHjOfIC1ALaq0AIL4Ur+M70ARvLvU75Zww==", "09c71b08-1431-4f53-8e4a-6f8123ee96d3" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_productId",
                table: "Orders",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_productId",
                table: "Orders",
                column: "productId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
