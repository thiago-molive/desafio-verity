using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EasyCash.Command.Store.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "idempotent_messages",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    request = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false, comment: "Request of the message"),
                    response = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true, comment: "Response of the message")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_idempotent_messages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "outbox_messages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    occurred_on_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    type = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false, comment: "Type of class for desserializing"),
                    content = table.Column<string>(type: "jsonb", nullable: false, comment: "Content of the message"),
                    processed_on_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Date when the message was processed"),
                    error = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "Error message if the message processing failed")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_outbox_messages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "Name of the permission."),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "Description of the permission."),
                    module = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Module of the permission."),
                    action = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Action of the permission.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "Name of the role."),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "Description of the role."),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "Date of the transaction"),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false, comment: "Description of the transaction"),
                    type = table.Column<string>(type: "text", nullable: false, comment: "Type of the transaction"),
                    amount = table.Column<decimal>(type: "numeric", nullable: false, comment: "Amount of the transaction"),
                    category = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Category of the transaction"),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "Date when the transaction was created"),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Date when the transaction was updated"),
                    row_version = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "1", comment: "Concurrency Token")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_transactions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "The real first name of the user"),
                    last_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "The real last name of the user"),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "user e-mail"),
                    identity_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role_permissions",
                columns: table => new
                {
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    permission_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_permissions", x => new { x.role_id, x.permission_id });
                    table.ForeignKey(
                        name: "fk_role_permissions_permissions_permission_id",
                        column: x => x.permission_id,
                        principalTable: "permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_role_permissions_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "role_entity_user_entity",
                columns: table => new
                {
                    roles_id = table.Column<Guid>(type: "uuid", nullable: false),
                    users_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_entity_user_entity", x => new { x.roles_id, x.users_id });
                    table.ForeignKey(
                        name: "fk_role_entity_user_entity_role_entity_roles_id",
                        column: x => x.roles_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_role_entity_user_entity_user_entity_users_id",
                        column: x => x.users_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "action", "description", "module", "name" },
                values: new object[,]
                {
                    { new Guid("71901f50-380f-40c5-80ef-292eba6bf82b"), "All", "Admin permission", "Admin", "Admin permission" },
                    { new Guid("a08dab99-40a0-41ab-b5e5-ba8b727f8f3a"), "All", "Generic permission", "Collaborator", "Gereric permission" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "description", "is_active", "name" },
                values: new object[,]
                {
                    { new Guid("b8b1e85b-4492-4a33-b09b-dca91c067f49"), "", true, "Collaborator" },
                    { new Guid("ca9ed27c-c409-486f-a89f-31b8b37b1e56"), "", true, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "role_permissions",
                columns: new[] { "permission_id", "role_id" },
                values: new object[,]
                {
                    { new Guid("a08dab99-40a0-41ab-b5e5-ba8b727f8f3a"), new Guid("b8b1e85b-4492-4a33-b09b-dca91c067f49") },
                    { new Guid("71901f50-380f-40c5-80ef-292eba6bf82b"), new Guid("ca9ed27c-c409-486f-a89f-31b8b37b1e56") },
                    { new Guid("a08dab99-40a0-41ab-b5e5-ba8b727f8f3a"), new Guid("ca9ed27c-c409-486f-a89f-31b8b37b1e56") }
                });

            migrationBuilder.CreateIndex(
                name: "ix_idempotent_messages_id",
                table: "idempotent_messages",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_outbox_messages_occurred_on_utc_processed_on_utc",
                table: "outbox_messages",
                columns: new[] { "occurred_on_utc", "processed_on_utc" })
                .Annotation("Npgsql:IndexInclude", new[] { "id", "type", "content" });

            migrationBuilder.CreateIndex(
                name: "ix_permissions_module_action",
                table: "permissions",
                columns: new[] { "module", "action" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_user_entity_users_id",
                table: "role_entity_user_entity",
                column: "users_id");

            migrationBuilder.CreateIndex(
                name: "ix_role_permissions_permission_id_role_id",
                table: "role_permissions",
                columns: new[] { "permission_id", "role_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_roles_name",
                table: "roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_transactions_date",
                table: "transactions",
                column: "date");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_identity_id",
                table: "users",
                column: "identity_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "idempotent_messages");

            migrationBuilder.DropTable(
                name: "outbox_messages");

            migrationBuilder.DropTable(
                name: "role_entity_user_entity");

            migrationBuilder.DropTable(
                name: "role_permissions");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
