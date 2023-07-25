using Microsoft.AspNetCore.Mvc;
using ShiftSoftware.ShiftEntity.Web;
using ToDo.API.Data;
using ToDo.API.Data.Repositories;
using ToDo.Shared;
using ToDo.Shared.DTOs.Task;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : ShiftEntitySecureControllerAsync<TaskRepository, Data.Entities.Task, TaskListDTO, TaskDTO>
    {
        public TaskController() : base(ToDoActions.Task)
        {
            
        }
    }
}
