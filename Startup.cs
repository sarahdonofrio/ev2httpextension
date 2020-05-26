using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using EV2HttpExtension.Models;

namespace TodoApi
{
    public class Startup
    {
        #region snippet_ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "EV2HttpExtension API",
                    Description = "This is a sample EV2 Extension designed to help the EV2 team show/share a sample app that can be run as an EV2 HttpExtension"
                });

                c.OperationFilter<DefaultHeaderFilter>();
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

    
            });
        }
        #endregion

        #region snippet_Configure
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EV2HttpExtension");
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        #endregion
    }
}
