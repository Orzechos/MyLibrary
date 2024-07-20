using Microsoft.Extensions.Options;
using MyLibraryApi.WebApi.IRepository;
using MyLibraryApi.WebApi.Repository;
using Serilog;
using System.Threading.RateLimiting;

namespace MyLibraryApi.WebApi.Extensions
{
    public static class Configuration
    {
        private static ILoggerFactory _Factory = null;

        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services
                   .AddEndpointsApiExplorer()
                   .AddSwaggerGen();

            builder.Services.AddHttpClient();

        }

        public static void AddScopedServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IBookRepository, BookRepository>();
        }

        public static void RegisterMiddlewares(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger()
                   .UseSwaggerUI();
            }

            app.UseHttpsRedirection();
        }

        public static void RegisterLogger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSerilog(lc => lc
                .WriteTo.Console()
                .ReadFrom.Configuration(builder.Configuration));
        }
    }
}
