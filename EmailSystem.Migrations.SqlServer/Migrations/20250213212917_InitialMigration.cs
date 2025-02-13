using Microsoft.EntityFrameworkCore.Migrations;

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
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MailDefinitionCore_From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailDefinitionCore_To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailDefinitionCore_CC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailDefinitionCore_BCC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailDefinitionCore_ReplyTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailDefinitionCore_Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailDefinitionCore_ContentHTML = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailDefinitionCore_ContentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailTemplateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ViewModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendBox = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailDefinitions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MailDefinitionID = table.Column<int>(type: "int", nullable: false)
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
