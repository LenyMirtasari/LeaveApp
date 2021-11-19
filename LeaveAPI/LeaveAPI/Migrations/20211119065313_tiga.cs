using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveAPI.Migrations
{
    public partial class tiga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_T_TotalLeave_Tb_T_Employee_EmployeeId",
                table: "Tb_T_TotalLeave");

            migrationBuilder.DropColumn(
                name: "LeaveDetailId",
                table: "Tb_T_TotalLeave");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Tb_T_TotalLeave",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_T_TotalLeave_Tb_T_Employee_EmployeeId",
                table: "Tb_T_TotalLeave",
                column: "EmployeeId",
                principalTable: "Tb_T_Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_T_TotalLeave_Tb_T_Employee_EmployeeId",
                table: "Tb_T_TotalLeave");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Tb_T_TotalLeave",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LeaveDetailId",
                table: "Tb_T_TotalLeave",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_T_TotalLeave_Tb_T_Employee_EmployeeId",
                table: "Tb_T_TotalLeave",
                column: "EmployeeId",
                principalTable: "Tb_T_Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
