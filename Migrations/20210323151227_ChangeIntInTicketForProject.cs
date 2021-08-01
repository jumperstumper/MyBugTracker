using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication20.Migrations
{
    public partial class ChangeIntInTicketForProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_Project_Id",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "Project_Id",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projects_Project_Id",
                table: "Tickets",
                column: "Project_Id",
                principalTable: "Projects",
                principalColumn: "Project_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_Project_Id",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "Project_Id",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projects_Project_Id",
                table: "Tickets",
                column: "Project_Id",
                principalTable: "Projects",
                principalColumn: "Project_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
