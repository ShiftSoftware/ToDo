using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Owin;
using ShiftSoftware.ShiftEntity.CosmosDbSync.Extensions;

[assembly: OwinStartup(typeof(ToDo.Functions.Startup))]

namespace ToDo.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddShiftEntityCosmosDbSync(x => { x.ConnectionString = ""; x.DefaultDatabaseName = ""; });

            //builder.Services.AddOptions<CSVSettings>()
            //    .Configure<IConfiguration>((settings, configuration) =>
            //    {
            //        configuration.GetSection("CSVSettings").Bind(settings);
            //    });

        }
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            //FunctionsHostBuilderContext context = builder.GetContext();

            //builder.ConfigurationBuilder
            //    .AddJsonFile(Path.Combine(context.ApplicationRootPath, "local.settings.json"), optional: true, reloadOnChange: false);
        }
    }
}
