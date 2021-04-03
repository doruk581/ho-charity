using Microsoft.EntityFrameworkCore.Migrations;

namespace Ho.Charity.Migrations
{
    public partial class EntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrganizationAuthorizedPersonIdentityNumber",
                table: "CharityOrganizations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganizationAuthorizedPersonIdentityNumber",
                table: "CharityOrganizations");
        }
    }
}
