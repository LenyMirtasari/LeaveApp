using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveAPI.Migrations
{
    public partial class kedua : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_Acoount_Tb_T_Employee_EmployeeId",
                table: "Tb_M_Acoount");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_T_AccountRole_Tb_M_Acoount_EmployeeId",
                table: "Tb_T_AccountRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tb_M_Acoount",
                table: "Tb_M_Acoount");

            migrationBuilder.RenameTable(
                name: "Tb_M_Acoount",
                newName: "Tb_M_Account");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tb_M_Account",
                table: "Tb_M_Account",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_M_Account_Tb_T_Employee_EmployeeId",
                table: "Tb_M_Account",
                column: "EmployeeId",
                principalTable: "Tb_T_Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_T_AccountRole_Tb_M_Account_EmployeeId",
                table: "Tb_T_AccountRole",
                column: "EmployeeId",
                principalTable: "Tb_M_Account",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_Account_Tb_T_Employee_EmployeeId",
                table: "Tb_M_Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_T_AccountRole_Tb_M_Account_EmployeeId",
                table: "Tb_T_AccountRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tb_M_Account",
                table: "Tb_M_Account");

            migrationBuilder.RenameTable(
                name: "Tb_M_Account",
                newName: "Tb_M_Acoount");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tb_M_Acoount",
                table: "Tb_M_Acoount",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_M_Acoount_Tb_T_Employee_EmployeeId",
                table: "Tb_M_Acoount",
                column: "EmployeeId",
                principalTable: "Tb_T_Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_T_AccountRole_Tb_M_Acoount_EmployeeId",
                table: "Tb_T_AccountRole",
                column: "EmployeeId",
                principalTable: "Tb_M_Acoount",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
