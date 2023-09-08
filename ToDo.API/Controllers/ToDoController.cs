using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShiftSoftware.ShiftEntity.Web;
using ShiftSoftware.ShiftEntity.Web.Services;
using ToDo.API.Data;
using ToDo.API.Data.Repositories;
using ToDo.Shared;
using ToDo.Shared.DTOs.ToDo;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : ShiftEntitySecureControllerAsync<ToDoRepository, Data.Entities.ToDo, ToDoListDTO, ToDoDTO>
    {
        private DB db;
        ToDoRepository repository;
        public ToDoController(ToDoRepository repository, DB db) : base(ToDoActions.ToDo, x =>
        {
            x.ListingDynamicActionResolver = r =>
            {
                var accessibleProjectIds = r.GetAccessibleIds<ToDoListDTO>(ToDoActions.DataLevelAccess.Projects);

                var loggedInUserId = r.GetUserId();

                return x => (accessibleProjectIds.WildCard || !x.ProjectID.HasValue) ? true :
                    (accessibleProjectIds.AccessibleIds.Contains(x.ProjectID.Value) || x.Project!.CreatedByUserID == loggedInUserId)
                ;
            };
        })
        {
            this.db = db;
            this.repository = repository;
        }

        [HttpGet("print/{ID}")]
        public async Task<ActionResult> Print(long ID)
        {
            var task = await repository.FindAsync(ID, null);

            //Data source fo Fast Report
            var data = new
            {
                ID = task.ID,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status.ToString(),
            };

            var allTasks = (await this.db
                .ToDos
                .Where(x => x.ID != task.ID)
                .ToListAsync())
                .Select(x => new
                {
                    ID = x.ID,
                    Title = x.Title,
                    Description = x.Description,
                    Status = x.Status.ToString(),
                })
                .ToList();

            var statuses = allTasks.Select(x => x.Status).Distinct().Select(x => new { Name = x }).ToList();

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
