﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Extensions;
using ShiftSoftware.ShiftEntity.Web;
using ShiftSoftware.ShiftEntity.Web.Services;
using ToDo.API.Data;
using ToDo.API.Data.Repositories;
using ToDo.Shared.DTOs.ToDo;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : ShiftEntityControllerAsync<ToDoRepository, Data.Entities.ToDo, ToDoListDTO, ToDoDTO>
    {
        private DB db;
        public ToDoController(ToDoRepository repository, DB db) : base(repository)
        {
            this.db = db;
        }

        [HttpGet("print/{ID}")]
        public async Task<ActionResult> Print(long ID)
        {
            var task = await base.repository.FindAsync(ID);

            //Data source fo Fast Report
            var data = new
            {
                ID = task.ID,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status.ToDescriptionString(),
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
                    Status = x.Status.ToDescriptionString(),
                })
                .ToList();

            var statuses = allTasks.Select(x => x.Status).Distinct().Select(x=> new { Name = x }).ToList();

            return await new FastReportBuilder()
                .AddFastReportFile("Reports/Task.frx")
                .AddDataObject("Task", data)
                .AddDataList("AllTasks", "AllTasksDataBand", allTasks.ToList<object>())
                .AddDataList("Statuses", "StatusDataBand", statuses.ToList<object>())
                .AddDataList("AllTasks", "AllTasksByStatusDataBand", allTasks.ToList<object>(), 3, "[Statuses.Name] == [AllTasks.Status]")
                .GetPDFFile();
        }
    }
}
