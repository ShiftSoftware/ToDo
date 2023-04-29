using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ShiftSoftware.ShiftEntity.Model.HashId;
using ShiftSoftware.ShiftEntity.Web.Services;
using ToDo.API.Data;
using ToDo.API.Data.Repositories;
using ToDo.Shared.DTOs.ToDo;

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();

    builder.EntitySet<ToDoListDTO>("ToDo");

    return builder.GetEdmModel();
}

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<DB>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer")))
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    })
.AddOData(opt =>
{
    opt.Count().Filter().Expand().Select().OrderBy().SetMaxTop(1000)
    .AddRouteComponents("odata", GetEdmModel(), services =>
    {
        services.RegisterOdataHashIdConverter("odata", GetEdmModel());
    });
});

builder.Services.AddScoped<ToDoRepository>();

builder.Services.AddSwaggerGen(c =>
{
    c.DocInclusionPredicate(SwaggerService.DocInclusionPredicate);
});

#if DEBUG
builder.Services.AddRazorPages();
#endif

var app = builder.Build();

#if DEBUG

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

#endif

app.MapControllers();

app.UseCors(x => x.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

HashId.RegisterHashId(app.Environment.IsDevelopment());
HashId.RegisterUserIdsHasher("k02iUHSb2ier9fiui02349AbfJEI", 5);

#if DEBUG

app.MapRazorPages();
app.MapFallbackToFile("index.html");

#endif

app.Run();