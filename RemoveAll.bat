dotnet remove ToDo.Web\ToDo.Web.csproj reference ..\ShiftIdentity\ShiftIdentity.Dashboard.Blazor\ShiftIdentity.Dashboard.Blazor.csproj
dotnet remove ToDo.Web\ToDo.Web.csproj reference ..\ShiftIdentity\ShiftIdentity.Blazor\ShiftIdentity.Blazor.csproj
dotnet remove ToDo.Web\ToDo.Web.csproj reference ..\ShiftBlazor\ShiftBlazor\ShiftBlazor.csproj


dotnet remove ToDo.Shared\ToDo.Shared.csproj reference ..\ShiftEntity\ShiftEntity.Model\ShiftEntity.Model.csproj

dotnet remove ToDo.API\ToDo.API.csproj reference ..\ShiftEntity\ShiftEntity.Web\ShiftEntity.Web.csproj
dotnet remove ToDo.API\ToDo.API.csproj reference ..\ShiftEntity\ShiftEntity.EFCore.SqlServer\ShiftEntity.EFCore.SqlServer.csproj

dotnet sln remove ..\ShiftEntity\ShiftEntity.Model\ShiftEntity.Model.csproj
dotnet sln remove ..\ShiftEntity\ShiftEntity.Core\ShiftEntity.Core.csproj
dotnet sln remove ..\ShiftEntity\ShiftEntity.Web\ShiftEntity.Web.csproj
dotnet sln remove ..\ShiftEntity\ShiftEntity.EFCore.SqlServer\ShiftEntity.EFCore.SqlServer.csproj

dotnet sln remove ..\ShiftBlazor\ShiftBlazor\ShiftBlazor.csproj

dotnet sln remove ..\TypeAuth\TypeAuth.Core\TypeAuth.Core.csproj
dotnet sln remove ..\TypeAuth\TypeAuth.Blazor\TypeAuth.Blazor.csproj
dotnet sln remove ..\TypeAuth\TypeAuth.AspNetCore\TypeAuth.AspNetCore.csproj


dotnet sln remove ..\ShiftIdentity\ShiftIdentity.Core\ShiftIdentity.Core.csproj
dotnet sln remove ..\ShiftIdentity\ShiftIdentity.AspNetCore\ShiftIdentity.AspNetCore.csproj
dotnet sln remove ..\ShiftIdentity\ShiftIdentity.Blazor\ShiftIdentity.Blazor.csproj
dotnet sln remove ..\ShiftIdentity\ShiftIdentity.Dashboard.AspNetCore\ShiftIdentity.Dashboard.AspNetCore.csproj
dotnet sln remove ..\ShiftIdentity\ShiftIdentity.Dashboard.Blazor\ShiftIdentity.Dashboard.Blazor.csproj