using Microsoft.AspNetCore.Mvc;
using ShiftSoftware.ShiftEntity.Web;
using ToDo.API.Data.Repositories;
using ToDo.Shared;
using ToDo.Shared.DTOs.Project;

namespace ToDo.API.Controllers;

[Route("api/[controller]")]
public class ProjectController : ShiftEntitySecureControllerAsync<ProjectRepository, Data.Entities.Project, ProjectListDTO, ProjectDTO>
{
    public ProjectController() : base(ToDoActions.Project, x => x.FilterBy(x => x.ID, ToDoActions.DataLevelAccess.Projects).DecodeHashId<ProjectDTO>().IncludeCreatedByCurrentUser(x => x.CreatedByUserID))
    {
        //{
        //    x.SimpleDynamicActionFilter = ToDoActions.DataLevelAccess.Projects; //This will only allow access to projects that the user has access to (As defined on their Access Tree(s))

        //    //This will also include projects that the user has not been granted access to in Access Tree(s). But they're created by them
        //    x.ListingDynamicActionResolver = r =>
        //    {
        //        var loggedInUserId = r.GetUserId();

        //        return x => x.CreatedByUserID == loggedInUserId;
        //    };
        //}
    }
}
