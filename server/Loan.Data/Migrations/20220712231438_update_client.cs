using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan.Data.Migrations
{
    public partial class update_client : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullAddress",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "replace(replace([AddressLine1] + ' ' + [AddressLine2] + ' ' + [AddressLine3], '  ',' '), '  ', ' ')");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "replace(replace([FirstName] + ' ' + [MiddleName] + ' ' + [LastName], '  ',' '), '  ', ' ')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullAddress",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Client");
        }
    }
}
