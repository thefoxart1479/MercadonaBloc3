using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mercadona_V3.Migrations
{
    /// <inheritdoc />
    public partial class CreatingAuthDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5de39ffd-d217-4b17-9c39-5a56b004856c", "9631f711-531e-400a-933c-fec6ab3ce8c0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5de39ffd-d217-4b17-9c39-5a56b004856c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9631f711-531e-400a-933c-fec6ab3ce8c0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "054e0b7d-8297-432d-b73f-afc0138c44f4", "054e0b7d-8297-432d-b73f-afc0138c44f4", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "25033cc8-f09e-4d5f-a0c7-c50a724fa5c1", 0, "d8388ef9-9fab-4541-afd8-4ec7f1416694", "admin@mercadona.com", false, false, null, "ADMIN@MERCADONA.COM", "ADMIN@MERCADONA.COM", "AQAAAAEAACcQAAAAEAu1lT1jmbPR3uhH5+H0bwm3CzG4sU/Af3GC5j+/klAkzbgFk4yqs2LaKdjtoUCrLQ==", null, false, "afd0ed93-b3fb-4b4d-8d4c-1effa1cb8728", false, "adminmercadona" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "054e0b7d-8297-432d-b73f-afc0138c44f4", "25033cc8-f09e-4d5f-a0c7-c50a724fa5c1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "054e0b7d-8297-432d-b73f-afc0138c44f4", "25033cc8-f09e-4d5f-a0c7-c50a724fa5c1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "054e0b7d-8297-432d-b73f-afc0138c44f4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "25033cc8-f09e-4d5f-a0c7-c50a724fa5c1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5de39ffd-d217-4b17-9c39-5a56b004856c", "5de39ffd-d217-4b17-9c39-5a56b004856c", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9631f711-531e-400a-933c-fec6ab3ce8c0", 0, "d03555f1-752b-49ae-9447-d3749f49b673", "admin@mercadona.com", false, false, null, "ADMIN@MERCADONA.COM", "ADMIN@MERCADONA.COM", "AQAAAAEAACcQAAAAEMXrdm2xpFpGPcntnnilKF4UF9YuUezjnSl5LbJRXqZbiFIEYuIjBKTKA4SLn4/kwg==", null, false, "d0b070c1-b7c7-4a79-85b6-87c637fa4e1a", false, "admin@mercadona.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5de39ffd-d217-4b17-9c39-5a56b004856c", "9631f711-531e-400a-933c-fec6ab3ce8c0" });
        }
    }
}
