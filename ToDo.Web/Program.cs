using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShiftSoftware.ShiftBlazor.Extensions;
using ShiftSoftware.ShiftBlazor.Services;
using ShiftSoftware.ShiftEntity.Model.HashId;
using System.Globalization;
using ToDo.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var httpClient = new HttpClient
{
    BaseAddress = new Uri(builder.Configuration!.GetValue<string>("BaseURL")!),
};

//HashId.RegisterHashId(false);

httpClient.DefaultRequestHeaders.Add("timezone-offset", TimeZoneInfo.Local.BaseUtcOffset.ToString("c"));

builder.Services.AddScoped(sp => httpClient);

builder.Services.AddShiftServices(config =>
{
    config.ShiftConfiguration = options =>
    {
        options.BaseAddress = builder.Configuration!.GetValue<string>("BaseURL")!;
        options.ApiPath = "/api";
        options.ODataPath = "/odata";
        options.UserListEndpoint = "http://localhost:5088".AddUrlPath("odata/PublicUser"); //ToDo: this parameter should be optional.
    };
    config.SyncfusionLicense = builder.Configuration.GetValue<string>("SyncfusionLicense");
});

var host = builder.Build();


var setMan = host.Services.GetRequiredService<SettingManager>();

var culture = setMan.GetCulture();

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

//await host.RefreshTokenAsync(50);

await host.RunAsync();

