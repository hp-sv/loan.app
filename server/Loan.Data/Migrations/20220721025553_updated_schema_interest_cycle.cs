using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan.Data.Migrations
{
    public partial class updated_schema_interest_cycle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApproveDate",
                table: "Account",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterestCycleTypeId",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "LookupSet",
                columns: new[] { "Id", "CreateBy", "CreatedAt", "Description", "Name", "RecordStatusId", "SeedTypeId", "TransactionId", "UpdatedAt", "UpdatedBy", "VersionNo" },
                values: new object[] { 10036, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interest Cycle Type", "Interest Cycle Type", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 });

            migrationBuilder.InsertData(
                table: "Lookup",
                columns: new[] { "Id", "CreateBy", "CreatedAt", "Description", "LookupSetId", "Name", "RecordStatusId", "SeedTypeId", "TransactionId", "UpdatedAt", "UpdatedBy", "VersionNo" },
                values: new object[] { 10037, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monthly Cycle", 10036, "Monthly", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 });

            migrationBuilder.InsertData(
                table: "Lookup",
                columns: new[] { "Id", "CreateBy", "CreatedAt", "Description", "LookupSetId", "Name", "RecordStatusId", "SeedTypeId", "TransactionId", "UpdatedAt", "UpdatedBy", "VersionNo" },
                values: new object[] { 10038, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yearly Cycle", 10036, "Yearly", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Account_InterestCycleTypeId",
                table: "Account",
                column: "InterestCycleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Lookup_InterestCycleTypeId",
                table: "Account",
                column: "InterestCycleTypeId",
                principalTable: "Lookup",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Lookup_InterestCycleTypeId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_InterestCycleTypeId",
                table: "Account");

            migrationBuilder.DeleteData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10037);

            migrationBuilder.DeleteData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10038);

            migrationBuilder.DeleteData(
                table: "LookupSet",
                keyColumn: "Id",
                keyValue: 10036);

            migrationBuilder.DropColumn(
                name: "ApproveDate",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "InterestCycleTypeId",
                table: "Account");
        }
    }
}
