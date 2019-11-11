using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Sample.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Sample.API.Authentication;

//[assembly:ApiConventionType(typeof(DefaultApiConventions))] // Api convention type at global type
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
            services.AddMvc(Options =>
            {
                Options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status401Unauthorized));
                Options.Filters.Add(new AuthorizeFilter());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            // configure basic authentication 
            services.AddAuthentication("Basic")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("Basic", null);


            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("OrderOpenApiSpecification",
                    new OpenApiInfo()
                    {
                        Title = "Order Api", // Title Of the app,
                        Version = "1",
                        Description = "This is a order api for swagger tutorial",
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

                setupAction.SwaggerDoc("SampleOpenApiSpecification",
                    new OpenApiInfo()
                    {
                        Title = "Sample Api", // Title Of the app,
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

                setupAction.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    Description = "Input your username and password to access this api"

                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {

                                Type = ReferenceType.SecurityScheme,
                                Id = "basicAuth"
                            }
                        },
                        new List<string>()
                    }

                });


                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; // generate this file using project property
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                setupAction.IncludeXmlComments(xmlPath); // add documentation on swagger ui
            });

            services.AddApiVersioning(Options =>
            {
                Options.AssumeDefaultVersionWhenUnspecified = true;
                Options.DefaultApiVersion = new ApiVersion(1, 0);
                Options.ReportApiVersions = true;
                // Options.ApiVersionReader = new HeaderApiVersionReader("api-version");

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
                options.SwaggerEndpoint("/swagger/OrderOpenApiSpecification/swagger.json", "Order API");
                options.SwaggerEndpoint("/swagger/SampleOpenApiSpecification/swagger.json", "Sample API");
                options.RoutePrefix = "";
            });
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
