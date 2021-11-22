using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveAPI.Migrations
{
    public partial class ketiga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_T_TotalLeave_Tb_T_LeaveDetail_LeaveDetailId",
                table: "Tb_T_TotalLeave");

            migrationBuilder.DropIndex(
                name: "IX_Tb_T_TotalLeave_LeaveDetailId",
                table: "Tb_T_TotalLeave");

            migrationBuilder.RenameColumn(
                name: "LeaveDetailId",
                table: "Tb_T_TotalLeave",
                newName: "EmployeeId");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Tb_T_Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_TotalLeave_EmployeeId",
                table: "Tb_T_TotalLeave",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_Employee_ManagerId",
                table: "Tb_T_Employee",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_T_Employee_Tb_T_Employee_ManagerId",
                table: "Tb_T_Employee",
                column: "ManagerId",
                principalTable: "Tb_T_Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Tb_T_Employee_Tb_T_Employee_ManagerId",
                table: "Tb_T_Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_T_TotalLeave_Tb_T_Employee_EmployeeId",
                table: "Tb_T_TotalLeave");

            migrationBuilder.DropIndex(
                name: "IX_Tb_T_TotalLeave_EmployeeId",
                table: "Tb_T_TotalLeave");

            migrationBuilder.DropIndex(
                name: "IX_Tb_T_Employee_ManagerId",
                table: "Tb_T_Employee");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Tb_T_Employee");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Tb_T_TotalLeave",
                newName: "LeaveDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_TotalLeave_LeaveDetailId",
                table: "Tb_T_TotalLeave",
                column: "LeaveDetailId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_T_TotalLeave_Tb_T_LeaveDetail_LeaveDetailId",
                table: "Tb_T_TotalLeave",
                column: "LeaveDetailId",
                principalTable: "Tb_T_LeaveDetail",
                principalColumn: "LeaveDetailId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
