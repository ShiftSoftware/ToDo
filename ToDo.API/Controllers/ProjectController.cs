using Microsoft.AspNetCore.Mvc;
using ShiftSoftware.ShiftEntity.Web;
using ShiftSoftware.TypeAuth.AspNetCore.Services;
using ToDo.API.Data.Repositories;
using ToDo.Shared;
using ToDo.Shared.DTOs.Project;

namespace ToDo.API.Controllers;

[Route("api/[controller]")]
public class ProjectController : ShiftEntitySecureControllerAsync<ProjectRepository, Data.Entities.Project, ProjectListDTO, ProjectDTO>
{
    public ProjectController() : base(ToDoActions.Project, x =>
            x.FilterBy(x => x.ID, ToDoActions.DataLevelAccess.Projects)
            .DecodeHashId<ProjectDTO>()
            .IncludeCreatedByCurrentUser(x => x.CreatedByUserID)

        //{
        //    //This will also include projects that the user has not been granted access to in Access Tree(s). But they're created by them
        //    x.DynamicActionExpressionBuilder = r =>
        //    {
        //        var loggedInUserId = r.GetUserId();

        //        var typeAuth = r.GetRequiredService<TypeAuthService>();

        //        var acceessibleIds = typeAuth.GetAccessibleItems(ToDoActions.DataLevelAccess.Projects, r.AccessPredicate);

        //        var accessibleIdsLong = acceessibleIds.AccessibleIds.Select(ShiftSoftware.ShiftEntity.Web.Services.ShiftEntityHashIds.Decode<ProjectDTO>).ToList();

        //        return x => acceessibleIds.WildCard ? true : (x.CreatedByUserID == loggedInUserId || accessibleIdsLong.Contains(x.ID));
        //    };
        //}
    )
    {
    }
}
