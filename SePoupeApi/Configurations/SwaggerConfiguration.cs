using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SePoupeApi.Services.Configurations
{
    public class SwaggerConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {

            //Configure API documentation(swagger)
            services.AddSwaggerGen(
                swagger =>
                {
                    swagger.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Se Poupe API.",
                        Description = "Project using AspNet 5 API, SQL Server and Dapper.",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Se Poupe",
                        }
                    });
                }
                );
        }
    }
}
