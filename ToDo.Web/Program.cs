using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Localization;
using ShiftSoftware.ShiftBlazor.Extensions;
using ShiftSoftware.ShiftBlazor.Services;
using ShiftSoftware.ShiftIdentity.Blazor.Extensions;
using ShiftSoftware.ShiftIdentity.Blazor.Handlers;
using ShiftSoftware.ShiftIdentity.Dashboard.Blazor.Extensions;
using ShiftSoftware.TypeAuth.Blazor.Extensions;
using System.Globalization;
using ToDo.Shared;
using ToDo.Web;


[assembly: RootNamespace("ToDo.Web")]
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp =>
{
    var httpClient = new HttpClient(sp.GetRequiredService<TokenMessageHandlerWithAutoRefresh>())
    {
        BaseAddress = new Uri(builder.Configuration!.GetValue<string>("BaseURL")!)
    };

    httpClient.DefaultRequestHeaders.Add("timezone-offset", TimeZoneInfo.Local.BaseUtcOffset.ToString("c"));

    return httpClient;
});

var baseUrl = builder.Configuration!.GetValue<string>("BaseURL")!;

builder.Services.AddShiftBlazor(config =>
{
    config.ShiftConfiguration = options =>
    {
        options.BaseAddress = baseUrl!;
        options.ApiPath = "/api";
        options.ODataPath = "/odata";
        options.UserListEndpoint = baseUrl.AddUrlPath("odata/IdentityPublicUser"); //ToDo: this parameter should be optional.
        options.AdditionalAssemblies = new[] { typeof(ShiftSoftware.ShiftIdentity.Dashboard.Blazor.ShiftIdentityDashboarBlazorMaker).Assembly };
        options.AddLanguage("en-US", "English");
    };
    config.SyncfusionLicense = builder.Configuration.GetValue<string>("SyncfusionLicense");
});

builder.Services.AddShiftIdentity("to-do-dev", baseUrl, baseUrl);

builder.Services.AddShiftIdentityDashboardBlazor(x =>
{
    x.ShiftIdentityHostingType = ShiftSoftware.ShiftIdentity.Core.ShiftIdentityHostingTypes.Internal;
    x.LogoPath = "/img/shift-full.png";
    x.Title = "ToDo";
});

builder.Services.AddTypeAuth(x =>
    x
    .AddActionTree<ShiftSoftware.ShiftIdentity.Core.ShiftIdentityActions>()
    .AddActionTree<ToDoActions>()
);

var host = builder.Build();

var setMan = host.Services.GetRequiredService<SettingManager>();

var culture = setMan.GetCulture();

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RefreshTokenAsync(50);

await host.RunAsync();

