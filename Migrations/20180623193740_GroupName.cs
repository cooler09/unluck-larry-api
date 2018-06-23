using Microsoft.EntityFrameworkCore.Migrations;

namespace unlucky_larry.Migrations
{
    public partial class GroupName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "Questions",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Questions");

        }
    }
}
