using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SePoupeApi.Data.Interfaces;
using SePoupeApi.Data.Repositories;
using SePoupeApi.Services.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SePoupeApi
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

            services.AddControllers();

            //Getting connectionstring
            var Context_UsuarioDB = Configuration.GetConnectionString("Context_DB");
            var Context_QuestoesDB = Configuration.GetConnectionString("Context_QuestoesDB");

            //Dependency injection
            services.AddTransient<IPontosRepository, PontosRepository>(map => new PontosRepository(Context_UsuarioDB, Context_QuestoesDB));
            services.AddTransient<IUsuarioRepository, UsuarioRepository>(map => new UsuarioRepository(Context_UsuarioDB, Context_QuestoesDB));



            SwaggerConfiguration.ConfigureServices(services);

            //Configure CORS
            services.AddCors(
                s => s.AddPolicy("DefaultPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();

                })
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Configure api documentation(swagger) including initial config

            app.UseSwagger();
            app.UseSwaggerUI(s => { s.SwaggerEndpoint("/swagger/v1/swagger.json", "Se Poupe"); });


            app.UseRouting();

            app.UseCors("DefaultPolicy");


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
