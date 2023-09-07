using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.API.Migrations
{
    public partial class builtInFlagForRegionCompanyAndBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuiltIn",
                schema: "ShiftIdentity",
                table: "AccessTrees")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "AccessTreesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.AddColumn<bool>(
                name: "BuiltIn",
                schema: "ShiftIdentity",
                table: "Regions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BuiltIn",
                schema: "ShiftIdentity",
                table: "CompanyBranches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BuiltIn",
                schema: "ShiftIdentity",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuiltIn",
                schema: "ShiftIdentity",
                table: "Regions")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "RegionsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "BuiltIn",
                schema: "ShiftIdentity",
                table: "CompanyBranches")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "CompanyBranchesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "BuiltIn",
                schema: "ShiftIdentity",
                table: "Companies")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "CompaniesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.AddColumn<bool>(
                name: "BuiltIn",
                schema: "ShiftIdentity",
                table: "AccessTrees",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
