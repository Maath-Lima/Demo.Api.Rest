using DevIO.Api.Extensions;
using Elmah.Io.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace DevIO.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "e772e8325efb470e90daee552f02855d";
                o.LogId = new Guid("eee786e1-ce62-4fe0-93bd-6accc1e88581");
            });

            //services.AddLogging(builder =>
            //{
            //    builder.AddElmahIo(o =>
            //    {
            //        o.ApiKey = "e772e8325efb470e90daee552f02855d";
            //        o.LogId = new Guid("eee786e1-ce62-4fe0-93bd-6accc1e88581");
            //    });

            //    builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            //});

            services.AddHealthChecks()
                .AddElmahIoPublisher(options =>
                {
                    options.ApiKey = "e772e8325efb470e90daee552f02855d";
                    options.LogId = new Guid("eee786e1-ce62-4fe0-93bd-6accc1e88581");
                    options.HeartbeatId = "aed448e595f3437ab41c894aa1245c64";
                })
                .AddCheck("Produtos", new SqlServerHealthCheck(configuration.GetConnectionString("DefaultConnection")))
                .AddCheck<HealthCheckWithDI>(
                    "Fornecedores",
                    tags: new[] { "inject" }
                )
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "BancoSQL");

            services.AddHealthChecksUI()
                .AddSqlServerStorage(configuration.GetConnectionString("DefaultConnection"));

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
