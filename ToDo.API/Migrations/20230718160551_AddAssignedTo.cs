using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.API.Migrations
{
    public partial class AddAssignedTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AssignedToId",
                table: "Tasks",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssignedToName",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedToId",
                table: "Tasks")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TasksHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);

            migrationBuilder.DropColumn(
                name: "AssignedToName",
                table: "Tasks")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TasksHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);
        }
    }
}
