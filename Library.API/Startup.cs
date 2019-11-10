using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Sample.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Sample.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("SampleOpenApiSpecification",
                    new OpenApiInfo()
                    {
                        Title = "Sample Sample", // Title Of the app,
                        Version = "1",
                        Description = "This is a sample api for swagger tutorial",
                        Contact = new OpenApiContact()
                        {
                            Name = "Akash Mane",
                            Email = "maneakash7593@gmail.com",
                            Url = new Uri("https://github.com/maneakash")
                        },
                        License = new OpenApiLicense()
                        {
                            Name = "MIT License",
                            Url = new Uri("https://opensource.org/licenses/MIT")
                        }
                    });
                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; // generate this file using project property
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                setupAction.IncludeXmlComments(xmlPath); // add documentation on swagger ui
            });

            services.AddTransient<IOrderService, OrderService>(); // Dependancy injection

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSwagger(); // middleware for swagger
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/SampleOpenApiSpecification/swagger.json", "Sample API");
                options.RoutePrefix = "";
            });
            app.UseMvc();
        }
    }
}
