using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;


using NSwag;
using NSwag.Generation.Processors.Security;
using NSwag.AspNetCore;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

using Microsoft.AspNetCore.Http;
using SpaceStationAPI.Model;
using SpaceStationAPI.Services;

namespace SpaceStationAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseMiddleware<JwtMiddleware>();



            app.UseDeveloperExceptionPage();

            app.UseCors(options =>
                options.WithOrigins()
                       .AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod());


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Create the DB if not exist yet.
            //db.Database.EnsureCreated();

            //swagger
            app.UseOpenApi();
            app.UseSwaggerUi3();


        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
      
            services.AddControllers();


            services.AddScoped<IIssService, IssService>();
   

            services.AddOpenApiDocument(document =>
            {
                document.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.Basic,
                    Scheme = "Bearer",
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                document.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });




            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


           // services.AddControllersWithViews().AddJsonOptions();
            // JWT
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);


   
            services.AddHttpClient();


        }

    }
}
