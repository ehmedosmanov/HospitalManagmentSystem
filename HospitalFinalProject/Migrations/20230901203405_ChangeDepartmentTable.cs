using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalFinalProject.Migrations
{
    public partial class ChangeDepartmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Doctors_DepartmentHeadId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepartmentHeadId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepartmentHeadId",
                table: "Departments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentHeadId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentHeadId",
                table: "Departments",
                column: "DepartmentHeadId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Doctors_DepartmentHeadId",
                table: "Departments",
                column: "DepartmentHeadId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
