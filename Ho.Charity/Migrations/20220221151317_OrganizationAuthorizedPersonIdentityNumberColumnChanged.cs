using Microsoft.EntityFrameworkCore.Migrations;

namespace Ho.Charity.Migrations
{
    public partial class OrganizationAuthorizedPersonIdentityNumberColumnChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubMerchantKey",
                table: "CharityOrganizations");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizationAuthorizedPersonPhoneNumber",
                table: "CharityOrganizations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrganizationAuthorizedPersonPhoneNumber",
                table: "CharityOrganizations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "SubMerchantKey",
                table: "CharityOrganizations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
