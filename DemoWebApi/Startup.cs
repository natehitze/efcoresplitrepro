using System.Text.Json.Serialization;
using DemoWebApi.ValueConverters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DemoWebApi
{
    public class Startup
    {
        private IWebHostEnvironment Environment { get; }
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Environment = environment;
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<MyDbContext>(opt =>
            {
                opt.ReplaceService<IValueConverterSelector, MyValueConverterSelector>();
                opt.UseSqlServer(Configuration["DBConnectionString"], sqlOpt =>
                {
                    //sqlOpt.UseNetTopologySuite();
                    sqlOpt.EnableRetryOnFailure();
                });
                opt.ConfigureWarnings(warnings =>
                {
                    // EF will default to create a single query for multiple collection navigation. See https://go.microsoft.com/fwlink/?linkid=2134277  
                    warnings.Ignore(RelationalEventId.MultipleCollectionIncludeWarning);
                });
            });

            services.AddMvcCore();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            app.UseExceptionHandler(pipeline =>
            {
                pipeline.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";

                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();

                    // The exception handler middleware already logs the exception at Error level
                    var exception = exceptionHandlerPathFeature?.Error;

                    var message = exception?.Message;

                    var model = new ProblemDetails
                    {
                        Status = context.Response.StatusCode,
                        Title = "Internal Server Error",
                        Detail = message,
                    };

                    await context.Response.WriteAsJsonAsync(model);
                });
            });
            
            app.UseRouting();
            
            app.UseEndpoints(cfg =>
            {
                cfg.MapControllers();
            });
        }
    }
}