using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.API.Migrations
{
    public partial class identityUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "RegionID",
                schema: "ShiftIdentity",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CompanyID",
                schema: "ShiftIdentity",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CompanyBranchID",
                schema: "ShiftIdentity",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyBranchID",
                schema: "ShiftIdentity",
                table: "Users",
                column: "CompanyBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyID",
                schema: "ShiftIdentity",
                table: "Users",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RegionID",
                schema: "ShiftIdentity",
                table: "Users",
                column: "RegionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyID",
                schema: "ShiftIdentity",
                table: "Users",
                column: "CompanyID",
                principalSchema: "ShiftIdentity",
                principalTable: "Companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CompanyBranches_CompanyBranchID",
                schema: "ShiftIdentity",
                table: "Users",
                column: "CompanyBranchID",
                principalSchema: "ShiftIdentity",
                principalTable: "CompanyBranches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Regions_RegionID",
                schema: "ShiftIdentity",
                table: "Users",
                column: "RegionID",
                principalSchema: "ShiftIdentity",
                principalTable: "Regions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyID",
                schema: "ShiftIdentity",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_CompanyBranches_CompanyBranchID",
                schema: "ShiftIdentity",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Regions_RegionID",
                schema: "ShiftIdentity",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompanyBranchID",
                schema: "ShiftIdentity",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompanyID",
                schema: "ShiftIdentity",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RegionID",
                schema: "ShiftIdentity",
                table: "Users");

            migrationBuilder.AlterColumn<long>(
                name: "RegionID",
                schema: "ShiftIdentity",
                table: "Users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CompanyID",
                schema: "ShiftIdentity",
                table: "Users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CompanyBranchID",
                schema: "ShiftIdentity",
                table: "Users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
