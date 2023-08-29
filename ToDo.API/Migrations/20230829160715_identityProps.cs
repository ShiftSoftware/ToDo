using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.API.Migrations
{
    public partial class identityProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CompanyBranchID",
                schema: "ShiftIdentity",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyID",
                schema: "ShiftIdentity",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RegionID",
                schema: "ShiftIdentity",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyBranchID",
                table: "ToDos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyID",
                table: "ToDos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RegionID",
                table: "ToDos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyBranchID",
                table: "Tasks",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyID",
                table: "Tasks",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RegionID",
                table: "Tasks",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyBranchID",
                schema: "ShiftIdentity",
                table: "Services",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyID",
                schema: "ShiftIdentity",
                table: "Services",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RegionID",
                schema: "ShiftIdentity",
                table: "Services",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyBranchID",
                schema: "ShiftIdentity",
                table: "Regions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyID",
                schema: "ShiftIdentity",
                table: "Regions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RegionID",
                schema: "ShiftIdentity",
                table: "Regions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyBranchID",
                table: "Projects",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyID",
                table: "Projects",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RegionID",
                table: "Projects",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyBranchID",
                schema: "ShiftIdentity",
                table: "Departments",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyID",
                schema: "ShiftIdentity",
                table: "Departments",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RegionID",
                schema: "ShiftIdentity",
                table: "Departments",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyBranchID",
                schema: "ShiftIdentity",
                table: "CompanyBranches",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyBranchID",
                schema: "ShiftIdentity",
                table: "Companies",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyID",
                schema: "ShiftIdentity",
                table: "Companies",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RegionID",
                schema: "ShiftIdentity",
                table: "Companies",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyBranchID",
                schema: "ShiftIdentity",
                table: "Apps",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyID",
                schema: "ShiftIdentity",
                table: "Apps",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RegionID",
                schema: "ShiftIdentity",
                table: "Apps",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyBranchID",
                schema: "ShiftIdentity",
                table: "AccessTrees",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyID",
                schema: "ShiftIdentity",
                table: "AccessTrees",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RegionID",
                schema: "ShiftIdentity",
                table: "AccessTrees",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyBranchID",
                schema: "ShiftIdentity",
                table: "Users")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                schema: "ShiftIdentity",
                table: "Users")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "RegionID",
                schema: "ShiftIdentity",
                table: "Users")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "CompanyBranchID",
                table: "ToDos")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ToDosHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "ToDos")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ToDosHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);

            migrationBuilder.DropColumn(
                name: "RegionID",
                table: "ToDos")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ToDosHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);

            migrationBuilder.DropColumn(
                name: "CompanyBranchID",
                table: "Tasks")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TasksHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Tasks")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TasksHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);

            migrationBuilder.DropColumn(
                name: "RegionID",
                table: "Tasks")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TasksHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);

            migrationBuilder.DropColumn(
                name: "CompanyBranchID",
                schema: "ShiftIdentity",
                table: "Services")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ServicesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                schema: "ShiftIdentity",
                table: "Services")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ServicesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "RegionID",
                schema: "ShiftIdentity",
                table: "Services")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ServicesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "CompanyBranchID",
                schema: "ShiftIdentity",
                table: "Regions")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "RegionsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                schema: "ShiftIdentity",
                table: "Regions")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "RegionsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "RegionID",
                schema: "ShiftIdentity",
                table: "Regions")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "RegionsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "CompanyBranchID",
                table: "Projects")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ProjectsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Projects")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ProjectsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);

            migrationBuilder.DropColumn(
                name: "RegionID",
                table: "Projects")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ProjectsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);

            migrationBuilder.DropColumn(
                name: "CompanyBranchID",
                schema: "ShiftIdentity",
                table: "Departments")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "DepartmentsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                schema: "ShiftIdentity",
                table: "Departments")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "DepartmentsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "RegionID",
                schema: "ShiftIdentity",
                table: "Departments")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "DepartmentsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "CompanyBranchID",
                schema: "ShiftIdentity",
                table: "CompanyBranches")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "CompanyBranchesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "CompanyBranchID",
                schema: "ShiftIdentity",
                table: "Companies")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "CompaniesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                schema: "ShiftIdentity",
                table: "Companies")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "CompaniesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "RegionID",
                schema: "ShiftIdentity",
                table: "Companies")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "CompaniesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "CompanyBranchID",
                schema: "ShiftIdentity",
                table: "Apps")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "AppsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                schema: "ShiftIdentity",
                table: "Apps")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "AppsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "RegionID",
                schema: "ShiftIdentity",
                table: "Apps")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "AppsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "CompanyBranchID",
                schema: "ShiftIdentity",
                table: "AccessTrees")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "AccessTreesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                schema: "ShiftIdentity",
                table: "AccessTrees")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "AccessTreesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");

            migrationBuilder.DropColumn(
                name: "RegionID",
                schema: "ShiftIdentity",
                table: "AccessTrees")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "AccessTreesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "ShiftIdentity");
        }
    }
}
