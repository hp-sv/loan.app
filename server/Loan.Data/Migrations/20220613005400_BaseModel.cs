using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan.Data.Migrations
{
    public partial class BaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChangeTransaction",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeTransaction", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AddressLine3 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EmergencyContactId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_Client_EmergencyContactId",
                        column: x => x.EmergencyContactId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookupSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionNo = table.Column<int>(type: "int", nullable: false),
                    RecordStatusId = table.Column<int>(type: "int", nullable: false),
                    SeedTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChangeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PrimaryKey = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChangeOperationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChangeEntity_ChangeTransaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "ChangeTransaction",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LookupSetId = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionNo = table.Column<int>(type: "int", nullable: false),
                    RecordStatusId = table.Column<int>(type: "int", nullable: false),
                    SeedTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lookup_LookupSet_LookupSetId",
                        column: x => x.LookupSetId,
                        principalTable: "LookupSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChangeEntityDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeEntityId = table.Column<int>(type: "int", nullable: false),
                    ColumnName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeEntityDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChangeEntityDetail_ChangeEntity_ChangeEntityId",
                        column: x => x.ChangeEntityId,
                        principalTable: "ChangeEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    DurationTypeId = table.Column<int>(type: "int", nullable: false),
                    RepaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Account_Lookup_DurationTypeId",
                        column: x => x.DurationTypeId,
                        principalTable: "Lookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Account_Lookup_RepaymentTypeId",
                        column: x => x.RepaymentTypeId,
                        principalTable: "Lookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Account_Lookup_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Lookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ActualAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_AccountTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTransaction_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountTransaction_Lookup_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "Lookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "LookupSet",
                columns: new[] { "Id", "CreateBy", "CreatedAt", "Description", "Name", "RecordStatusId", "SeedTypeId", "TransactionId", "UpdatedAt", "UpdatedBy", "VersionNo" },
                values: new object[,]
                {
                    { 10001, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transaction types", "Transaction Type", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10002, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Duration types", "Duration Type", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10003, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Repayment schedules", "Repayment Schedule", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10014, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Record statuses", "Record Status", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10018, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed constant types", "Seed Constant Type", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10022, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Change Operations Create, Update & Delete", "Change Operations", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10026, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Account statuses i.e. Active, Pending etc", "Account Status", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 }
                });

            migrationBuilder.InsertData(
                table: "Lookup",
                columns: new[] { "Id", "CreateBy", "CreatedAt", "Description", "LookupSetId", "Name", "RecordStatusId", "SeedTypeId", "TransactionId", "UpdatedAt", "UpdatedBy", "VersionNo" },
                values: new object[,]
                {
                    { 10001, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Credit transaction", 10001, "Credit", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10002, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Debit transaction", 10001, "Debit", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10003, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interest transaction", 10001, "Interest", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10004, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adjustment transaction", 10001, "Adjustment", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10005, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monthly duration", 10002, "Monthly", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10006, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weekly duration", 10002, "Weekly", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10007, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quarterly duration", 10002, "Quarterly", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10008, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Half year duration", 10002, "Half a year", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10009, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yearly duration", 10002, "Yearly", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10010, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daily repayment schedule", 10003, "Daily", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10011, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weekly repayment schedule", 10003, "Weekly", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10012, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monthly repayment schedule", 10003, "Monthly", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10013, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Twice a month repayment schedule", 10003, "Twice Monthly", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10015, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active record", 10014, "Active", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10016, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deleted record", 10014, "Deleted", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10017, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Archive record", 10014, "Archive", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10018, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending record", 10014, "Pending", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10019, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Constant seed data", 10018, "Constant", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10020, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User updated seed data", 10018, "User Updated", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10021, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Updatable seed data", 10018, "Updatable", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10023, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create entity", 10001, "Create", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10024, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Update entity", 10001, "Update", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10025, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delete entity", 10001, "Delete", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10027, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Account is pending and waiting for approval", 10026, "Pending", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10028, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Account is approved", 10026, "Approved", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10029, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Account is on going", 10026, "Active", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10030, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Account is cancelled", 10026, "Cancelled", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 },
                    { 10031, "la:seeduser", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Account is declined and waiting for approval", 10026, "Declined", 10015, 10019, new Guid("ab3b99d9-b824-4277-b367-2151d6e403a8"), null, "", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_ClientId",
                table: "Account",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_DurationTypeId",
                table: "Account",
                column: "DurationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_RecordStatusId",
                table: "Account",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_RepaymentTypeId",
                table: "Account",
                column: "RepaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_StatusId",
                table: "Account",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransaction_AccountId",
                table: "AccountTransaction",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransaction_RecordStatusId",
                table: "AccountTransaction",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransaction_TransactionTypeId",
                table: "AccountTransaction",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeEntity_TransactionId",
                table: "ChangeEntity",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeEntityDetail_ChangeEntityId",
                table: "ChangeEntityDetail",
                column: "ChangeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_EmergencyContactId",
                table: "Client",
                column: "EmergencyContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_RecordStatusId",
                table: "Client",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Lookup_LookupSetId",
                table: "Lookup",
                column: "LookupSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Lookup_RecordStatusId",
                table: "Lookup",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LookupSet_RecordStatusId",
                table: "LookupSet",
                column: "RecordStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTransaction");

            migrationBuilder.DropTable(
                name: "ChangeEntityDetail");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "ChangeEntity");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Lookup");

            migrationBuilder.DropTable(
                name: "ChangeTransaction");

            migrationBuilder.DropTable(
                name: "LookupSet");
        }
    }
}
