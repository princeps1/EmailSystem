using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmailSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailDefinitions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MailDefinitionCore_From = table.Column<string>(type: "text", nullable: false),
                    MailDefinitionCore_To = table.Column<string>(type: "text", nullable: false),
                    MailDefinitionCore_CC = table.Column<string>(type: "text", nullable: false),
                    MailDefinitionCore_BCC = table.Column<string>(type: "text", nullable: false),
                    MailDefinitionCore_ReplyTo = table.Column<string>(type: "text", nullable: false),
                    MailDefinitionCore_Subject = table.Column<string>(type: "text", nullable: false),
                    MailDefinitionCore_ContentHTML = table.Column<string>(type: "text", nullable: false),
                    MailDefinitionCore_ContentText = table.Column<string>(type: "text", nullable: false),
                    TenantName = table.Column<string>(type: "text", nullable: false),
                    EmailTemplateName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ViewModel = table.Column<string>(type: "text", nullable: false),
                    SendBox = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailDefinitions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Data = table.Column<byte[]>(type: "bytea", nullable: false),
                    ContentType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FileName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    MailDefinitionID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Attachments_MailDefinitions_MailDefinitionID",
                        column: x => x.MailDefinitionID,
                        principalTable: "MailDefinitions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_MailDefinitionID",
                table: "Attachments",
                column: "MailDefinitionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "MailDefinitions");
        }
    }
}
