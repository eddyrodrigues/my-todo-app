using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Web.Migrations
{
    public partial class Adicionadocampodoneaotodoitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Done",
                table: "Todos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Done",
                table: "Todos");
        }
    }
}
