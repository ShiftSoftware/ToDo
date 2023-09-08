using Microsoft.AspNetCore.Mvc;
using ShiftSoftware.ShiftEntity.Web;
using ToDo.API.Data.Repositories;
using ToDo.Shared;
using ToDo.Shared.DTOs.Project;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : ShiftEntitySecureControllerAsync<ProjectRepository, Data.Entities.Project, ProjectListDTO, ProjectDTO>
    {
        public ProjectController() : base(ToDoActions.Project, value =>
        {
            var accessibleIds = value.GetAccessibleIds<ProjectDTO>(ToDoActions.DataLevelAccess.Projects);

            return  x => accessibleIds.WildCard ? true : accessibleIds.AccessibleIds.Contains(x.ID);
        })
        {
        }
    }
}
