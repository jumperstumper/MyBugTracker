using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication20.Migrations
{
    public partial class m2mUserTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTicket_AspNetUsers_UserId",
                table: "UserTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTicket_Tickets_Ticket_Id",
                table: "UserTicket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTicket",
                table: "UserTicket");

            migrationBuilder.RenameTable(
                name: "UserTicket",
                newName: "UserTickets");

            migrationBuilder.RenameIndex(
                name: "IX_UserTicket_Ticket_Id",
                table: "UserTickets",
                newName: "IX_UserTickets_Ticket_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTickets",
                table: "UserTickets",
                columns: new[] { "UserId", "Ticket_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserTickets_AspNetUsers_UserId",
                table: "UserTickets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTickets_Tickets_Ticket_Id",
                table: "UserTickets",
                column: "Ticket_Id",
                principalTable: "Tickets",
                principalColumn: "Ticket_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTickets_AspNetUsers_UserId",
                table: "UserTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTickets_Tickets_Ticket_Id",
                table: "UserTickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTickets",
                table: "UserTickets");

            migrationBuilder.RenameTable(
                name: "UserTickets",
                newName: "UserTicket");

            migrationBuilder.RenameIndex(
                name: "IX_UserTickets_Ticket_Id",
                table: "UserTicket",
                newName: "IX_UserTicket_Ticket_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTicket",
                table: "UserTicket",
                columns: new[] { "UserId", "Ticket_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserTicket_AspNetUsers_UserId",
                table: "UserTicket",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTicket_Tickets_Ticket_Id",
                table: "UserTicket",
                column: "Ticket_Id",
                principalTable: "Tickets",
                principalColumn: "Ticket_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
