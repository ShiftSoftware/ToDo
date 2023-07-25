dotnet sln add --solution-folder ShiftFramework\ShiftEntity ..\ShiftEntity\ShiftEntity.Model\ShiftEntity.Model.csproj
dotnet sln add --solution-folder ShiftFramework\ShiftEntity ..\ShiftEntity\ShiftEntity.Core\ShiftEntity.Core.csproj
dotnet sln add --solution-folder ShiftFramework\ShiftEntity ..\ShiftEntity\ShiftEntity.Web\ShiftEntity.Web.csproj
dotnet sln add --solution-folder ShiftFramework\ShiftEntity ..\ShiftEntity\ShiftEntity.EFCore.SqlServer\ShiftEntity.EFCore.SqlServer.csproj

dotnet sln add --solution-folder ShiftFramework\ShiftBlazor ..\ShiftBlazor\ShiftBlazor\ShiftBlazor.csproj
dotnet sln add --solution-folder ShiftFramework\ShiftBlazor ..\ShiftBlazor\ShiftBlazor.Tests\ShiftBlazor.Tests.csproj

dotnet sln add --solution-folder ShiftFramework\TypeAuth ..\TypeAuth\TypeAuth.Core\TypeAuth.Core.csproj
dotnet sln add --solution-folder ShiftFramework\TypeAuth ..\TypeAuth\TypeAuth.Blazor\TypeAuth.Blazor.csproj
dotnet sln add --solution-folder ShiftFramework\TypeAuth ..\TypeAuth\TypeAuth.AspNetCore\TypeAuth.AspNetCore.csproj


dotnet sln add --solution-folder ShiftFramework\ShiftIdentity ..\ShiftIdentity\ShiftIdentity.Core\ShiftIdentity.Core.csproj
dotnet sln add --solution-folder ShiftFramework\ShiftIdentity ..\ShiftIdentity\ShiftIdentity.AspNetCore\ShiftIdentity.AspNetCore.csproj
dotnet sln add --solution-folder ShiftFramework\ShiftIdentity ..\ShiftIdentity\ShiftIdentity.Blazor\ShiftIdentity.Blazor.csproj
dotnet sln add --solution-folder ShiftFramework\ShiftIdentity ..\ShiftIdentity\ShiftIdentity.Dashboard.AspNetCore\ShiftIdentity.Dashboard.AspNetCore.csproj
dotnet sln add --solution-folder ShiftFramework\ShiftIdentity ..\ShiftIdentity\ShiftIdentity.Dashboard.Blazor\ShiftIdentity.Dashboard.Blazor.csproj

dotnet sln add --solution-folder ShiftFramework\TestingTools ..\ShiftFrameworkTestingTools\ShiftFrameworkTestingTools\ShiftFrameworkTestingTools.csproj

dotnet add ToDo.Web\ToDo.Web.csproj reference ..\ShiftIdentity\ShiftIdentity.Dashboard.Blazor\ShiftIdentity.Dashboard.Blazor.csproj
dotnet add ToDo.Web\ToDo.Web.csproj reference ..\ShiftIdentity\ShiftIdentity.Blazor\ShiftIdentity.Blazor.csproj
dotnet add ToDo.Web\ToDo.Web.csproj reference ..\ShiftBlazor\ShiftBlazor\ShiftBlazor.csproj


dotnet add ToDo.Shared\ToDo.Shared.csproj reference ..\ShiftEntity\ShiftEntity.Model\ShiftEntity.Model.csproj
dotnet add ToDo.Shared\ToDo.Shared.csproj reference ..\TypeAuth\TypeAuth.Core\TypeAuth.Core.csproj

dotnet add ToDo.API\ToDo.API.csproj reference ..\ShiftEntity\ShiftEntity.Web\ShiftEntity.Web.csproj
dotnet add ToDo.API\ToDo.API.csproj reference ..\ShiftEntity\ShiftEntity.EFCore.SqlServer\ShiftEntity.EFCore.SqlServer.csproj
dotnet add ToDo.API\ToDo.API.csproj reference ..\ShiftIdentity\ShiftIdentity.Dashboard.AspNetCore\ShiftIdentity.Dashboard.AspNetCore.csproj


dotnet add ToDo.Test\ToDo.Test.csproj reference ..\ShiftFrameworkTestingTools\ShiftFrameworkTestingTools\ShiftFrameworkTestingTools.csproj

