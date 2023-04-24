using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSuperMarket.Migrations
{
    /// <inheritdoc />
    public partial class database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f86e5e52-5558-42d3-b3b6-d5c2385cbaf9", "AQAAAAIAAYagAAAAEPS3sCs6ZHFmBdlkvALEZXhQrlO0tkZmvYXz4AdaBDSxhLeZIjx2rbZ0dog/A9tKDQ==", "29615a6b-4d71-4026-8e70-56ed63292613" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e547a9c0-2428-4a5c-9bd7-df59c8c034f3", "AQAAAAIAAYagAAAAEOYU4WI9y9jrFyDY/Q6JIbBsXgWPd+gUykovRsmiq6CpKgq5dkiJsTI2HfoBiFNiQA==", "0312c0d8-ccd9-47ad-96bf-a4b5b6006374" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d57d316-3c04-43ad-a697-fcb9f4706ed0", "AQAAAAIAAYagAAAAEB/4SWUF3E8GRh5DYqYxXHas04XUCiQDbW3JMiF+UfhR1f7I1TD5NqITtqRJbjMgHQ==", "cf9c09f4-3e1d-4247-af0b-f533da5de5b7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "930d10db-c8c3-4669-859b-dc5a420aeedb", "AQAAAAIAAYagAAAAEKytoiTJWOh/8nO1lDJaE1/aike4n2knxVs6Y1Abse/uUDQhLMdo9MoQF/tlhB7gHQ==", "a4f838cc-86ed-4104-9d8d-08197a3c56da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f57568e-9a4c-48e0-8fb2-e73169ba187c", "AQAAAAIAAYagAAAAEAvdavDx+BLEoEuNtPhF4Ti3Mku0bufFqhAfuaS0RU0r9eLa2hFOxZoiepZveSbkkQ==", "d4bed3a9-b9d4-4fe8-8b77-f911374956eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8aa75e22-eadd-4e58-9b25-08b24997f2e1", "AQAAAAIAAYagAAAAEOCF+zh8sH5VpJpaO9VZ3KfiLB1RG+WrVdHfPg9EFyKT9ve25PoENnEEREIPYFVh2A==", "ef383b32-8960-4551-a727-d3ba88f149d6" });
        }
    }
}
