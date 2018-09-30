using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Threax.AspNetCore.BuiltInTools;
using Threax.Extensions.Configuration.SchemaBinder;

namespace Threax.Static
{
    public class Startup
    {
        private AppConfig appConfig = new AppConfig();

        public Startup(IConfiguration configuration)
        {
            Configuration = new SchemaConfigurationBinder(configuration);
            Configuration.Bind("AppConfig", appConfig);
        }

        public SchemaConfigurationBinder Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IToolRunner>(s =>
            {
                return new ToolRunner()
                .AddTool("updateConfigSchema", new ToolCommand("Update the schema file for this application's configuration.", async a =>
                {
                    var json = await Configuration.CreateSchema();
                    await File.WriteAllTextAsync("appsettings.schema.json", json);
                }));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                ServeUnknownFileTypes = appConfig.ServeUnknownFileTypes,
            });
        }
    }
}
