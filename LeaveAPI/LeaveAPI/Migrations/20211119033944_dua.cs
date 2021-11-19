using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveAPI.Migrations
{
    public partial class dua : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_T_TotalLeave_Tb_T_LeaveDetail_LeaveDetailId",
                table: "Tb_T_TotalLeave");

            migrationBuilder.DropIndex(
                name: "IX_Tb_T_TotalLeave_LeaveDetailId",
                table: "Tb_T_TotalLeave");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
