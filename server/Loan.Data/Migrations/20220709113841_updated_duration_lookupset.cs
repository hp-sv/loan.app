using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan.Data.Migrations
{
    public partial class updated_duration_lookupset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Client_ClientId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_Lookup_DurationTypeId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_Lookup_RepaymentTypeId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_Lookup_StatusId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransaction_Account_AccountId",
                table: "AccountTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransaction_Lookup_TransactionTypeId",
                table: "AccountTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeEntity_ChangeTransaction_TransactionId",
                table: "ChangeEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeEntityDetail_ChangeEntity_ChangeEntityId",
                table: "ChangeEntityDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_Client_EmergencyContactId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Lookup_LookupSet_LookupSetId",
                table: "Lookup");

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10005,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Month duration", "Month" });

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10006,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Week duration", "Week" });

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10007,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Quarter duration", "Quarter" });

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10008,
                column: "Name",
                value: "Half Year");

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10009,
                column: "Name",
                value: "Year");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Client_ClientId",
                table: "Account",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Lookup_DurationTypeId",
                table: "Account",
                column: "DurationTypeId",
                principalTable: "Lookup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Lookup_RepaymentTypeId",
                table: "Account",
                column: "RepaymentTypeId",
                principalTable: "Lookup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Lookup_StatusId",
                table: "Account",
                column: "StatusId",
                principalTable: "Lookup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransaction_Account_AccountId",
                table: "AccountTransaction",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransaction_Lookup_TransactionTypeId",
                table: "AccountTransaction",
                column: "TransactionTypeId",
                principalTable: "Lookup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeEntity_ChangeTransaction_TransactionId",
                table: "ChangeEntity",
                column: "TransactionId",
                principalTable: "ChangeTransaction",
                principalColumn: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeEntityDetail_ChangeEntity_ChangeEntityId",
                table: "ChangeEntityDetail",
                column: "ChangeEntityId",
                principalTable: "ChangeEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Client_EmergencyContactId",
                table: "Client",
                column: "EmergencyContactId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lookup_LookupSet_LookupSetId",
                table: "Lookup",
                column: "LookupSetId",
                principalTable: "LookupSet",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Client_ClientId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_Lookup_DurationTypeId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_Lookup_RepaymentTypeId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_Lookup_StatusId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransaction_Account_AccountId",
                table: "AccountTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransaction_Lookup_TransactionTypeId",
                table: "AccountTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeEntity_ChangeTransaction_TransactionId",
                table: "ChangeEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeEntityDetail_ChangeEntity_ChangeEntityId",
                table: "ChangeEntityDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_Client_EmergencyContactId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Lookup_LookupSet_LookupSetId",
                table: "Lookup");

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10005,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Monthly duration", "Monthly" });

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10006,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Weekly duration", "Weekly" });

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10007,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Quarterly duration", "Quarterly" });

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10008,
                column: "Name",
                value: "Half a year");

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10009,
                column: "Name",
                value: "Yearly");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Client_ClientId",
                table: "Account",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Lookup_DurationTypeId",
                table: "Account",
                column: "DurationTypeId",
                principalTable: "Lookup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Lookup_RepaymentTypeId",
                table: "Account",
                column: "RepaymentTypeId",
                principalTable: "Lookup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Lookup_StatusId",
                table: "Account",
                column: "StatusId",
                principalTable: "Lookup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransaction_Account_AccountId",
                table: "AccountTransaction",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransaction_Lookup_TransactionTypeId",
                table: "AccountTransaction",
                column: "TransactionTypeId",
                principalTable: "Lookup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeEntity_ChangeTransaction_TransactionId",
                table: "ChangeEntity",
                column: "TransactionId",
                principalTable: "ChangeTransaction",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeEntityDetail_ChangeEntity_ChangeEntityId",
                table: "ChangeEntityDetail",
                column: "ChangeEntityId",
                principalTable: "ChangeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Client_EmergencyContactId",
                table: "Client",
                column: "EmergencyContactId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lookup_LookupSet_LookupSetId",
                table: "Lookup",
                column: "LookupSetId",
                principalTable: "LookupSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
