
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using CoordinatorsMicroservice.Services;
using CoordinatorsMicroservice.Repository;
using Microsoft.EntityFrameworkCore;
using CoordinatorsMicroservice.Models;

namespace CoordinatorsMicroservice
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
            services.AddControllersWithViews();


            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PlacementSystem_CoordinatorsMicroservice",
                    Version = "v1"
                });
            });


            //Repositories and Services
            services.AddTransient<ICoordinatorsService, CoordinatorsService>();
            services.AddTransient<ICoordinatorsRepository, CoordinatorsRepository>();


            //CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });


            //Databases
            //DbContext Code
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration["ConnectionString:PlacementDB"]));


            services.AddMvc();
        }

        


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoordinatorsMicroservice_v1"));

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => builder
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());

            app.UseCors(
               options => options.WithOrigins("https://localhost:44346/").AllowAnyMethod()
           );

            app.UseAuthorization();

            app.UseDeveloperExceptionPage();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
