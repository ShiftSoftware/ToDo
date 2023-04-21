using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShiftSoftware.ShiftBlazor.Extensions;
using ShiftSoftware.ShiftEntity.Model.HashId;
using ToDo.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var httpClient = new HttpClient
{
    BaseAddress = new Uri(builder.Configuration!.GetValue<string>("BaseURL")!),
};

//HashId.RegisterHashId(false);

builder.Services.AddScoped(sp => httpClient);

builder.Services.AddShiftServices(config =>
{
    config.ShiftConfiguration = options =>
    {
        options.BaseAddress = builder.Configuration!.GetValue<string>("BaseURL")!;
        options.ApiPath = "/api";
        options.ODataPath = "/odata";
        options.UserListEndpoint = "http://localhost"; //ToDo: this parameter should be optional.
    };
    config.SyncfusionLicense = builder.Configuration.GetValue<string>("SyncfusionLicense");
});

await builder.Build().RunAsync();
