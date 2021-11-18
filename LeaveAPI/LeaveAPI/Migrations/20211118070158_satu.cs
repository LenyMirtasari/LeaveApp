using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveAPI.Migrations
{
    public partial class satu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_M_Job",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Job", x => x.JobId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_LeaveType",
                columns: table => new
                {
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Day = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_LeaveType", x => x.LeaveTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_T_Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_T_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Tb_T_Employee_Tb_M_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Tb_M_Job",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_T_Account",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_T_Account", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Tb_T_Account_Tb_T_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Tb_T_Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_T_LeaveDetail",
                columns: table => new
                {
                    LeaveDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approval = table.Column<bool>(type: "bit", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_T_LeaveDetail", x => x.LeaveDetailId);
                    table.ForeignKey(
                        name: "FK_Tb_T_LeaveDetail_Tb_M_LeaveType_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "Tb_M_LeaveType",
                        principalColumn: "LeaveTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_T_LeaveDetail_Tb_T_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Tb_T_Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_T_LeaveDetail_Tb_T_Employee_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Tb_T_Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tb_T_AccountRole",
                columns: table => new
                {
                    AccountRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    AccountEmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_T_AccountRole", x => x.AccountRoleId);
                    table.ForeignKey(
                        name: "FK_Tb_T_AccountRole_Tb_M_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Tb_M_Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_T_AccountRole_Tb_T_Account_AccountEmployeeId",
                        column: x => x.AccountEmployeeId,
                        principalTable: "Tb_T_Account",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tb_T_TotalLeave",
                columns: table => new
                {
                    TotalLeaveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EligibleLeave = table.Column<int>(type: "int", nullable: false),
                    LastYear = table.Column<int>(type: "int", nullable: false),
                    TotalLeaves = table.Column<int>(type: "int", nullable: false),
                    CurrentYear = table.Column<int>(type: "int", nullable: false),
                    LeaveDetailId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_T_TotalLeave", x => x.TotalLeaveId);
                    table.ForeignKey(
                        name: "FK_Tb_T_TotalLeave_Tb_T_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Tb_T_Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_T_TotalLeave_Tb_T_LeaveDetail_LeaveDetailId",
                        column: x => x.LeaveDetailId,
                        principalTable: "Tb_T_LeaveDetail",
                        principalColumn: "LeaveDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_AccountRole_AccountEmployeeId",
                table: "Tb_T_AccountRole",
                column: "AccountEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_AccountRole_RoleId",
                table: "Tb_T_AccountRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_Employee_Email",
                table: "Tb_T_Employee",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_Employee_JobId",
                table: "Tb_T_Employee",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_Employee_PhoneNumber",
                table: "Tb_T_Employee",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_LeaveDetail_EmployeeId",
                table: "Tb_T_LeaveDetail",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_LeaveDetail_LeaveTypeId",
                table: "Tb_T_LeaveDetail",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_LeaveDetail_ManagerId",
                table: "Tb_T_LeaveDetail",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_TotalLeave_EmployeeId",
                table: "Tb_T_TotalLeave",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_TotalLeave_LeaveDetailId",
                table: "Tb_T_TotalLeave",
                column: "LeaveDetailId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_T_AccountRole");

            migrationBuilder.DropTable(
                name: "Tb_T_TotalLeave");

            migrationBuilder.DropTable(
                name: "Tb_M_Role");

            migrationBuilder.DropTable(
                name: "Tb_T_Account");

            migrationBuilder.DropTable(
                name: "Tb_T_LeaveDetail");

            migrationBuilder.DropTable(
                name: "Tb_M_LeaveType");

            migrationBuilder.DropTable(
                name: "Tb_T_Employee");

            migrationBuilder.DropTable(
                name: "Tb_M_Job");
        }
    }
}
