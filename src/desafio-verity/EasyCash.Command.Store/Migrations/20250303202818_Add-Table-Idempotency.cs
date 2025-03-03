using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCash.Command.Store.Migrations
{
    /// <inheritdoc />
    public partial class AddTableIdempotency : Migration
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

            migrationBuilder.CreateIndex(
                name: "ix_idempotent_messages_id",
                table: "idempotent_messages",
                column: "id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "idempotent_messages");
        }
    }
}
