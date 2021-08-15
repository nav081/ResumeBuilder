using Microsoft.EntityFrameworkCore.Migrations;

namespace ResumeBuilder.Data.Migrations
{
    public partial class ForeignKeyInTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BodyHeirarchy",
                table: "Templates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FooterHeirarchy",
                table: "Templates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeaderHeirarchy",
                table: "Templates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalutaionHeirarchy",
                table: "Templates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalutationId",
                table: "Templates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Templates_BodyId",
                table: "Templates",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_FooterId",
                table: "Templates",
                column: "FooterId");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_HeaderId",
                table: "Templates",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_SalutationId",
                table: "Templates",
                column: "SalutationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_Bodies_BodyId",
                table: "Templates",
                column: "BodyId",
                principalTable: "Bodies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_Footer_FooterId",
                table: "Templates",
                column: "FooterId",
                principalTable: "Footer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_Headers_HeaderId",
                table: "Templates",
                column: "HeaderId",
                principalTable: "Headers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_Salutations_SalutationId",
                table: "Templates",
                column: "SalutationId",
                principalTable: "Salutations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Templates_Bodies_BodyId",
                table: "Templates");

            migrationBuilder.DropForeignKey(
                name: "FK_Templates_Footer_FooterId",
                table: "Templates");

            migrationBuilder.DropForeignKey(
                name: "FK_Templates_Headers_HeaderId",
                table: "Templates");

            migrationBuilder.DropForeignKey(
                name: "FK_Templates_Salutations_SalutationId",
                table: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_Templates_BodyId",
                table: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_Templates_FooterId",
                table: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_Templates_HeaderId",
                table: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_Templates_SalutationId",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "BodyHeirarchy",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "FooterHeirarchy",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "HeaderHeirarchy",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "SalutaionHeirarchy",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "SalutationId",
                table: "Templates");
        }
    }
}
