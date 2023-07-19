using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.API.Migrations
{
    public partial class RemoveAssignedUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedToName",
                table: "Tasks")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TasksHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssignedToName",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
