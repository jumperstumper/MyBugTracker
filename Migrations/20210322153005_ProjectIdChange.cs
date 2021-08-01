using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication20.Migrations
{
    public partial class ProjectIdChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_Project_Id",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "UserProjects");

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

            migrationBuilder.CreateTable(
                name: "UserProjects",
                columns: table => new
                {
                    UserProject_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Project_Id = table.Column<int>(type: "int", nullable: false),
                    Project_Id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjects", x => x.UserProject_Id);
                    table.ForeignKey(
                        name: "FK_UserProjects_Projects_Project_Id1",
                        column: x => x.Project_Id1,
                        principalTable: "Projects",
                        principalColumn: "Project_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_Project_Id1",
                table: "UserProjects",
                column: "Project_Id1");

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
