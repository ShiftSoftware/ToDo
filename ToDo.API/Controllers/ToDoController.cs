using Microsoft.AspNetCore.Mvc;
using ShiftSoftware.ShiftEntity.Web;
using ToDo.API.Data.Repositories;
using ToDo.Shared.DTOs.ToDo;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : ShiftEntityControllerAsync<ToDoRepository, Data.Entities.ToDo, ToDoListDTO, ToDoDTO>
    {
        public ToDoController(ToDoRepository repository) : base(repository)
        {

        }
    }
}
