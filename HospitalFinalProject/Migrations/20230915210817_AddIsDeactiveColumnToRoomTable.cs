using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalFinalProject.Migrations
{
    public partial class AddIsDeactiveColumnToRoomTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeactive",
                table: "RoomAllotments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeactive",
                table: "RoomAllotments");
        }
    }
}
