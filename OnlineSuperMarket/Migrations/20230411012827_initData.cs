using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSuperMarket.Migrations
{
    /// <inheritdoc />
    public partial class initData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40d4a157-b5a1-4111-950a-c665fdbface0", "AQAAAAIAAYagAAAAELUDQTOWurO8z3kN0v3ry4piOCaaUqf4IGOB4nZCUfD6z4JZ3O9YyZ0u83CFS/FFwQ==", "9f53ccb7-1d94-4658-8077-1bbb699ef498" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc00a343-cf38-41ce-8476-222f75e1de1b", "AQAAAAIAAYagAAAAEML5LRl9VeGIZ+h/KzlmbFnEGmweYw9PgPzPNjapLGAP4q2lfTvly2weTy/Ux0ju5A==", "c6fd6836-6091-423e-a165-6ac7ea9ae97f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc166930-130d-41ad-9a4d-14d9fa381047", "AQAAAAIAAYagAAAAEG6j0LFlwPet0CeuFmuYT7L+f/BW3tQlZuVVahukKLu4zZKHuKFbZzuD5v/Mm+8ddw==", "ec91b439-f259-4fb3-9a67-7380dcd9bdc0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73d6b7ab-fa0c-45af-854e-3e6635077810", "AQAAAAIAAYagAAAAEIfeN82pAQRJnePvxUUO9nRq157vQYANDogsmqDVI7+dA8SnnWaIzXTNxBo4rK4aFA==", "ce0d8239-1b97-46ca-9d35-97144952f44b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f18b9beb-13d7-47ea-a055-d3caa9065c38", "AQAAAAIAAYagAAAAEA7KqcExRJb46feNuULmsRS5rY37wPB6N4xnaaU6oFZq79rGz+dzjjUYS2/0rCHrEQ==", "d8374bcf-0ca3-4959-b6cc-d625b8dd7c2f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22b29c19-64b9-4843-bf79-4b59db69e60b", "AQAAAAIAAYagAAAAEH9zAKthzMApc0DkQH2+QS2sm/jNDWdVVw9qin+7x1a6kvViKvtuATWplvgiOABiug==", "78b0cb42-d71a-4fc1-9fd9-df58c81e0e98" });
        }
    }
}
