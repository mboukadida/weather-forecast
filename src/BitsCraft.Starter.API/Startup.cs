using System.Reflection;
using BitsCraft.Starter.API.V1.Requests;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace BitsCraft.Starter.API
{
    public class Startup
    {
        private static string XmlPath
        {
            get
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var s = Path.Combine(AppContext.BaseDirectory, xmlFile);
                return s;
            }
        }

        public IConfigurationRoot Configuration { get; }

        public Startup(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureSwagger(services);
            ConfigureValidation(services);
        }

        public void Configure<T>(T app, IHostApplicationLifetime lifetime, IWebHostEnvironment env)
            where T : IApplicationBuilder, IEndpointRouteBuilder
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    var provider = app.ApplicationServices.GetService<IApiVersionDescriptionProvider>();
                    foreach (var apiVersionDescription in provider!.ApiVersionDescriptions.OrderByDescending(x => x.ApiVersion))
                    {
                        options.SwaggerEndpoint($"/swagger/{apiVersionDescription.GroupName}/swagger.json",
                            apiVersionDescription.GroupName.ToUpperInvariant());
                    }
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.ConfigureOptions<ConfigureSwaggerOptions>();
            services.AddSwaggerGen(c =>
            {
                // SwaggerDoc already added throw discovering ConfigureSwaggerOptions
                // c.SwaggerDoc("v1", new OpenApiInfo { Title = "Weather Forecast API", Version = "v1" });
                c.IncludeXmlComments(XmlPath);
            });

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new ApiVersion(2, 0);
                options.Conventions.Controller<V2.Controllers.WeatherForecastController>().HasApiVersion(options.DefaultApiVersion);
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
            });
        }

        private void ConfigureValidation(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
                options.InvalidModelStateResponseFactory = ModelStateValidator.ValidateModelState);
            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<RegisterWeatherForecastRequest>();
            });
        }
    }
}
