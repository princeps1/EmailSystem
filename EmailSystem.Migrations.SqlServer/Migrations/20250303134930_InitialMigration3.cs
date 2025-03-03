using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "MailDefinitions",
                newName: "MailDefinitionID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Attachments",
                newName: "AttachmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MailDefinitionID",
                table: "MailDefinitions",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "AttachmentID",
                table: "Attachments",
                newName: "ID");
        }
    }
}
