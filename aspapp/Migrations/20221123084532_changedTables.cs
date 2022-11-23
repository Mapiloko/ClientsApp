using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspApp.Migrations
{
    public partial class changedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientContact_UserClients_ClientsId",
                table: "ClientContact");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientContact_UserContacts_ContactsId",
                table: "ClientContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserContacts",
                table: "UserContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserClients",
                table: "UserClients");

            migrationBuilder.RenameTable(
                name: "UserContacts",
                newName: "Contacts");

            migrationBuilder.RenameTable(
                name: "UserClients",
                newName: "Clients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientContact_Clients_ClientsId",
                table: "ClientContact",
                column: "ClientsId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientContact_Contacts_ContactsId",
                table: "ClientContact",
                column: "ContactsId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientContact_Clients_ClientsId",
                table: "ClientContact");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientContact_Contacts_ContactsId",
                table: "ClientContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "UserContacts");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "UserClients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserContacts",
                table: "UserContacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserClients",
                table: "UserClients",
                column: "Id");

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
    }
}
