using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeChoiceDiscipline.Migrations
{
    public partial class baseentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Users",
                newName: "Lastname");

            migrationBuilder.AddColumn<int>(
                name: "DisciplineId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxAmountOfStudents = table.Column<byte>(type: "tinyint", nullable: false),
                    CurrentAmountOfStudents = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discipline", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_DisciplineId",
                table: "Users",
                column: "DisciplineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Discipline_DisciplineId",
                table: "Users",
                column: "DisciplineId",
                principalTable: "Discipline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Discipline_DisciplineId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropIndex(
                name: "IX_Users_DisciplineId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DisciplineId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Users",
                newName: "Phone");
        }
    }
}
