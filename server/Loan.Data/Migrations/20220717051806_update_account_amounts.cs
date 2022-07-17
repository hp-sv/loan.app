using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan.Data.Migrations
{
    public partial class update_account_amounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Interest",
                table: "Account",
                type: "decimal(18,2)",
                nullable: true,
                computedColumnSql: "(Principal * (Rate/100)) PERSISTED");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Account",
                type: "decimal(18,2)",
                nullable: true,
                computedColumnSql: "(Principal * (1+(Rate/100))) PERSISTED");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interest",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Account");
        }
    }
}
