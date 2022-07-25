using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan.Data.Migrations
{
    public partial class update_account_schema : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "TransactionTypeId",
                table: "AccountTransaction",
                type: "int",
                nullable: false,
                defaultValue: 10001,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "JournalEntryTypeId",
                table: "AccountTransaction",
                type: "int",
                nullable: false,
                defaultValue: 10034);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 10027,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RepaymentTypeId",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 10011,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DurationTypeId",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 10005,
                oldClrType: typeof(int),
                oldType: "int");

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
                defaultValue: 10037);

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
                values: new object[,]
                {
                    { 10033, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Journal Entry Type (Debit/Credit)", "Journal Entry Type", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10036, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interest Cycle Type", "Interest Cycle Type", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 }
                });

            migrationBuilder.InsertData(
                table: "Lookup",
                columns: new[] { "Id", "CreateBy", "CreatedAt", "Description", "LookupSetId", "Name", "RecordStatusId", "SeedTypeId", "TransactionId", "UpdatedAt", "UpdatedBy", "VersionNo" },
                values: new object[,]
                {
                    { 10034, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Debit Entry", 10033, "Debit", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10035, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Credit Entry", 10033, "Credit", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10037, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monthly Cycle", 10036, "Monthly", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10038, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yearly Cycle", 10036, "Yearly", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransaction_JournalEntryTypeId",
                table: "AccountTransaction",
                column: "JournalEntryTypeId");

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
                name: "FK_Account_Lookup_InterestCycleTypeId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransaction_Lookup_JournalEntryTypeId",
                table: "AccountTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountTransaction_JournalEntryTypeId",
                table: "AccountTransaction");

            migrationBuilder.DropIndex(
                name: "IX_Account_InterestCycleTypeId",
                table: "Account");

            migrationBuilder.DeleteData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10034);

            migrationBuilder.DeleteData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10035);

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
                keyValue: 10033);

            migrationBuilder.DeleteData(
                table: "LookupSet",
                keyColumn: "Id",
                keyValue: 10036);

            migrationBuilder.DropColumn(
                name: "Interest",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "JournalEntryTypeId",
                table: "AccountTransaction");

            migrationBuilder.DropColumn(
                name: "ApproveDate",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "InterestCycleTypeId",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "AccountTransaction",
                newName: "ExpectedAmount");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionTypeId",
                table: "AccountTransaction",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 10001);

            migrationBuilder.AddColumn<decimal>(
                name: "ActualAmount",
                table: "AccountTransaction",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Account",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 10027);

            migrationBuilder.AlterColumn<int>(
                name: "RepaymentTypeId",
                table: "Account",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 10011);

            migrationBuilder.AlterColumn<int>(
                name: "DurationTypeId",
                table: "Account",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 10005);

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
