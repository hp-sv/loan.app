using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan.Data.Migrations
{
    public partial class update_account_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Account",
                newName: "Principal");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Account",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "replace(replace([FirstName] + ' ' + [MiddleName] + ' ' + [LastName], '  ',' '), '  ', ' ') PERSISTED",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "replace(replace([FirstName] + ' ' + [MiddleName] + ' ' + [LastName], '  ',' '), '  ', ' ')");

            migrationBuilder.AlterColumn<string>(
                name: "FullAddress",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "replace(replace([AddressLine1] + ' ' + [AddressLine2] + ' ' + [AddressLine3], '  ',' '), '  ', ' ')  PERSISTED",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "replace(replace([AddressLine1] + ' ' + [AddressLine2] + ' ' + [AddressLine3], '  ',' '), '  ', ' ')");

            migrationBuilder.CreateTable(
                name: "AccountComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionNo = table.Column<int>(type: "int", nullable: false),
                    RecordStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountComment_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountComment_Lookup_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Lookup",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Lookup",
                columns: new[] { "Id", "CreateBy", "CreatedAt", "Description", "LookupSetId", "Name", "RecordStatusId", "SeedTypeId", "TransactionId", "UpdatedAt", "UpdatedBy", "VersionNo" },
                values: new object[] { 10032, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Account is completed", 10026, "Completed", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_AccountComment_AccountId",
                table: "AccountComment",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountComment_RecordStatusId",
                table: "AccountComment",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountComment_StatusId",
                table: "AccountComment",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountComment");

            migrationBuilder.DeleteData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10032);

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "Principal",
                table: "Account",
                newName: "TotalAmount");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "replace(replace([FirstName] + ' ' + [MiddleName] + ' ' + [LastName], '  ',' '), '  ', ' ')",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComputedColumnSql: "replace(replace([FirstName] + ' ' + [MiddleName] + ' ' + [LastName], '  ',' '), '  ', ' ') PERSISTED");

            migrationBuilder.AlterColumn<string>(
                name: "FullAddress",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "replace(replace([AddressLine1] + ' ' + [AddressLine2] + ' ' + [AddressLine3], '  ',' '), '  ', ' ')",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComputedColumnSql: "replace(replace([AddressLine1] + ' ' + [AddressLine2] + ' ' + [AddressLine3], '  ',' '), '  ', ' ')  PERSISTED");
        }
    }
}
