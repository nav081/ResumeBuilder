using Microsoft.EntityFrameworkCore.Migrations;

namespace ResumeBuilder.Data.Migrations
{
    public partial class AddedIPtoToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IPAdress",
                table: "Tokens",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IPAdress",
                table: "Tokens");
        }
    }
}
