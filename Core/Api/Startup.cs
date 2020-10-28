using Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;


namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.ConfigureProviders(Configuration);
            services.AddCoreServices();
            services.ConfigureJWT(Configuration);

            services.ConfigureMVC();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.AddHttpContextAccessor();
            services.ConfigureRepoAndUnitOfWork();
            services.ConfigureCors();
            services.ConfigureSwagger();



        }

        public void Configure(IApplicationBuilder app,  ILoggerFactory loggerFactory)
        {
            app.UseMiddleware<StackifyMiddleware.RequestTracerMiddleware>();

            app.ConfigureExceptionHandler();

            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });



            loggerFactory.AddSerilog();
            app.UseCors("AllowCors"); // Enable CORS!

            app.UseAuthentication();
            app.UseSession();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(Configuration.GetSection("App:BaseRoot").Value + "/swagger/v1/swagger.json", "WebApi");
            });

            app.UseMvc();
        }
    }

    public class BasePathFilter //: IDocumentFilter
    {
        public IConfiguration Configuration { get; }
        public BasePathFilter(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        //{
        //    swaggerDoc.BasePath = Configuration.GetSection("App:BaseRoot").Value;
        //}
    }
}
