using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResumeBuilder.Data.Migrations
{
    public partial class seedDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AddressLine3", "ContactNumber", "CountryId", "CreatedOn", "Email", "EmailVerificationCode", "FirstName", "Gender", "IpAdress", "IsTwoFactorEnabled", "LastLogin", "LastName", "MiddleName", "MobileVerificationCode", "ModifiedOn", "NewsletterSubcription", "Password", "ReferalCode", "Roles", "StateId", "Status", "Token", "UserName", "Zipcode" },
                values: new object[] { 1, null, null, null, "+919911227565", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nicenavneet99@gmail.com", null, "Navneet", 1, null, false, null, "Yadav", "k", null, null, false, "TLHjuTFxUHxvymkOYn8vPA==", null, 0, null, 0, null, "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
