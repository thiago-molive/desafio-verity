using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCash.Command.Store.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "ix_outbox_messages_occurred_on_utc_processed_on_utc",
                table: "outbox_messages",
                columns: new[] { "occurred_on_utc", "processed_on_utc" })
                .Annotation("Npgsql:IndexInclude", new[] { "id", "type", "content" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "outbox_messages");
        }
    }
}
