using Microsoft.EntityFrameworkCore.Migrations;

namespace test_reverse_engineer.Migrations
{
    public partial class ModifyDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOC_FORMAT",
                table: "DOCUMENT");

            migrationBuilder.DropColumn(
                name: "DOC_SIZE",
                table: "DOCUMENT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DOC_FORMAT",
                table: "DOCUMENT",
                unicode: false,
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DOC_SIZE",
                table: "DOCUMENT",
                type: "decimal(18, 0)",
                nullable: true);
        }
    }
}
