using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Localization;
using ShiftSoftware.ShiftBlazor.Extensions;
using ShiftSoftware.ShiftBlazor.Services;
using ShiftSoftware.ShiftIdentity.Blazor.Extensions;
using ShiftSoftware.ShiftIdentity.Blazor.Handlers;
using System.Globalization;
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

builder.Services.AddShiftServices(config =>
{
    config.ShiftConfiguration = options =>
    {
        options.BaseAddress = baseUrl!;
        options.ApiPath = "/api";
        options.ODataPath = "/odata";
        options.UserListEndpoint = baseUrl.AddUrlPath("odata/PublicUser"); //ToDo: this parameter should be optional.
    };
    config.SyncfusionLicense = builder.Configuration.GetValue<string>("SyncfusionLicense");
});

builder.Services.AddShiftIdentity("to-do-dev", baseUrl, baseUrl);

var host = builder.Build();

var setMan = host.Services.GetRequiredService<SettingManager>();

var culture = setMan.GetCulture();

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RefreshTokenAsync(50);

await host.RunAsync();

