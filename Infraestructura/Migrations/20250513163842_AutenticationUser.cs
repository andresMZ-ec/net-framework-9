using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class AutenticationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contraseña",
                table: "Usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 13, 16, 38, 41, 244, DateTimeKind.Utc).AddTicks(2938), new DateTime(2025, 5, 13, 16, 38, 41, 244, DateTimeKind.Utc).AddTicks(2938) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 13, 16, 38, 41, 244, DateTimeKind.Utc).AddTicks(2938), new DateTime(2025, 5, 13, 16, 38, 41, 244, DateTimeKind.Utc).AddTicks(2938) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 13, 16, 38, 41, 244, DateTimeKind.Utc).AddTicks(2938), new DateTime(2025, 5, 13, 16, 38, 41, 244, DateTimeKind.Utc).AddTicks(2938) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaCreacion", "FechaModificacion" },
                values: new object[] { "dev12345", new DateTime(2025, 5, 13, 16, 38, 41, 245, DateTimeKind.Utc).AddTicks(901), new DateTime(2025, 5, 13, 16, 38, 41, 245, DateTimeKind.Utc).AddTicks(901) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Contraseña", "FechaCreacion", "FechaModificacion" },
                values: new object[] { "admin12345", new DateTime(2025, 5, 13, 16, 38, 41, 245, DateTimeKind.Utc).AddTicks(901), new DateTime(2025, 5, 13, 16, 38, 41, 245, DateTimeKind.Utc).AddTicks(901) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Contraseña", "FechaCreacion", "FechaModificacion" },
                values: new object[] { "mod12345", new DateTime(2025, 5, 13, 16, 38, 41, 245, DateTimeKind.Utc).AddTicks(901), new DateTime(2025, 5, 13, 16, 38, 41, 245, DateTimeKind.Utc).AddTicks(901) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contraseña",
                table: "Usuarios");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { null, null });
        }
    }
}
