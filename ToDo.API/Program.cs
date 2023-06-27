using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using ShiftSoftware.ShiftEntity.Web.Extensions;
using ShiftSoftware.ShiftEntity.Web.Services;
using System.Globalization;
using ToDo.API.Data;
using ToDo.API.Data.Repositories;
using ToDo.Shared.DTOs.ToDo;
using ShiftSoftware.ShiftIdentity.AspNetCore.Extensions;
using ShiftSoftware.ShiftIdentity.Core.Models;
using ShiftSoftware.ShiftIdentity.Core.DTOs;
using ShiftSoftware.ShiftIdentity.Dashboard.AspNetCore.Extentsions;
using ShiftSoftware.TypeAuth.AspNetCore.Extensions;
using ShiftSoftware.ShiftIdentity.Core;

var builder = WebApplication.CreateBuilder(args);

var fakeUser = new TokenUserDataDTO
{
    FullName = "Fake User",
    ID = 1,
    Username = "fake-user"
};

builder.Services
    .AddLocalization()
    .AddHttpContextAccessor()
    .AddDbContext<DB>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer")))
    .AddControllers()
    .AddShiftEntity(x =>
    {
        x.WrapValidationErrorResponseWithShiftEntityResponse(true);
        x.HashId.RegisterHashId(builder.Configuration.GetValue<bool>("Settings:HashIdSettings:AcceptUnencodedIds"));
        x.HashId.RegisterUserIdsHasher();
    })
    .AddShiftIdentity("ToDo", "one-two-three-four-five-six-seven-eight.one-two-three-four-five-six-seven-eight")
    .AddShiftEntityOdata(x =>
    {
        x.DefaultOptions();
        x.OdataEntitySet<ToDoListDTO>("ToDo");
    });
    //.AddFakeIdentityEndPoints(
    //    new TokenSettingsModel
    //    {
    //        Issuer = "ToDo",
    //        Key = "one-two-three-four-five-six-seven-eight.one-two-three-four-five-six-seven-eight",
    //        ExpireSeconds = 60
    //    },
    //    fakeUser,
    //    new ShiftSoftware.ShiftIdentity.Core.DTOs.App.AppDTO
    //    {
    //        AppId = "to-do-dev",
    //        DisplayName = "ToDo Dev",
    //        RedirectUri = "http://localhost:5028/Auth/Token"
    //    },
    //    "123a",
    //    new string[] {
    //        """
    //            {
    //                "ToDo": [1,2,3,4]
    //            }
    //        """
    //    }
    //);

builder.Services.AddSwaggerGen(c =>
{
    c.DocInclusionPredicate(SwaggerService.DocInclusionPredicate);
});

builder.Services.AddScoped<ToDoRepository>();

builder.Services.AddTypeAuth((o) =>
{
    o.AddActionTree<ShiftIdentityActions>();
});

#if DEBUG
builder.Services.AddRazorPages();
#endif

var app = builder.Build();

//app.AddFakeIdentityEndPoints();


var supportedCultures = new List<CultureInfo>
{
    new CultureInfo("en-US"),
    new CultureInfo("ar-IQ"),
    new CultureInfo("ku-IQ"),
};

app.UseRequestLocalization(options =>
{
    options.SetDefaultCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.RequestCultureProviders = new List<IRequestCultureProvider> { new AcceptLanguageHeaderRequestCultureProvider() };
    options.ApplyCurrentCultureToResponseHeaders = true;
});

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

#if DEBUG

app.MapRazorPages();
app.MapFallbackToFile("index.html");

#endif

app.Run();