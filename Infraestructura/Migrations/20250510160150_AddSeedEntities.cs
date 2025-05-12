using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermisoRol");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<bool>(
                name: "Estado",
                table: "Roles",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PermisosRoles",
                columns: table => new
                {
                    PermisoId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisosRoles", x => new { x.PermisoId, x.RolId });
                    table.ForeignKey(
                        name: "FK_PermisosRoles_Permisos_PermisoId",
                        column: x => x.PermisoId,
                        principalTable: "Permisos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermisosRoles_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Id", "Codigo", "Nombre" },
                values: new object[,]
                {
                    { 1, "admin_users_creating", "Crear usuarios" },
                    { 2, "admin_users_updating", "Actualizar usuarios" },
                    { 3, "admin_users_deleting", "Eliminar usuarios" },
                    { 4, "admin_users_list_and_detail", "Listar usuarios" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Descripcion", "EsEliminado", "Estado", "FechaCreacion", "FechaEliminacion", "FechaModificacion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Acceso completo a opciones de administrador y sistema de cotización", false, true, null, null, null, "Desarrollador" },
                    { 2, "Acceso completo al sistema administrativo y opciones de usuarios", false, true, null, null, null, "Administrador" },
                    { 3, "Visualizacion de usuarios", false, true, null, null, null, "Moderador" }
                });

            migrationBuilder.InsertData(
                table: "PermisosRoles",
                columns: new[] { "PermisoId", "RolId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 3, 2 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Correo", "EsEliminado", "Estado", "FechaCreacion", "FechaEliminacion", "FechaModificacion", "NombreUsuario", "Nombres", "Nui", "RolId" },
                values: new object[,]
                {
                    { 1, "del Sistema", "desarrollo@prueba.com", false, true, null, null, null, "desarrollador", "Desarrollador", "9999999999", 1 },
                    { 2, "del Sistema", "admin@prueba.com", false, true, null, null, null, "system_admin", "Desarrollador", "9999999998", 2 },
                    { 3, "del Sistema", "mod@prueba.com", false, true, null, null, null, "system_mod", "Moderador", "9999999997", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermisosRoles_RolId",
                table: "PermisosRoles",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermisosRoles");

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Usuarios",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Roles",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PermisoRol",
                columns: table => new
                {
                    PermisosId = table.Column<int>(type: "int", nullable: false),
                    RolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisoRol", x => new { x.PermisosId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_PermisoRol_Permisos_PermisosId",
                        column: x => x.PermisosId,
                        principalTable: "Permisos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermisoRol_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PermisoRol_RolesId",
                table: "PermisoRol",
                column: "RolesId");
        }
    }
}
