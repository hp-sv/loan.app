using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan.Data.Migrations
{
    public partial class updatedschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualAmount",
                table: "AccountTransaction");

            migrationBuilder.RenameColumn(
                name: "ExpectedAmount",
                table: "AccountTransaction",
                newName: "Amount");

            migrationBuilder.AddColumn<int>(
                name: "JournalEntryTypeId",
                table: "AccountTransaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10001,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Projected transaction", "Projection" });

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10002,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Actual transaction", "Actual" });

            migrationBuilder.InsertData(
                table: "LookupSet",
                columns: new[] { "Id", "CreateBy", "CreatedAt", "Description", "Name", "RecordStatusId", "SeedTypeId", "TransactionId", "UpdatedAt", "UpdatedBy", "VersionNo" },
                values: new object[] { 10033, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Journal Entry Type (Debit/Credit)", "Journal Entry Type", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 });

            migrationBuilder.InsertData(
                table: "Lookup",
                columns: new[] { "Id", "CreateBy", "CreatedAt", "Description", "LookupSetId", "Name", "RecordStatusId", "SeedTypeId", "TransactionId", "UpdatedAt", "UpdatedBy", "VersionNo" },
                values: new object[] { 10034, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Debit Entry", 10033, "Debit", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 });

            migrationBuilder.InsertData(
                table: "Lookup",
                columns: new[] { "Id", "CreateBy", "CreatedAt", "Description", "LookupSetId", "Name", "RecordStatusId", "SeedTypeId", "TransactionId", "UpdatedAt", "UpdatedBy", "VersionNo" },
                values: new object[] { 10035, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Credit Entry", 10033, "Credit", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransaction_JournalEntryTypeId",
                table: "AccountTransaction",
                column: "JournalEntryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransaction_Lookup_JournalEntryTypeId",
                table: "AccountTransaction",
                column: "JournalEntryTypeId",
                principalTable: "Lookup",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransaction_Lookup_JournalEntryTypeId",
                table: "AccountTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountTransaction_JournalEntryTypeId",
                table: "AccountTransaction");

            migrationBuilder.DeleteData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10034);

            migrationBuilder.DeleteData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10035);

            migrationBuilder.DeleteData(
                table: "LookupSet",
                keyColumn: "Id",
                keyValue: 10033);

            migrationBuilder.DropColumn(
                name: "JournalEntryTypeId",
                table: "AccountTransaction");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "AccountTransaction",
                newName: "ExpectedAmount");

            migrationBuilder.AddColumn<decimal>(
                name: "ActualAmount",
                table: "AccountTransaction",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10001,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Credit transaction", "Credit" });

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10002,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Debit transaction", "Debit" });
        }
    }
}
