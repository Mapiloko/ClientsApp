using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspApp.Migrations
{
    public partial class addedNewColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientContact_UserClients_LinkedContactsId",
                table: "ClientContact");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientContact_UserContacts_LinkedClientsId",
                table: "ClientContact");

            migrationBuilder.RenameColumn(
                name: "linkedContacts",
                table: "UserClients",
                newName: "LinkedContacts");

            migrationBuilder.RenameColumn(
                name: "LinkedContactsId",
                table: "ClientContact",
                newName: "ContactsId");

            migrationBuilder.RenameColumn(
                name: "LinkedClientsId",
                table: "ClientContact",
                newName: "ClientsId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientContact_LinkedContactsId",
                table: "ClientContact",
                newName: "IX_ClientContact_ContactsId");

            migrationBuilder.AddColumn<int>(
                name: "LinkedClients",
                table: "UserContacts",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LinkedContacts",
                table: "UserClients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserClients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "UserClients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientContact_UserClients_ClientsId",
                table: "ClientContact",
                column: "ClientsId",
                principalTable: "UserClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientContact_UserContacts_ContactsId",
                table: "ClientContact",
                column: "ContactsId",
                principalTable: "UserContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientContact_UserClients_ClientsId",
                table: "ClientContact");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientContact_UserContacts_ContactsId",
                table: "ClientContact");

            migrationBuilder.DropColumn(
                name: "LinkedClients",
                table: "UserContacts");

            migrationBuilder.RenameColumn(
                name: "LinkedContacts",
                table: "UserClients",
                newName: "linkedContacts");

            migrationBuilder.RenameColumn(
                name: "ContactsId",
                table: "ClientContact",
                newName: "LinkedContactsId");

            migrationBuilder.RenameColumn(
                name: "ClientsId",
                table: "ClientContact",
                newName: "LinkedClientsId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientContact_ContactsId",
                table: "ClientContact",
                newName: "IX_ClientContact_LinkedContactsId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserClients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "linkedContacts",
                table: "UserClients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "UserClients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientContact_UserClients_LinkedContactsId",
                table: "ClientContact",
                column: "LinkedContactsId",
                principalTable: "UserClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientContact_UserContacts_LinkedClientsId",
                table: "ClientContact",
                column: "LinkedClientsId",
                principalTable: "UserContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
