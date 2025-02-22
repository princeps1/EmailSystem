using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ViewModel",
                table: "MailDefinitions",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<bool>(
                name: "SendBox",
                table: "MailDefinitions",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<string>(
                name: "MailDefinitionCore_ReplyTo",
                table: "MailDefinitions",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "MailDefinitionCore_ContentText",
                table: "MailDefinitions",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "MailDefinitionCore_ContentHTML",
                table: "MailDefinitions",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "MailDefinitionCore_CC",
                table: "MailDefinitions",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "MailDefinitionCore_BCC",
                table: "MailDefinitions",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EmailTemplateName",
                table: "MailDefinitions",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MailDefinitions",
                keyColumn: "ViewModel",
                keyValue: null,
                column: "ViewModel",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ViewModel",
                table: "MailDefinitions",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<bool>(
                name: "SendBox",
                table: "MailDefinitions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "MailDefinitions",
                keyColumn: "MailDefinitionCore_ReplyTo",
                keyValue: null,
                column: "MailDefinitionCore_ReplyTo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "MailDefinitionCore_ReplyTo",
                table: "MailDefinitions",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "MailDefinitions",
                keyColumn: "MailDefinitionCore_ContentText",
                keyValue: null,
                column: "MailDefinitionCore_ContentText",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "MailDefinitionCore_ContentText",
                table: "MailDefinitions",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "MailDefinitions",
                keyColumn: "MailDefinitionCore_ContentHTML",
                keyValue: null,
                column: "MailDefinitionCore_ContentHTML",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "MailDefinitionCore_ContentHTML",
                table: "MailDefinitions",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "MailDefinitions",
                keyColumn: "MailDefinitionCore_CC",
                keyValue: null,
                column: "MailDefinitionCore_CC",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "MailDefinitionCore_CC",
                table: "MailDefinitions",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "MailDefinitions",
                keyColumn: "MailDefinitionCore_BCC",
                keyValue: null,
                column: "MailDefinitionCore_BCC",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "MailDefinitionCore_BCC",
                table: "MailDefinitions",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "MailDefinitions",
                keyColumn: "EmailTemplateName",
                keyValue: null,
                column: "EmailTemplateName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "EmailTemplateName",
                table: "MailDefinitions",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
