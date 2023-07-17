using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShiftSoftware.ShiftEntity.Web;
using ShiftSoftware.ShiftEntity.Web.Services;
using ToDo.API.Data;
using ToDo.API.Data.Repositories;
using ToDo.Shared.DTOs.Task;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : ShiftEntityControllerAsync<TaskRepository, Data.Entities.Task, TaskListDTO, TaskDTO>
    {
        private DB db;
        TaskRepository repository;
        public TaskController(TaskRepository repository, DB db) : base()
        {
            this.db = db;
            this.repository = repository;
        }

        [HttpGet("print/{ID}")]
        public async Task<ActionResult> Print(long ID)
        {
            var task = await repository.FindAsync(ID);

            //Data source fo Fast Report
            var data = new
            {
                task.ID,
                task.Name,
                task.Description,
                Status = task.Status.ToString(),
            };

            var allTasks = (await this.db
                .Tasks
                .Where(x => x.ID != task.ID)
                .ToListAsync())
                .Select(x => new
                {
                    x.ID,
                    x.Name,
                    x.Description,
                    Status = x.Status.ToString(),
                })
                .ToList();

            var statuses = allTasks.Select(x => x.Status).Distinct().Select(x=> new { Name = x }).ToList();

            return await new FastReportBuilder()
                .AddFastReportFile("Reports/Task.frx")
                .AddDataObject("Task", data)
                .AddDataList("AllTasks", "AllTasksDataBand", allTasks.ToList<object>())
                .AddDataList("Statuses", "StatusDataBand", statuses.ToList<object>())
                .AddDataList("AllTasks", "AllTasksByStatusDataBand", allTasks.ToList<object>(), 3, "[Statuses.Name] == [AllTasks.Status]")
                .HideDataBandIfEmpty("AllTasksDataBand", "AllTasksHeaderBand")
                .HideDataBandIfEmpty("StatusDataBand", "StatusHeaderBand")
                .HideDataBandIfEmpty("AllTasksByStatusDataBand")
                .GetPDFFile(report =>
                {
                    (report.FindObject("Cell1") as FastReport.Table.TableCell)!.FillColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
                });
        }
    }
}
