using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSuperMarket.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca370f1f-291e-4a30-9404-6535e8503291", "AQAAAAIAAYagAAAAEFssF8jLYQqdZsNxgXmVEjJQwplnirvxQs0fC9p3fIMz05tpRKtjVrRjmRwxssAC6g==", "fcb220e0-4c7f-4edd-8671-281a2ebde717" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edd4fe26-2d97-44e6-8790-51fbdfd5f551", "AQAAAAIAAYagAAAAEFwbOeuWi8v5VB4LsLiRWAsYpzzxRqGgKYgcKUQlt9G8NUbDogS5HbJZiMuLbKzlCQ==", "cfaf684a-cd08-49e4-9a92-8c7e1dc001c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a84ba0f7-b05e-4ad7-99ae-4d101f651ae3", "AQAAAAIAAYagAAAAEGVmiy3a7KX2VmTOzK0SZcVllUgJ6JQ0reZqm5aqLg9s1rL7Ou0O6kVwMcKNS8g58w==", "23f15d98-2708-44af-b3fd-f0bc54660e44" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04c0e58f-68f5-4289-a4f6-f0b97996163c", "AQAAAAIAAYagAAAAEDXCfay1ILL5lJrLWuPu+qnkbOyubTF5+uXb5TfuV8BqHh89dLxltrddGJNmL2W2qw==", "868c4be0-8834-4965-9349-305d09fe4778" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "672666a2-f11b-4303-9f1e-7471593ef95c", "AQAAAAIAAYagAAAAEM2+aeRPt7kzPONJulSjoc8pyS+6SmunSc9mHNhENkB1f9tJQftZ8peJ+PeGEH2QPQ==", "7e053a3e-f763-410f-8b14-ff176ddfa2ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22dc7a29-775e-43d5-b2b5-d17161b3a67b", "AQAAAAIAAYagAAAAEODaCacxXz1HWGs44L1IOUqLh13hyUgLYUwOLUGGLNTWo1AjG5eZXKdVHed+pcTcxQ==", "a27b6aae-2daf-4aa2-84aa-9476dc4eaf29" });
        }
    }
}
