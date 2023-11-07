using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TESTE.ApiNetCore.Api.Filters;
using TESTE.ApiNetCore.Api.Logging;
using TESTE.ApiNetCore.CrossCutting.Assemblies;
using TESTE.ApiNetCore.CrossCutting.IoC;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace TESTE.ApiNetCore.Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllers();

            services.AddMvc(options => options.Filters.Add(new DefaultExceptionFilterAttribute()));

            services.AddLoggingSerilog();

            services.AddAutoMapper(AssemblyUtil.GetCurrentAssemblies());

            services.AddDependencyResolver();

            services.AddHealthChecks();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TESTE.ApiNetCore",
                    Description = "API - TESTE.ApiNetCore",
                    Version = "v1"
                });

                var apiPath = Path.Combine(AppContext.BaseDirectory, "TESTE.ApiNetCore.Api.xml");
                var applicationPath = Path.Combine(AppContext.BaseDirectory, "TESTE.ApiNetCore.Application.xml");

                c.IncludeXmlComments(apiPath);
                c.IncludeXmlComments(applicationPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UsePathBase("/TESTE.ApiNetCore");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/TESTE.ApiNetCore/swagger/v1/swagger.json", "API TESTE.ApiNetCore");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
