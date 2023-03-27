using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using ShiftSoftware.TypeAuth.Core;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ToDo.API;
using ToDo.API.Data;

namespace ToDo.Test
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        IConfiguration config;
        static string? token;

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseEnvironment("Development");

            config = new ConfigurationBuilder()
                   .SetBasePath(AppContext.BaseDirectory)
                   .AddJsonFile("appsettings.json", false, true)
                   .Build();

            var host = builder.Build();

            host.Start();

            var serviceProvider = host.Services;

            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<DB>();

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

            return host;
        }

        protected override void ConfigureClient(HttpClient client)
        {
            base.ConfigureClient(client);
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<DB>));

                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

                    services.AddDbContext<DB>(options =>
                    {
                        options.UseSqlServer(config.GetConnectionString("SQLServer_Test_APIs"));
                    });
                });
        }
    }

    [CollectionDefinition("API Collection")]
    public class DatabaseCollection : ICollectionFixture<CustomWebApplicationFactory<WebMarker>>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
