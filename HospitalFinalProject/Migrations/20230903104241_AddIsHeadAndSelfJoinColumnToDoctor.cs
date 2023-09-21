using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalFinalProject.Migrations
{
    public partial class AddIsHeadAndSelfJoinColumnToDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Appointments");

            migrationBuilder.AddColumn<bool>(
                name: "IsHead",
                table: "Doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SupervisorId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HeadDoctorId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SupervisorId",
                table: "Doctors",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HeadDoctorId",
                table: "Departments",
                column: "HeadDoctorId",
                unique: true,
                filter: "[HeadDoctorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Doctors_HeadDoctorId",
                table: "Departments",
                column: "HeadDoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Doctors_SupervisorId",
                table: "Doctors",
                column: "SupervisorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Doctors_HeadDoctorId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Doctors_SupervisorId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_SupervisorId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Departments_HeadDoctorId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsHead",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "HeadDoctorId",
                table: "Departments");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Appointments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Appointments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Appointments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Appointments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
